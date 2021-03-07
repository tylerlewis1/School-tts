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
using Newtonsoft.Json.Linq;

namespace TTS
{
    public partial class Form1 : Form
    {
        public SpeechSynthesizer ss = new SpeechSynthesizer();
        SpeechRecognitionEngine r = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        String data = "Nothing";
        String data2 = "Nothing";
        Thread thread;
        String URl = "";
        String code = "null";
        String blurt = "true";
        String[] parse = {"null", "null", "null"};
        public Form1()
        {
            //getting server url
            JObject data = JObject.Parse(File.ReadAllText("./Settings.json"));
            URl = (String)data["Server_URL"];
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
                        WebRequest request = WebRequest.Create(URl);
                        WebResponse response = request.GetResponse();
                        Stream datastream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(datastream);
                        String data1 = reader.ReadToEnd();
                        if (!data2.Equals(data1))
                        {
                            parse = data1.Split('|');
                            data2 = data1;
                            if (code == parse[2]) {
                                data = (parse[0] + " said " + parse[1]);
                                ss.SpeakAsync(data);
                            }
                        }

                    }
                    else if(this.blurt == "false")
                    {
                        WebRequest request = WebRequest.Create(URl);
                        WebResponse response = request.GetResponse();
                        Stream datastream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(datastream);
                        String data1 = reader.ReadToEnd();
                        if (!data2.Equals(data1))
                        {
                            parse = data1.Split('|');
                            data2 = data1;
                            if (code == parse[2])
                            {
                                data = (parse[0] + " said " + parse[1]);
                                Console.Beep();
                            }
                        }


                    }
                }
            }
            catch (WebException e)
            {
                MessageBox.Show("ERROR: " + e + " |  check internet connection :)");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String setcode = this.textBox1.Text;
            code = setcode;
            MessageBox.Show("Your class code was set to: " + code);

        }
    }
}
