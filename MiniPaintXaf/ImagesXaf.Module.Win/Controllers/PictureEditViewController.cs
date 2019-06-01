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
    public class PictureEditViewController<DetailView> : PictureEditController<DetailView>
    {


        //private string environmentPath;
        //private const string markerFileName = "Marker.xml";

        //Image mainImage = null;
        //bool startPaint = false;
        //Graphics graphics;
        ////nullable int for storing Null value
        //int? initX = null;
        //int? initY = null;
        //PointF ulCorner;

        Osoba currentRec;
        //Point mouseDownPoint = Point.Empty;
        //Rectangle lasso = Rectangle.Empty;
        //bool ZoomPercentChanged;

        public PictureEditViewController()
        {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Osoba);
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

        protected override void OnActivated()
        {
            base.OnActivated();
            ((CompositeView)View).ItemsChanged += PictureditorController_ItemsChanged;
            TryInitializePictureItem();



            currentRec = (Osoba)View.CurrentObject;
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

        void loadSavedMarkers()
        {
            foreach (var opis in currentRec.OpisZdjeciaCollection)
            {
                var marker = new RectangleMarker(pEdit, new Rectangle(opis.XPos - 50, opis.YPos, 100, 100));
                rectangleMarkers.Add(marker);
            }
        }

        private void Resize(object sender, EventArgs e)
        {

            UpdateGraphics();

        }

        private void ImageChanged(object sender, EventArgs e)
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
