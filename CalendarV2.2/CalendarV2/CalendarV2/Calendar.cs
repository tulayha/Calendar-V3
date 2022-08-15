using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CalendarV2
{
    
    public partial class Calendar : Form
    {
        private EmptyLabel lblEmpty = new EmptyLabel();
        private BtnMonth btnPressed;
        private string path = "Holidays.txt";
        private int index = 0;
        private Dictionary<string, Holiday> lsHolidays = new Dictionary<string, Holiday>();
        private Dictionary<string, List<Holiday>> lsHolidays2 = new Dictionary<string, List<Holiday>>(); //////////
        private Dictionary<string, List<EventHolder>> lsEventHolder = new Dictionary<string,List<EventHolder>>();////////
        #region Initialize form and set up grid
        public Calendar()
        {
            checkFile();
            InitializeComponent();
            SetCalendar();
            setDates();
            this.FormClosing += Calendar_FormClosing;
        }

        private void SetCalendar()
        {
            BtnMonth btnDay = new BtnMonth();
            flPnlGrid.Size = new System.Drawing.Size((btnDay.Size.Width + btnDay.Margin.All * 2) * 7, (btnDay.Size.Height + btnDay.Margin.All * 2) * 6);
            fpPanelDaylbl.Size = new System.Drawing.Size(flPnlGrid.Size.Width, (btnDay.Size.Height + btnDay.Margin.All * 2));
            pnlEvents.Size = new System.Drawing.Size(flPnlGrid.Size.Width,200);
            pnlEvenTop.Size = new System.Drawing.Size(flPnlGrid.Size.Width, 200);
            foreach (Label lbl in fpPanelDaylbl.Controls)
            {
                lbl.Size = btnDay.Size;
            }
            for (int i = 0; i < 6 * 7; i++)
            {
                btnDay = new BtnMonth();
                flPnlGrid.Controls.Add(btnDay);
                btnDay.Click += btnDay_Click;
            }

        }

        #endregion

        #region Update calendar values
        private void setDates(int indexMonth = 0)
        {
            DateTime refDate = DateTime.Now.AddMonths(indexMonth);
            refDate = new DateTime(refDate.Year, refDate.Month, 1);
            int firstDayMonth = (int) refDate.DayOfWeek;
            int startDate = firstDayMonth == 7 ? 0 : -firstDayMonth;
            ttPopup.RemoveAll();
            lblDispMY.Text = refDate.ToString("MMMM yyyy");
            foreach (BtnMonth e in flPnlGrid.Controls)
            {
                e.date = refDate.AddDays(startDate++);
                if (lsEventHolder.ContainsKey(e.date.ToShortDateString()))
                {
                    e.isHoliday = true;
                    string txt = "Holiday!" + Environment.NewLine;
                    List<EventHolder> lsTemp = lsEventHolder[e.date.ToShortDateString()];

                    if (lsTemp.Count == 1)
                    {
                        txt += "Title: " + lsTemp[0].holiday.title;
                        txt += lsTemp[0].holiday.details != "" ? Environment.NewLine + "Details: " + lsTemp[0].holiday.details : "";
                    }
                    else
                    {
                        txt += lsTemp.Count.ToString() + " Holidays" + Environment.NewLine + "Click to view!";
                    }
                   ////////// e.holiday = lsHolidays[e.date.ToShortDateString()];
                    
                    ttPopup.SetToolTip(e, txt);
                }
                e.isCurrentMonth(refDate);
            }
        }

        #endregion

        #region Button Click Handlers
        private void btnDay_Click(object sender, EventArgs e)
        {

            btnPressed =  sender as BtnMonth;

            lblEventsTop.Text = btnPressed.date.ToString("dddd dd"); /////

            pnlEvents.Controls.Clear();

            if (btnPressed.isHoliday)
            {
                foreach (EventHolder item in lsEventHolder[btnPressed.date.ToShortDateString()])
                {
                    item.Click += holder_Click;
                    pnlEvents.Controls.Add(item);
                }
            }
            else
            {
                pnlEvents.Controls.Add(lblEmpty);
            }
           
        }

        void holder_Click(object sender, EventArgs e)
        {
            EventHolder holder = sender as EventHolder;

            EventAdder AdderForm = new EventAdder(btnPressed.date, holder.holiday);
            AdderForm.ShowDialog();
            if (holder.holiday != AdderForm.holiday)
            {
                List<EventHolder> ls = lsEventHolder[btnPressed.date.ToShortDateString()];
                ls.Remove(holder);
                if (AdderForm.holiday == null)
                {
                    pnlEvents.Controls.Remove(holder);
                    //  fix tooltip code, add new funtion
                    ttPopup.SetToolTip(holder, null);   ///////////////00000000000
                }
                else
                {
                    holder.holiday = AdderForm.holiday;
                    ls.Add(holder);
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            setDates(--index);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            setDates(++index);
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            index = 0;
            setDates();
        }

        #endregion

        #region Timer Handler
        private void timerOneSec_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }
        #endregion

        #region File Loader/Saver operations
        private void checkFile()
        {
            if (File.Exists(path))
            {
                string[] tempDataF = File.ReadAllLines(path);
                if (tempDataF != null)
                {

                    foreach (string evnt in tempDataF)
                    {
                        string[] data = evnt.Split('#');
                        string[] events = data[1].Split('%');
                        List<EventHolder> lsHoli = new List<EventHolder>();
                        foreach (string e in events)
                        {
                            string[] details = e.Split('$');
                            lsHoli.Add(new EventHolder(new Holiday(details[0], details[1])));
                        }

                        lsEventHolder.Add(data[0], lsHoli);
                    }
                }
            }
        }

        private void Calendar_FormClosing(object sender, FormClosingEventArgs e)
        {
               File.Delete(path);
               string data;
               foreach (var item in lsEventHolder)
               {
                   data = item.Key + "#";
                   int x = 0;
                   while (x < item.Value.Count)
                   {
                       data += item.Value[x].holiday.title + "$" + item.Value[x].holiday.details;
                       x++;
                       if (x < item.Value.Count)
                       {
                           data += "%";
                       }
                   }
                   File.AppendAllText(path, data + Environment.NewLine);
               }
        }

        #endregion

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            EventAdder AdderForm = new EventAdder(btnPressed.date);
            AdderForm.ShowDialog();
            if (AdderForm.holiday != null)
            {
                List<EventHolder> ls = new List<EventHolder>();
                if (lsEventHolder.ContainsKey(btnPressed.date.ToShortDateString()))
                {
                    ls = lsEventHolder[btnPressed.date.ToShortDateString()];
                    EventHolder holder = ls.First(a => a.holiday.title == AdderForm.holiday.title);
                    ls.RemoveAll(a => a.holiday.title == AdderForm.holiday.title);
                    holder = new EventHolder(AdderForm.holiday);
                    ls.Add(holder);
                    lsEventHolder[btnPressed.date.ToShortDateString()] = ls;
                }
            }
        }
    }
}
