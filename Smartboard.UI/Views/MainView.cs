using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraLayout;
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
        private int tick = 0;
        private bool bookHold = false;

        private Book book = null;

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
                
            }
            else
            {
                MessageBox.Show("Kitap yok!");
            }
        }

        private void OpenBookSubMenu()
        {
            this.tick = 0;
            this.bookHold = false;

            BookView bookView = new BookView(this.book);
            bookView.Show();
        }

        #endregion

        #region event handlers

        private void OnLoad(object sender, EventArgs e)
        {
            this.picEditLoader.Visible = true;
            this.layoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.workerReadFile.RunWorkerAsync();
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
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
                
                control.Height = 500;

                if (categoryCount > 1)
                {
                    control.Width = 
                        this.scrollableContainer.Width - (System.Windows.Forms.SystemInformation.VerticalScrollBarWidth);
                }
                else
                {
                    control.Width = this.scrollableContainer.Width;
                }
                
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
                view.ViewCaption = "     Kategori-" + i.ToString();
                view.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                

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
                pictureEdit.MouseDown += new MouseEventHandler(this.StartTimer);
                pictureEdit.MouseUp += new MouseEventHandler(this.StopTimer);

                // set location
                control.Location = new Point(0, y);
                y += 500;
                this.scrollableContainer.Controls.Add(control);
            }

            this.picEditLoader.Visible = false;
            this.picEditLoader.Dispose();

            this.layoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void OnBookClick(object sender, EventArgs e)
        {
            if (this.bookHold)
            {
                this.bookHold = false;
                return;
            }

            this.tick = 0;
            timerBook.Stop();

            PictureEdit edit = sender as PictureEdit;
            GridControl control = edit.Parent as GridControl;
            LayoutView view = control.MainView as LayoutView;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle > -1)
            {
                Book book = view.GetRow(rowHandle) as Book;

                BookView bookView = new BookView(book);
                bookView.Show();
            }
        }

        private void picEditClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEditMultimediaSearch_Click(object sender, EventArgs e)
        {
            SearchView searchView = 
                new SearchView(SearchView.SearchViewType.MultimediaSearch);
            searchView.ShowDialog();
        }

        private void pictureEditAllNotesSearch_Click(object sender, EventArgs e)
        {
            SearchView searchView =
                new SearchView(SearchView.SearchViewType.AllNotesSearch);
            searchView.ShowDialog();
        }

        private void StartTimer(object sender, MouseEventArgs e)
        {
            PictureEdit edit = sender as PictureEdit;
            GridControl control = edit.Parent as GridControl;
            LayoutView view = control.MainView as LayoutView;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle > -1)
            {
                this.book = view.GetRow(rowHandle) as Book;
            }

            timerBook.Start();
        }

        private void StopTimer(object sender, MouseEventArgs e)
        {
            timerBook.Stop();
        }

        private void timerBook_Tick(object sender, EventArgs e)
        {
            tick++;
            if (tick == 2)
            {
                tick = 0;
                timerBook.Stop();
                this.bookHold = true;
                this.OpenBookSubMenu();
            }
        }

        #endregion event handlers

        
    }
}
