using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            List<MyClass> lst = new List<MyClass>();
            for (int i = 0; i < 10; i++) 
                lst.Add(new MyClass { Id = i, Image = string.Format("Image{0}", i) });

                gridControl1.DataSource = lst;

            gridView1.CustomDrawCell += gridView1_CustomDrawCell;
        }

        Dictionary<string, Image> imgCache = new Dictionary<string, Image>();
        void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            if (e.Column != null && e.Column.FieldName == "Image")
            {
                string cellValue = e.CellValue as string;
                Image img = null;
                if (!imgCache.TryGetValue(cellValue, out img))
                {
                    img = GetRandomImage(45, 45);
                    imgCache[cellValue] = img;
                }
                e.Graphics.DrawImage(img, e.Bounds.Location);
                e.Handled = true;
            }
        }

        public static Image GetRandomImage(int w, int h) {
            Color randomColor = GetRandomColor();
            Image img = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(img))
                g.FillRectangle(new SolidBrush(randomColor), new Rectangle(0, 0, img.Width, img.Height));
            return img;
        }

        public static Color GetRandomColor() {
            Random r = new Random();
            Thread.Sleep(10);
            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }

        public class MyClass {
            public int Id { get; set; }
            public string Image { get; set; }
        }
    }
}
