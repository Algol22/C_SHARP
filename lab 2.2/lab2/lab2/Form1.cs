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

/*
 *     1. Створити пусті файли за допомогою С# формату Прізвище1.txt та Прізвище2.txt.
    2. Відкрити файл Прізвище1.txt в операційній системі та записати туди частину відомого тексту без додаткових символів (тільки алфавіт) .
    3. Прочитати файл Прізвище1.txt за допомогою С#.
    4. Зашифрувати дані шляхом використання плаваючого шифру ціни три (зсув букв від 1 до 3, тобто якщо першою буквою була А то буде Б, друга Б то Г, третя В то Е, а четверта кодується як перша, тобто Г в Д і т.д.) (Примітка: Бутьте обережні з символами, які ідуть вкінці алфавіту Щ, Ю, Я, ь).
    5. Записати в файл Прізвище2.txt зашифрований текст.
Завдання 2 на лабораторну роботу 2:
    1. Отримати в одногрупника файл Прізвище2.txt.
    2. Прочитати файл Прізвище2.txt.
    3. Розшифрувати текст.
    4. Записати розшифрований текст в Прізвище3.txt.
 * 
 */

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFile.FileName, Encoding.Default);
            }
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
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = EncryptPhrase(richTextBox1.Text, 1);

        }

        public static string EncryptPhrase(string st, byte key)
        {
            string res = string.Empty;
            if (key < 1 || key > 9) key = 2;
            foreach (char i in st)
                res += (char)(((int)i) + key);
            return res;
        }

        public static string DecryptPhrase(string st, byte key)
        {
            string res = string.Empty;
            if (key < 1 || key > 9) key = 2;
            foreach (char i in st)
                res += (char)(((int)i) - key);
            return res;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = DecryptPhrase(richTextBox1.Text, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var inputText = richTextBox1.Text;
            var password = textBox1.Text;

            richTextBox1.Text = VigenereCipher.Encode(inputText, password);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var inputText = richTextBox1.Text;
            var password = textBox1.Text;

            richTextBox1.Text = VigenereCipher.Decode(inputText, password);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                string strr;
                int alp, digit, splch, i, l;
                alp = digit = splch = i = 0;

                strr = File.ReadAllText(openFile.FileName, Encoding.Default);

                l = strr.Length;
                while (i < l)
                {
                    if ((strr[i] >= 'a' && strr[i] <= 'z') || (strr[i] >= 'A' && strr[i] <= 'Z'))
                    {
                        alp++;
                    }
                    else if (strr[i] >= '0' && strr[i] <= '9')
                    {
                        digit++;
                    }
                    else
                    {
                        splch++;
                    }

                    i++;


                    
                }
                string text = File.ReadAllText(openFile.FileName, Encoding.Default);
                string countedcharacters = "Total number of symbols is " + text.Length.ToString();
                string countedletters = "\n Number of Alphabets in the string is "+ alp;
                string countedsymbols = "\n Number of Special characters in the string is "+ splch;
                string counteddigits = "\n Number of Digits in the string is " + digit;
                richTextBox1.Text = countedcharacters + " " + countedletters + " " + countedsymbols + " " + counteddigits;
            }
        }

        public class VigenereCipher
        {

            public static char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0' };

            public static int N = characters.Length;

            public static string Encode(string input, string keyword)
            {
                input = input.ToUpper();
                keyword = keyword.ToUpper();

                string result = "";

                int keyword_index = 0;

                foreach (char symbol in input)
                {
                    int c = (Array.IndexOf(characters, symbol) +
                        Array.IndexOf(characters, keyword[keyword_index])) % N;

                    result += characters[c];

                    keyword_index++;

                    if ((keyword_index + 1) == keyword.Length)
                        keyword_index = 0;
                }

                return result;
            }
            public static string Decode(string input, string keyword)
            {
                input = input.ToUpper();
                keyword = keyword.ToUpper();

                string result = "";

                int keyword_index = 0;

                foreach (char symbol in input)
                {
                    int p = (Array.IndexOf(characters, symbol) + N -
                        Array.IndexOf(characters, keyword[keyword_index])) % N;

                    result += characters[p];

                    keyword_index++;

                    if ((keyword_index + 1) == keyword.Length)
                        keyword_index = 0;
                }

                return result;
            }




        }
    }
}
