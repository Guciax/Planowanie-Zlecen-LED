using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planowanie_Zlecen_LED.Forms
{
    public partial class SummaryForm : Form
    {
        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            foreach (var orderEntry in ordersChanges.changesInPlannedShipping)
            {
                richTextBox1.AppendText($"Zlecenie nr:{orderEntry.Key}"
                                        + Environment.NewLine
                                        + $"Zmieniona data wysyłki na: {orderEntry.Value.ToShortDateString()}"
                                        + Environment.NewLine);

                if (ordersChanges.changesInQty.ContainsKey(orderEntry.Key))
                {
                    richTextBox1.AppendText($"Zmieniona ilość na: {ordersChanges.changesInQty[orderEntry.Key]}szt."
                                            + Environment.NewLine);
                    ordersChanges.changesInQty.Remove(orderEntry.Key);
                }

                richTextBox1.AppendText(Environment.NewLine);
            }

            foreach (var orderEntry in ordersChanges.changesInQty)
            {
                richTextBox1.AppendText($"Zlecenie nr:{orderEntry.Key}"
                                        + Environment.NewLine
                                        + $"Zmieniona ilość na: {orderEntry.Value}szt."
                                        + Environment.NewLine);
                richTextBox1.AppendText(Environment.NewLine);

            }
        }
    }
}
