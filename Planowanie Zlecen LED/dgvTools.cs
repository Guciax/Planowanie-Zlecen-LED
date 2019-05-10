using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planowanie_Zlecen_LED
{
    public class dgvTools
    {
        public static Dictionary<string, List<DateTime>> CreatePcbToShippingDateDictionary(CustomDataGridView grid)
        {
            Dictionary<string, List<DateTime>> result = new Dictionary<string, List<DateTime>>();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["Koniec"].Value != null) break;
                if (row.Cells["NC12"].Value == null) continue;
                if (row.Cells["Plan"].Value == null) continue;

                string model = row.Cells["NC12"].Value.ToString().Replace(" ", "");
                var dtModel = MST.MES.DtTools.GetDtModel00(model, DevTools.devToolsDb);
                if (dtModel == null)
                    continue;
                var pcb12Nc = MST.MES.DtTools.GetPcb12NC(dtModel);

                if (!result.ContainsKey(pcb12Nc))
                {
                    result.Add(pcb12Nc, new List<DateTime>());
                }

                DateTime shippingDate = (DateTime)row.Cells["Plan"].Value;
                result[pcb12Nc].Add(shippingDate);
            }
            return result;
        }

        public static void MarkRepeatedModels(CustomDataGridView grid)
        {
            Dictionary<string, List<int>> rowIndexOfModels = new Dictionary<string, List<int>>();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["Koniec"].Value != null) break;
                string model = row.Cells["NC12"].Value.ToString().Replace(" ","");
                var dtModel = MST.MES.DtTools.GetDtModel00(model, DevTools.devToolsDb);
                if (dtModel == null)
                    continue;
                var pcb12Nc = MST.MES.DtTools.GetPcb12NC(dtModel);

                if (!rowIndexOfModels.ContainsKey(pcb12Nc))
                {
                    rowIndexOfModels.Add(pcb12Nc, new List<int>());
                }
                rowIndexOfModels[pcb12Nc].Add(row.Index);
            }

            int colorIndex = 0;
            foreach (var pcbEntry in rowIndexOfModels)
            {
                if (pcbEntry.Value.Count < 2) continue;

                foreach (var idx in pcbEntry.Value)
                {
                    grid.Rows[idx].Cells[0].Style.BackColor = MST.MES.Colors.materialDesignColors[colorIndex];
                    grid.Rows[idx].Cells[1].Style.BackColor = MST.MES.Colors.materialDesignColors[colorIndex];
                    grid.Rows[idx].Cells[2].Style.BackColor = MST.MES.Colors.materialDesignColors[colorIndex];
                }
                colorIndex++;
                if (colorIndex > MST.MES.Colors.materialDesignColors.Count - 1)
                {
                    colorIndex = 0;
                }
            }
        }

        public static void SetUpDailySeparators(CustomDataGridView grid)
        {
            List<int> indexesOfSeparators = new List<int>();

            for (int r = 1; r < grid.Rows.Count; r++) 
            {
                if(grid.Rows[r - 1].Cells["Koniec"].Value != null) break;
                if (grid.Rows[r].Cells["Plan"].Value == null) break;
                DateTime previousDate = (DateTime)grid.Rows[r - 1].Cells["Plan"].Value;
                DateTime currentDate = (DateTime)grid.Rows[r].Cells["Plan"].Value;

                if (previousDate.Date != currentDate.Date)
                {
                    indexesOfSeparators.Add(r);
                }
            }

            for (int i = 0; i < indexesOfSeparators.Count; i++) 
            {
                grid.Rows.Insert(indexesOfSeparators[i]);
                grid.Rows[indexesOfSeparators[i]].Height = 2;

                foreach (DataGridViewCell cell in grid.Rows[indexesOfSeparators[i]].Cells)
                {
                    cell.Style.BackColor = Color.DarkGray;
                }

                indexesOfSeparators = indexesOfSeparators.Select(id => id + 1).ToList();
            }
        }
    }
}
