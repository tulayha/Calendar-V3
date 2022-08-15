using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarV2
{
    class EmptyLabel : Label
    {
        public EmptyLabel()
        {
            this.AutoSize = true;
            this.Enabled = true;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "lblTitle";
            this.Size = new System.Drawing.Size(64, 24);
            this.Text = "No Holidays to show!";
            this.Dock = DockStyle.Top;
        }
    }
}
