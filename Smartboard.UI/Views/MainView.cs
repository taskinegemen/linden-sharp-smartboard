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
    public partial class MainView : Form
    {
        #region private members

        private MainViewPresenter presenter;
        private List<Book> books;

        #endregion

        #region public members

        #endregion public members

        #region public methods

        public MainView()
        {
            InitializeComponent();
            this.presenter = new MainViewPresenter();
        }

        #endregion

        #region private methods

        private Book GetBook(int bookId)
        {
            return this.books.Find(b => b.Id == bookId);
        }

        #endregion

        #region event handlers

        private void onLoad(object sender, EventArgs e)
        {
            this.books = this.presenter.GetBooks();
            if (this.books != null && this.books.Count > 0)
            {
                for (int i = 0; i < this.books.Count; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    
                    pictureBox.Image = Image.FromFile(this.books[i].ImagePath);
                    pictureBox.Width = pictureBox.Image.Width;
                    pictureBox.Height = pictureBox.Image.Height;

                    pictureBox.Name = this.books[i].Id.ToString();

                    pictureBox.Click += new EventHandler(bookClick);

                    this.lytPictures.Controls.Add(pictureBox);
                }
            }
            else
            {
                MessageBox.Show("Kitap yok!");
            }
        }

        private void bookClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Book book = this.GetBook(int.Parse(pictureBox.Name));
            BookView bookView = new BookView(book);
            bookView.Show();
        }
        
        #endregion event handlers
        
    }
}
