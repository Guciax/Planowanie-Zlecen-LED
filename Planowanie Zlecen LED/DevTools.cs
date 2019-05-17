using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MST.MES.OrderStructureByOrderNo;

namespace Planowanie_Zlecen_LED
{
    public class DevTools
    {
        public static List<MST.MES.Data_structures.DevToolsModelStructure> devToolsDb = new List<MST.MES.Data_structures.DevToolsModelStructure>();
        public static Dictionary<string, MST.MES.ModelInfo.ModelSpecification> mesModels = new Dictionary<string, MST.MES.ModelInfo.ModelSpecification>();
        public static Dictionary<string, string> nc12ToCollective = new Dictionary<string, string>();

        public static void LoadDevToolsDb()
        {
            devToolsDb = MST.MES.Data_structures.DevTools.DevToolsLoader.LoadDevToolsModels();
        }

        public static void LoadMesModels()
        {
            mesModels = MST.MES.SqlDataReaderMethods.MesModels.allModels();
        }

        public static MST.MES.Data_structures.DevToolsModelStructure TryGetDtModel00(string model10NC)
        {
            var dtModels = devToolsDb.Where(m => m.nc12 == model10NC + "00");
            if (dtModels.Count() > 0)
            {
                return dtModels.First();
            }
            else
            {
                return null;
            }
        }

        public static MST.MES.Data_structures.DevToolsModelStructure TryGetDtModel46(string model10NC)
        {
            var dtModels = devToolsDb.Where(m => m.nc12 == model10NC + "46");
            if (dtModels.Count() > 0)
            {
                return dtModels.First();
            }
            else
            {
                return null;
            }
        }
    }
}
