using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace lastShutdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            const string logType = "System";

            EventLog ev = new EventLog(logType, System.Environment.MachineName);

            
            if (ev.Entries.Count <= 0)
            {
                // No Events in the log
               MessageBox.Show("No Events in the log",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                
                //DateTime date = DateTime.Now;
                DateTime lastShutdown = new DateTime();
                EventLogEntry currentEntry = null;

                for (int i = ev.Entries.Count-1; i > 0 ; i--)
                {
                    currentEntry = ev.Entries[i];
                    
                    if (currentEntry.Source.ToUpper() == "USER32" && currentEntry.EventID == 1074 )
                    {                        
                        lastShutdown = currentEntry.TimeGenerated;
                        break;
                    }

                }
                MessageBox.Show("Last Shutdown : " + lastShutdown,
                    "Notice!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

            }

            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
