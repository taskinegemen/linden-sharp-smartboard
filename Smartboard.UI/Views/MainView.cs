using DevExpress.XtraEditors;
using Smartboard.Business.Entities;
using Smartboard.UI.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartboard.UI.Views
{
    public partial class MainView : XtraForm
    {
        #region private members

        private MainViewPresenter presenter;
        private List<Book> books;
        private User user;

        #endregion

        #region public members

        #endregion public members

        #region public methods

        public MainView()
        {
            InitializeComponent();
            this.presenter = new MainViewPresenter();
            this.user = new User();
        }

        #endregion

        #region private methods

        private Book GetBook(int bookId)
        {
            return this.books.Find(b => b.BookId == bookId);
        }

        private void GetBooks()
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

                    pictureBox.Name = this.books[i].BookId.ToString();

                    pictureBox.Click += new EventHandler(BookClick);

                    //this.lytPictures.Controls.Add(pictureBox);

                    
                }
            }
            else
            {
                MessageBox.Show("Kitap yok!");
            }
        }

        #endregion

        #region event handlers

        private void OnLoad(object sender, EventArgs e)
        {
            this.gridControl1.Visible = false;

            this.workerReadFile.RunWorkerAsync();
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BookClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Book book = this.GetBook(int.Parse(pictureBox.Name));
            BookView bookView = new BookView(book);
            bookView.Show();
        }

        private void CloseProgram(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Synchronize(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView(this.user);
            loginView.Show();

            loginView.FormClosing += new FormClosingEventHandler(this.LoginViewClosing);
        }

        private void LoginViewClosing(object sender, EventArgs e)
        {
            LoginView view = sender as LoginView;
            if (view.User.Status)
            {
                this.user = view.User;
            }
        }

        private void ReadFile(object sender, DoWorkEventArgs e)
        {
            this.GetBooks();
        }

        private void ReadFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gridControl1.Visible = true;
            this.picEditLoader.Visible = false;
            this.picEditLoader.Dispose();

            this.bookBindingSource.DataSource = this.books;
        }

        #endregion event handlers

    }
}
