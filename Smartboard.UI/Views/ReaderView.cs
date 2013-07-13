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
            GridControl control = new GridControl();
            LayoutView view = new LayoutView();

            control.MainView = view;

            this.xtraScrollableControlPage.Controls.Add(control);
        }

        #endregion

    }
}