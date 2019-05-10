using MST.MES;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_Zlecen_LED
{
    public class ProductionSmtNorms
    {
        public class SmtLineConfiguration
        {
            public string lineName;
            public int pcbReflowSpeed;
            public int carrierReflowSpeed;
            public int siplaceCph;
            public int printerCt;
            public int connCph;
        }

        public class SmtEfficiencyNormStruct
        {
            public double siplaceCT { get; set; }
            public double connCT { get; set; }
            public double reflowCT { get; set; }
            public double outputPerHour { get; set; }
            //public ModelInfo.ModelSpecification modelSpec { get; set; }
            public Tuple<double, double> mbDimensionsLWmm { get; set; }
        }

        public static int CalculateProductionTime(string modelId, double productionQty)
        {
            var modelNorm = CalculateModelNormPerHour(modelId);

            return (int)Math.Ceiling(productionQty * 60 / modelNorm.outputPerHour);
        }

        public static SmtEfficiencyNormStruct CalculateModelNormPerHour(string modelId, int siplaceHeads2or4 = 2)
        {
            //ModelInfo.ModelSpecification modelSpec = new ModelInfo.ModelSpecification();
            //if (!DevTools.mesModels.TryGetValue(modelId, out modelSpec)) return new SmtEfficiencyNormStruct();

            Tuple<double, double> mbDimensionsLWmm = new Tuple<double, double>(0, 0);

            Dictionary<string, SmtLineConfiguration> lineConfiguration = new Dictionary<string, SmtLineConfiguration>
                {
                    {"SMT1",new SmtLineConfiguration(){lineName="SMT1", pcbReflowSpeed=90, carrierReflowSpeed=90, siplaceCph=20000, printerCt = 30, connCph =  10000} },
                    {"SMT2",new SmtLineConfiguration(){lineName="SMT2", pcbReflowSpeed=130, carrierReflowSpeed=110, siplaceCph=20000, printerCt = 30, connCph =  10000 } },
                    {"SMT3",new SmtLineConfiguration(){lineName="SMT3", pcbReflowSpeed=95, carrierReflowSpeed=90, siplaceCph=20000, printerCt = 30, connCph =  10000 } },
                    {"SMT4",new SmtLineConfiguration(){lineName="SMT4", pcbReflowSpeed=130, carrierReflowSpeed=0, siplaceCph=20000, printerCt = 40, connCph =  10000 } },
                    {"SMT5",new SmtLineConfiguration(){lineName="SMT5", pcbReflowSpeed=140, carrierReflowSpeed=105, siplaceCph=20000, printerCt = 30, connCph =  1800 } },
                    {"SMT6",new SmtLineConfiguration(){lineName="SMT6", pcbReflowSpeed=140, carrierReflowSpeed=110, siplaceCph=20000, printerCt = 30, connCph =  1800 } },
                    {"SMT7",new SmtLineConfiguration(){lineName="SMT7", pcbReflowSpeed=90, carrierReflowSpeed=90, siplaceCph=15000, printerCt = 25, connCph =  1800 } },
                    {"SMT8",new SmtLineConfiguration(){lineName="SMT8", pcbReflowSpeed=90, carrierReflowSpeed=90, siplaceCph=15000, printerCt = 25, connCph =  1800 } },
                };


            var dtModels = DevTools.devToolsDb.Where(rec => rec.nc12 == modelId + "00");
            if (dtModels.Count() == 0)
            {
                return null;
            }

            var dtModel = dtModels.First();//need smth better than first



            double reflowCT = 0;
            double siplaceCph = 0;
            double connCT = 0;
            int pcbLoadingUnloading = 15;



            mbDimensionsLWmm = MST.MES.DtTools.GetMbDimensions(dtModel);
            var ledCount = MST.MES.DtTools.GetLedCount(dtModel);
            var pcbPerMB = MST.MES.DtTools.GetPcbPerMbCount(dtModel);
            var connCount = MST.MES.DtTools.GetConnCount(dtModel);

            string smtLine = "SMT2";
            if(mbDimensionsLWmm.Item1>610 || mbDimensionsLWmm.Item2 > 450)
            {
                smtLine = "SMT4";
            }


                reflowCT = (double)(mbDimensionsLWmm.Item1 / 10) / (double)lineConfiguration[smtLine].pcbReflowSpeed * 60 + pcbLoadingUnloading;
                siplaceCph = 50 * ledCount * pcbPerMB + 10000;
                connCT = pcbPerMB * connCount * (3600 / (double)lineConfiguration[smtLine].connCph) + pcbLoadingUnloading;
            


            if (siplaceCph < 15000) siplaceCph = 15000;
            if (siplaceCph > lineConfiguration[smtLine].siplaceCph) siplaceCph = lineConfiguration[smtLine].siplaceCph;

            double siplaceCT = ledCount * pcbPerMB / (siplaceCph / 3600) + pcbLoadingUnloading;
            double lineCT = Math.Max(
                                    Math.Max(lineConfiguration[smtLine].printerCt, connCT),
                                    Math.Max(siplaceCT, reflowCT));


            return new SmtEfficiencyNormStruct()
            {
                connCT = Math.Ceiling(connCT),
                outputPerHour = Math.Ceiling(3600 / lineCT * pcbPerMB),
                reflowCT = Math.Ceiling(reflowCT),
                siplaceCT = Math.Ceiling(siplaceCT),
                mbDimensionsLWmm = mbDimensionsLWmm
            };
        }


        
    }
}
