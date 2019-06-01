using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureEditDrawing
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        


        public frmMain()
        {
            InitializeComponent();
        }


        public void EchoCoordinates(Shape currentShape)
        {
            lblEndX.Text = String.Format("End X: {0}", currentShape.EndX);
            lblEndY.Text = String.Format("End Y: {0}", currentShape.EndY);
            lblStartX.Text = String.Format("Start X: {0}", currentShape.StartX);
            lblStartY.Text = String.Format("Start Y: {0}", currentShape.StartY);
        }
    }
}
