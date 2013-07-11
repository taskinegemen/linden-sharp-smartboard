namespace Smartboard.UI.Views
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.workerReadFile = new System.ComponentModel.BackgroundWorker();
            this.picEditLoader = new DevExpress.XtraEditors.PictureEdit();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pictureEditAllNotesSearch = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEditMultimediaSearch = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEditClose = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemMultimediaSearch = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.scrollableContainer = new DevExpress.XtraEditors.XtraScrollableControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.timerBook = new System.Windows.Forms.Timer(this.components);
            this.labelControlLibrary = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItemLibrary = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.picEditLoader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditAllNotesSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditMultimediaSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditClose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMultimediaSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLibrary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // workerReadFile
            // 
            this.workerReadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadFile);
            this.workerReadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ReadFinished);
            // 
            // picEditLoader
            // 
            this.picEditLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picEditLoader.EditValue = ((object)(resources.GetObject("picEditLoader.EditValue")));
            this.picEditLoader.Location = new System.Drawing.Point(0, 0);
            this.picEditLoader.Name = "picEditLoader";
            this.picEditLoader.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picEditLoader.Size = new System.Drawing.Size(527, 364);
            this.picEditLoader.TabIndex = 0;
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataSource = typeof(Smartboard.Business.Entities.Book);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControlLibrary);
            this.layoutControl1.Controls.Add(this.scrollableContainer);
            this.layoutControl1.Controls.Add(this.pictureEditAllNotesSearch);
            this.layoutControl1.Controls.Add(this.pictureEditMultimediaSearch);
            this.layoutControl1.Controls.Add(this.pictureEditClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(527, 364);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pictureEditAllNotesSearch
            // 
            this.pictureEditAllNotesSearch.EditValue = ((object)(resources.GetObject("pictureEditAllNotesSearch.EditValue")));
            this.pictureEditAllNotesSearch.Location = new System.Drawing.Point(467, 12);
            this.pictureEditAllNotesSearch.Name = "pictureEditAllNotesSearch";
            this.pictureEditAllNotesSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEditAllNotesSearch.Size = new System.Drawing.Size(29, 30);
            this.pictureEditAllNotesSearch.StyleController = this.layoutControl1;
            this.pictureEditAllNotesSearch.TabIndex = 6;
            this.pictureEditAllNotesSearch.Click += new System.EventHandler(this.pictureEditAllNotesSearch_Click);
            // 
            // pictureEditMultimediaSearch
            // 
            this.pictureEditMultimediaSearch.EditValue = ((object)(resources.GetObject("pictureEditMultimediaSearch.EditValue")));
            this.pictureEditMultimediaSearch.Location = new System.Drawing.Point(443, 12);
            this.pictureEditMultimediaSearch.Name = "pictureEditMultimediaSearch";
            this.pictureEditMultimediaSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEditMultimediaSearch.Size = new System.Drawing.Size(20, 30);
            this.pictureEditMultimediaSearch.StyleController = this.layoutControl1;
            this.pictureEditMultimediaSearch.TabIndex = 5;
            this.pictureEditMultimediaSearch.Click += new System.EventHandler(this.pictureEditMultimediaSearch_Click);
            // 
            // pictureEditClose
            // 
            this.pictureEditClose.EditValue = ((object)(resources.GetObject("pictureEditClose.EditValue")));
            this.pictureEditClose.Location = new System.Drawing.Point(12, 12);
            this.pictureEditClose.Name = "pictureEditClose";
            this.pictureEditClose.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEditClose.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.pictureEditClose.Size = new System.Drawing.Size(30, 30);
            this.pictureEditClose.StyleController = this.layoutControl1;
            this.pictureEditClose.TabIndex = 0;
            this.pictureEditClose.Click += new System.EventHandler(this.picEditClose_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemClose,
            this.layoutControlItemMultimediaSearch,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItemLibrary,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(527, 364);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemClose
            // 
            this.layoutControlItemClose.Control = this.pictureEditClose;
            this.layoutControlItemClose.CustomizationFormText = "layoutControlItemClose";
            this.layoutControlItemClose.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemClose.MaxSize = new System.Drawing.Size(34, 34);
            this.layoutControlItemClose.MinSize = new System.Drawing.Size(34, 34);
            this.layoutControlItemClose.Name = "layoutControlItemClose";
            this.layoutControlItemClose.Size = new System.Drawing.Size(34, 34);
            this.layoutControlItemClose.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemClose.Text = "layoutControlItemClose";
            this.layoutControlItemClose.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemClose.TextToControlDistance = 0;
            this.layoutControlItemClose.TextVisible = false;
            // 
            // layoutControlItemMultimediaSearch
            // 
            this.layoutControlItemMultimediaSearch.Control = this.pictureEditMultimediaSearch;
            this.layoutControlItemMultimediaSearch.CustomizationFormText = "layoutControlItemMultimediaSearch";
            this.layoutControlItemMultimediaSearch.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.layoutControlItemMultimediaSearch.Location = new System.Drawing.Point(431, 0);
            this.layoutControlItemMultimediaSearch.MaxSize = new System.Drawing.Size(34, 34);
            this.layoutControlItemMultimediaSearch.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItemMultimediaSearch.Name = "layoutControlItemMultimediaSearch";
            this.layoutControlItemMultimediaSearch.Size = new System.Drawing.Size(24, 34);
            this.layoutControlItemMultimediaSearch.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemMultimediaSearch.Text = "layoutControlItemMultimediaSearch";
            this.layoutControlItemMultimediaSearch.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemMultimediaSearch.TextToControlDistance = 0;
            this.layoutControlItemMultimediaSearch.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pictureEditAllNotesSearch;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(455, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(34, 34);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(33, 34);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(488, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(20, 34);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(19, 34);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(34, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(188, 34);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // scrollableContainer
            // 
            this.scrollableContainer.Location = new System.Drawing.Point(12, 46);
            this.scrollableContainer.Name = "scrollableContainer";
            this.scrollableContainer.Size = new System.Drawing.Size(503, 306);
            this.scrollableContainer.TabIndex = 7;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.scrollableContainer;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(507, 310);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // timerBook
            // 
            this.timerBook.Interval = 500;
            this.timerBook.Tick += new System.EventHandler(this.timerBook_Tick);
            // 
            // labelControlLibrary
            // 
            this.labelControlLibrary.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlLibrary.Location = new System.Drawing.Point(232, 10);
            this.labelControlLibrary.Name = "labelControlLibrary";
            this.labelControlLibrary.Size = new System.Drawing.Size(91, 34);
            this.labelControlLibrary.StyleController = this.layoutControl1;
            this.labelControlLibrary.TabIndex = 8;
            this.labelControlLibrary.Text = "Kütüphane";
            // 
            // layoutControlItemLibrary
            // 
            this.layoutControlItemLibrary.Control = this.labelControlLibrary;
            this.layoutControlItemLibrary.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItemLibrary.CustomizationFormText = "layoutControlItemLibrary";
            this.layoutControlItemLibrary.Location = new System.Drawing.Point(222, 0);
            this.layoutControlItemLibrary.MaxSize = new System.Drawing.Size(100, 0);
            this.layoutControlItemLibrary.MinSize = new System.Drawing.Size(1, 1);
            this.layoutControlItemLibrary.Name = "layoutControlItemLibrary";
            this.layoutControlItemLibrary.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItemLibrary.Size = new System.Drawing.Size(91, 34);
            this.layoutControlItemLibrary.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemLibrary.Text = "layoutControlItemLibrary";
            this.layoutControlItemLibrary.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItemLibrary.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemLibrary.TextToControlDistance = 0;
            this.layoutControlItemLibrary.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(313, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(118, 34);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(527, 364);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.picEditLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linden-Sharp-Smartboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnLoad);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picEditLoader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditAllNotesSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditMultimediaSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditClose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMultimediaSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLibrary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker workerReadFile;
        private DevExpress.XtraEditors.PictureEdit picEditLoader;
        private System.Windows.Forms.BindingSource bookBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.PictureEdit pictureEditClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemClose;
        private DevExpress.XtraEditors.PictureEdit pictureEditMultimediaSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMultimediaSearch;
        private DevExpress.XtraEditors.PictureEdit pictureEditAllNotesSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.XtraScrollableControl scrollableContainer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.Timer timerBook;
        private DevExpress.XtraEditors.LabelControl labelControlLibrary;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemLibrary;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;



    }
}

