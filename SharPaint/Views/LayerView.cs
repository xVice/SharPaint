using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharPaint.Views
{
    public partial class LayerView : UserControl
    {
        public Dictionary<Point, Color> pixels;

        public Graphics gfx;
        public Bitmap bmp;

        public bool IsActiveLayer;

        public MainForm mainForm;

        public LayerView(MainForm mainForm)
        {
            this.mainForm = mainForm;
            bmp = new Bitmap(mainForm.GetPaintPanel().Width, mainForm.GetPaintPanel().Height);
            gfx = Graphics.FromImage(bmp);
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //gfx = panel1.CreateGraphics();
            InitializeComponent();
        }

        public void UpdateLayerPic()
        {
            pictureBox1.Image = bmp;
        }

        public void UpdateLayerPic(Bitmap bmp)
        {
            pictureBox1.Image = bmp;
        }

        private void LayerView_Load(object sender, EventArgs e)
        {
            pixels = new Dictionary<Point, Color>();
            //LayerManager.AddLayerview(this);
        }

        public void AddPixel(Point point, Color color)
        {
            pixels.Add(point, color);
        }

        private void airButton1_Click(object sender, EventArgs e)
        {
            LayerManager.DeleteLayer(this);
            mainForm.UpdateLayerViews();
            //mainForm.DrawLayer(gfx);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LayerManager.SetActiveLayer(this);
            mainForm.SetActiveLayer(this);
        }
    }
}
