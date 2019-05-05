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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OrdersStatus.LoadDataFromSql();
            OrdersStatus.FillOutOrdersStatusGrid(dgvOrdersStatus);
        }

        private void dgvOrdersStatus_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 & (e.ColumnIndex == 4 || e.ColumnIndex == 6) & dgvOrdersStatus.userEnteredData) 
            {
                string orderNo = dgvOrdersStatus.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 4)
                {
                    DataGridViewCell cell = dgvOrdersStatus.Rows[e.RowIndex].Cells[4];
                    DateTime newShipingDate = Convert.ToDateTime(cell.Value);

                    if (!ordersChanges.changesInPlannedShipping.ContainsKey(orderNo))
                    {
                        ordersChanges.changesInPlannedShipping.Add(orderNo, newShipingDate);
                    }
                    else
                    {
                        ordersChanges.changesInPlannedShipping[orderNo] = newShipingDate;
                    }

                    cell.Style.BackColor = Color.Yellow;
                }

                if (e.ColumnIndex == 6)
                {
                    DataGridViewCell cell = dgvOrdersStatus.Rows[e.RowIndex].Cells[6];
                    int newQty = Convert.ToInt32(cell.Value);

                    if (!ordersChanges.changesInQty.ContainsKey(orderNo))
                    {
                        ordersChanges.changesInQty.Add(orderNo, newQty);
                    }
                    else
                    {
                        ordersChanges.changesInQty[orderNo] = newQty;
                    }
                    cell.Style.BackColor = Color.Yellow;
                }

                bSaveAndSendChanges.Visible = true;
            }
        }

        private void dgvOrdersStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
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
                        }
                    }
                }

                dgvOrdersStatus.CurrentCell = null;
            }
        }

        private void bSaveAndSendChanges_Click(object sender, EventArgs e)
        {
            using(SummaryForm sumForm = new SummaryForm())
            {
                if (sumForm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
