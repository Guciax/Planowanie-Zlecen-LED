using Planowanie_Zlecen_LED.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planowanie_Zlecen_LED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Parent = dgvDailyOrdersSummary;
            pictureBox1.Dock = DockStyle.Right;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            tabControl1.TabPages.Remove(tabPage2);
            await OrdersStatus.LoadDataFromSqlParallelAsync();

            pictureBox1.Visible = false;
            tabControl1.TabPages.Add(tabPage2);

            OrdersStatus.FillOutOrdersStatusGrid(dgvOrdersStatus);
            OrdersStatus.FillOutDailyPlanSummary(dgvDailyOrdersSummary);
            dgvOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            var y = dgvDailyOrdersSummary.GetCellDisplayRectangle(1, dgvDailyOrdersSummary.Rows.Count - 1, false);
            splitter1.Location = new Point(0, 50);
        }

        private void dgvOrdersStatus_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvOrdersStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string orderNo = dgvOrdersStatus.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 4)
                {
                    DateTime startDate = Convert.ToDateTime( dgvOrdersStatus.Rows[e.RowIndex].Cells["Poczatek"].Value);
                    DateTime plannedFinish = startDate.AddDays(5);
                    if(dgvOrdersStatus.Rows[e.RowIndex].Cells["Plan"].Value != null)
                    {
                        plannedFinish = Convert.ToDateTime(dgvOrdersStatus.Rows[e.RowIndex].Cells["Plan"].Value);
                    }
                    using (ChangeDate changeDateForm = new ChangeDate(startDate, plannedFinish))
                    {
                        if (changeDateForm.ShowDialog() == DialogResult.OK)
                        {
                            dgvOrdersStatus.Rows[e.RowIndex].Cells[4].Value = changeDateForm.selectedDate;

                            if (!ordersChanges.changesInPlannedShipping.ContainsKey(orderNo))
                            {
                                ordersChanges.changesInPlannedShipping.Add(orderNo, changeDateForm.selectedDate);
                            }
                            else
                            {
                                ordersChanges.changesInPlannedShipping[orderNo] = changeDateForm.selectedDate;
                            }

                            dgvOrdersStatus.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.Yellow;
                            bSaveAndSendChangesForUpdates.Visible = true;
                        }
                    }
                }

                if (e.ColumnIndex == 6)
                {
                    DataGridViewCell cell = dgvOrdersStatus.Rows[e.RowIndex].Cells["Ilosc"];
                    var currentQty = Convert.ToInt32( cell.Value);

                    using (ChangeQty changeQtyForm = new ChangeQty(currentQty))
                    {
                        if (changeQtyForm.ShowDialog() == DialogResult.OK)
                        {
                            dgvOrdersStatus.Rows[e.RowIndex].Cells[6].Value = changeQtyForm.newQty;

                            if (!ordersChanges.changesInQty.ContainsKey(orderNo))
                            {
                                ordersChanges.changesInQty.Add(orderNo, changeQtyForm.newQty);
                            }
                            else
                            {
                                ordersChanges.changesInQty[orderNo] = changeQtyForm.newQty;
                            }

                            cell.Style.BackColor = Color.Yellow;
                            bSaveAndSendChangesForUpdates.Visible = true;
                        }
                    }
                }

                dgvOrdersStatus.CurrentCell = null;
            }
        }

        private void bSaveAndSendChangesForUpdates_Click(object sender, EventArgs e)
        {
            using(SummaryForm sumForm = new SummaryForm())
            {
                if (sumForm.ShowDialog() == DialogResult.OK)
                {
                    ordersChanges.ApplyChanges();

                    foreach (DataGridViewRow row in dgvOrdersStatus.Rows)
                    {
                        if(row.Cells["shippingQty"].Style.BackColor == Color.Yellow) { row.Cells["shippingQty"].Style.BackColor = Color.White; }
                        if(row.Cells["Plan"].Style.BackColor == Color.Yellow) { row.Cells["Plan"].Style.BackColor = Color.White; }
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 0;
            if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = (!int.TryParse(e.KeyChar.ToString(), out check) || tb10NC.Text.Length > 9);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 0;
            if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = (!int.TryParse(e.KeyChar.ToString(), out check) || tbQty.Text.Length > 9);
            }
        }

        private void tb10NC_TextChanged(object sender, EventArgs e)
        {

            if (tb10NC.Text.Length == 10) 
            {
                UpdateDescriptionLabels();
            }
            else
            {
                lModelDescribtion.Text = "...";
                lOutputNorm.Text = "...";
            }
        }

        private void UpdateDescriptionLabels()
        {
            var dtModel00 = DevTools.TryGetDtModel00(tb10NC.Text);
            float qty = 0;
            float.TryParse(tbQty.Text, out qty);

            if (dtModel00 != null)
            {
                var ledCount = MST.MES.DtTools.GetLedCount(dtModel00);
                lModelDescribtion.Text = dtModel00.name + Environment.NewLine;
                lModelDescribtion.Text += $"LED: {ledCount}szt." + Environment.NewLine;
                lModelDescribtion.Text += $"CONN: {MST.MES.DtTools.GetConnCount(dtModel00)}szt." + Environment.NewLine;
                lModelDescribtion.Text += $"PCB/MB: {MST.MES.DtTools.GetPcbPerMbCount(dtModel00)}szt." + Environment.NewLine;
                lModelDescribtion.Text += $"Potrzeba łącznie: {qty*ledCount}szt. LED" + Environment.NewLine;

                if (qty > 0)
                {
                    var smtNorm = ProductionSmtNorms.CalculateModelNormPerHour(tb10NC.Text);
                    var boxNorm = ProductionTestNorms.GetTestOutputPerHour(tb10NC.Text);
                    lOutputNorm.Text = $"Czas SMT: {Math.Round((float)qty * 60 / smtNorm.outputPerHour, 0)}min + przestawienie" + Environment.NewLine;
                    lOutputNorm.Text += $"Czas testu: {Math.Round((float)qty * 60 / boxNorm, 0)}min";
                }
            }
            else
            {
                lModelDescribtion.Text = "Brak danych w bazie DevTools";
                lOutputNorm.Text = "...";
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            var dtModel = DevTools.TryGetDtModel00(tb10NC.Text);
            if (dtModel == null)
            {
                MessageBox.Show($"Brak modelu {tb10NC.Text} w bazie DevTools");
                return;
            }
            var ledCount = MST.MES.DtTools.GetLedCount(dtModel);
            string ledsCollection = string.Join(Environment.NewLine, tbLeds.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                                                                        .Where(line => !string.IsNullOrWhiteSpace(line))
                                                                        .Select(line => line.Replace(" ", ""))
                                                                        .ToArray());

            dgvOrders.Rows.Add(tbOrderNo.Text, tb10NC.Text, tbQty.Text, mcShippingPlan.SelectionStart, ledsCollection, ledCount);
            tbOrderNo.Text = tb10NC.Text = tbQty.Text = tbLeds.Text = "";

            MST.MES.DgvTools.ColumnsAutoSize(dgvOrders, DataGridViewAutoSizeColumnMode.AllCells);
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1 & e.ColumnIndex == 6)
            {
                dgvOrders.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            UpdateDescriptionLabels();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                string orderNo = row.Cells[0].Value.ToString();
                string nc10 = row.Cells[1].Value.ToString();
                int shippingQty = int.Parse(row.Cells[2].Value.ToString());
                DateTime shippingDate = (DateTime)(row.Cells[3].Value);
                string[] ledsCollection =  row.Cells[4].Value.ToString().Split(new string[] { "\\n" }, StringSplitOptions.None);
                int ledCount = int.Parse(row.Cells[5].Value.ToString());

                MST.MES.SqlOperations.Kitting.InsertMstOrderForProductionPlanner(orderNo, nc10, -1, shippingQty, DateTime.Now, shippingDate, ledsCollection.Length, ledCount, string.Join(";", ledsCollection));
            }

            dgvOrders.Rows.Clear();
        }

        private void tbLeds_TextChanged(object sender, EventArgs e)
        {
            tbLeds.Text = tbLeds.Text.Replace(" ", "");
        }

        private void dgvOrdersStatus_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex > 0)
            //{
            //    if (!dgvOrdersStatus.Columns.Contains("Plan")) return;
            //    if (dgvOrdersStatus.Rows[e.RowIndex - 1].Cells["Plan"].Value == null) return;
            //    if (dgvOrdersStatus.Rows[e.RowIndex].Cells["Plan"].Value == null) return;
            //    if (dgvOrdersStatus.Rows[e.RowIndex].Cells["Koniec"].Value != null) return;

            //    DateTime previousDate = (DateTime)dgvOrdersStatus.Rows[e.RowIndex - 1].Cells["Plan"].Value;
            //    DateTime currentDate = (DateTime)dgvOrdersStatus.Rows[e.RowIndex].Cells["Plan"].Value;

            //    if (previousDate.Date != currentDate.Date)
            //    {
            //        e.Handled = true;

            //        Point topLeft = new Point(e.CellBounds.X, e.CellBounds.Y);
            //        Point topRight = new Point(e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y);
                    
            //        using (Brush b = new SolidBrush(dgvOrdersStatus.DefaultCellStyle.BackColor))
            //        {
            //            e.Graphics.FillRectangle(b, e.CellBounds);
            //            e.Graphics.DrawRectangle(new Pen(dgvOrdersStatus.GridColor), topLeft.X, topLeft.Y, e.CellBounds.Width, e.CellBounds.Height);
            //            e.Graphics.DrawLine(new Pen(Color.Red), topLeft, topRight);
            //            e.PaintContent(e.ClipBounds);
            //        }
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Load(this, new EventArgs());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvOrders.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Istnieją nie wysłane zlecenia. Zamknięcie okna spowoduje utratę danych. Czy mimo to chcesz zamknąć?", "UWAGA", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tb10NC_Leave(object sender, EventArgs e)
        {
            var pcbToShippingDate = dgvTools.CreatePcbToShippingDateDictionary(dgvOrdersStatus);
            var dtModel = MST.MES.DtTools.GetDtModel00(tb10NC.Text, DevTools.devToolsDb);
            if(dtModel != null)
            {
                var pcb12nc = MST.MES.DtTools.GetPcb12NC(dtModel);
                if (pcbToShippingDate.ContainsKey(pcb12nc))
                {
                    lSamePcbInfo.Text = $"W planie istnieje wyrób na tej sameł płycie PCB." + Environment.NewLine +
                                        $"Sprawdź możliwość połączenia zleceń. Planowana wysyłka na" + Environment.NewLine +
                                        string.Join(Environment.NewLine, pcbToShippingDate[pcb12nc]);
                }
                else
                {
                    lSamePcbInfo.Text = "...";
                }
            }
            
        }
    }
}
