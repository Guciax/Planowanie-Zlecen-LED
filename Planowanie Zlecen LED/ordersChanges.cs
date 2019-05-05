using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planowanie_Zlecen_LED
{
    public class ordersChanges
    {
        public static Dictionary<string, int> changesInQty = new Dictionary<string, int>();
        public static Dictionary<string, DateTime> changesInPlannedShipping = new Dictionary<string, DateTime>();

        public static void ApplyChanges()
        {
            if (changesInQty.Count > 0)
            {
                foreach (var orderEntry in changesInQty)
                {
                    MST.MES.SqlOperations.Kitting.UpdateOrderQty(orderEntry.Key, orderEntry.Value);
                }
            }

            if (changesInPlannedShipping.Count > 0)
            {
                foreach (var orderEntry in changesInPlannedShipping)
                {
                    MST.MES.SqlOperations.Kitting.UpdateOrderPlannedEndDate(orderEntry.Key, orderEntry.Value);
                }
            }
        }
    }
}
