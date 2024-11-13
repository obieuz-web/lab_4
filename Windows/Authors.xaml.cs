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
        public Author SelectedItem { get; set; }
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
            authorForm.ShowDialog();

            authorForm.Closed += CreateAuthor;


            MessageBox.Show("Dodano autora");
        }

        private void Usun(object sender, RoutedEventArgs e)
        {
            if(!isSelected())
            {
                return;
            }

            context.Authors.Remove((Author)_dataGrid.SelectedItem);

            //context.SaveChanges();

            authors.Remove((Author)_dataGrid.SelectedItem);

            MessageBox.Show("Usunieto autora");
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (!isSelected())
            {
                return;
            }
            Author author = (Author)_dataGrid.SelectedItem;

            context.Authors.Remove(author);

            //context.SaveChanges();
            
            authors.Remove((Author)_dataGrid.SelectedItem);

            AuthorForm authorForm = new AuthorForm(author);
            authorForm.ShowDialog();

            authorForm.Closed += CreateAuthor;

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
            MessageBox.Show("uwu");
            AuthorForm authorForm = (AuthorForm) s;
            if (authorForm.closed)
            {
                return;
            }

            Author author = new Author(authorForm._firstName.Text, authorForm._lastName.Text);

            context.Authors.Add(author);

            context.SaveChanges();

            authors.Add(author);

            MessageBox.Show(author.FirstName);

            _dataGrid.Items.Refresh();
        }
    }
}
