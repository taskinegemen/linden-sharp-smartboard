using Smartboard.Data.Entities;
using Smartboard.UI.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartboard.UI.Views
{
    public partial class BookView : Form
    {
        #region private members

        private BookViewPresenter presenter;
        private Book book;
        private List<Page> pages;

        #endregion

        #region public members
        #endregion

        #region public methods

        public BookView()
        {
            InitializeComponent();
            this.presenter = new BookViewPresenter();
        }

        public BookView(Book book)
            : this()
        {
            this.book = book;

            this.Text = this.book.Id.ToString();
        }

        #endregion

        #region private methods

        #endregion

        #region event handlers

        private void GetPages(object sender, EventArgs e)
        {
            this.pages = this.presenter.GetPages(this.book.Id);

            this.lstImages.View = View.LargeIcon;  
            this.imgLstPages.ImageSize = new Size(150, 210);

            this.lstImages.AutoArrange = false;
            
            //this.lstImages.Scrollable = true;
            //this.lstImages.HeaderStyle = ColumnHeaderStyle.None;

            foreach (Page page in this.pages)
            {
                this.imgLstPages.Images.Add(Image.FromFile(page.ThumbnailPath));
            }
            
            
            this.lstImages.LargeImageList = this.imgLstPages;

            this.lstImages.Alignment = ListViewAlignment.Left;
            

            for (int i = 0; i < this.imgLstPages.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Text = "sayfa " + i.ToString();

                this.lstImages.Items.Add(item);
            }
        }

        #endregion

        private void GetPages()
        {

        }


    }
}
