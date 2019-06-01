using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors.ViewInfo;
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
   public abstract class PictureEditController<T> : ViewController<DetailView>
    {
       internal List<RectangleMarker> rectangleMarkers;
       internal XafPictureEdit pEdit;

        public PictureEditController()
        {

        }


        internal void InitPhotoEditor(ImagePropertyEditor imageEditor)
        {
            rectangleMarkers = new List<RectangleMarker>();
            var ctrl = imageEditor.Control;
            pEdit = (XafPictureEdit)ctrl;
            if (pEdit != null)
            {
                pEdit.LoadCompleted += LoadCompleted;
                pEdit.MouseClick += PEdit_Click;
                //    pEdit.Paint += Paint;
                pEdit.Cursor = System.Windows.Forms.Cursors.Default;
                pEdit.Dock = System.Windows.Forms.DockStyle.Fill;
                pEdit.Properties.AllowScrollViaMouseDrag = false;
                pEdit.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
                pEdit.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
                pEdit.Properties.Appearance.BackColor = System.Drawing.Color.Black;
                pEdit.Properties.Appearance.Options.UseBackColor = true;
                pEdit.Properties.ShowMenu = true;
                pEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Never;
                pEdit.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
                pEdit.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.MouseWheel;

            }

        }
        internal void imageEditor_ControlCreated(object sender, EventArgs e)
        {
            InitPhotoEditor((ImagePropertyEditor)sender);
        }
        internal void LoadCompleted(object sender, EventArgs e)
        {
            UpdateGraphics();
        }

        internal void UpdateGraphics()
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

        internal void PEdit_Click(object sender, MouseEventArgs e)
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

    }
}
