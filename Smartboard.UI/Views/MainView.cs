using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Layout;
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
            this.picEditLoader.Visible = true;
            this.scrollableContainer.Visible = false;
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
            int categoryCount = 2;
            int y = 0;
            for (int i = 0; i < categoryCount; i++)
            {
                GridControl control = new GridControl();
                control.KeyPress += new KeyPressEventHandler(this.OnKeyPress);                

                control.Height = 500;
                control.Width = this.Width;
                control.Name = "gridControl-" + i.ToString();

                RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
                
                control.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                    pictureEdit
                });

                // bind books
                BindingSource source = new BindingSource();
                source.DataSource = this.books;
                control.DataSource = source;

                // set view
                LayoutView view = new LayoutView();
                control.MainView = view;

                // set view options
                view.OptionsBehavior.AllowRuntimeCustomization = false;
                view.OptionsView.ShowHeaderPanel = false;
                view.OptionsView.ShowViewCaption = true;
                view.OptionsView.ViewMode = LayoutViewMode.Row;
                view.ViewCaption = "Kategori-" + i.ToString();

                LayoutViewColumn colImage = new LayoutViewColumn();
                LayoutViewCard layoutViewCard = new LayoutViewCard();
                LayoutViewField layoutViewField_colImage = new LayoutViewField();


                view.CardMinSize = new System.Drawing.Size(200, 280);
                view.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
                    colImage
                });
                view.Name = "viewLayout-" + i.ToString();
                view.OptionsView.ShowCardCaption = false;
                view.TemplateCard = layoutViewCard;

                colImage.ColumnEdit = pictureEdit;
                
                colImage.CustomizationCaption = "Image";
                colImage.FieldName = "Image";
                
                colImage.LayoutViewField = layoutViewField_colImage;
                colImage.Name = "colImage-" + i.ToString();

                layoutViewCard.CustomizationFormText = "TemplateCard";
                layoutViewCard.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
                layoutViewCard.GroupBordersVisible = false;
                layoutViewCard.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                    layoutViewField_colImage});
                layoutViewCard.Name = "layoutViewCard-" + i.ToString();
                layoutViewCard.OptionsItemText.TextToControlDistance = 5;
                layoutViewCard.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 4, 5, 6);
                layoutViewCard.Text = "TemplateCard";
                layoutViewCard.TextVisible = false;

                layoutViewField_colImage.EditorPreferredWidth = 200;
                layoutViewField_colImage.Location = new System.Drawing.Point(0, 0);
                layoutViewField_colImage.Name = "layoutViewField_colImage-" + i.ToString();
                layoutViewField_colImage.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
                layoutViewField_colImage.Size = new System.Drawing.Size(200, 280);
                layoutViewField_colImage.TextSize = new System.Drawing.Size(0, 0);
                layoutViewField_colImage.TextToControlDistance = 0;
                layoutViewField_colImage.TextVisible = false;

                pictureEdit.Click += new EventHandler(this.OnBookClick);

                // set view keypress event
                view.KeyPress += new KeyPressEventHandler(this.OnKeyPress); 

                // set location
                control.Location = new Point(0, y);
                y += 500;
                this.scrollableContainer.Controls.Add(control);
            }

            this.picEditLoader.Visible = false;
            this.picEditLoader.Dispose();

            this.scrollableContainer.Visible = true;
        }

        private void OnBookClick(object sender, EventArgs e)
        {
            PictureEdit edit = sender as PictureEdit;
            GridControl control = edit.Parent as GridControl;
            LayoutView view = control.MainView as LayoutView;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle > -1)
            {
                Book book = view.GetRow(rowHandle) as Book;
                MessageBox.Show("Book: " + book.BookId.ToString());
            }
        }

        #endregion event handlers

    }
}
