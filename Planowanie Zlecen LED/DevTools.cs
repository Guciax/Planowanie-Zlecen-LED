using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_Zlecen_LED
{
    public class DevTools
    {
        public static List<MST.MES.Data_structures.DevToolsModelStructure> devToolsDb = new List<MST.MES.Data_structures.DevToolsModelStructure>();
        public static Dictionary<string, MST.MES.ModelInfo.ModelSpecification> mesModels = new Dictionary<string, MST.MES.ModelInfo.ModelSpecification>();

        public static void LoadDevToolsDb()
        {
            devToolsDb = MST.MES.Data_structures.DevTools.DevToolsLoader.LoadDevToolsModels();
        }

        public static void LoadMesModels()
        {
            mesModels = MST.MES.SqlDataReaderMethods.MesModels.allModels();
        }

    }
}
