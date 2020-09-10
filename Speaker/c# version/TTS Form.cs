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
using System.Speech.Recognition;


namespace TTS
{
    public partial class Form1 : Form
    {
        public SpeechSynthesizer ss = new SpeechSynthesizer();
        SpeechRecognitionEngine r = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        String data = "Nothing";
        String data2 = "Nothing";
        Thread thread;
        String blurt = "true";
        public Form1()
        {
            InitializeComponent();
            thread = new Thread(Get);
            thread.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "Speaker speak" });
            GrammarBuilder build = new GrammarBuilder();
            build.Append(commands);
            Grammar grammar = new Grammar(build);
            r.LoadGrammarAsync(grammar);
            r.SetInputToDefaultAudioDevice();
            r.SpeechRecognized += r_SpeechRecognitionEngine;
            
            
        }

        private void r_SpeechRecognitionEngine(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "Speaker speak") {
                ss.SpeakAsync(data);
            }
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
            if (comboBox1.Text == "Male")
            {
                ss.SelectVoiceByHints(VoiceGender.Male);
            }
            if (comboBox1.Text == "Female")
            {
                ss.SelectVoiceByHints(VoiceGender.Female);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mode.Text == "Blurt")
            {
                this.blurt = "true";
            }
            if (Mode.Text == "Wait") {
                this.blurt = "false";
                r.RecognizeAsync(RecognizeMode.Multiple);
               

            }
        }
        private void Get()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (this.blurt == "true")
                    {
                        WebRequest request = WebRequest.Create("https://game.thevibezone.com:25560/question");
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
                    else if(this.blurt == "false")
                    {
                        WebRequest request = WebRequest.Create("Webserver");
                        WebResponse response = request.GetResponse();
                        Stream datastream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(datastream);
                        String data1 = reader.ReadToEnd();
                        if (!data2.Equals(data1))
                        {
                            String[] parse = data1.Split('|');
                            data2 = data1;
                            data = (parse[0] + " said " + parse[1]);
                            Console.Beep();
                            
                        }


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
