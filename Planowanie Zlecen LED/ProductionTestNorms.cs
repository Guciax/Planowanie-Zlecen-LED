using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_Zlecen_LED
{
    public class ProductionTestNorms
    {
        public static int CalculateTimeNeededToProduce(string modelId, double qty)
        {
            double outPutNorm = GetTestOutputPerHour(modelId);
            return (int)Math.Ceiling(qty * 60 / outPutNorm);
        }

        public static int GetTestOutputPerHour(string modelId)
        {
            var models = DevTools.devToolsDb.Where(m => m.nc12 == modelId + "00");
            if (models.Count() == 0) return 0;
            MST.MES.Data_structures.DevToolsModelStructure model = models.First();
            var pcbDimensions = MST.MES.DtTools.GetPcbDimensions(model);
            if (pcbDimensions.Item1 == -1) return 0;
            if (model.name.ToUpper().StartsWith("LIN"))
            {
                if (pcbDimensions.Item1 <= 610) return 120;
                return 80;
            }
            if (model.name.ToUpper().StartsWith("REC"))
            {
                if (pcbDimensions.Item1 < 355) return 120;
                return 80;
            }
            if (model.name.ToUpper().StartsWith("RD"))
            {
                if (pcbDimensions.Item1 < 355) return 120;
                if (pcbDimensions.Item1 < 450) return 80;
                return 60;
            }
            if (model.name.ToUpper().StartsWith("HEX"))
            {
                return 200;
            }
            if (pcbDimensions.Item1 > 610 || pcbDimensions.Item2 > 450)
            {
                return 60;
            }

            return 120;
        }
    }
}
