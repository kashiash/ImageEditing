using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PictureEditDrawing
{
    public partial class frmDrawingTool : DevExpress.XtraEditors.XtraForm
    {

        #region Private members

        /// <summary>
        /// User-selected Shape
        /// </summary>
        private Shape _SelectedShape;

        #endregion

        #region Public accessors

        /// <summary>
        /// Gets the user-selected Shape
        /// </summary>
        public Shape SelectedShape
        {
            get { return _SelectedShape; }
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the frmDrawingTool class
        /// </summary>
        public frmDrawingTool()
        {
            InitializeComponent();
            pnlTools.Enabled = true;
        }


        /// <summary>
        /// Button click event handler for the Ok button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (pnlTools.Buttons[0].IsChecked.Value == true)
                _SelectedShape = new Line();
            else if (pnlTools.Buttons[1].IsChecked.Value == true)
                _SelectedShape = new Rectangle();
            else if (pnlTools.Buttons[2].IsChecked.Value == true)
                _SelectedShape = new Ellipse();

            _SelectedShape.BorderWidth = Convert.ToSingle(txtBorderWidth.Value);
            _SelectedShape.ForeColor = colorPickEdit1.Color;

            DialogResult = DialogResult.OK;
            Close();

        }   //End the btnOk_Click() method



    }   //End the frmDrawingTool class
}   //End the PictureEditDrawing namespace