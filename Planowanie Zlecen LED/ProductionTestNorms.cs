using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_Zlecen_LED
{
    public class ProductionTestNorms
    {
        public static int GetTestOutputPerHour(MST.MES.Data_structures.DevToolsModelStructure model)
        {
            var pcbDimensions = MST.MES.Data_structures.DevTools.DevToolsModelsOperations.GetMPcbimensions(model);
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
            if (pcbDimensions.Item1 > 450 || pcbDimensions.Item2 > 450) return 60;

            return 120;
        }
    }
}
