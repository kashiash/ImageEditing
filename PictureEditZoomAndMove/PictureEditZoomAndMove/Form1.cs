using DevExpress.XtraEditors.ViewInfo;
using PictureEditZoomAndMove.MarkerRectangles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PictureEditZoomAndMove
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<RectangleMarker> rectangleMarkers;
        private string environmentPath;
        private const string markerFileName = "Marker.xml";

        public Form1()
        {
            rectangleMarkers = new List<RectangleMarker>();
            environmentPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\"));
            InitializeComponent();
            //InitPictureEdit();
            pictureEdit.MouseDoubleClick += EventPictureEditXrayOnDoubleClick;
        }

        private void InitPictureEdit()
        {
            string fileName = "Xray.jpg";
            string path = environmentPath + fileName;
            pictureEdit.Image = Image.FromFile(path);
            rectangleMarkers.Clear();

           
           // rectangleMarkers.Add(new RectangleMarker(pictureEdit, LoadMarkerFromFile()));
        }

        private void EventPictureEditXrayOnDoubleClick(object sender, MouseEventArgs e)
        {
            PictureEditViewInfo viewInfo = pictureEdit.GetViewInfo() as PictureEditViewInfo;
            if (!viewInfo.PictureScreenBounds.Contains(e.Location)) return;

           rectangleMarkers.Add(new RectangleMarker(pictureEdit, new Rectangle(e.X, e.Y, 100, 100)));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = environmentPath + markerFileName;
            File.WriteAllText(path, Serialization.SerializeObject(rectangleMarkers.FirstOrDefault().DrawingRectangle));
        }

        private Rectangle LoadMarkerFromFile()
        {
            string path = environmentPath + markerFileName;
            Rectangle rectFromFile = Serialization.Deserialize<Rectangle>(File.ReadAllText(path));
            return rectFromFile;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            InitPictureEdit();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(pictureEdit.Bounds.X, pictureEdit.Bounds.Right - 20);
                int y = random.Next(pictureEdit.Bounds.Y, pictureEdit.Bounds.Bottom - 20);
                var rect = new Rectangle(x, y, random.Next(5, 20), random.Next(5, 20));
                rectangleMarkers.Add(new RectangleMarker(pictureEdit, rect));
            }
        }
    }
}
