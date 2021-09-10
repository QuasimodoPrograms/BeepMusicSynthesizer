using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> GetLinesFromTextBox(TextBox textBox)
        {
            List<string> lines = new List<string>();

            for (int line = 0; line < textBox.LineCount; line++)
                lines.Add(textBox.GetLineText(line));

            return lines;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> lines = GetLinesFromTextBox(tb);

            foreach(string line in lines)
            {
                if (line.ToLower().Contains("bsf"))//beep sequence fast processing
                {
                    int times = int.Parse(line[3].ToString());
                    string sequence = line.Substring(4);
                    PlaySequence(sequence, times, true);
                }
                else if (line.ToLower().Contains("bs"))//beep sequence processing
                {
                    int times = int.Parse(line[2].ToString());
                    string sequence = line.Substring(3);
                    PlaySequence(sequence, times, false);
                }
                else if(line.Contains("b") || line.Contains("B"))//beep processing
                {
                    string frequency = Regex.Match(line, @"\d+").Value;
                    if(frequency =="")//default beep
                    {
                        Console.Beep();
                    }
                    else
                    {
                        string frequencyANDduration = Regex.Match(line, @"\d+,\s*\d+").Value;
                        if(frequencyANDduration=="")//beep with frequency
                        {
                            if(int.Parse(frequency) <37) Console.Beep(37, 1000);
                            else Console.Beep(int.Parse(frequency), 1000);
                        }
                        else//beep with frequency and duration
                        {
                            string durationString = frequencyANDduration.Substring(frequencyANDduration.IndexOf(',') + 1);
                            int duration = int.Parse(durationString);
                            if (int.Parse(frequency) < 37)
                                Console.Beep(37, duration);
                            else
                                Console.Beep(int.Parse(frequency), duration);
                        }
                    }
                }//sleep processing
                else if(line.Contains("s") || line.Contains("S"))
                {
                    string numberString = Regex.Match(line, @"\d+").Value;
                    if(numberString != "")
                    {
                        Thread.Sleep(int.Parse(numberString));
                    }
                    else Thread.Sleep(1000);
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb.Text += Environment.NewLine + "b";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tb.Text += Environment.NewLine + string.Format( "b{0}", 900);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            tb.Text += Environment.NewLine + string.Format("b{0},{1}", 900, 150);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(150, 850), rnd.Next(50, 550));

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tb.Text += Environment.NewLine + "s";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            tb.Text += Environment.NewLine + string.Format("s{0}", 500);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 750));
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(200, 850), rnd.Next(100, 550));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 700));
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(200, 800), rnd.Next(100, 550));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 700));
            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(200, 800), rnd.Next(100, 550));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 700));
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(200, 800), rnd.Next(100, 600));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 700));

            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(200, 800), rnd.Next(100, 600));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 700));

            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(200, 800), rnd.Next(100, 600));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 700));
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(300, 800), rnd.Next(100, 700));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 600));

            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(300, 800), rnd.Next(100, 700));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 600));

            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(300, 800), rnd.Next(100, 700));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 600));

            tb.Text += Environment.NewLine + string.Format("b{0},{1}", rnd.Next(300, 800), rnd.Next(100, 700));
            tb.Text += Environment.NewLine + string.Format("s{0}", rnd.Next(50, 600));
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            tb.Clear();
        }

        void PlaySequence (string sounds, int times, bool fast)
        {
            if (times <= 0) return;

            var numbers = sounds.Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Random rnd = new Random();

            for (int i =0; i<numbers.Length; i++)
            {
                if (numbers[i] == 0)
                    Thread.Sleep(100);
                else
                {
                    if(fast==true)
                        Console.Beep(numbers[i] + (rnd.Next(10,20)), rnd.Next(140, 180));
                    else Console.Beep(numbers[i], rnd.Next(220, 250));
                    Thread.Sleep(rnd.Next(260, 290));
                }
            }
            times--;
            PlaySequence(sounds, times, fast);
        }

    }
}