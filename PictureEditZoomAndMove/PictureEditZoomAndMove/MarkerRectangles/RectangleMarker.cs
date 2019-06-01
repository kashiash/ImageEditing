using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PictureEditZoomAndMove.MarkerRectangles
{
    public class RectangleMarker : IDisposable
    {
        private bool IsActive = false;
        private PictureEdit mainPictureEdit;
        private PictureEditViewInfo viewInfo;
        private Rectangle drawingRectangle;
        public Rectangle DrawingRectangle { get { return drawingRectangle; } }

        #region Mouse actions
        private bool isMouseClicked = false;
        private bool mouseMove = false;
        #endregion

        private int oldX;
        private int oldY;
        private int sizeNodeRect = 10;

        private RectangleResizePoints nodeSelected = RectangleResizePoints.None;

        private const int defaultRectangleHeight = 100;
        private const int defaultRectangleWidth = 100;
        private const float rectangleBorderTickness = 5;
        private Color rectangleBorderColor = Color.Red;

        private RectangleF defaultRectangle;
        private PointF imageCenter;
        private double defaultZoomPercent;

        public bool Hidden { get; private set; }
        public bool Editable { get; private set; }

        private Point insertPoint = new Point(0, 0);

        public RectangleMarker(PictureEdit pictureEditForDraw, Rectangle rectangle, bool editable = true)
        {
            mainPictureEdit = pictureEditForDraw;
            viewInfo = mainPictureEdit.GetViewInfo() as PictureEditViewInfo;

            GetImageCenter();

            defaultZoomPercent = pictureEditForDraw.Properties.ZoomPercent;

            drawingRectangle = new Rectangle(
                rectangle.X,
                rectangle.Y,
                (int)(rectangle.Width * pictureEditForDraw.Properties.ZoomPercent / defaultZoomPercent),
                (int)(rectangle.Height * pictureEditForDraw.Properties.ZoomPercent / defaultZoomPercent));

            insertPoint = mainPictureEdit.ViewportToImage(rectangle.Location);

            defaultRectangle = new RectangleF(
                (float)(insertPoint.X),
                (float)(insertPoint.Y),
                (float)(drawingRectangle.Width ),
                (float)(drawingRectangle.Height));

            isMouseClicked = false;
            Editable = editable;
            InitEvents();
        }

        private void GetImageCenter()
        {
            imageCenter = new PointF(
                mainPictureEdit.TopLevelControl.Location.X + viewInfo.PictureScreenBounds.X + viewInfo.PictureSourceBounds.X + viewInfo.PictureScreenBounds.Width / 2,
                mainPictureEdit.TopLevelControl.Location.Y + viewInfo.PictureScreenBounds.Y + viewInfo.PictureSourceBounds.Y + viewInfo.PictureScreenBounds.Height / 2);
        }

        private void InitEvents()
        {
            if (Editable)
            {
                mainPictureEdit.MouseDown += new MouseEventHandler(mPictureEdit_MouseDown);
                mainPictureEdit.MouseUp   += new MouseEventHandler(mPictureEdit_MouseUp);
                mainPictureEdit.MouseMove += new MouseEventHandler(mPictureEdit_MouseMove);
            }
            mainPictureEdit.PaintEx += MainPictureEdit_PaintEx;
        }

        private void MainPictureEdit_PaintEx(object sender, DevExpress.XtraGrid.PaintExEventArgs e)
        {
            double actualZoomFactor = GetActualZoomFactor(sender as PictureEdit);
            if (actualZoomFactor == -1) return;

            double multiplier = actualZoomFactor;

            if (insertPoint.X == 0 && insertPoint.Y == 0) return;


            drawingRectangle.Width = Convert.ToInt32(defaultRectangle.Width * multiplier);
            drawingRectangle.Height = Convert.ToInt32(defaultRectangle.Height * multiplier);

            Point viewportPoint = mainPictureEdit.ImageToViewport(new Point(Convert.ToInt32(defaultRectangle.Location.X), Convert.ToInt32(defaultRectangle.Location.Y)));
            drawingRectangle.Location = viewportPoint;

            try
            {
                if (!Hidden)
                    DrawEx(e.Cache);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.ToString());
            }
        }

        private void DrawEx(GraphicsCache cache)
        {
            cache.DrawRectangle(new Pen(rectangleBorderColor, rectangleBorderTickness), drawingRectangle);

            foreach (RectangleResizePoints point in Enum.GetValues(typeof(RectangleResizePoints)))
                cache.DrawRectangle(new Pen(rectangleBorderColor), GetRectangle(point));
        }
        protected double GetActualZoomFactor(PictureEdit Owner)
        {
            PictureEditViewInfo viewInfo = Owner.GetViewInfo() as PictureEditViewInfo;
            if (Owner.Image != null && viewInfo.PictureSourceBounds.Width > 0)
            {
                return viewInfo.PictureScreenBounds.Width / viewInfo.PictureSourceBounds.Width;
            }
            return -1;
        }

        private void UpdateDefaultRectangle(int dX,int dY)
        {
            float multiplier = (float) (100/mainPictureEdit.Properties.ZoomPercent);

            float fDX = (float)dX;
            float fDY = (float)dY;

            defaultRectangle.X += dX * multiplier;
            defaultRectangle.Y += dY * multiplier;

            defaultRectangle.Height = drawingRectangle.Height * multiplier;
            defaultRectangle.Width = drawingRectangle.Width * multiplier;
        }

        private void mPictureEdit_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseClicked = true;

            nodeSelected = RectangleResizePoints.None;
            nodeSelected = GetNodeSelectable(e.Location);

            if (drawingRectangle.Contains(new Point(e.X, e.Y)))
            {
                mouseMove = true;
            }
            oldX = e.X;
            oldY = e.Y;

            
            if(nodeSelected!= RectangleResizePoints.None || mouseMove)
            {
                IsActive = true;
            }
        }

        private void mPictureEdit_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseClicked = false;
            mouseMove = false;
            IsActive = false;
            //mainPictureEdit.Refresh();
        }

        private void mPictureEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseClicked == false)
            {
                GetCursor(GetNodeSelectable(e.Location));
                return;
            }
            if (!IsActive) return;
            int dX = 0;
            int dY = 0;
            Rectangle backupRectangle = drawingRectangle;

            switch (nodeSelected)
            {
                case RectangleResizePoints.LeftUp:
                    dX += e.X - oldX;
                    drawingRectangle.Width -= dX;
                    dY += e.Y - oldY;
                    drawingRectangle.Height -= dY;
                    break;
                case RectangleResizePoints.LeftMiddle:
                    dX += e.X - oldX;
                    drawingRectangle.Width -= dX;
                    break;
                case RectangleResizePoints.LeftBottom:
                    dX += e.X - oldX;
                    drawingRectangle.Width -= e.X - oldX;
                    drawingRectangle.Height += e.Y - oldY;
                    break;
                case RectangleResizePoints.BottomMiddle:
                    drawingRectangle.Height += e.Y - oldY;
                    break;
                case RectangleResizePoints.RightUp:
                    drawingRectangle.Width += e.X - oldX;
                    dY += e.Y - oldY;
                    drawingRectangle.Height -= e.Y - oldY;
                    break;
                case RectangleResizePoints.RightBottom:
                    drawingRectangle.Width += e.X - oldX;
                    drawingRectangle.Height += e.Y - oldY;
                    break;
                case RectangleResizePoints.RightMiddle:
                    drawingRectangle.Width += e.X - oldX;
                    break;
                case RectangleResizePoints.UpMiddle:
                    dY += e.Y - oldY;
                    drawingRectangle.Height -= e.Y - oldY;
                    break;

                default:
                    if (mouseMove)
                    {
                        dX += e.X - oldX;
                        dY += e.Y - oldY;
                    }
                    break;
            }

            // no change
            if (drawingRectangle.Width < 5 || drawingRectangle.Height < 5)
            {
                drawingRectangle = backupRectangle;
            }
            else
            {
                // have to change the default one too, taking into consideration the zoom level
                UpdateDefaultRectangle(dX, dY);
            }
            oldX = e.X;
            oldY = e.Y;

            TestIfRectangleInsidePictureEditArea();
            Hidden = DetectIsRectangleOutsideAllowedArea();
            Rectangle invadidateRect = new Rectangle(drawingRectangle.Location.X - 40, drawingRectangle.Location.Y - 40, drawingRectangle.Width + 80, drawingRectangle.Height + 80);

            if (Math.Abs(lastPoint.X - e.Location.X) > 40 || Math.Abs(lastPoint.Y - e.Location.Y) > 40)
            {
                mainPictureEdit.Invalidate();
            }
            else
            {
                mainPictureEdit.Invalidate(invadidateRect);
            }
            lastPoint = e.Location;
        }

        Point lastPoint;

        /// <summary>
        /// This code ensures the rectangle does not get out of the main picture edit area
        /// </summary>
        private void TestIfRectangleInsidePictureEditArea()
        {

            if (drawingRectangle.X < 0)
                drawingRectangle.X = 0;
            if (drawingRectangle.Y < 0)
                drawingRectangle.Y = 0;
            if (drawingRectangle.Width <= 0)
                drawingRectangle.Width = 1;
            if (drawingRectangle.Height <= 0)
                drawingRectangle.Height = 1;

            if (drawingRectangle.X + drawingRectangle.Width > mainPictureEdit.Width)
            {
                drawingRectangle.Width = mainPictureEdit.Width - drawingRectangle.X - 1; // -1 to be still show 
                isMouseClicked = false;
            }
            if (drawingRectangle.Y + drawingRectangle.Height > mainPictureEdit.Height)
            {
                drawingRectangle.Height = mainPictureEdit.Height - drawingRectangle.Y - 1;// -1 to be still show 
                isMouseClicked = false;
            }
        }

        private bool DetectIsRectangleOutsideAllowedArea()
        {
            Rectangle imageArea = GetImageArea();

            return !(imageArea.Contains(drawingRectangle) || imageArea.IntersectsWith(drawingRectangle));
        }

        private Rectangle GetImageArea()
        {
            Rectangle imageArea = new Rectangle(
                Convert.ToInt32(mainPictureEdit.TopLevelControl.Location.X + viewInfo.PictureScreenBounds.X),
                Convert.ToInt32(mainPictureEdit.TopLevelControl.Location.Y + viewInfo.PictureScreenBounds.Y),
                Convert.ToInt32(viewInfo.PictureScreenBounds.Width),
                Convert.ToInt32(viewInfo.PictureScreenBounds.Height));

            return imageArea;
        }

        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);
        }

        private Rectangle GetRectangle(RectangleResizePoints resizePoint)
        {
            switch (resizePoint)
            {
                case RectangleResizePoints.LeftUp:
                    return CreateRectSizableNode(drawingRectangle.X, drawingRectangle.Y);

                case RectangleResizePoints.LeftMiddle:
                    return CreateRectSizableNode(drawingRectangle.X, drawingRectangle.Y + +drawingRectangle.Height / 2);

                case RectangleResizePoints.LeftBottom:
                    return CreateRectSizableNode(drawingRectangle.X, drawingRectangle.Y + drawingRectangle.Height);

                case RectangleResizePoints.BottomMiddle:
                    return CreateRectSizableNode(drawingRectangle.X + drawingRectangle.Width / 2, drawingRectangle.Y + drawingRectangle.Height);

                case RectangleResizePoints.RightUp:
                    return CreateRectSizableNode(drawingRectangle.X + drawingRectangle.Width, drawingRectangle.Y);

                case RectangleResizePoints.RightBottom:
                    return CreateRectSizableNode(drawingRectangle.X + drawingRectangle.Width, drawingRectangle.Y + drawingRectangle.Height);

                case RectangleResizePoints.RightMiddle:
                    return CreateRectSizableNode(drawingRectangle.X + drawingRectangle.Width, drawingRectangle.Y + drawingRectangle.Height / 2);

                case RectangleResizePoints.UpMiddle:
                    return CreateRectSizableNode(drawingRectangle.X + drawingRectangle.Width / 2, drawingRectangle.Y);
                default:
                    return new Rectangle();
            }
        }

        private RectangleResizePoints GetNodeSelectable(Point point)
        {
            foreach (RectangleResizePoints resizePoint in Enum.GetValues(typeof(RectangleResizePoints)))
                if (GetRectangle(resizePoint).Contains(point))
                    return resizePoint;

            return RectangleResizePoints.None;
        }


        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="resizePoint"></param>
        /// <returns></returns>
        private  void GetCursor(RectangleResizePoints resizePoint)
        {
            switch (resizePoint)
            {
                case RectangleResizePoints.LeftUp:
                    Cursor.Current= Cursors.SizeNWSE;
                    break;

                case RectangleResizePoints.LeftMiddle:
                    Cursor.Current = Cursors.SizeWE;
                    break;
                case RectangleResizePoints.LeftBottom:
                    Cursor.Current = Cursors.SizeNESW;
                    break;
                case RectangleResizePoints.BottomMiddle:
                    Cursor.Current = Cursors.SizeNS;
                    break;
                case RectangleResizePoints.RightUp:
                    Cursor.Current = Cursors.SizeNESW;
                    break;
                case RectangleResizePoints.RightBottom:
                    Cursor.Current = Cursors.SizeNWSE;
                    break;
                case RectangleResizePoints.RightMiddle:
                    Cursor.Current = Cursors.SizeWE;
                    break;
                case RectangleResizePoints.UpMiddle:
                    Cursor.Current = Cursors.SizeNS;
                    break;
                default: break;

            }
        }

        public void Dispose()
        {
            if (Editable)
            {
                mainPictureEdit.MouseDown -= new MouseEventHandler(mPictureEdit_MouseDown);
                mainPictureEdit.MouseUp -= new MouseEventHandler(mPictureEdit_MouseUp);
                mainPictureEdit.MouseMove -= new MouseEventHandler(mPictureEdit_MouseMove);
            }
            mainPictureEdit.PaintEx -= MainPictureEdit_PaintEx;

            mainPictureEdit = null;
            viewInfo = null;
        }
    }
}
