using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Smartboard.UI.Presenters;
using Smartboard.Business.Entities;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Layout;

namespace Smartboard.UI.Views
{
    public partial class ReaderView : DevExpress.XtraEditors.XtraForm
    {

        #region private members

        private ReaderPresenter presenter = new ReaderPresenter();

        #endregion

        #region public members

        public Book Book;
        public Page Page;

        #endregion

        #region public methods

        public ReaderView()
        {
            InitializeComponent();
        }

        public ReaderView(Book book)
        {
            InitializeComponent();
            this.Book = book;
        }

        #endregion

        #region event handlers

        // back to the library
        private void simpleButtonBackLibrary_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonOpenPages_Click(object sender, EventArgs e)
        {
            this.gridControlPages.Visible = !this.gridControlPages.Visible;
        }

        private void ReaderView_Load(object sender, EventArgs e)
        {
            // background worker will get page thumbnails in the background
            this.backgroundWorkerPageThumbnails.RunWorkerAsync();

            // set location of grid control pages
            Point point = this.pictureEditPage.Location;

            int y = point.Y;
            point.Y = (y + this.pictureEditPage.Height) - 300;

            this.gridControlPages.Location = point;

            this.gridControlPages.Width = this.pictureEditPage.Width;
            this.gridControlPages.Height = 300;
        }

        // get page thumbnails
        private void backgroundWorkerPageThumbnails_DoWork(object sender, DoWorkEventArgs e)
        {
            this.presenter.SetPageThumbnails(this.Book);
        }

        private void backgroundWorkerPageThumbnails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // now background worker finished its job.
            // set book page thumbnails
            this.bindingSourcePages.DataSource = this.Book.PageThumbnails;
        }

        private void repositoryItemPictureEdit1_Click(object sender, EventArgs e)
        {
            PictureEdit edit = sender as PictureEdit;
            GridControl control = edit.Parent as GridControl;
            LayoutView view = control.MainView as LayoutView;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle > -1)
            {
                Thumbnail thumbnail = view.GetRow(rowHandle) as Thumbnail;

                MessageBox.Show(thumbnail.PageId.ToString());
            }
            this.gridControlPages.Visible = false;
        }

        // get clicked page
        

        #endregion

        

    }
}