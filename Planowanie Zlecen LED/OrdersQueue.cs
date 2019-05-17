using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Planowanie_Zlecen_LED
{
    public class OrdersQueue
    {
        public static Dictionary<string, int> oryginalOrderNoToRowIndex = new Dictionary<string, int>();
        public static Dictionary<int, string> rowsWithChangedIndex = new Dictionary<int, string>();

        public static void UpdateRowIndexChanges(DataGridView grid)
        {
            rowsWithChangedIndex.Clear();
            foreach (DataGridViewRow row in grid.Rows)
            {
                string orderNo = row.Cells[0].Value.ToString();
                if (row.Index == oryginalOrderNoToRowIndex[orderNo]) continue;

                rowsWithChangedIndex.Add(row.Index, orderNo);
            }
        }

        public static string[] GetOrdersWithChangedQueue()
        {
            return rowsWithChangedIndex.Select(x => x.Value).ToArray();
        }

        public static void MakeOryginalDictionary(DataGridView grid)
        {
            oryginalOrderNoToRowIndex.Clear();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (oryginalOrderNoToRowIndex.ContainsKey(row.Cells[0].Value.ToString())) continue;
                oryginalOrderNoToRowIndex.Add(row.Cells[0].Value.ToString(), row.Index);
            }
        }

        public static void SetUpOrdersShippingDateColors(DataGridView grid)
        {
            Dictionary<DateTime, Color> dateToColor = new Dictionary<DateTime, Color>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                DateTime shippingDate = ((DateTime)row.Cells["ColShippingPlan"].Value).Date;
                if (!dateToColor.ContainsKey(shippingDate))
                {
                    int colorIndex = MST.MES.Colors.materialDesignColors.Count > dateToColor.Count ? dateToColor.Count : MST.MES.Colors.materialDesignColors.Count - 1;
                    dateToColor.Add(shippingDate, MST.MES.Colors.materialDesignColors[colorIndex]);
                }
                row.Cells["ColShippingPlan"].Style.BackColor = dateToColor[shippingDate];
                row.Cells["ColShippingPlan"].Style.SelectionBackColor = dateToColor[shippingDate];
            }
        }
    }
}