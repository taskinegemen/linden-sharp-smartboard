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

        #endregion

        #region public members

        public List<Page> Pages;

        #endregion

        #region public methods

        public BookView()
        {
            InitializeComponent();
            this.presenter = new BookViewPresenter(this);
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
            this.Pages = this.presenter.GetPages(this.book.Id);

            this.lstImages.View = View.LargeIcon;  
            this.imgLstPages.ImageSize = new Size(150, 210);

            this.lstImages.AutoArrange = false;
            
            //this.lstImages.Scrollable = true;
            //this.lstImages.HeaderStyle = ColumnHeaderStyle.None;

            foreach (Page page in this.Pages)
            {
                this.imgLstPages.Images.Add(Image.FromFile(page.ThumbnailPath));
            }
            
            
            this.lstImages.LargeImageList = this.imgLstPages;

            this.lstImages.Alignment = ListViewAlignment.Left;
            

            for (int i = 0; i < this.imgLstPages.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Name = (i + 1).ToString();
                item.Text = "sayfa " + i.ToString();

                this.lstImages.Items.Add(item);
            }
        }

        private void GetPage(object sender, EventArgs e)
        {
            ListViewItem item = this.lstImages.SelectedItems[0];

            Page page = this.presenter.GetPage(this.book.Id, int.Parse(item.Name));

            this.picBoxPage.Width = page.Width;
            this.picBoxPage.Height = page.Height;


            this.picBoxPage.Image = Image.FromFile(page.ImagePath);
            this.picBoxPage.Size = this.picBoxPage.Image.Size;
        }

        #endregion

    }
}
