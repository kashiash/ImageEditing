namespace PictureEditDrawing
{
    partial class frmDrawingTool
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
            DevExpress.XtraLayout.LayoutControl layoutControl1;
            DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
            DevExpress.XtraLayout.LayoutControlGroup grpAppearance;
            DevExpress.XtraLayout.LayoutControlItem ctrlCancel;
            DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
            DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
            DevExpress.XtraLayout.LayoutControlGroup grpDrawingTools;
            DevExpress.XtraLayout.LayoutControlItem ctrlTools;
            DevExpress.XtraLayout.LayoutControlItem ctrlOk;
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlTools = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.txtBorderWidth = new DevExpress.XtraEditors.SpinEdit();
            this.colorPickEdit1 = new DevExpress.XtraEditors.ColorPickEdit();
            this.ctrlForeColor = new DevExpress.XtraLayout.LayoutControlItem();
            this.ctrlBorderWidth = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            grpAppearance = new DevExpress.XtraLayout.LayoutControlGroup();
            ctrlCancel = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            grpDrawingTools = new DevExpress.XtraLayout.LayoutControlGroup();
            ctrlTools = new DevExpress.XtraLayout.LayoutControlItem();
            ctrlOk = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(layoutControl1)).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorderWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grpAppearance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlForeColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBorderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ctrlCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grpDrawingTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ctrlTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ctrlOk)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.AllowCustomization = false;
            layoutControl1.Controls.Add(this.btnOk);
            layoutControl1.Controls.Add(this.btnCancel);
            layoutControl1.Controls.Add(this.pnlTools);
            layoutControl1.Controls.Add(this.txtBorderWidth);
            layoutControl1.Controls.Add(this.colorPickEdit1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(464, 85, 250, 350);
            layoutControl1.Root = layoutControlGroup1;
            layoutControl1.Size = new System.Drawing.Size(410, 248);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(302, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 22);
            this.btnCancel.StyleController = layoutControl1;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            // 
            // pnlTools
            // 
            this.pnlTools.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Line", global::PictureEditDrawing.Properties.Resources.line32, -1, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", true, -1, true, null, true, true, true, null, null, 0, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Rectangle", global::PictureEditDrawing.Properties.Resources.rectangle32, -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, 0),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Ellipse", global::PictureEditDrawing.Properties.Resources.ellipse32, -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, 0)});
            this.pnlTools.Location = new System.Drawing.Point(24, 43);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(362, 55);
            this.pnlTools.TabIndex = 6;
            this.pnlTools.Text = "windowsUIButtonPanel1";
            // 
            // txtBorderWidth
            // 
            this.txtBorderWidth.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtBorderWidth.Location = new System.Drawing.Point(320, 145);
            this.txtBorderWidth.Name = "txtBorderWidth";
            this.txtBorderWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBorderWidth.Properties.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.txtBorderWidth.Properties.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtBorderWidth.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtBorderWidth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtBorderWidth.Size = new System.Drawing.Size(66, 20);
            this.txtBorderWidth.StyleController = layoutControl1;
            this.txtBorderWidth.TabIndex = 5;
            // 
            // colorPickEdit1
            // 
            this.colorPickEdit1.EditValue = System.Drawing.Color.Black;
            this.colorPickEdit1.Location = new System.Drawing.Point(90, 145);
            this.colorPickEdit1.Name = "colorPickEdit1";
            this.colorPickEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEdit1.Size = new System.Drawing.Size(160, 20);
            this.colorPickEdit1.StyleController = layoutControl1;
            this.colorPickEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            grpAppearance,
            ctrlCancel,
            emptySpaceItem1,
            emptySpaceItem2,
            ctrlOk,
            grpDrawingTools,
            this.simpleSeparator1});
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "Root";
            layoutControlGroup1.Size = new System.Drawing.Size(410, 248);
            layoutControlGroup1.TextVisible = false;
            // 
            // grpAppearance
            // 
            grpAppearance.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ctrlForeColor,
            this.ctrlBorderWidth});
            grpAppearance.Location = new System.Drawing.Point(0, 102);
            grpAppearance.Name = "grpAppearance";
            grpAppearance.Size = new System.Drawing.Size(390, 67);
            grpAppearance.Text = "Appearance";
            // 
            // ctrlForeColor
            // 
            this.ctrlForeColor.Control = this.colorPickEdit1;
            this.ctrlForeColor.Location = new System.Drawing.Point(0, 0);
            this.ctrlForeColor.Name = "ctrlForeColor";
            this.ctrlForeColor.Size = new System.Drawing.Size(230, 24);
            this.ctrlForeColor.Text = "Fore Color";
            this.ctrlForeColor.TextSize = new System.Drawing.Size(63, 13);
            // 
            // ctrlBorderWidth
            // 
            this.ctrlBorderWidth.Control = this.txtBorderWidth;
            this.ctrlBorderWidth.Location = new System.Drawing.Point(230, 0);
            this.ctrlBorderWidth.Name = "ctrlBorderWidth";
            this.ctrlBorderWidth.Size = new System.Drawing.Size(136, 24);
            this.ctrlBorderWidth.Text = "Border Width";
            this.ctrlBorderWidth.TextSize = new System.Drawing.Size(63, 13);
            // 
            // ctrlCancel
            // 
            ctrlCancel.Control = this.btnCancel;
            ctrlCancel.Location = new System.Drawing.Point(290, 202);
            ctrlCancel.MaxSize = new System.Drawing.Size(100, 26);
            ctrlCancel.MinSize = new System.Drawing.Size(100, 26);
            ctrlCancel.Name = "ctrlCancel";
            ctrlCancel.Size = new System.Drawing.Size(100, 26);
            ctrlCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            ctrlCancel.TextSize = new System.Drawing.Size(0, 0);
            ctrlCancel.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 169);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(390, 32);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new System.Drawing.Point(0, 202);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new System.Drawing.Size(190, 26);
            emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // grpDrawingTools
            // 
            grpDrawingTools.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            ctrlTools});
            grpDrawingTools.Location = new System.Drawing.Point(0, 0);
            grpDrawingTools.Name = "grpDrawingTools";
            grpDrawingTools.Size = new System.Drawing.Size(390, 102);
            grpDrawingTools.Text = "Drawing Tools";
            // 
            // ctrlTools
            // 
            ctrlTools.Control = this.pnlTools;
            ctrlTools.Location = new System.Drawing.Point(0, 0);
            ctrlTools.Name = "ctrlTools";
            ctrlTools.Size = new System.Drawing.Size(366, 59);
            ctrlTools.TextSize = new System.Drawing.Size(0, 0);
            ctrlTools.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 201);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(390, 1);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(202, 214);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 22);
            this.btnOk.StyleController = layoutControl1;
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ctrlOk
            // 
            ctrlOk.Control = this.btnOk;
            ctrlOk.Location = new System.Drawing.Point(190, 202);
            ctrlOk.MaxSize = new System.Drawing.Size(100, 26);
            ctrlOk.MinSize = new System.Drawing.Size(100, 26);
            ctrlOk.Name = "ctrlOk";
            ctrlOk.Size = new System.Drawing.Size(100, 26);
            ctrlOk.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            ctrlOk.TextSize = new System.Drawing.Size(0, 0);
            ctrlOk.TextVisible = false;
            // 
            // frmDrawingTool
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(410, 248);
            this.Controls.Add(layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDrawingTool";
            this.Text = "Drawing Tool";
            ((System.ComponentModel.ISupportInitialize)(layoutControl1)).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBorderWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grpAppearance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlForeColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBorderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ctrlCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grpDrawingTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ctrlTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ctrlOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit txtBorderWidth;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEdit1;
        private DevExpress.XtraLayout.LayoutControlItem ctrlForeColor;
        private DevExpress.XtraLayout.LayoutControlItem ctrlBorderWidth;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel pnlTools;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
    }
}