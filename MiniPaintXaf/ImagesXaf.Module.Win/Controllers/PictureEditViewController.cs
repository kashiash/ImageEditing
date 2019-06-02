using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using ImagesXaf.Module.BusinessObjects;
using PictureEditZoomAndMove.MarkerRectangles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesXaf.Module.Win.Controllers
{
    public class PictureEditViewController : ViewController<DetailView>
    {

        private List<RectangleMarker> rectangleMarkers;
        private string environmentPath;
        private const string markerFileName = "Marker.xml";

        Image mainImage = null;
        bool startPaint = false;
        Graphics graphics;
        //nullable int for storing Null value
        int? initX = null;
        int? initY = null;
        PointF ulCorner;
        XafPictureEdit pEdit;
        Osoba currentRec;
        Point mouseDownPoint = Point.Empty;
        Rectangle lasso = Rectangle.Empty;
        bool ZoomPercentChanged;

        public PictureEditViewController()
        {

            TargetViewType = ViewType.DetailView;

            TargetObjectType = typeof(Osoba);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            ((CompositeView)View).ItemsChanged += PictureditorController_ItemsChanged;
            TryInitializePictureItem();




        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ((CompositeView)View).ItemsChanged -= PictureditorController_ItemsChanged;
        }


        private void PictureditorController_ItemsChanged(Object sender, ViewItemsChangedEventArgs e)
        {
            if (e.ChangedType == ViewItemsChangedType.Added && e.Item.Id == "Photo")
            {
                TryInitializePictureItem();
            }


        }

        public void TryInitializePictureItem()
        {
            ImagePropertyEditor imageEditor = View.FindItem("Photo") as ImagePropertyEditor;
            if (imageEditor != null)
            {
                if (imageEditor.Control != null)
                {
                    InitPhotoEditor(imageEditor);
                }
                else
                {
                    imageEditor.ControlCreated += new EventHandler<EventArgs>(imageEditor_ControlCreated);
                }
            }
        }

        private void imageEditor_ControlCreated(object sender, EventArgs e)
        {
            InitPhotoEditor((ImagePropertyEditor)sender);

            currentRec = (Osoba)View.CurrentObject;
        }

        private void InitPhotoEditor(ImagePropertyEditor imageEditor)
        {
            //rectangleMarkers = new List<RectangleMarker>();
            //var ctrl = imageEditor.Control;
            //pEdit = (XafPictureEdit)ctrl;
            //if (pEdit != null)
            //{
            //    pEdit.LoadCompleted += LoadCompleted;
            //    pEdit.MouseClick += PEdit_Click;
            //    //    pEdit.Paint += Paint;
            //    pEdit.Cursor = System.Windows.Forms.Cursors.Default;
            //    //   pEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            //    pEdit.Properties.AllowScrollViaMouseDrag = false;
            //    pEdit.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
            //    pEdit.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
            //    pEdit.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            //    pEdit.Properties.Appearance.Options.UseBackColor = true;
            //    pEdit.Properties.ShowMenu = true;
            //    pEdit.Properties.ShowScrollBars = true;
            //    pEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            //    pEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Never;
            //    pEdit.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            //    pEdit.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.MouseWheel;
            //}

        }

        private void PEdit_Click(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                AddMarker(e);
            }
            //AddMarker(e);
            //AddMarker(e);
            //AddMarker(e);
        }



        private void AddMarker(MouseEventArgs e)
        {
            PictureEditViewInfo viewInfo = pEdit.GetViewInfo() as PictureEditViewInfo;
            if (!viewInfo.PictureScreenBounds.Contains(e.Location)) return;
            var marker = new RectangleMarker(pEdit, new Rectangle(e.X - 50, e.Y, 100, 100));
            rectangleMarkers.Add(marker);
        }


        private void Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            //e.Graphics.DrawEllipse(pen, mouseDownPoint.X - 50, mouseDownPoint.Y - 50, 100, 100);

            //foreach (var opis in currentRec.OpisZdjeciaCollection)
            //{

            // //   e.Graphics.DrawEllipse(pen, opis.XPos - 50, opis.YPos - 50, 100, 100);
            //    var marker = new RectangleMarker(pEdit, new Rectangle(opis.XPos - 50, opis.YPos, 100, 100));
            //    rectangleMarkers.Add(marker);
            //}

        }



        private void Resize(object sender, EventArgs e)
        {
            UpdateGraphics();
        }

        private void ImageChanged(object sender, EventArgs e)
        {

            UpdateGraphics();

        }

        private void UpdateGraphics()
        {
            //graphics = pEdit.CreateGraphics();
            //mainImage = pEdit.Image;

            //ulCorner = new PointF(0, 0);
            //if (mainImage != null && graphics != null)
            //{
            //    graphics.DrawImage(mainImage, 0, 0, pEdit.Width, pEdit.Height);
            //}
            //if (mainImage != null && graphics != null)
            //{
            //    foreach (var opis in currentRec.OpisZdjeciaCollection)
            //    {
            //        Pen pen = new Pen(Color.Red, 3);
            //        graphics.DrawEllipse(pen, opis.XPos - 50, opis.YPos - 50, 100, 100);
            //    }
            //}
        }

        private void LoadCompleted(object sender, EventArgs e)
        {
            UpdateGraphics();
        }

        private void Invalidated(object sender, InvalidateEventArgs e)
        {

        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            //if (startPaint && graphics != null)
            //{
            //    //Setting the Pen BackColor and line Width
            //    Pen p = new Pen(Color.Red, 3);
            //    //Drawing the line.
            //    sender.graphics.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
            //    initX = e.X;
            //    initY = e.Y;
            //}
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            // startPaint = false;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {

            //if (e.Button != MouseButtons.Left) return;
            //mouseDownPoint = e.Location;
            //PictureEdit edit = sender as PictureEdit;
            //edit.Refresh();
            // startPaint = true;

            //  SolidBrush sb = new SolidBrush(Color.Red);
            //Pen pen = new Pen(Color.Red, 3);
            //graphics.DrawEllipse(pen, e.X - 50, e.Y - 50, 100, 100);

            //IObjectSpace objectSpace = View.ObjectSpace;
            //var opis = objectSpace.CreateObject<OpisZdjecia>();
            //opis.Opis = $"Opis {DateTime.Now}";
            //opis.XPos = e.X;
            //opis.YPos = e.Y;
            //opis.Osoba = objectSpace.GetObject(currentRec);
            ////  currentRec.OpisZdjeciaCollection.Add(opis);
            //objectSpace.CommitChanges();
            //objectSpace.Refresh();
        }
    }
}
