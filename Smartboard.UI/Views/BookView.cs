using Smartboard.Business.Entities;
using Smartboard.UI.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool areaSelection = false;
        private int areaSelectionClickCount = 0;

        private int firstX = 0;
        private int firstY = 0;
        private int secondX = 0;
        private int secondY = 0;

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

        private void CropImage(Image img, int fx, int fy, int sx, int sy)
        {
            Rectangle cropArea = new Rectangle(fx, fy, sx - fx, sy - fy);
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            this.picBoxPage.Image = (Image)bmpCrop;
        }

        #endregion

        #region event handlers

        private void GetPages(object sender, EventArgs e)
        {
            this.Pages = this.presenter.GetPages(this.book.Id);

            this.lstImages.View = View.LargeIcon;

            for(int i = 0; i < this.Pages.Count; i++)
            {
                ListViewItem item = new ListViewItem("asdsd", i);
                item.Text = "sayfa: " + (i + 1).ToString();
                item.Name = (i + 1).ToString();
                this.lstImages.Items.Add(item);
            }

            //this.lstImages.View = View.Details;  
            this.imgLstPages.ImageSize = new Size(150, 210);

            //this.lstImages.AutoArrange = false;
            
            //this.lstImages.Scrollable = true;
            //this.lstImages.HeaderStyle = ColumnHeaderStyle.None;

            foreach (Page page in this.Pages)
            {    
                this.imgLstPages.Images.Add(Image.FromFile(page.ThumbnailPath));
            }

            this.lstImages.LargeImageList = this.imgLstPages;
            //this.lstImages.LargeImageList = this.imgLstPages;

            //this.lstImages.Alignment = ListViewAlignment.Left;
            

            //for (int i = 0; i < this.imgLstPages.Images.Count; i++)
            //{
            //    ListViewItem item = new ListViewItem();
            //    
            //    item.ImageIndex = i;
            //    item.Name = (i + 1).ToString();
            //    item.Text = "sayfa " + i.ToString();

            //    this.lstImages.Items.Add(item);
            //}
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

        private void panel1_Resize(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            this.picBoxPage.Size = panel.Size;
        }

        private void picBoxPage_Click(object sender, EventArgs e)
        {
            //Process.Start(@"C:\Wildlife.wmv");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.picBoxPage.AllowClickZoom = !this.picBoxPage.AllowClickZoom;
            this.areaSelection = !this.areaSelection;
            this.areaSelectionClickCount = 0;
        }

        private void picBoxPage_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.areaSelection && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.areaSelectionClickCount++;
                switch (this.areaSelectionClickCount)
                {
                    case 1:
                        firstX = e.X;
                        firstY = e.Y;
                        break;
                    case 2:
                        secondX = e.X;
                        secondY = e.Y;
                        this.toolStripButton1_Click(null, null);
                        this.CropImage(this.picBoxPage.Image, firstX, firstY, secondX, secondY);
                        break;
                    default:
                        this.areaSelectionClickCount = 0;
                        break;
                }
            }

        }

        #endregion

        
    }
}
