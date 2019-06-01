using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using System.Reflection;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;

namespace Sample {
    public class MyPictureEdit : PictureEdit {
        int MouseWheelZoomIndex { get { return Math.Max(1, this.Properties.ZoomPercent / 10); } }
        private PointF RectStartPoint;
        private RectangleF Rect = new RectangleF();
        private RectangleF[] Rects;
        private Brush brush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
        private Pen pen = new System.Drawing.Pen(Color.FromArgb(0x48, 0x91, 0xDC));
        bool isSpaceLocked = false;
        private float originalPercent = 1;
        double zoomImageX, zoomImageY;

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.Properties.ZoomPercent += Math.Sign(e.Delta) * MouseWheelZoomIndex;
            base.OnMouseWheel(e);
            Refresh();
           if (Rect.Size != null && Rect.Location != null)
                {
                    float currentPercent = this.Properties.ZoomPercent;

                    float relativePercent = currentPercent / originalPercent;

                    float tempWidth = Rect.Size.Width;
                    float tempHeight = Rect.Size.Height;
                    Rect.Size = new SizeF(tempWidth * relativePercent, tempHeight * relativePercent);
                    double zoomFactor = (double)Properties.ZoomPercent / 100;
                    double deltaX = zoomImageX * ViewInfo.Image.Width * zoomFactor;
                    double deltaY = zoomImageY * ViewInfo.Image.Height * zoomFactor;

                    PropertyInfo pr = ViewInfo.GetType().GetProperty("HScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                    int hScrollPosition = (int)pr.GetValue(ViewInfo, null);
                    if (hScrollPosition >= 0)
                        Rect.X = (int)(ViewInfo.PictureRect.X + deltaX - hScrollPosition);
                    else
                        Rect.X = (int)(ViewInfo.PictureStartX + deltaX);


                    pr = ViewInfo.GetType().GetProperty("VScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                    int vScrollPosition = (int)pr.GetValue(ViewInfo, null);
                    if (vScrollPosition >= 0)
                        Rect.Y = (int)(ViewInfo.PictureRect.Y + deltaY - vScrollPosition);
                    else
                        Rect.Y = (int)(ViewInfo.PictureStartY + deltaY);
                    Debug.WriteLine("Begin");
                    Debug.WriteLine(Rect);
                    Debug.WriteLine(deltaX.ToString() + "    " + deltaY.ToString());
                    Debug.WriteLine(zoomImageX.ToString() + "    " + zoomImageY.ToString());
                    Debug.WriteLine(hScrollPosition.ToString() + "    " + vScrollPosition.ToString());
                    Debug.WriteLine("End");
                    Rects = new RectangleF[] { Rect };
                    this.Invalidate();
                    this.originalPercent = currentPercent;
                }
          

            if (!isSpaceLocked)
                this.Cursor = default(Cursor);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!isSpaceLocked || e.Button != MouseButtons.Left || !this.Properties.AllowScrollViaMouseDrag)
            {
                IsMouseDown(e);
                return;
            }
            base.OnMouseDown(e);


        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!isSpaceLocked)
                this.Cursor = default(Cursor);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            isSpaceLocked = e.KeyCode == Keys.Space;
            if (!isSpaceLocked)
                this.Cursor = default(Cursor);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            isSpaceLocked = !(e.KeyCode == Keys.Space);
            if (!isSpaceLocked)
                this.Cursor = default(Cursor);
        }

        #region Draw

        // Start Rectangle
        //
        public void IsMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            // Determine the initial rectangle coordinates...
            RectStartPoint = e.Location;
            double deltaX = RectStartPoint.X - ViewInfo.PictureStartX;
            double deltaY = RectStartPoint.Y - ViewInfo.PictureStartY;
            double zoomFactor =  (double)Properties.ZoomPercent / 100;
            zoomImageX = deltaX / (ViewInfo.Image.Width * zoomFactor);
            zoomImageY = deltaY / (ViewInfo.Image.Height * zoomFactor);
           // new Rectangle(r.X + x, r.Y + y, (int)(vi.Image.Width * vi.Item.ZoomFactor), (int)(vi.Image.Height * vi.Item.ZoomFactor)
            Invalidate();
            if (!isSpaceLocked)
                this.Cursor = default(Cursor);
        }
        public void IsMouseDown(System.Windows.Forms.MouseEventArgs e)
        {

            // Determine the initial rectangle coordinates...
            RectStartPoint = e.Location;
            double deltaX, deltaY;
            PropertyInfo pr = ViewInfo.GetType().GetProperty("HScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
            int hScrollPosition = (int)pr.GetValue(ViewInfo, null);
            if (hScrollPosition >= 0)
                deltaX = (int)(RectStartPoint.X - ViewInfo.PictureRect.X + hScrollPosition);
            else
                deltaX = RectStartPoint.X - ViewInfo.PictureStartX;

            pr = ViewInfo.GetType().GetProperty("VScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
            int vScrollPosition = (int)pr.GetValue(ViewInfo, null);
            if (vScrollPosition >= 0)
                deltaY = (int)(RectStartPoint.Y - ViewInfo.PictureRect.Y + vScrollPosition);
            else
                deltaY = RectStartPoint.Y - ViewInfo.PictureStartY;
            double zoomFactor = (double)Properties.ZoomPercent / 100;
            zoomImageX = deltaX / (ViewInfo.Image.Width * zoomFactor);
            zoomImageY = deltaY / (ViewInfo.Image.Height * zoomFactor);
            Invalidate();
            if (!isSpaceLocked)
                this.Cursor = default(Cursor);
        }

        // Draw Rectangle
        //
        public void IsMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left | isSpaceLocked)
                return;
            PointF tempEndPoint = e.Location;
            Rect.Location = new PointF(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new SizeF(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            Rects = new RectangleF[] { Rect };
            originalPercent = this.Properties.ZoomPercent;
            this.Invalidate();
            this.Cursor = default(Cursor);

            Debug.WriteLine(ViewInfo.PictureRect.ToString());
            Debug.WriteLine(ViewInfo.PictureStartX.ToString());
            Debug.WriteLine(ViewInfo.PictureStartY.ToString());
            Debug.WriteLine(Rect.ToString());
        }

        // Draw Area
        //
        public void ToPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (isSpaceLocked)
                return;
            // Draw the rectangle...
            if (this.Image != null)
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                    e.Graphics.DrawRectangles(pen, Rects);
        }

        public void ToPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (isSpaceLocked)
                return;
            // Draw the rectangle...
            if (this.Image != null)
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                    e.Graphics.DrawRectangles(pen, Rects);
        }

        public void IsMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isSpaceLocked)
                return;
            if (e.Button == MouseButtons.Right)
                if (Rect.Contains(e.Location))
                    Debug.WriteLine("Right click");
        }
        #endregion
    }

}
