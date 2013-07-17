namespace Smartboard.UI.ToolBoxItems.PaintMenu
{
    partial class PaintMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.trackBarControl1 = new DevExpress.XtraEditors.TrackBarControl();
            this.trackBarControlOpacity = new DevExpress.XtraEditors.TrackBarControl();
            this.colorEdit1 = new DevExpress.XtraEditors.ColorEdit();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonEraser = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemOpacity = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemThickness = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControlOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControlOpacity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.trackBarControl1);
            this.layoutControl1.Controls.Add(this.trackBarControlOpacity);
            this.layoutControl1.Controls.Add(this.colorEdit1);
            this.layoutControl1.Controls.Add(this.simpleButtonClose);
            this.layoutControl1.Controls.Add(this.simpleButtonSave);
            this.layoutControl1.Controls.Add(this.simpleButtonEraser);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(172, 279);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // trackBarControl1
            // 
            this.trackBarControl1.EditValue = 3;
            this.trackBarControl1.Location = new System.Drawing.Point(12, 78);
            this.trackBarControl1.Name = "trackBarControl1";
            this.trackBarControl1.Properties.Minimum = 1;
            this.trackBarControl1.Properties.ShowValueToolTip = true;
            this.trackBarControl1.Size = new System.Drawing.Size(148, 45);
            this.trackBarControl1.StyleController = this.layoutControl1;
            this.trackBarControl1.TabIndex = 13;
            this.trackBarControl1.Value = 3;
            this.trackBarControl1.EditValueChanged += new System.EventHandler(this.trackBarControl1_EditValueChanged);
            // 
            // trackBarControlOpacity
            // 
            this.trackBarControlOpacity.EditValue = 10;
            this.trackBarControlOpacity.Location = new System.Drawing.Point(12, 143);
            this.trackBarControlOpacity.Name = "trackBarControlOpacity";
            this.trackBarControlOpacity.Properties.Minimum = 1;
            this.trackBarControlOpacity.Properties.ShowValueToolTip = true;
            this.trackBarControlOpacity.Size = new System.Drawing.Size(148, 45);
            this.trackBarControlOpacity.StyleController = this.layoutControl1;
            this.trackBarControlOpacity.TabIndex = 12;
            this.trackBarControlOpacity.Value = 10;
            this.trackBarControlOpacity.EditValueChanged += new System.EventHandler(this.trackBarControlOpacity_EditValueChanged);
            // 
            // colorEdit1
            // 
            this.colorEdit1.EditValue = System.Drawing.Color.Empty;
            this.colorEdit1.Location = new System.Drawing.Point(12, 38);
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit1.Size = new System.Drawing.Size(148, 20);
            this.colorEdit1.StyleController = this.layoutControl1;
            this.colorEdit1.TabIndex = 11;
            this.colorEdit1.EditValueChanged += new System.EventHandler(this.colorEdit1_EditValueChanged);
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Location = new System.Drawing.Point(12, 218);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(148, 22);
            this.simpleButtonClose.StyleController = this.layoutControl1;
            this.simpleButtonClose.TabIndex = 10;
            this.simpleButtonClose.Text = "Kapat";
            this.simpleButtonClose.Click += new System.EventHandler(this.simpleButtonClose_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Location = new System.Drawing.Point(12, 192);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(148, 22);
            this.simpleButtonSave.StyleController = this.layoutControl1;
            this.simpleButtonSave.TabIndex = 9;
            this.simpleButtonSave.Text = "Kaydet";
            // 
            // simpleButtonEraser
            // 
            this.simpleButtonEraser.Location = new System.Drawing.Point(12, 12);
            this.simpleButtonEraser.Name = "simpleButtonEraser";
            this.simpleButtonEraser.Size = new System.Drawing.Size(148, 22);
            this.simpleButtonEraser.StyleController = this.layoutControl1;
            this.simpleButtonEraser.TabIndex = 5;
            this.simpleButtonEraser.Text = "Silgi";
            this.simpleButtonEraser.Click += new System.EventHandler(this.simpleButtonEraser_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItemOpacity,
            this.layoutControlItemThickness});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(172, 279);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonEraser;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(152, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.simpleButtonSave;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 180);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(152, 26);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.simpleButtonClose;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 206);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(152, 53);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.colorEdit1;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(152, 24);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItemOpacity
            // 
            this.layoutControlItemOpacity.Control = this.trackBarControlOpacity;
            this.layoutControlItemOpacity.CustomizationFormText = "Opasite";
            this.layoutControlItemOpacity.Location = new System.Drawing.Point(0, 115);
            this.layoutControlItemOpacity.Name = "layoutControlItemOpacity";
            this.layoutControlItemOpacity.Size = new System.Drawing.Size(152, 65);
            this.layoutControlItemOpacity.Text = "Opasite";
            this.layoutControlItemOpacity.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemOpacity.TextSize = new System.Drawing.Size(37, 13);
            // 
            // layoutControlItemThickness
            // 
            this.layoutControlItemThickness.Control = this.trackBarControl1;
            this.layoutControlItemThickness.CustomizationFormText = "Kalınlık";
            this.layoutControlItemThickness.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItemThickness.Name = "layoutControlItemThickness";
            this.layoutControlItemThickness.Size = new System.Drawing.Size(152, 65);
            this.layoutControlItemThickness.Text = "Kalınlık";
            this.layoutControlItemThickness.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemThickness.TextSize = new System.Drawing.Size(37, 13);
            // 
            // PaintMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "PaintMenu";
            this.Size = new System.Drawing.Size(172, 279);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControlOpacity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControlOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemThickness)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEraser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TrackBarControl trackBarControlOpacity;
        private DevExpress.XtraEditors.ColorEdit colorEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemOpacity;
        private DevExpress.XtraEditors.TrackBarControl trackBarControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemThickness;

    }
}
