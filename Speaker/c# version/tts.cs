using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Net;
using System.Linq.Expressions;
using System.IO;
using System.Threading;

namespace TTS
{
    public partial class Form1 : Form
    {
        public SpeechSynthesizer ss = new SpeechSynthesizer();
        String data = "Nothing";
        String data2 = "Nothing";
        Thread thread;
        public Form1()
        {
            thread = new Thread(Get);
            thread.Start();
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ss.Rate = trackBar1.Value;
            ss.Volume = trackBar2.Value;
            ss.SpeakAsync(data);
        }

        
        protected override void OnClosing(CancelEventArgs e)
        {
            ss.SpeakAsyncCancelAll();
            thread.Abort();
            base.OnClosing(e);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Male") {
                ss.SelectVoiceByHints(VoiceGender.Male);
            }
            if (comboBox1.Text == "Female")
            {
                ss.SelectVoiceByHints(VoiceGender.Female);
            }
        }
        private void Get() {
            try
            {
                while (true)
                {
                    Thread.Sleep(500);
                    WebRequest request = WebRequest.Create("Server adress");
                    WebResponse response = request.GetResponse();
                    Stream datastream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(datastream);
                    String data1 = reader.ReadToEnd();
                    if (!data2.Equals(data1))
                    {
                        String[] parse = data1.Split('|');
                        data2 = data1;
                        data = (parse[0] + " said " + parse[1]);
                        ss.SpeakAsync(data);
                    }
                }
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show("ERROR: " + e + " |  check internet connection :)");
            }
        }   
    }
}
