using lab_4.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
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
    public partial class Books : Window
    {
        private ObservableCollection<Book> books { get; set; }
        private MyDbContext context { get; set; }
        public Books()
        {
            InitializeComponent();

            context = new MyDbContext();
            books = new ObservableCollection<Book>(
                context.Books.Include("Author")
            .Include("Publisher")
            .ToList()
    );

            _dataGrid.ItemsSource = books;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            BookForm bookForm = new BookForm();

            bookForm.Closed += CreateBook;

            bookForm.ShowDialog();
        }

        private void Usun(object sender, RoutedEventArgs e)
        {
            if (!isSelected())
            {
                return;
            }
            Book book = (Book)_dataGrid.SelectedItem;

            DeleteBook(book);

            context.SaveChanges();

            MessageBox.Show("Usunieto ksiazke");
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (!isSelected())
            {
                return;
            }
            Book book = (Book)_dataGrid.SelectedItem;

            BookForm bookForm = new BookForm(book);

            bookForm.Closed += CreateBook;

            bookForm.ShowDialog();

            if (bookForm.closed)
            {
                return;
            }

            DeleteBook(book);

        }
        private bool isSelected()
        {
            if (_dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Wybierz element klikajac na niego");
                return false;
            }
            return true;
        }
        private void CreateBook(object s, EventArgs ev)
        {
            BookForm bookForm = (BookForm)s;
            if (bookForm.closed)
            {
                return;
            }

            Book book = new Book(bookForm._title.Text, (Author)bookForm._author.SelectedItem, (Publisher)bookForm._publisher.SelectedItem);
            //Book book = new Book(bookForm._title.Text, null, null);
            context.Books.Add(book);

            books.Add(book);

            _dataGrid.Items.Refresh();

            context.SaveChanges();

            MessageBox.Show("Dodano ksiazke");
        }
        private void DeleteBook(Book book)
        {
            books.Remove(book);

            context.Books.Remove(book);
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string search = _textblock_search.Text.ToLower();

            books = new ObservableCollection<Book>(context.Books.Where(a => a.Title.ToLower().Contains(search)).ToList());

            _dataGrid.ItemsSource = books;
        }
    }
}
