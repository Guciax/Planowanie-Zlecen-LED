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
    public partial class ChangeDate : Form
    {
        private readonly DateTime minimumDate;
        private readonly DateTime currentDate;
        public DateTime selectedDate;

        public ChangeDate(DateTime minimumDate, DateTime currentDate)
        {
            InitializeComponent();
            this.minimumDate = minimumDate;
            this.currentDate = currentDate;
        }

        private void ChangeDate_Load(object sender, EventArgs e)
        {
            monthCalendar1.MinDate = minimumDate;
            //monthCalendar1.TodayDate = currentDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedDate = monthCalendar1.SelectionRange.Start;
        }
    }
}
