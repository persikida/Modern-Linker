using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Processing_Large_Files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mdcOntrolButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mdButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0)
            {
                try
                {                  Split(openFileDialog.FileName);
                    GC.Collect();
                }
                catch (ArgumentException)
                {
                    Split(openFileDialog.FileName);
                    GC.Collect();
                }
            }
        }

        static void Split(string file)
        {
            int FileNumber = 1;
            StreamWriter SW = new StreamWriter(string.Format(Environment.CurrentDirectory + @"\Temp\Splitted{0:d7}.txt", FileNumber));
            using (StreamReader SR = new StreamReader(file))
            {
                while (SR.Peek() >= 0)
                {
                    SW.WriteLine(SR.ReadLine());
                    if (SW.BaseStream.Length > 10485760 && SR.Peek() >= 0)
                    {
                        SW.Close();
                        FileNumber++;
                        SW = new StreamWriter(string.Format(Environment.CurrentDirectory + @"\Temp\Splitted{0:d7}.txt", FileNumber));
                    }
                }
            }
            SW.Close();
        }
        static void Sort()
        {
            foreach (string path in Directory.GetFiles(Environment.CurrentDirectory + @"\Temp\", "Splitted*.txt"))
            {
                string[] Content = File.ReadAllLines(path);
                string[] Garbage = {"@111.com","@222.ru","@333.kz","@444.com","@555.ru"};
                File.WriteAllLines(path.Replace("Splitted", "Sorted"), Content.Where(e => !Garbage.Any(x => e.Contains(x))).ToArray());
                File.Delete(path);
                Content = null;
                GC.Collect();
            }
        }

        private void mdButton2_Click(object sender, EventArgs e)
        {
            Sort();
        }

        static void Merger()
        {
            string[] Paths = Directory.GetFiles(Environment.CurrentDirectory + @"\Temp\", "Sorted*.txt");
            using (var Result = new FileStream(Environment.CurrentDirectory + @"\Result.txt", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                foreach (string Path in Paths)
                {
                    using (var Chunk = File.OpenRead(Path))
                    {
                        Chunk.CopyTo(Result);
                    }
                    File.Delete(Path);
                }
            }
        }

        private void mdButton3_Click(object sender, EventArgs e)
        {
            Merger();
        }

        private void mdForm1_Click(object sender, EventArgs e)
        {

        }
    }
}
