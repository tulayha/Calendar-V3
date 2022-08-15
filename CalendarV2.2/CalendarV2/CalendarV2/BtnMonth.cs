using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarV2
{
    public class BtnMonth : Button
    {
        private DateTime _date;
        private bool _isHoliday;
        public BtnMonth()
        {
            this.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(50, 50);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.UseVisualStyleBackColor = false;
        }


        public DateTime date 
        {
            get
            {
                return _date;
            }
            set 
            {
                _date = value;
                this.Text = _date.Day.ToString();
                if (_date.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    this.BackColor = System.Drawing.Color.Blue;
                    
                }
                else { this.BackColor = Parent.BackColor; }
            }
        }

        public void isCurrentMonth(DateTime refDate)
        {
           this.ForeColor = refDate.Month == date.Month? System.Drawing.SystemColors.Control : System.Drawing.SystemColors.ControlDarkDark;
        }

        public bool isHoliday
        {
            set
            {
                if (value)
                {
                    this.FlatAppearance.BorderSize = 2;
                }
                else
                {
                    this.FlatAppearance.BorderSize = 0;
                }
                _isHoliday = value;
            }
            get
            {
                return _isHoliday;
            }
        }
    }
}
