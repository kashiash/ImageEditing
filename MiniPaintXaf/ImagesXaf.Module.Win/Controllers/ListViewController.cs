using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesXaf.Module.Win.Controllers
{
    using System;
    using DevExpress.ExpressApp;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Columns;
    using ImagesXaf.Module.BusinessObjects;
    using System.Drawing;
    using DevExpress.ExpressApp.Win.Editors;
    using PictureEditZoomAndMove.MarkerRectangles;

    namespace WinSolution.Module.Win
    {
        public class ListViewController : ViewController
        {

         //   Graphics graphics;
            Image mainImage = null;
            CompositeView parentView;
         //   XafPictureEdit pEdit;

            public ListViewController()
            {
                TargetViewType = ViewType.ListView;
                TargetViewNesting = Nesting.Nested;
                TargetObjectType = typeof(OpisZdjecia);
            }
            protected override void OnActivated()
            {
                base.OnActivated();
                ObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
                View.ControlsCreated += new EventHandler(View_ControlsCreated);
                View.CurrentObjectChanged += View_CurrentObjectChanged;
                View.SelectionChanged += ViewSelecttionChanged;
            }

            private void View_CurrentObjectChanged(object sender, EventArgs e)
            {
                UpdateDetailViewImage();
            }

            protected override void OnDeactivated()
            {
                base.OnDeactivated();
                ObjectSpace.ObjectChanged -= new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
                View.ControlsCreated -= new EventHandler(View_ControlsCreated);
                View.CurrentObjectChanged -= View_CurrentObjectChanged;
                View.SelectionChanged -= ViewSelecttionChanged;


            }

            private void ViewSelecttionChanged(object sender, EventArgs e)
            {
                UpdateDetailViewImage();
            }

            private void InitGraphics()
            {
                if (Frame is NestedFrame)
                {
                    //parentView = ((NestedFrame)Frame).ViewItem.View;
                    //ImagePropertyEditor imageEditor = parentView.FindItem("Photo") as ImagePropertyEditor;
                    //if (imageEditor != null)
                    //{
                    //    var ctrl = imageEditor.Control;
                    //    pEdit = (XafPictureEdit)ctrl;
                    //}
                }
            }

            GridView gridViewCore = null;
            void View_ControlsCreated(object sender, EventArgs e)
            {
                GridControl gridControl = (GridControl)((ListView)(View)).Editor.Control;
                gridViewCore = (GridView)gridControl.FocusedView;

                foreach (GridColumn column in gridViewCore.Columns)
                {
                    column.ColumnEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(ColumnEdit_EditValueChanging);
                    column.ColumnEdit.EditValueChanged += new EventHandler(ColumnEdit_EditValueChanged);
                }

                InitGraphics();
            }

            void ColumnEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
            {
                //0
            }
            void ColumnEdit_EditValueChanged(object sender, EventArgs e)
            {
                //1
            }
            void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
            {
                //2
            }
            public OpisZdjecia CurrentObject
            {
                get { return (OpisZdjecia)View.CurrentObject; }
            }
            private void UpdateDetailViewImage()
            {
                //if (pEdit != null && pEdit.Image != null)
                //{
                //    if (Frame is NestedFrame)
                //    {

                //        Pen pen = new Pen(Color.Red, 3);

                //        if (View.SelectedObjects.Count > 0)
                //        {
                //            foreach (OpisZdjecia opis in View.SelectedObjects)
                //            {
                //                    var marker = new RectangleMarker(pEdit, new Rectangle(opis.XPos - 50, opis.YPos, 100, 100));
                //                //    rectangleMarkers.Add(marker);
                //            }

                //        }
                //        else

                //        {
                //            if (CurrentObject != null)
                //            {
                //                graphics.DrawEllipse(pen, CurrentObject.XPos - 50, CurrentObject.YPos - 50, 100, 100);
                //                //   ((NestedFrame)Frame).ViewItem.View.Caption = CurrentObject.Name;
                //            }
                //        }
                //    }
                //}
            }
        }
    }

}
