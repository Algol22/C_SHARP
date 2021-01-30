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

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = ".txt";
            savefile.Filter = "Test files|*.txt";
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)// если диалог ок,  
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName, true, Encoding.Default))
                {
                    sw.WriteLine(textBox1.Text+ "\r\n" +
                        textBox2.Text + "\r\n" +
                        textBox3.Text + "\r\n" +
                        textBox4.Text + "\r\n" +
                        textBox5.Text + "\r\n" +
                        textBox6.Text + "\r\n" +
                        textBox7.Text + "\r\n" +
                        textBox8.Text + "\r\n" +
                        textBox9.Text + "\r\n" +
                        textBox10.Text + "\r\n");
                    sw.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string[] arStr = File.ReadAllLines(openFile.FileName, Encoding.Default);
                textBox1.Text = arStr[0];
                textBox2.Text = arStr[1];
                textBox3.Text = arStr[2];
                textBox4.Text = arStr[3];
                textBox5.Text = arStr[4];
                textBox6.Text = arStr[5];
                textBox7.Text = arStr[6];
                textBox8.Text = arStr[7];
                textBox9.Text = arStr[8];
                textBox10.Text = arStr[9];
            }
        }
    }
}
