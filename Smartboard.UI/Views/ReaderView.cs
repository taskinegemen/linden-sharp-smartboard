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
using System.Diagnostics;
using System.Drawing.Imaging;
using Smartboard.UI.ToolBoxItems.PaintMenu;
using DevExpress.XtraEditors.ViewInfo;
using System.Reflection;

namespace Smartboard.UI.Views
{
    public partial class ReaderView : DevExpress.XtraEditors.XtraForm
    {
        #region private members

        private ReaderPresenter presenter = new ReaderPresenter();

        private int zoomPercentInc = 20;
        private int oldPageNo = 1;

        private Pen pen = new Pen(Color.Black);
        private SolidBrush solidBrush = new SolidBrush(Color.Black);

        private bool paintMode = false;
        private bool canPaint = false;

        private ThicknessWrapper thickness = new ThicknessWrapper();

        private int zoomPercent = 0;
        private int oldZoomPercent = 0;

        private bool addNote = false;
        private bool canAddNote = false;

        private int addNoteFirstX = 0;
        private int addNoteFirstY = 0;

        private int _addNoteFirstX = 0;
        private int _addNoteFirstY = 0;

        private int addNoteSecondX = 0;
        private int addNoteSecondY = 0;

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
            this.oldZoomPercent = this.zoomPercent = this.pictureEditPage.Properties.ZoomPercent;
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
            Point point = this.panelControl1.Location;

            int y = point.Y;
            point.Y = 
                (y + this.panelControl1.Height) - 
                (300 + this.emptySpaceItem2.Height + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight);
            point.X = 0;
            this.gridControlPages.Location = point;

            this.gridControlPages.Width = this.panelControl1.Width;
            this.gridControlPages.Height = 300;

            // set paint menu position
            this.paintMenu.Location = new Point(2, (this.Height / 2) - 200);

            this.paintMenu.Pen = this.pen;
            this.paintMenu.SolidBrush = this.solidBrush;
            this.paintMenu.Thickness = this.thickness;

            // set picture edit
            this.pictureEditPage.SendToBack();

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
            this.pictureEditPage.Properties.ZoomPercent += this.zoomPercentInc;

            MessageBox.Show(this.pictureEditPage.Image.Width.ToString());

        }

