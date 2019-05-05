using MST.MES;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MST.MES.OrderStructureByOrderNo;

namespace Planowanie_Zlecen_LED
{
    public class OrdersStatus
    {
        static Dictionary<string, Kitting> kittingData = new Dictionary<string, Kitting>();
        static Dictionary<string, SMT> smtData = new Dictionary<string, SMT>();
        static Dictionary<string, VisualInspection> viData = new Dictionary<string, VisualInspection>();
        static Dictionary<string, List<BoxingInfo>> boxingData = new Dictionary<string, List<BoxingInfo>>();
        static string[] orders;

        public static void LoadDataFromSql()
        {
            kittingData = MST.MES.SqlDataReaderMethods.Kitting.GetKittingDataForClientGroup(MST.MES.SqlDataReaderMethods.Kitting.clientGroup.MST, 20);
            orders = kittingData.Select(o => o.Key).ToArray();
            smtData = MST.MES.SqlDataReaderMethods.SMT.GetOrders(orders);
            viData = MST.MES.SqlDataReaderMethods.VisualInspection.GetViRecordsForOrders(orders);
            boxingData = MST.MES.SqlDataReaderMethods.Boxing.GetMstBoxingForOrders(orders);
        }

        public static void FillOutOrdersStatusGrid(CustomDataGridView grid)
        {
            grid.userEnteredData = false;
            grid.Columns.Clear();
            grid.Columns.Add("Zlecenie", "Zlecenie");
            grid.Columns.Add("NC12", "12NC");
            grid.Columns.Add("Nazwa", "Nazwa");
            grid.Columns.Add("Poczatek", "Początek zlecenia");
            grid.Columns["Poczatek"].ValueType = typeof(DateTime);
            grid.Columns.Add("Plan", "Planowana wysyłka");
            grid.Columns["Plan"].ValueType = typeof(DateTime);
            grid.Columns.Add("Koniec", "Data zakończenia");
            grid.Columns["Koniec"].ValueType = typeof(DateTime);
            grid.Columns.Add("Ilosc", "Ilość zlecenia");
            grid.Columns["Ilosc"].ValueType = typeof(int);
            DataGridViewImageColumn smtImgCol = new DataGridViewImageColumn();
            smtImgCol.Name = "SMT";
            smtImgCol.HeaderText = "SMT";
            smtImgCol.Width = 120;
            grid.Columns.Add(smtImgCol);

            DataGridViewImageColumn boxImgCol = new DataGridViewImageColumn();
            boxImgCol.Name = "Spakowane";
            boxImgCol.HeaderText = "Spakowane";
            boxImgCol.Width = 120;
            grid.Columns.Add(boxImgCol);

            //grid.Columns.Add("Spakowane", "Spakowane");
            grid.Columns.Add("Ilosckartonow", "Ilość kartonów");
            //grid.Columns.Add("SMT", "Ilość SMT");
            grid.Columns.Add("NG", "NG");
            grid.Columns.Add("SCR", "SCR");
            int firstFinishedRow = 0;

            foreach (var order in orders)
            {
                if (order.Trim() == "") continue;
                int currentRow = 0;

                if (kittingData[order].endDate > kittingData[order].kittingDate)
                {
                    grid.Rows.Insert(firstFinishedRow, order);
                    currentRow = firstFinishedRow;
                    DgvTools.SetRowColor(grid.Rows[currentRow], Color.LightGray, Color.Black);
                }
                else
                {
                    grid.Rows.Insert(0, order);
                    currentRow = 0;
                    firstFinishedRow++;
                }

                if (kittingData.ContainsKey(order))
                {
                    grid.Rows[currentRow].Cells["NC12"].Value = kittingData[order].modelId_12NCFormat;
                    grid.Rows[currentRow].Cells["Nazwa"].Value = kittingData[order].ModelName;
                    grid.Rows[currentRow].Cells["Poczatek"].Value = kittingData[order].kittingDate;
                    grid.Rows[currentRow].Cells["Ilosc"].Value = kittingData[order].orderedQty;
                    if (kittingData[order].plannedEnd.Year > 2000)
                    {
                        grid.Rows[currentRow].Cells["Plan"].Value = kittingData[order].plannedEnd;
                    }

                    if (kittingData[order].endDate.Year > 2000)
                    {
                        grid.Rows[currentRow].Cells["Koniec"].Value = kittingData[order].endDate;
                    }
                   
                }

                float smtProgress = 0;
                int smtCount = 0;
                if (smtData.ContainsKey(order))
                {
                    smtCount = smtData[order].totalManufacturedQty;
                    smtProgress = (float)smtCount / (float)kittingData[order].orderedQty;
                    var smtLastRecord = smtData[order].smtOrders[smtData[order].smtOrders.Count - 1];
                    string smtTooltip = $"Ostatnia aktualizacja: {smtLastRecord.smtEndDate.ToString("HH:mm dd-MMM")} {smtLastRecord.smtLine}";
                    grid.Rows[currentRow].Cells["SMT"].ToolTipText = smtTooltip;
                }
                ImageProgressBar.CreateProgressbar(smtProgress, smtCount, grid.Rows[currentRow].Cells["SMT"] as DataGridViewImageCell);

                if (viData.ContainsKey(order))
                {
                    grid.Rows[currentRow].Cells["NG"].Value = viData[order].ngCount.ToString();
                    grid.Rows[currentRow].Cells["SCR"].Value = viData[order].scrapCount.ToString();
                }

                float boxingProgress = 0;
                int boxedCount = 0;
                if (boxingData.ContainsKey(order))
                {
                    //grid.Rows[lastRow].Cells["Spakowane"].Value = boxingData[order].Count.ToString();
                    boxedCount = boxingData[order].Count();
                    grid.Rows[currentRow].Cells["Ilosckartonow"].Value = boxingData[order].Select(o => o.boxId).Distinct().Count().ToString();
                    boxingProgress = (float)boxedCount / (float)kittingData[order].orderedQty;
                    string toolTip = $"Ostatnia aktualizacja: {boxingData[order].OrderBy(b => b.boxingDate).Last().boxingDate.ToString("HH:mm dd-MMM")}";
                    grid.Rows[currentRow].Cells["Spakowane"].ToolTipText = toolTip;
                }
                ImageProgressBar.CreateProgressbar(boxingProgress, boxedCount, grid.Rows[currentRow].Cells["Spakowane"] as DataGridViewImageCell);


            }

            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column.Name == "SMT") continue;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            grid.userEnteredData = true;
        }

    }
}
