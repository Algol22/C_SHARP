using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            INIT();
        }
        private Point firstPoint = new Point();

        public void INIT()
        {
            movObj.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left) { firstPoint = Control.MousePosition; }
            };

            movObj.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);
                    movObj.Location = new Point(movObj.Location.X - res.X, movObj.Location.Y - res.Y);

                    firstPoint = temp;
                }
            };
        }
    }
}