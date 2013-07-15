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

        private int zoomPercent = 20;
        private int oldPageNo = 1;
        #endregion

        #region public members

        public Book Book;
        public Page Page;
        public int PageId = 1;

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

            // get first page
            this.ChangePage(1);
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

            this.labelControlTotalPages.Text = this.Book.PageThumbnails.Count.ToString();
        }

        // get selected page
        private void repositoryItemPictureEdit1_Click(object sender, EventArgs e)
        {
            PictureEdit edit = sender as PictureEdit;
            GridControl control = edit.Parent as GridControl;
            LayoutView view = control.MainView as LayoutView;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle > -1)
            {
                Thumbnail thumbnail = view.GetRow(rowHandle) as Thumbnail;

                this.ChangePage(thumbnail);
            }
            this.gridControlPages.Visible = false;
        }

        private void simpleButtonZoomPlus_Click(object sender, EventArgs e)
        {
            this.pictureEditPage.Properties.ZoomPercent += this.zoomPercent;
        }

        private void simpleButtonZoomMinus_Click(object sender, EventArgs e)
        {
            this.pictureEditPage.Properties.ZoomPercent -= this.zoomPercent;
        }

        private void textEditPage_TextChanged(object sender, EventArgs e)
        {
            int pageNo;
            if (this.Page.PageNo.ToString() == this.textEditPage.Text) return;
            int.TryParse(textEditPage.Text, out pageNo);

            if (pageNo > 0 && pageNo <= this.Book.PageThumbnails.Count)
            {
                Thumbnail thumbnail = this.Book.PageThumbnails.Find(p => p.PageId == pageNo);
                this.ChangePage(thumbnail);
                this.oldPageNo = thumbnail.PageId;
            }
            else
            {
                this.ChangePage(this.oldPageNo);
            }
        }

        private void simpleButtonNextPage_Click(object sender, EventArgs e)
        {
            if (this.PageId < this.Book.PageThumbnails.Count)
            {
                this.ChangePage(++this.PageId);
            }
        }

        private void simpleButtonPreviousPage_Click(object sender, EventArgs e)
        {
            if (this.PageId > 1)
            {
                this.ChangePage(--this.PageId);
            }
        }

        #endregion

        #region private methods

        private void ChangePage(Thumbnail thumbnail)
        {
            this.Page = this.presenter.GetPage(this.Book, thumbnail.PageId);

            this.SetPictureEdit();
        }

        private void ChangePage(int pageId)
        {
            this.Page = this.presenter.GetPage(this.Book, pageId);

            this.SetPictureEdit();
        }

        private void SetPictureEdit()
        {
            this.pictureEditPage.Image = this.Page.Image;

            this.pictureEditPage.Properties.AllowScrollViaMouseDrag = true;
            this.pictureEditPage.Properties.ShowScrollBars = true;

            this.labelControlCurrentPage.Text = this.Page.PageNo.ToString();
            this.textEditPage.Text = this.Page.PageNo.ToString();

            this.PageId = this.Page.PageNo;
        }

        #endregion

        

        

    }
}