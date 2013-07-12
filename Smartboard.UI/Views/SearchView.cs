using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Smartboard.Business.Entities;
using Smartboard.UI.Presenters;

namespace Smartboard.UI.Views
{
    public partial class SearchView : DevExpress.XtraEditors.XtraForm
    {
        #region private members

        private SearchViewType searchViewType;

        private List<Category> categories = new List<Category>();

        private SearchPresenter presenter = new SearchPresenter();
        private bool isDoubleClick = false;

        #endregion

        #region public methods

        public SearchView()
        {
            InitializeComponent();
        }

        public SearchView(SearchViewType searchViewType)
        {
            InitializeComponent();
            this.searchViewType = searchViewType;
        }

        #endregion

        #region event handlers

        private void OnViewLoad(object sender, EventArgs e)
        {
            if (this.searchViewType == SearchViewType.MultimediaSearch)
            {
                this.OnMultimediaSearchLoad(sender, e);
            }
            else
            {
                this.OnAllNotesSearchLoad(sender, e);
            }
        }

        private void OnMultimediaSearchLoad(object sender, EventArgs e)
        {
            this.categories = this.presenter.GetCategories();
            this.bindingSourceClasses.DataSource = this.categories;
        }

        private void OnAllNotesSearchLoad(object sender, EventArgs e)
        {
            this.categories = this.presenter.GetCategories();
            this.bindingSourceClasses.DataSource = this.categories;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonOpen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Easy boy!...");
        }

        private void simpleButtonSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Easy boy!...");
        }

        private void listBoxControlClasses_SelectedValueChanged(object sender, EventArgs e)
        {
            Category category = this.listBoxControlClasses.SelectedValue as Category;
            this.presenter.GetCourses(category);
            this.bindingSourceCourses.DataSource = category.Courses;
            this.listBoxControlCourses.DataSource = this.bindingSourceCourses;
        }

        private void listBoxControlCourses_SelectedValueChanged(object sender, EventArgs e)
        {
            Course course = this.listBoxControlCourses.SelectedValue as Course;
            if (this.searchViewType == SearchViewType.AllNotesSearch)
            {
                this.presenter.GetNotes(course);
                this.bindingSourceNotes.DataSource = course.Notes;
                this.listBoxControlBooks.DataSource = this.bindingSourceNotes;
            }
            else
            {
                this.presenter.GetMultimedias(course);
                this.bindingSourceMultimedias.DataSource = course.Multimedias;
                this.listBoxControlBooks.DataSource = this.bindingSourceMultimedias;
            }
            this.listBoxControlBooks.SelectedIndex = -1;
        }

        private void listBoxControlBooks_Click(object sender, EventArgs e)
        {
            this.isDoubleClick = false;
            this.timerClick.Start();
        }

        private void listBoxControlBooks_DoubleClick(object sender, EventArgs e)
        {
            this.isDoubleClick = true;
            this.timerClick.Start();
        }

        private void timerClick_Tick(object sender, EventArgs e)
        {
            this.timerClick.Stop();
            if (this.isDoubleClick)
            {
                this.DoDoubleClickEvent();
            }
            else
            {
                this.DoClickEvent();
            }
        }

        private void DoClickEvent()
        {
            if (this.searchViewType == SearchViewType.AllNotesSearch)
            {
                Note note = this.listBoxControlBooks.SelectedValue as Note;
                MessageBox.Show("click: " + note.ToString());
            }
            else
            {
                Multimedia note = this.listBoxControlBooks.SelectedValue as Multimedia;
                MessageBox.Show("click: " + note.ToString());
            }
        }

        private void DoDoubleClickEvent()
        {
            if (this.searchViewType == SearchViewType.AllNotesSearch)
            {
                Note note = this.listBoxControlBooks.SelectedValue as Note;
                MessageBox.Show("double click: " + note.ToString());
            }
            else
            {
                Multimedia note = this.listBoxControlBooks.SelectedValue as Multimedia;
                MessageBox.Show("double click: " + note.ToString());
            }
        }

        #endregion

        #region enums

        public enum SearchViewType
        {
            MultimediaSearch,
            AllNotesSearch
        }

        #endregion


    }

    
}