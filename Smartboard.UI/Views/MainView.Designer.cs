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
            this.scrollableContainer = new DevExpress.XtraEditors.XtraScrollableControl();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picEditLoader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
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
            // scrollableContainer
            // 
            this.scrollableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollableContainer.Location = new System.Drawing.Point(0, 0);
            this.scrollableContainer.Name = "scrollableContainer";
            this.scrollableContainer.Size = new System.Drawing.Size(527, 364);
            this.scrollableContainer.TabIndex = 1;
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataSource = typeof(Smartboard.Business.Entities.Book);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(527, 364);
            this.Controls.Add(this.scrollableContainer);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker workerReadFile;
        private DevExpress.XtraEditors.PictureEdit picEditLoader;
        private DevExpress.XtraEditors.XtraScrollableControl scrollableContainer;
        private System.Windows.Forms.BindingSource bookBindingSource;



    }
}

