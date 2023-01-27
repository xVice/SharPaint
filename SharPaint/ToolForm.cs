using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharPaint
{
    public partial class ToolForm : Form
    {
        private MainForm mainForm;

        public ToolForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Point cursorPos = this.PointToClient(Cursor.Position);
            if ((e.Button == MouseButtons.Left && cursorPos.X >= this.Width - 5 && cursorPos.Y >= this.Height - 5) ||
                (e.Button == MouseButtons.Right && cursorPos.X <= 5 && cursorPos.Y <= 5))
            {
                this.Size = new System.Drawing.Size(cursorPos.X, cursorPos.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.SetTol(int.Parse(textBox1.Text));
            crownLabel1.Text = $"Tolerance changed to {textBox1.Text}%";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
