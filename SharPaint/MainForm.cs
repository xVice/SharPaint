using Microsoft.VisualBasic;
using SharPaint.Views;
using SharCessing;
using SharCessing.Helpers;

namespace SharPaint
{
    public partial class MainForm : Form
    {
        Pen pen;
        Graphics gfx;
        System.Drawing.Point previousPoint;
        int delay = 10;
        System.Drawing.Color buckCol;
        int tollerance = 120;

        public enum ToolsEnum
        {
            //Tools
            None, BucketTool, CirlceTool, RectangleTool, ColorPickerTool, TextTool, Pen, Canvas, Eraser, MagicTool
        }

        ToolsEnum selectedTool = ToolsEnum.RectangleTool;

        public MainForm()
        {
            InitializeComponent();
            gfx = paintPanel.CreateGraphics();
            pen = new Pen(System.Drawing.Color.Black, 6);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            previousPoint = new System.Drawing.Point(-1, -1);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            selectedTool = ToolsEnum.Pen;
        }

        private void cyberColorPicker1_ColorChanged(System.Drawing.Color color)
        {
            paintPanel.BackColor = color;
        }

        public Panel GetPaintPanel()
        {
            return paintPanel;
        }

        private void paintPanel_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Point cursorPos = paintPanel.PointToClient(Cursor.Position);
            if ((e.Button == MouseButtons.Left && cursorPos.X >= paintPanel.Width - 5 && cursorPos.Y >= paintPanel.Height - 5) ||
                (e.Button == MouseButtons.Right && cursorPos.X <= 5 && cursorPos.Y <= 5))
            {
                paintPanel.Size = new System.Drawing.Size(cursorPos.X, cursorPos.Y);
                gfx = paintPanel.CreateGraphics();
            }
            else if (e.Button == MouseButtons.Left & selectedTool == ToolsEnum.Pen)
            {
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                LayerManager.activeLayer.gfx.DrawLine(pen, previousPoint, e.Location);
                LayerManager.activeLayer.UpdateLayerPic();
                gfx.DrawLine(pen, previousPoint, e.Location);
                //curLayer.UpdateLayerPic();
                //curLayer.AddPixel(e.Location, curLayer.gfx)
                previousPoint = e.Location;
                System.Threading.Thread.Sleep(delay);
            }
        }

