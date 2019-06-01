using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesXaf.Module.Win.Editors
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.ExpressApp.Editors;
    using DevExpress.ExpressApp.Model;
    using DevExpress.ExpressApp.Win.Editors;
    using DevExpress.XtraEditors.ViewInfo;
    using PictureEditZoomAndMove.MarkerRectangles;

    [PropertyEditor(typeof(byte[]), false)]
    public class CustomImageEditor : ImagePropertyEditor
    {
        private XafPictureEdit control = null;
        private List<RectangleMarker> rectangleMarkers;

        public CustomImageEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info)
        {
          
        }


        protected override void Dispose(bool disposing)
        {
            if (control != null)
            {
                control.ImageChanged -= OnImageChanged;
                control = null;
            }
            base.Dispose(disposing);
        }

        protected override object CreateControlCore()
        {
            control = new XafPictureEdit();
            if (CurrentObject != null)
            {
                var businessObject = CurrentObject;
       //         control.OpenDialogFilter = string.Format("Custom filter for Bitmaps (*.bmp)|*{0}*.bmp", businessObject.ID);
            }

            control.ImageChanged += OnImageChanged;
            control.MouseDoubleClick += EventPictureEditXrayOnDoubleClick;
            return control;
        }

        private void EventPictureEditXrayOnDoubleClick(object sender, MouseEventArgs e)
        {
            AddMarker(e);
        }

        private void AddMarker(MouseEventArgs e)
        {
            PictureEditViewInfo viewInfo = control.GetViewInfo() as PictureEditViewInfo;
            if (!viewInfo.PictureScreenBounds.Contains(e.Location)) return;
            rectangleMarkers.Add(new RectangleMarker(control, new Rectangle(e.X - 50, e.Y - 50, 100, 100)));
        }

        protected override void ReadValueCore()
        {
            if (control != null)
            {
                if (CurrentObject != null)
                {
                    control.ReadOnly = false;
                    control.Image = (Image)PropertyValue;
                }
                else
                {
                    control.ReadOnly = true;
                    control.Image = null;
                }
            }
        }
        protected override object GetControlValueCore()
        {
            if (control != null)
            {
                return (Image)control.Image;
            }
            return null;
        }
        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            ReadValue();
        }

        private void OnImageChanged(object sender, EventArgs e)
        {
            if (!IsValueReading)
            {
                OnControlValueChanged();
                WriteValueCore();
            }
        }

        private void InitPhotoEditor(ImagePropertyEditor imageEditor)
        {
            rectangleMarkers = new List<RectangleMarker>();

            if (control != null)
            {
                control.LoadCompleted += LoadCompleted;
                control.MouseClick += control_Click;
                //    control.Paint += Paint;
                control.Cursor = System.Windows.Forms.Cursors.Default;
                //   control.Dock = System.Windows.Forms.DockStyle.Fill;
                control.Properties.AllowScrollViaMouseDrag = false;
                control.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
                control.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
                control.Properties.Appearance.BackColor = System.Drawing.Color.Black;
                control.Properties.Appearance.Options.UseBackColor = true;
                control.Properties.ShowMenu = true;
                control.Properties.ShowScrollBars = true;
                control.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                control.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Never;
                control.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
                control.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.MouseWheel;

            }

        }

        private void control_Click(object sender, MouseEventArgs e)
        {
          //  throw new NotImplementedException();
        }

        private void LoadCompleted(object sender, EventArgs e)
        {
          //  throw new NotImplementedException();
        }
    }
}
