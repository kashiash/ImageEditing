namespace PictureEditDrawing
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStartX = new DevExpress.XtraEditors.LabelControl();
            this.lblStartY = new DevExpress.XtraEditors.LabelControl();
            this.lblEndX = new DevExpress.XtraEditors.LabelControl();
            this.lblEndY = new DevExpress.XtraEditors.LabelControl();
            this.pictureEditCanvas1 = new PictureEditDrawing.PictureEditCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditCanvas1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStartX
            // 
            this.lblStartX.Location = new System.Drawing.Point(492, 54);
            this.lblStartX.Name = "lblStartX";
            this.lblStartX.Size = new System.Drawing.Size(63, 13);
            this.lblStartX.TabIndex = 3;
            this.lblStartX.Text = "labelControl1";
            // 
            // lblStartY
            // 
            this.lblStartY.Location = new System.Drawing.Point(492, 78);
            this.lblStartY.Name = "lblStartY";
            this.lblStartY.Size = new System.Drawing.Size(63, 13);
            this.lblStartY.TabIndex = 4;
            this.lblStartY.Text = "labelControl2";
            // 
            // lblEndX
            // 
            this.lblEndX.Location = new System.Drawing.Point(492, 102);
            this.lblEndX.Name = "lblEndX";
            this.lblEndX.Size = new System.Drawing.Size(63, 13);
            this.lblEndX.TabIndex = 5;
            this.lblEndX.Text = "labelControl3";
            // 
            // lblEndY
            // 
            this.lblEndY.Location = new System.Drawing.Point(492, 126);
            this.lblEndY.Name = "lblEndY";
            this.lblEndY.Size = new System.Drawing.Size(63, 13);
            this.lblEndY.TabIndex = 6;
            this.lblEndY.Text = "labelControl4";
            // 
            // pictureEditCanvas1
            // 
            this.pictureEditCanvas1.EditValue = global::PictureEditDrawing.Properties.Resources.Boeing737;
            this.pictureEditCanvas1.Location = new System.Drawing.Point(6, 12);
            this.pictureEditCanvas1.Name = "pictureEditCanvas1";
            this.pictureEditCanvas1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEditCanvas1.Size = new System.Drawing.Size(432, 300);
            this.pictureEditCanvas1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 355);
            this.Controls.Add(this.lblEndY);
            this.Controls.Add(this.lblEndX);
            this.Controls.Add(this.lblStartY);
            this.Controls.Add(this.lblStartX);
            this.Controls.Add(this.pictureEditCanvas1);
            this.Name = "frmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditCanvas1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureEditCanvas pictureEditCanvas1;
        private DevExpress.XtraEditors.LabelControl lblStartX;
        private DevExpress.XtraEditors.LabelControl lblStartY;
        private DevExpress.XtraEditors.LabelControl lblEndX;
        private DevExpress.XtraEditors.LabelControl lblEndY;

    }
}

