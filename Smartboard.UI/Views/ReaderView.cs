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


        public ReaderView()
        {
            InitializeComponent();
        }

        public ReaderView(Book book)
        {
            InitializeComponent();
        }
    }
}