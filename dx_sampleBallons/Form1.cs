using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.ViewInfo;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace dxExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureEdit1.MouseDown += pictureEdit1_MouseDown;
            pictureEdit1.MouseUp += pictureEdit1_MouseUp;
            pictureEdit1.MouseMove += pictureEdit1_MouseMove;
            pictureEdit1.Paint += pictureEdit1_Paint;
            pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            pictureEdit1.Properties.ShowScrollBars = true;
            pictureEdit1.Properties.AllowScrollViaMouseDrag = false;
            pictureEdit1.ZoomPercentChanged += pictureEdit1_ZoomPercentChanged;
            pictureEdit1.HScrollBar.ValueChanged += ScrollBar_ValueChanged;
            pictureEdit1.VScrollBar.ValueChanged += ScrollBar_ValueChanged;

            sourceImage = Image.FromFile(path + @"\1.jpg");
            pictureEdit1.EditValue = sourceImage;

            comboBoxEdit1.Properties.Items.AddRange(new PictureSizeMode[] {PictureSizeMode.Clip,PictureSizeMode.Squeeze, PictureSizeMode.Stretch, PictureSizeMode.StretchHorizontal,PictureSizeMode.StretchVertical,PictureSizeMode.Zoom});
            comboBoxEdit1.EditValueChanged+= comboBoxEdit1_EditValueChanged;
            comboBoxEdit1.SelectedIndex = 0;
        }

   
        Image sourceImage;
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        Point mouseDownPoint = Point.Empty;
        Rectangle lasso = Rectangle.Empty;
        bool ZoomPercentChanged;


        void pictureEdit1_ZoomPercentChanged(object sender, EventArgs e)
        {
            ZoomPercentChanged = true;
            ResetLasso();
        }

        void ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            ResetLasso();
        }

        private void ResetLasso()
        {
            lasso = Rectangle.Empty;
        }

        void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit edit = sender as ComboBoxEdit;
            pictureEdit1.Properties.SizeMode = (PictureSizeMode)edit.EditValue;
            ZoomPercentChanged = false;
        }

        bool CheckBounds(int x, int y)
        {
            return x >= 0 && x < pictureEdit1.Image.Width && y >= 0 && y < pictureEdit1.Image.Height;
        }

        void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            mouseDownPoint = e.Location;
            ResetLasso();
            PictureEdit edit = sender as PictureEdit;
            edit.Refresh();
        }

        void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint.IsEmpty) return;
            if (e.Button != MouseButtons.Left) return;
            Point mouseMovePoint = e.Location;
            if (CheckBounds(mouseMovePoint.X, mouseMovePoint.Y))
            {
                lasso = new Rectangle(mouseDownPoint.X, mouseDownPoint.Y, mouseMovePoint.X - mouseDownPoint.X, mouseMovePoint.Y - mouseDownPoint.Y);
                PictureEdit edit = sender as PictureEdit;
                edit.Refresh();
            }
        }

        void pictureEdit1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Red,3), lasso);
        }

        private Point ConvertPoint(PictureEdit edit, Point p)
        {
            Point result = Point.Empty;
            if (edit.Image != null)
            {
                PictureEditViewInfo vi = edit.GetViewInfo() as PictureEditViewInfo;
                double zoomX = 1.0, zoomY = 1.0;

                if (ZoomPercentChanged && edit.Properties.SizeMode != PictureSizeMode.Squeeze)
                    zoomX = zoomY = Convert.ToDouble(edit.Properties.ZoomPercent) / 100;
                else
                    switch (edit.Properties.SizeMode)
                    {
                        case PictureSizeMode.Zoom:
                        case PictureSizeMode.Squeeze:
                            zoomX = zoomY = Convert.ToDouble(vi.PictureScreenBounds.Width / edit.Image.Size.Width);
                            break;
                        case PictureSizeMode.Stretch:
                            zoomX = Convert.ToDouble(vi.PictureScreenBounds.Width / edit.Image.Size.Width);
                            zoomY = Convert.ToDouble(vi.PictureScreenBounds.Height / edit.Image.Size.Height);
                            break;
                        case PictureSizeMode.StretchHorizontal:
                            zoomX = Convert.ToDouble(vi.PictureScreenBounds.Width / edit.Image.Size.Width);
                            break;
                        case PictureSizeMode.StretchVertical:
                            zoomY = zoomY = Convert.ToDouble(vi.PictureScreenBounds.Height / edit.Image.Size.Height);
                            break;
                    }

                int scrollX = (edit.Controls[1] as DevExpress.XtraEditors.HScrollBar).Value;
                int scrollY = (edit.Controls[0] as DevExpress.XtraEditors.VScrollBar).Value;

                int x, y;
                if (edit.Controls[1].Visible == true)
                    x = (int)((p.X + scrollX - vi.PictureScreenBounds.X) / zoomX);
                else
                    x = (int)((p.X - vi.PictureScreenBounds.X) / zoomX);
                if (edit.Controls[0].Visible == true)
                    y = (int)((p.Y + scrollY - vi.PictureScreenBounds.Y) / zoomY);
                else
                    y = (int)((p.Y - vi.PictureScreenBounds.Y) / zoomY);
                result = new Point(x, y);
            }
            return result;
        }

        void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            PictureEdit edit = sender as PictureEdit;
            Point start = ConvertPoint(edit,lasso.Location);
            Point end = ConvertPoint(edit,new Point(lasso.Right,lasso.Bottom));
            Rectangle selectedImageRectangle = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            if (selectedImageRectangle.Size.Width <= 0 || selectedImageRectangle.Size.Height <= 0) return;
            Bitmap selectedImage = new Bitmap(sourceImage);
            pictureEdit2.EditValue = selectedImage.Clone(selectedImageRectangle, selectedImage.PixelFormat);
        }
    }
}
