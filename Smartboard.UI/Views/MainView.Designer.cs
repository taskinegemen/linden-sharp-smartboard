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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colBookId = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colDateTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colImagePath = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.layoutViewField_colBookId = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colUserId = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colIsDeleted = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colDateTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colImagePath = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.picEditLoader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBookId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUserId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colIsDeleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colImagePath)).BeginInit();
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
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bookBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(527, 364);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataSource = typeof(Smartboard.Business.Entities.Book);
            // 
            // layoutView1
            // 
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colBookId,
            this.colUserId,
            this.colIsDeleted,
            this.colDateTime,
            this.colImagePath});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // colBookId
            // 
            this.colBookId.FieldName = "BookId";
            this.colBookId.LayoutViewField = this.layoutViewField_colBookId;
            this.colBookId.Name = "colBookId";
            // 
            // colUserId
            // 
            this.colUserId.FieldName = "UserId";
            this.colUserId.LayoutViewField = this.layoutViewField_colUserId;
            this.colUserId.Name = "colUserId";
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.LayoutViewField = this.layoutViewField_colIsDeleted;
            this.colIsDeleted.Name = "colIsDeleted";
            // 
            // colDateTime
            // 
            this.colDateTime.FieldName = "DateTime";
            this.colDateTime.LayoutViewField = this.layoutViewField_colDateTime;
            this.colDateTime.Name = "colDateTime";
            // 
            // colImagePath
            // 
            this.colImagePath.FieldName = "ImagePath";
            this.colImagePath.LayoutViewField = this.layoutViewField_colImagePath;
            this.colImagePath.Name = "colImagePath";
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colBookId,
            this.layoutViewField_colUserId,
            this.layoutViewField_colIsDeleted,
            this.layoutViewField_colDateTime,
            this.layoutViewField_colImagePath});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // layoutViewField_colBookId
            // 
            this.layoutViewField_colBookId.EditorPreferredWidth = 172;
            this.layoutViewField_colBookId.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colBookId.Name = "layoutViewField_colBookId";
            this.layoutViewField_colBookId.Size = new System.Drawing.Size(240, 20);
            this.layoutViewField_colBookId.TextSize = new System.Drawing.Size(59, 13);
            this.layoutViewField_colBookId.TextToControlDistance = 5;
            // 
            // layoutViewField_colUserId
            // 
            this.layoutViewField_colUserId.EditorPreferredWidth = 172;
            this.layoutViewField_colUserId.Location = new System.Drawing.Point(0, 20);
            this.layoutViewField_colUserId.Name = "layoutViewField_colUserId";
            this.layoutViewField_colUserId.Size = new System.Drawing.Size(240, 20);
            this.layoutViewField_colUserId.TextSize = new System.Drawing.Size(59, 13);
            this.layoutViewField_colUserId.TextToControlDistance = 5;
            // 
            // layoutViewField_colIsDeleted
            // 
            this.layoutViewField_colIsDeleted.EditorPreferredWidth = 172;
            this.layoutViewField_colIsDeleted.Location = new System.Drawing.Point(0, 40);
            this.layoutViewField_colIsDeleted.Name = "layoutViewField_colIsDeleted";
            this.layoutViewField_colIsDeleted.Size = new System.Drawing.Size(240, 20);
            this.layoutViewField_colIsDeleted.TextSize = new System.Drawing.Size(59, 13);
            this.layoutViewField_colIsDeleted.TextToControlDistance = 5;
            // 
            // layoutViewField_colDateTime
            // 
            this.layoutViewField_colDateTime.EditorPreferredWidth = 172;
            this.layoutViewField_colDateTime.Location = new System.Drawing.Point(0, 60);
            this.layoutViewField_colDateTime.Name = "layoutViewField_colDateTime";
            this.layoutViewField_colDateTime.Size = new System.Drawing.Size(240, 20);
            this.layoutViewField_colDateTime.TextSize = new System.Drawing.Size(59, 13);
            this.layoutViewField_colDateTime.TextToControlDistance = 5;
            // 
            // layoutViewField_colImagePath
            // 
            this.layoutViewField_colImagePath.EditorPreferredWidth = 172;
            this.layoutViewField_colImagePath.Location = new System.Drawing.Point(0, 80);
            this.layoutViewField_colImagePath.Name = "layoutViewField_colImagePath";
            this.layoutViewField_colImagePath.Size = new System.Drawing.Size(240, 40);
            this.layoutViewField_colImagePath.TextSize = new System.Drawing.Size(59, 13);
            this.layoutViewField_colImagePath.TextToControlDistance = 5;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(527, 364);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.picEditLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linden-Sharp-Smartboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnLoad);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picEditLoader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBookId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUserId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colIsDeleted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colImagePath)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker workerReadFile;
        private DevExpress.XtraEditors.PictureEdit picEditLoader;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private System.Windows.Forms.BindingSource bookBindingSource;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colBookId;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colUserId;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colIsDeleted;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDateTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colImagePath;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colBookId;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colUserId;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colIsDeleted;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDateTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colImagePath;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;



    }
}

