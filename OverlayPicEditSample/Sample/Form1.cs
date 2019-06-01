 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sample {
    public partial class Form1 : Form {
        private MyPictureEdit pe;

        public Form1() {
            InitializeComponent();

            pe = new MyPictureEdit();
            this.Controls.Add(pe);

            pe.LoadImage();

            pe.Dock = System.Windows.Forms.DockStyle.Fill;
            pe.BackColor = Color.Green;
            pe.EditValue = global::Sample.Properties.Resources.Untitled;
            pe.Location = new System.Drawing.Point(0, 0);
            pe.Name = "pictureEdit1";
            pe.Properties.ShowScrollBars = true;
            pe.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            pe.Size = new System.Drawing.Size(292, 269);
            pe.TabIndex = 0;
            
            pe.MouseDown += new System.Windows.Forms.MouseEventHandler(pe_MouseDown);
            pe.MouseMove += new System.Windows.Forms.MouseEventHandler(pe_MouseMove);
            pe.MouseUp += new System.Windows.Forms.MouseEventHandler(pe_MouseUp);
            pe.Paint += new System.Windows.Forms.PaintEventHandler(pe_Paint);

            //pe.ZoomPercentChanged += pe_ZoomPercentChanged;
            //pe.MouseDown += pe_MouseDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Draw

        // Start Rectangle
        //
        private void pe_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.pe.IsMouseDown(sender, e);
        }

        // Draw Rectangle
        //
        private void pe_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.pe.IsMouseMove(sender, e);
        }

        // Draw Area
        //
        private void pe_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            this.pe.ToPaint(sender, e);
        }

        private void pe_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.pe.IsMouseUp(sender, e);
        }
        #endregion
        
    }
}
