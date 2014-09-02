using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace SteamProject.WindowsService
{
    public partial class Service : ServiceBase
    {
        public readonly string SeviceName = "SteamService";

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            File.AppendAllLines(@"C:\Projects\exception.txt", new string[] { "ServiceStart " + DateTime.Now });
        }

        protected override void OnStop()
        {
            File.AppendAllLines(@"C:\Projects\exception.txt", new string[] { "ServiceStop " + DateTime.Now });
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            try
            {
                WriteLog(ServiceName, e.Entry.Message);
            }
            catch (Exception ex)
            {
                WriteLog(ServiceName, ex.Message);
            }
        }

        void WriteLog(string source, string message)
        {
            if (!EventLog.SourceExists(SeviceName))
            {
                EventLog.CreateEventSource(SeviceName, SeviceName);
            }
            eventLog1.Source = SeviceName;
            eventLog1.WriteEntry(message);
        }
    }
}
