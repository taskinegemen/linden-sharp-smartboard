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
        private int bookId;

        public BookView()
        {
            InitializeComponent();
        }

        public BookView(string name)
            :this()
        {
            this.bookId = int.Parse(name);

            this.Text = "Book Id: " + name;
        }
    }
}
