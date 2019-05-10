using MST.MES;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //static Stopwatch st = new Stopwatch();
        public static async Task LoadDataFromSqlParallelAsync()
        {
            //st.Start();
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => GetMesData()));
            tasks.Add(Task.Run(() => GetDevTools()));
            tasks.Add(Task.Run(() => GetMesModels()));

            await Task.WhenAll(tasks);
        }

        private static async Task GetMesData()
        {
            await Task.Run(() => GetKitting());
            //Debug.WriteLine($"kitting done: {st.Elapsed}");

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => GetSmt()));
            tasks.Add(Task.Run(() => GetVi()));
            tasks.Add(Task.Run(() => GetBoxing()));
            await Task.WhenAll(tasks);
            //Debug.WriteLine($"mes done: {st.Elapsed}");
        }

        private static void GetKitting()
        {
            kittingData = MST.MES.SqlDataReaderMethods.Kitting.GetKittingDataForClientGroup(MST.MES.SqlDataReaderMethods.Kitting.clientGroup.MST, 40);
            orders = kittingData.OrderBy(o => o.Value.endDate).ThenByDescending(o => o.Value.plannedEnd).Select(o => o.Key).ToArray();
        }

        private static void GetSmt()
        {
            smtData = MST.MES.SqlDataReaderMethods.SMT.GetOrders(orders);
        }

        private static void GetVi()
        {
            viData = MST.MES.SqlDataReaderMethods.VisualInspection.GetViRecordsForOrders(orders);
        }

        private static void GetBoxing()
        {
            boxingData = MST.MES.SqlDataReaderMethods.Boxing.GetMstBoxingForOrders(orders);
        }

        private static void GetDevTools()
        {
            DevTools.devToolsDb = MST.MES.Data_structures.DevTools.DevToolsLoader.LoadDevToolsModels();
            //Debug.WriteLine($"devTools done: {st.Elapsed}");
        }

        private static void GetMesModels()
        {
            DevTools.mesModels = MST.MES.SqlDataReaderMethods.MesModels.allModels();
            //Debug.WriteLine($"mesModels done: {st.Elapsed}");
        }

        public static void FillOutDailyPlanSummary(DataGridView grid)
        {
            grid.Columns.Clear();

            var ordersByDay = kittingData.Where(o => o.Value.endDate < o.Value.kittingDate)
                                         .GroupBy(o => o.Value.plannedEnd.Date)
                                         .OrderBy(o=>o.Key)
                                         .ToDictionary(day => day.Key, o => o.ToList());

            int dayIndex = 0;
            foreach (var dayEntry in ordersByDay)
            {
                var totalProdCount = dayEntry.Value.Select(o => o.Value.orderedQty).Sum();
                int smtTotalTimeCount = 0;
                int testTotalTimeCount = 0;

                grid.Columns.Add(dayEntry.ToString() + "Model", "Model");
                grid.Columns[dayEntry.ToString() + "Model"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                grid.Columns.Add(dayEntry.ToString() + "Qty", "Qty");
                grid.Columns[dayEntry.ToString() + "Qty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                grid.Columns.Add(dayEntry.ToString() + "Time", "Time");
                grid.Columns[dayEntry.ToString() + "Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                grid.Columns.Add(dayEntry.ToString() + "TimeTest", "TimeTest");
                grid.Columns[dayEntry.ToString() + "TimeTest"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                grid.Columns.Add(dayEntry.ToString() + "Sep", "separator");
                grid.Columns[dayEntry.ToString() + "Sep"].Width = 2;

                var grouppedByModel = dayEntry.Value.GroupBy(o => o.Value.modelId).ToDictionary(model => model.Key, o => o.ToList());
                if (grid.Rows.Count < grouppedByModel.Count + 2) //2 -> header, total
                {
                    grid.Rows.Add(grouppedByModel.Count + 2 - grid.Rows.Count);
                }

                int modelIndex = 2;
                foreach (var modelEntry in grouppedByModel)
                {
                    var modelQty = modelEntry.Value.Select(o => o.Value.orderedQty).Sum() > 0 ? modelEntry.Value.Select(o => o.Value.orderedQty).Sum() : modelEntry.Value.Select(o => o.Value.shippingQty).Sum();
                    grid.Rows[modelIndex].Cells[5 * dayIndex].Value = modelEntry.Key;
                    grid.Rows[modelIndex].Cells[5 * dayIndex + 1].Value = modelQty + " szt.";

                    var smtTimeNeeded = ProductionSmtNorms.CalculateProductionTime(modelEntry.Key, modelQty);
                    string smtTimeNeededString = smtTimeNeeded > 0 ? $"{smtTimeNeeded + 45}min" : "Brak danych";
                    if (smtTimeNeeded > 0) smtTotalTimeCount += smtTimeNeeded + 45;
                    grid.Rows[modelIndex].Cells[5 * dayIndex + 2].Value = smtTimeNeededString;

                    var testTimeNeeded = ProductionTestNorms.CalculateTimeNeededToProduce(modelEntry.Key, modelQty);
                    string testTimeNeededString = testTimeNeeded > 0 ? $"{testTimeNeeded + 10}min" : "Brak danych";
                    if (testTimeNeeded > 0) testTotalTimeCount += testTimeNeeded;
                    grid.Rows[modelIndex].Cells[5 * dayIndex + 3].Value = testTimeNeededString;
                    modelIndex++;
                }

                grid.Rows[0].Cells[5 * dayIndex].Value = dayEntry.Key.Year > 2000 ? dayEntry.Key.ToString("dd-MMM") : "Brak daty";
                grid.Rows[0].Cells[5 * dayIndex + 1].Value = $"{totalProdCount}szt.";
                grid.Rows[0].Cells[5 * dayIndex + 2].Value = $"SMT: {smtTotalTimeCount}min.";
                grid.Rows[0].Cells[5 * dayIndex + 3].Value = $"TEST: {testTotalTimeCount}min.";
                dayIndex++;
            }

            grid.Rows[1].Height = 5;
            Color cellColor = Color.White;
            for (int c = 0; c < grid.Columns.Count; c += 5) 
            {
                if (cellColor == Color.White)
                {
                    cellColor = Color.LightSteelBlue;
                }
                else
                {
                    cellColor = Color.White;
                }

                grid.Rows[0].Cells[c].Style.BackColor = Color.Black;
                grid.Rows[0].Cells[c + 1].Style.BackColor = Color.Black;
                grid.Rows[0].Cells[c + 2].Style.BackColor = Color.Black;
                grid.Rows[0].Cells[c + 3].Style.BackColor = Color.Black;
                grid.Rows[0].Cells[c + 4].Style.BackColor = Color.Black;

                grid.Rows[0].Cells[c].Style.ForeColor = Color.White;
                grid.Rows[0].Cells[c + 1].Style.ForeColor = Color.White;
                grid.Rows[0].Cells[c + 2].Style.ForeColor = Color.White;
                grid.Rows[0].Cells[c + 3].Style.ForeColor = Color.White;

                for (int r = 1; r < grid.Rows.Count; r++)
                {
                    grid.Rows[r].Cells[c].Style.BackColor = cellColor;
                    grid.Rows[r].Cells[c + 1].Style.BackColor = cellColor;
                    grid.Rows[r].Cells[c + 2].Style.BackColor = cellColor;
                    grid.Rows[r].Cells[c + 3].Style.BackColor = cellColor;
                    grid.Rows[r].Cells[c + 4].Style.BackColor = Color.Black;
                }
            }
            grid.CurrentCell = null;
        }

        public static void FillOutOrdersStatusGrid(CustomDataGridView grid)
        {

            #region SetUpColumns
            grid.Columns.Clear();
            grid.userEnteredData = false;
            grid.Columns.Clear();
            grid.Columns.Add("Zlecenie", "Zlecenie");
            grid.Columns.Add("NC12", "10NC");
            grid.Columns.Add("Nazwa", "Nazwa");
            grid.Columns.Add("Poczatek", "Start zlecenia");
            grid.Columns["Poczatek"].ValueType = typeof(DateTime);
            grid.Columns.Add("Plan", "Planowana wysyłka");
            grid.Columns["Plan"].ValueType = typeof(DateTime);
            grid.Columns.Add("Koniec", "Koniec zlecenia");
            grid.Columns["Koniec"].ValueType = typeof(DateTime);
            grid.Columns.Add("shippingQty", "Ilość do wysyłki");
            grid.Columns["shippingQty"].ValueType = typeof(int);
            grid.Columns.Add("Ilosc", "Ilość produkcji");
            grid.Columns["Ilosc"].ValueType = typeof(int);

            DataGridViewImageColumn smtImgCol = new DataGridViewImageColumn();
            smtImgCol.Name = "SMT";
            smtImgCol.HeaderText = "SMT postęp";
            smtImgCol.Width = 120;
            grid.Columns.Add(smtImgCol);

            grid.Columns.Add("SmtTime", "SMT czas");

            DataGridViewImageColumn boxImgCol = new DataGridViewImageColumn();
            boxImgCol.Name = "Spakowane";
            boxImgCol.HeaderText = "Pakowanie postęp";
            boxImgCol.Width = 120;
            grid.Columns.Add(boxImgCol);

            grid.Columns.Add("BoxTime", "Pakowanie czas");

            //grid.Columns.Add("Spakowane", "Spakowane");
            grid.Columns.Add("Ilosckartonow", "Ilość kartonów");
            //grid.Columns.Add("SMT", "Ilość SMT");
            grid.Columns.Add("NG", "NG (naprawione)");
            grid.Columns.Add("SCR", "SCR");

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            #endregion

            int firstFinishedRow = 0;

            foreach (var order in orders)
            {
                if (order.Trim() == "") continue;
                int currentRow = 0;

                if (kittingData[order].endDate > kittingData[order].kittingDate)
                {
                    if ((DateTime.Now - kittingData[order].endDate).TotalDays > 7) continue;
                    grid.Rows.Insert(firstFinishedRow, order);
                    currentRow = firstFinishedRow;
                    MST.MES.DgvTools.SetRowColor(grid.Rows[currentRow], Color.LightGray, Color.Black);
                }
                else
                {
                    if (kittingData[order].plannedEnd.Year > 2000)
                    {
                        grid.Rows.Insert(0, order);
                        currentRow = 0;
                    }
                    else
                    {
                        currentRow = firstFinishedRow;
                        grid.Rows.Insert(currentRow, order);
                    }
                    
                    firstFinishedRow++;
                }

                if (kittingData.ContainsKey(order))
                {
                    grid.Rows[currentRow].Cells["NC12"].Value = kittingData[order].modelId_12NCFormat;
                    grid.Rows[currentRow].Cells["Nazwa"].Value = kittingData[order].ModelName;

                    var dtModel = MST.MES.DtTools.GetDtModel00(kittingData[order].modelId, DevTools.devToolsDb);
                    if (dtModel != null)
                    {
                        var mb = MST.MES.DtTools.GetMbDimensions(dtModel);
                        var mbDim = mb.Item1 > 0 ? $"{mb.Item1}x{mb.Item2}mm" : "Brak danych";
                        var pcb = MST.MES.DtTools.GetPcbDimensions(dtModel);
                        var pcbDim = pcb.Item1 > 0 ? $"{pcb.Item1}x{pcb.Item2}mm" : "Brak danych";
                        string toolTip = $"LED {MST.MES.DtTools.GetLedCount(dtModel)}szt." + Environment.NewLine
                                                                            + $"CONN {MST.MES.DtTools.GetConnCount(dtModel)}szt." + Environment.NewLine
                                                                            + $"RES {MST.MES.DtTools.GetResCount(dtModel)}szt." + Environment.NewLine
                                                                            + $"{MST.MES.DtTools.GetPcbPerMbCount(dtModel)} PCB/MB" + Environment.NewLine
                                                                            + $"MB {mbDim}" + Environment.NewLine
                                                                            + $"PCB {pcbDim}";
                        grid.Rows[currentRow].Cells["NC12"].ToolTipText = toolTip;
                        grid.Rows[currentRow].Cells["Nazwa"].ToolTipText = toolTip;
                    }

                    if (kittingData[order].ModelName== kittingData[order].modelId+"00" & dtModel != null)
                    {
                        grid.Rows[currentRow].Cells["Nazwa"].Value = dtModel.name;
                    }
                    grid.Rows[currentRow].Cells["Poczatek"].Value = kittingData[order].kittingDate;
                    grid.Rows[currentRow].Cells["shippingQty"].Value = kittingData[order].shippingQty;
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
                    string ngInfo = "0";
                    if (viData[order].ngCount > 0)
                    {
                        ngInfo = $"{viData[order].ngCount}({viData[order].reworkedOkCout})";
                    }
                    grid.Rows[currentRow].Cells["NG"].Value = ngInfo;
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

                if (kittingData[order].endDate < kittingData[order].kittingDate)
                {
                    var remainingSmt = kittingData[order].orderedQty - smtCount;

                    if (remainingSmt > 0)
                    {
                        var smtNorm = ProductionSmtNorms.CalculateModelNormPerHour(kittingData[order].modelId);
                        if (smtNorm.outputPerHour > 0)
                        {
                            var smtRemainingTime = Math.Round(remainingSmt * 60 / smtNorm.outputPerHour * 0.85, 0);
                            string smtTime = $"{smtRemainingTime}min";
                            grid.Rows[currentRow].Cells["SmtTime"].Value = smtTime;
                        }
                        else
                        {
                            grid.Rows[currentRow].Cells["SmtTime"].Value = "Brak danych";
                        }
                    }

                    var remainingBoxing = kittingData[order].orderedQty - boxedCount;

                    if (remainingBoxing > 0)
                    {
                        var boxNorm = ProductionTestNorms.GetTestOutputPerHour(kittingData[order].modelId);
                        if (boxNorm > 0)
                        {
                            var boxingTimeLeft = Math.Round((remainingBoxing * 60) / boxNorm, 0);
                            string boxTime = $"{boxingTimeLeft}min";
                            grid.Rows[currentRow].Cells["BoxTime"].Value = boxTime;
                        }
                        else
                        {
                            grid.Rows[currentRow].Cells["BoxTime"].Value = "Brak danych";
                        }
                    }
                }
            }

            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column.Name == "SMT") continue;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dgvTools.MarkRepeatedModels(grid);
            
            dgvTools.SetUpDailySeparators(grid);
            grid.CurrentCell = null;
            grid.userEnteredData = true;
        }

        
    }
}
