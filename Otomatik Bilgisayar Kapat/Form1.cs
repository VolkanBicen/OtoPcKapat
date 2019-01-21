using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace Otomatik_Bilgisayar_Kapat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("cmd", "/c \" sc stop OtoPcKapatma \"")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();
       
            p.WaitForExit();


            DateTime dt = new DateTime();

            maskedTextBox1.Text = dt.ToString("HH:mm");


            if (!Directory.Exists(@"c:\log"))
            {
                Directory.CreateDirectory(@"C:\log");
                StreamWriter Dosya = File.CreateText(@"C:\log//log.txt");
                Dosya.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            if (Directory.Exists(@"c:\log"))
            {
               
                TextWriter tw = new StreamWriter(@"C:\log//log.txt");
                tw.Write("");
                tw.WriteLine(maskedTextBox1.Text);
                tw.Close();

                Process pr = new Process();
                pr.StartInfo = new ProcessStartInfo("cmd", "/c \" sc start OtoPcKapatma \"")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                pr.Start();
                pr.WaitForExit();


                Application.Exit();
            }

           


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Process pr = new Process();
            pr.StartInfo = new ProcessStartInfo("cmd", "/c \" sc start OtoPcKapatma \"")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            pr.Start();
            pr.WaitForExit();
            Application.Exit();
        }
    }
}