        private void hopeForm1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Point cursorPos = this.PointToClient(Cursor.Position);
            if ((e.Button == MouseButtons.Left && cursorPos.X >= this.Width - 5 && cursorPos.Y >= this.Height - 5) ||
                (e.Button == MouseButtons.Right && cursorPos.X <= 5 && cursorPos.Y <= 5))
            {
                this.Size = new System.Drawing.Size(cursorPos.X, cursorPos.Y);
            }
        }

        private void cyberColorPicker1_ColorChanged_1(System.Drawing.Color color)
        {
            switch (selectedTool)
            {
                case ToolsEnum.BucketTool:
                    {
                        buckCol = color;
                        break;
                    }
                case ToolsEnum.Pen:
                    {
                        pen.Color = color;
                        break;
                    }
                case ToolsEnum.Canvas:
                    {
                        paintPanel.BackColor = color;
                        break;
                    }
            }
        }

        private void hopeForm1_Click(object sender, EventArgs e)
        {

        }

        private void paintPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                previousPoint = e.Location;
            }
        }

        private Bitmap SaveControlImage(Control ctr)
        {
            try
            {
                Bitmap bmp = new Bitmap(ctr.Width, ctr.Height);
                var gg = Graphics.FromImage(bmp);
                var rect = ctr.RectangleToScreen(ctr.ClientRectangle);
                gg.CopyFromScreen(rect.Location, System.Drawing.Point.Empty, ctr.Size);

                return bmp;
            }
            catch (Exception)
            {
                throw new FileFormatException();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            buckCol = cyberColorPicker1.SelectedColor;
            selectedTool = ToolsEnum.BucketTool;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LayerManager.AddLayerview(new LayerView(this));
            UpdateLayerViews();
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            saveDialog.Title = "Save an Image File";
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                // Save the paintPanel's background image to the chosen file directory
                SaveControlImage(paintPanel).Save(saveDialog.FileName);
            }
        }

        private void paintPanel_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                switch (selectedTool)
                {
                    case ToolsEnum.BucketTool:
                        {
                            /*
                            Bitmap floodFilledArea = SharCessing.Filling.QFloodFillRaw(SaveControlImage(paintPanel), new Point(e.X, e.Y), buckCol, tollerance);
                            paintPanel.Invalidate();
                            paintPanel.BackgroundImage = ImageHelpers.MergeMap(new[] { LayerManager.activeLayer.bmp, floodFilledArea });
                            break;
                            */
                            
                            Bitmap img = SharCessing.Filling.QFloodFillRaw(SaveControlImage(paintPanel), new Point(e.X, e.Y), buckCol, tollerance);
                            Bitmap curLayerBmp = LayerManager.activeLayer.bmp;
                            Bitmap merged = ImageHelpers.MergeMap(new[] { curLayerBmp, img });
                            paintPanel.BackgroundImage = merged;
                            LayerManager.activeLayer.bmp = merged;
                            LayerManager.activeLayer.UpdateLayerPic();
                            //LayerManager.activeLayer.gfx.DrawImage(img, new Point(0, 0));
                            //gfx.DrawImage(img, new Point(0, 0));
                            break;
                            
                        }
                    case ToolsEnum.TextTool:
                        {
                            Image img = SaveControlImage(paintPanel);
                            string textin = Interaction.InputBox("Enter your text: ", "Lorem", "");
                            gfx.DrawString(textin, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF(e.X, e.Y));
                            LayerManager.activeLayer.gfx.DrawString(textin, new Font("Arial", 12), new SolidBrush(Color.Black), new PointF(e.X, e.Y));
                            break;
                        }
                    case ToolsEnum.MagicTool:
                        {
                            Bitmap img = SaveControlImage(paintPanel);
                            Bitmap selection = Filling.GetOutline(img, new Point(e.X, e.Y), tollerance);
                            paintPanel.BackgroundImage = ImageHelpers.MergeMap(new[] { img, selection });
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                PrintEx("Tool", ex);
            }
        }

        private void PrintEx(string errortype,Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"{errortype} Error:");
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("------------------------------------");
            Console.ResetColor();
        }

        public void SetActiveLayer(LayerView view)
        {
            paintPanel.Invalidate();
            paintPanel.BackgroundImage = LayerManager.activeLayer.bmp;
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            LayerManager.AddLayerview(new LayerView(this));
            UpdateLayerViews();

        }

        public void UpdateLayerViews()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var view in LayerManager.layerViews)
            {
                flowLayoutPanel1.Controls.Add(view);
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            paintPanel.Invalidate();
            paintPanel.BackgroundImage = LayerManager.GetAllLayersAsImage(paintPanel.Width, paintPanel.Height);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            selectedTool = ToolsEnum.RectangleTool;
        }

        private void materialButton9_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            saveDialog.Title = "Save an Image File";
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                // Save the paintPanel's background image to the chosen file directory
                LayerManager.GetAllLayersAsImage(paintPanel.Width, paintPanel.Height).Save(saveDialog.FileName);
            }
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Point cursorPos = this.PointToClient(Cursor.Position);
            if ((e.Button == MouseButtons.Left && cursorPos.X >= this.Width - 5 && cursorPos.Y >= this.Height - 5) ||
                (e.Button == MouseButtons.Right && cursorPos.X <= 5 && cursorPos.Y <= 5))
            {
                this.Size = new System.Drawing.Size(cursorPos.X, cursorPos.Y);
            }
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            selectedTool = ToolsEnum.TextTool;
        }

        public void SetTol(int tol)
        {
            tollerance = tol;
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            ToolForm toolsForm = new ToolForm(this);
            toolsForm.Show();
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            selectedTool = ToolsEnum.MagicTool;
        }
    }
}