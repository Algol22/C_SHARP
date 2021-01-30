using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        [STAThread]
        public static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new OpenFileDialogForm());
        }


        private Button button1_Click;
        private Form1 openFileDialog1;

        public Form1()
        {
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };

            selectButton = new Button()
            {
                Size = new Size(100, 20),
                Location = new Point(15, 15),
                Text = "Select file"
            };
            selectButton.Click += new EventHandler(selectButton_Click);
            Controls.Add(selectButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Створити пусті файли за допомогою С# формату Прізвище1.txt та Прізвище2.txt.
         
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        Process.Start("notepad.exe", filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
