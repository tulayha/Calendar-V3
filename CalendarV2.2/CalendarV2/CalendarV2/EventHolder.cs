using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarV2
{
    public partial class EventHolder : UserControl
    {
        public EventHolder(Holiday holi)
        {
            //
            InitializeComponent();
            holiday = holi;
            this.MouseEnter += EventHolder_MouseEnter;
            this.MouseLeave += EventHolder_MouseLeave;
        }
        public Holiday holiday
        {
            get
            {
                return (new Holiday(lblTitleTxt.Text, lblDetailsTxt.Text));
            }
            set
            {
                lblTitleTxt.Text = value.title;
                lblDetailsTxt.Text = value.details;
            }
        }

        void EventHolder_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Transparent;
        }

        void EventHolder_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.SteelBlue;
        }

       
    }
}
