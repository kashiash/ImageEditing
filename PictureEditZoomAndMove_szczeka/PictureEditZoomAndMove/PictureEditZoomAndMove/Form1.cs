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
    public partial class Form1 : Form
    {
        private List<RectangleMarker> rectangleMarkers;
        private string environmentPath;
        private const string markerFileName = "Marker.xml";

        public Form1()
        {
            rectangleMarkers = new List<RectangleMarker>();
            environmentPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\"));
            InitializeComponent();
            InitPictureEdit();
            pictureEdit.MouseDoubleClick += EventPictureEditXrayOnDoubleClick;
        }

        private void InitPictureEdit()
        {
            string fileName = "Xray.jpg";
            string path = environmentPath + fileName;
            pictureEdit.Image = Image.FromFile(path);
            rectangleMarkers.Clear();
            rectangleMarkers.Add(new RectangleMarker(pictureEdit, LoadMarkerFromFile()));
        }

        private void EventPictureEditXrayOnDoubleClick(object sender, MouseEventArgs e)
        {
            AddMarker(e);
            AddMarker(e);
            AddMarker(e);
            AddMarker(e);

        }

        private void AddMarker(MouseEventArgs e)
        {
            PictureEditViewInfo viewInfo = pictureEdit.GetViewInfo() as PictureEditViewInfo;
            if (!viewInfo.PictureScreenBounds.Contains(e.Location)) return;
            rectangleMarkers.Add(new RectangleMarker(pictureEdit, new Rectangle(e.X - 50, e.Y, 100, 100)));
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
    }
}
