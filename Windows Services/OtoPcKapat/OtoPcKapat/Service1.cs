using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OtoPcKapat
{
    public partial class Service1 : ServiceBase
    {
       Timer tmr = new Timer();
      
        string zaman;
        string now;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            tmr.Elapsed += new ElapsedEventHandler(Tmr_Elapsed);
            tmr.Interval = 60000;
            tmr.Start();
       
        }

        protected override void OnStop()
        {
          
        }

        private void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            now = DateTime.Now.ToShortTimeString().ToString();

            string dosyayolu = @"C:\log\log.txt";
            StreamReader sr1 = new StreamReader(dosyayolu);

            zaman = sr1.ReadLine();

           if (now == zaman)
             {
                 System.Diagnostics.Process.Start("shutdown", "-h");

             }


        }

    }
}
