namespace Smartboard.UI.Views
{
    partial class SearchView
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
            this.layoutControlSearch = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonSearch = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOpen = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxControlCourses = new DevExpress.XtraEditors.ListBoxControl();
            this.listBoxControlBooks = new DevExpress.XtraEditors.ListBoxControl();
            this.listBoxControlClasses = new DevExpress.XtraEditors.ListBoxControl();
            this.textEditSearch = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemSearch = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSourceClasses = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceCourses = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceNotes = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceMultimedias = new System.Windows.Forms.BindingSource(this.components);
            this.timerClick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSearch)).BeginInit();
            this.layoutControlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMultimedias)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlSearch
            // 
            this.layoutControlSearch.Controls.Add(this.simpleButtonSearch);
            this.layoutControlSearch.Controls.Add(this.simpleButtonCancel);
            this.layoutControlSearch.Controls.Add(this.simpleButtonOpen);
            this.layoutControlSearch.Controls.Add(this.listBoxControlCourses);
            this.layoutControlSearch.Controls.Add(this.listBoxControlBooks);
            this.layoutControlSearch.Controls.Add(this.listBoxControlClasses);
            this.layoutControlSearch.Controls.Add(this.textEditSearch);
            this.layoutControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlSearch.Location = new System.Drawing.Point(0, 0);
            this.layoutControlSearch.Name = "layoutControlSearch";
            this.layoutControlSearch.Root = this.layoutControlGroup1;
            this.layoutControlSearch.Size = new System.Drawing.Size(536, 316);
            this.layoutControlSearch.TabIndex = 0;
            this.layoutControlSearch.Text = "layoutControl1";
            // 
            // simpleButtonSearch
            // 
            this.simpleButtonSearch.Location = new System.Drawing.Point(446, 12);
            this.simpleButtonSearch.Name = "simpleButtonSearch";
            this.simpleButtonSearch.Size = new System.Drawing.Size(78, 22);
            this.simpleButtonSearch.StyleController = this.layoutControlSearch;
            this.simpleButtonSearch.TabIndex = 10;
            this.simpleButtonSearch.Text = "Ara";
            this.simpleButtonSearch.Click += new System.EventHandler(this.simpleButtonSearch_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(270, 282);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(254, 22);
            this.simpleButtonCancel.StyleController = this.layoutControlSearch;
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "İptal";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOpen
            // 
            this.simpleButtonOpen.Location = new System.Drawing.Point(12, 282);
            this.simpleButtonOpen.Name = "simpleButtonOpen";
            this.simpleButtonOpen.Size = new System.Drawing.Size(254, 22);
            this.simpleButtonOpen.StyleController = this.layoutControlSearch;
            this.simpleButtonOpen.TabIndex = 8;
            this.simpleButtonOpen.Text = "Aç";
            this.simpleButtonOpen.Click += new System.EventHandler(this.simpleButtonOpen_Click);
            // 
            // listBoxControlCourses
            // 
            this.listBoxControlCourses.Location = new System.Drawing.Point(181, 38);
            this.listBoxControlCourses.Name = "listBoxControlCourses";
            this.listBoxControlCourses.Size = new System.Drawing.Size(166, 240);
            this.listBoxControlCourses.StyleController = this.layoutControlSearch;
            this.listBoxControlCourses.TabIndex = 7;
            this.listBoxControlCourses.SelectedValueChanged += new System.EventHandler(this.listBoxControlCourses_SelectedValueChanged);
            // 
            // listBoxControlBooks
            // 
            this.listBoxControlBooks.Location = new System.Drawing.Point(351, 38);
            this.listBoxControlBooks.Name = "listBoxControlBooks";
            this.listBoxControlBooks.Size = new System.Drawing.Size(173, 240);
            this.listBoxControlBooks.StyleController = this.layoutControlSearch;
            this.listBoxControlBooks.TabIndex = 6;
            this.listBoxControlBooks.Click += new System.EventHandler(this.listBoxControlBooks_Click);
            this.listBoxControlBooks.DoubleClick += new System.EventHandler(this.listBoxControlBooks_DoubleClick);
            // 
            // listBoxControlClasses
            // 
            this.listBoxControlClasses.DataSource = this.bindingSourceClasses;
            this.listBoxControlClasses.Location = new System.Drawing.Point(12, 38);
            this.listBoxControlClasses.Name = "listBoxControlClasses";
            this.listBoxControlClasses.Size = new System.Drawing.Size(165, 240);
            this.listBoxControlClasses.StyleController = this.layoutControlSearch;
            this.listBoxControlClasses.TabIndex = 5;
            this.listBoxControlClasses.SelectedValueChanged += new System.EventHandler(this.listBoxControlClasses_SelectedValueChanged);
            // 
            // textEditSearch
            // 
            this.textEditSearch.Location = new System.Drawing.Point(12, 12);
            this.textEditSearch.Name = "textEditSearch";
            this.textEditSearch.Size = new System.Drawing.Size(430, 20);
            this.textEditSearch.StyleController = this.layoutControlSearch;
            this.textEditSearch.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemSearch,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(536, 316);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemSearch
            // 
            this.layoutControlItemSearch.Control = this.textEditSearch;
            this.layoutControlItemSearch.CustomizationFormText = "Multimedia Ara";
            this.layoutControlItemSearch.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemSearch.Name = "layoutControlItemSearch";
            this.layoutControlItemSearch.Size = new System.Drawing.Size(434, 26);
            this.layoutControlItemSearch.Text = "Multimedia Ara";
            this.layoutControlItemSearch.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemSearch.TextToControlDistance = 0;
            this.layoutControlItemSearch.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.listBoxControlClasses;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(169, 244);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.listBoxControlBooks;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(339, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(177, 244);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.listBoxControlCourses;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(169, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(170, 244);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButtonOpen;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 270);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(258, 26);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButtonCancel;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(258, 270);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(258, 26);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.simpleButtonSearch;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(434, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // bindingSourceClasses
            // 
            this.bindingSourceClasses.DataSource = typeof(Smartboard.Business.Entities.Category);
            // 
            // bindingSourceCourses
            // 
            this.bindingSourceCourses.DataSource = typeof(Smartboard.Business.Entities.Course);
            // 
            // bindingSourceNotes
            // 
            this.bindingSourceNotes.DataSource = typeof(Smartboard.Business.Entities.Note);
            // 
            // bindingSourceMultimedias
            // 
            this.bindingSourceMultimedias.DataSource = typeof(Smartboard.Business.Entities.Multimedia);
            // 
            // timerClick
            // 
            this.timerClick.Interval = 200;
            this.timerClick.Tick += new System.EventHandler(this.timerClick_Tick);
            // 
            // SearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 316);
            this.Controls.Add(this.layoutControlSearch);
            this.Name = "SearchView";
            this.Text = "SearchView";
            this.Load += new System.EventHandler(this.OnViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSearch)).EndInit();
            this.layoutControlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMultimedias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlSearch;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit textEditSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSearch;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOpen;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlCourses;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlBooks;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlClasses;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.BindingSource bindingSourceClasses;
        private System.Windows.Forms.BindingSource bindingSourceCourses;
        private System.Windows.Forms.BindingSource bindingSourceNotes;
        private System.Windows.Forms.BindingSource bindingSourceMultimedias;
        private System.Windows.Forms.Timer timerClick;

    }
}