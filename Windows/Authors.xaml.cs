using lab_4.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static lab_4.MainWindow;

namespace lab_4.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Authors.xaml
    /// </summary>
    public partial class Authors : Window
    {
        private ObservableCollection<Author> authors { get; set; }
        private MyDbContext context { get; set; }
        public Authors()
        {
            InitializeComponent();

            context = new MyDbContext();

            authors = new ObservableCollection<Author>(context.Authors.ToList());

            _dataGrid.ItemsSource = authors;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            AuthorForm authorForm = new AuthorForm();

            authorForm.Closed += CreateAuthor;

            authorForm.ShowDialog();

            context.SaveChanges();

            MessageBox.Show("Dodano autora");
        }

        private void Usun(object sender, RoutedEventArgs e)
        {
            if(!isSelected())
            {
                return;
            }
            Author author = (Author)_dataGrid.SelectedItem;

            DeleteAuthor(author);

            context.SaveChanges();

            MessageBox.Show("Usunieto autora");
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (!isSelected())
            {
                return;
            }
            Author author = (Author)_dataGrid.SelectedItem;

            AuthorForm authorForm = new AuthorForm(author);

            authorForm.Closed += CreateAuthor;

            authorForm.ShowDialog();

            if (authorForm.closed)
            {
                return;
            }

            DeleteAuthor(author);

            MessageBox.Show("Zmodyfikowano autora");

        }
        private bool isSelected()
        {
            if(_dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Wybierz element klikajac na niego");
                return false;
            }
            return true;
        }
        private void CreateAuthor(object s, EventArgs ev)
        {
            AuthorForm authorForm = (AuthorForm) s;
            if (authorForm.closed)
            {
                return;
            }

            Author author = new Author(authorForm._firstName.Text, authorForm._lastName.Text);

            context.Authors.Add(author);

            context.SaveChanges();

            authors.Add(author);

            _dataGrid.Items.Refresh();
        }
        private void DeleteAuthor(Author author)
        {
            authors.Remove(author);

            var booksToRemove = context.Books.Where(b => b.Author.Id == author.Id).ToList();
            foreach (var book in booksToRemove)
            {
                context.Books.Remove(book);
            }

            context.Authors.Remove(author);

            context.SaveChanges();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string search = _textblock_search.Text.ToLower();

            authors = new ObservableCollection<Author>(context.Authors.Where(a => a.LastName.ToLower().Contains(search)).ToList());

            _dataGrid.ItemsSource = authors;
        }
    }
}
