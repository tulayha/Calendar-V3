using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarV2
{
    public partial class EventAdder : Form
    {
        public Holiday holiday;
        public bool delete;
        public EventAdder(DateTime refDate, Holiday holi = null )
        {
            InitializeComponent();
            lblDate.Text += refDate.ToLongDateString();
            holiday = holi;
            if (holiday != null)
            {
                btnAdd.Text = "Update";
                tbTitle.Text = holiday.title;
                tbDetails.Text = holiday.details;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text.Equals(""))
            {
                MessageBox.Show("Title cannot be empty!","Error");
            }
            else
            {
                holiday = new Holiday(tbTitle.Text, tbDetails.Text);
                this.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Holiday newHoliday = new Holiday(tbTitle.Text, tbDetails.Text);
            if (holiday.isEqual(newHoliday))
            {
                holiday = null;
            }

            this.Close();
        }


    }
}