        private void simpleButtonZoomMinus_Click(object sender, EventArgs e)
        {
            this.pictureEditPage.Properties.ZoomPercent -= this.zoomPercentInc;

            MessageBox.Show(this.pictureEditPage.Image.Width.ToString());
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

        private void textEditPage_Enter(object sender, EventArgs e)
        {
            try
            {
                Process.Start("osk.exe");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Klavye açılamadı.");
            }
        }

        private void simpleButtonPaint_Click(object sender, EventArgs e)
        {
            if (this.paintMenu.Visible)
            {
                this.pictureEditPage.Properties.ZoomPercent = this.oldZoomPercent;
                this.paintMenu.Visible = false;
                this.RemovePaint();
            }
            else
            {
                this.oldZoomPercent = this.pictureEditPage.Properties.ZoomPercent;
                this.pictureEditPage.Properties.ZoomPercent = this.zoomPercent;

                this.paintMenu.Visible = true;
                this.SetPaint();
            }
        }

        private void pictureEditPage_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.paintMode)
            {
                this.canPaint = true;
            }
            else if (this.addNote)
            {
                this.addNoteFirstX = e.X;
                this.addNoteFirstY = e.Y;

                PictureEditViewInfo viewInfo = this.pictureEditPage.GetViewInfo() as PictureEditViewInfo;
                PropertyInfo pr = viewInfo.GetType().GetProperty("HScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                int fHScrollBarPosition = (int)pr.GetValue(viewInfo, null);
                pr = viewInfo.GetType().GetProperty("VScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                int fVScrollBarPosition = (int)pr.GetValue(viewInfo, null);

                this.addNoteFirstX += fHScrollBarPosition - viewInfo.PictureStartX;
                this.addNoteFirstY += fVScrollBarPosition;

                this._addNoteFirstX = e.X;
                this._addNoteFirstY = e.Y;

                this.canAddNote = true;
            }
        }

        private void pictureEditPage_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.paintMode)
            {
                this.canPaint = false;
            }
            else if (this.addNote)
            {
                this.addNote = false;
                this.canAddNote = false;

                this.addNoteSecondX = e.X;
                this.addNoteSecondY = e.Y;

                this.pictureEditPage.Properties.ZoomPercent = this.oldZoomPercent;
                this.pictureEditPage.Properties.AllowScrollViaMouseDrag = true;

                Graphics g = Graphics.FromImage(this.pictureEditPage.Image);

                PictureEditViewInfo viewInfo = this.pictureEditPage.GetViewInfo() as PictureEditViewInfo;
                PropertyInfo pr = viewInfo.GetType().GetProperty("HScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                int fHScrollBarPosition = (int)pr.GetValue(viewInfo, null);
                pr = viewInfo.GetType().GetProperty("VScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                int fVScrollBarPosition = (int)pr.GetValue(viewInfo, null);

                this.addNoteSecondX += fHScrollBarPosition - viewInfo.PictureStartX;
                this.addNoteSecondY += fVScrollBarPosition;

                Pen pen = new Pen(Color.Black, 1);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

                g.DrawRectangle(pen, new Rectangle(this.addNoteFirstX, this.addNoteFirstY, this.addNoteSecondX - this.addNoteFirstX, this.addNoteSecondY - this.addNoteFirstY));

                this.pictureEditPage.Invalidate();

                g.Dispose();


                this.DoAddNoteCrop();
            }
        }

        private void pictureEditPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.canPaint)
            {
                int x = e.X;
                int y = e.Y;

                Graphics g = Graphics.FromImage(this.pictureEditPage.Image);

                PictureEditViewInfo viewInfo = this.pictureEditPage.GetViewInfo() as PictureEditViewInfo;
                PropertyInfo pr = viewInfo.GetType().GetProperty("HScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                int fHScrollBarPosition = (int)pr.GetValue(viewInfo, null);
                pr = viewInfo.GetType().GetProperty("VScrollBarPosition", BindingFlags.Instance | BindingFlags.NonPublic);
                int fVScrollBarPosition = (int)pr.GetValue(viewInfo, null);

                x += fHScrollBarPosition - viewInfo.PictureStartX;
                y += fVScrollBarPosition;

                g.FillRectangle(this.solidBrush, x, y, this.thickness.Thickness, this.thickness.Thickness);

                this.pictureEditPage.Invalidate();

                g.Dispose();
            }
            else if (this.canAddNote)
            {
                this.pictureEditPage.Refresh();
                Graphics g = this.pictureEditPage.CreateGraphics();
                
                Pen pen = new Pen(Color.Black, 1);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                g.DrawRectangle(pen, this._addNoteFirstX, this._addNoteFirstY, e.X - this._addNoteFirstX, e.Y - this._addNoteFirstY);

                g.Dispose();
            }
        }

        private void simpleButtonAddNote_Click(object sender, EventArgs e)
        {
            this.oldZoomPercent = this.pictureEditPage.Properties.ZoomPercent;
            this.pictureEditPage.Properties.ZoomPercent = this.zoomPercent;
            this.addNote = true;
            this.pictureEditPage.Properties.AllowScrollViaMouseDrag = false;
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

        private void SetPaint()
        {
            this.pictureEditPage.Properties.AllowScrollViaMouseDrag = false;
            this.paintMode = true;
        }

        private void RemovePaint()
        {
            this.pictureEditPage.Properties.AllowScrollViaMouseDrag = true;
            this.paintMode = false;
        }

        private void DoAddNoteCrop()
        {
            
        }

        #endregion

    }
}