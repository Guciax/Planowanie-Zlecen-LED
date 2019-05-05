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
            public ModelInfo.ModelSpecification modelSpec { get; set; }
            public Tuple<double, double> mbDimensionsLWmm { get; set; }
        }

        public static SmtEfficiencyNormStruct CalculateModelNormPerHour(string modelId, int siplaceHeads2or4 = 2)
        {
            ModelInfo.ModelSpecification modelSpec = DevTools.mesModels[modelId];
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
            double reflowCT = 0;
            double siplaceCph = 0;
            double connCT = 0;
            int pcbLoadingUnloading = 15;

            if (dtModels.Count() == 0)
            {
                return null;
            }
            
                mbDimensionsLWmm = GetMbDimensions(dtModels.First()); //need smth better than first

            string smtLine = "SMT2";
            if(mbDimensionsLWmm.Item1>610 || mbDimensionsLWmm.Item2 > 450)
            {
                smtLine = "SMT4";
            }


                reflowCT = (double)(mbDimensionsLWmm.Item1 / 10) / (double)lineConfiguration[smtLine].pcbReflowSpeed * 60 + pcbLoadingUnloading;
                siplaceCph = 50 * modelSpec.ledCountPerModel * modelSpec.pcbCountPerMB + 10000;
                connCT = modelSpec.pcbCountPerMB * modelSpec.connectorCountPerModel * (3600 / (double)lineConfiguration[smtLine].connCph) + pcbLoadingUnloading;
            


            if (siplaceCph < 15000) siplaceCph = 15000;
            if (siplaceCph > lineConfiguration[smtLine].siplaceCph) siplaceCph = lineConfiguration[smtLine].siplaceCph;

            double siplaceCT = modelSpec.ledCountPerModel * modelSpec.pcbCountPerMB / (siplaceCph / 3600) + pcbLoadingUnloading;
            double lineCT = Math.Max(
                                    Math.Max(lineConfiguration[smtLine].printerCt, connCT),
                                    Math.Max(siplaceCT, reflowCT));


            return new SmtEfficiencyNormStruct()
            {
                connCT = Math.Ceiling(connCT),
                outputPerHour = Math.Ceiling(3600 / lineCT * modelSpec.pcbCountPerMB),
                reflowCT = Math.Ceiling(reflowCT),
                siplaceCT = Math.Ceiling(siplaceCT),
                modelSpec = modelSpec,
                mbDimensionsLWmm = mbDimensionsLWmm
            };
        }

        private static double GetLgModelConnQty(string modelId)
        {
            if (modelId.StartsWith("K2") || modelId.StartsWith("G2"))
            {
                int connMark = int.Parse(modelId[8].ToString());
                if (connMark % 2 == 0) return 4;
            }
            return 2;
        }

        private static Tuple<double, double> GetLgModelMbDimension(string model)
        {

            if (model.StartsWith("33")) return new Tuple<double, double>(270, 270);
            if (model.StartsWith("22")) return new Tuple<double, double>(250, 250);
            if (model.StartsWith("32")) return new Tuple<double, double>(272, 230);
            return new Tuple<double, double>(600, 350);
        }

        private static Tuple<double, double> GetMbDimensions(MST.MES.Data_structures.DevToolsModelStructure dtModel00)
        {
            MST.MES.Data_structures.DevToolsModelStructure model = new MST.MES.Data_structures.DevToolsModelStructure();
            bool success = false;
            foreach (var subComponent in dtModel00.children)
            {
                if (subComponent.nc12.StartsWith("6010616")) //SMD Assy
                {
                    foreach (var component in subComponent.children)
                    {
                        if (component.name.StartsWith("PCB") & component.children.Count == 0)
                        {
                            model = component;
                            success = true;
                            break;
                        }
                        if (component.nc12.StartsWith("4010440"))
                        {
                            foreach (var pcb in component.children)
                            {
                                if (pcb.name.StartsWith("MB"))
                                {
                                    model = pcb;
                                    success = true;
                                    break;
                                }
                            }
                        }
                        if (success) break;
                    }
                }
                if (success) break;
            }

            Tuple<double, double> result = new Tuple<double, double>(0, 0);
            if (success)
            {
                try
                {
                    string[] size = model.atributes["L x W"].ToUpper().Split('X');
                    string l = size[0];
                    string w = size[1];
                    result = new Tuple<double, double>(double.Parse(l, CultureInfo.InvariantCulture), double.Parse(w, CultureInfo.InvariantCulture));
                }
                catch (Exception ex)
                {

                    return new Tuple<double, double>(-1, -1);
                }
            }

            return result;
        }

        private static double WeightedAverage(List<Tuple<double, double>> valueWeigth)
        {
            var sumOfWeigth = valueWeigth.Select(v => v.Item2).Sum();
            var sumWeightedValues = valueWeigth.Select(v => v.Item1 * v.Item2).Sum();
            return sumWeightedValues / sumOfWeigth;
        }

        
    }
}
