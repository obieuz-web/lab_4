using lab_4.Classes;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using static lab_4.MainWindow;

namespace lab_4.Windows
{
    public partial class Publishers : Window
    {
        private ObservableCollection<Publisher> publishers { get; set; }
        private MyDbContext context { get; set; }
        public Publishers()
        {
            InitializeComponent();

            context = new MyDbContext();
            publishers = new ObservableCollection<Publisher>(context.Publishers.ToList());

            _dataGrid.ItemsSource = publishers;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            PublisherForm publisherForm = new PublisherForm();

            publisherForm.Closed += CreatePublisher;

            publisherForm.ShowDialog();

            context.SaveChanges();

            MessageBox.Show("Dodano wydawce");
        }

        private void Usun(object sender, RoutedEventArgs e)
        {
            if (!isSelected())
            {
                return;
            }
            Publisher Publisher = (Publisher)_dataGrid.SelectedItem;

            DeletePublisher(Publisher);

            MessageBox.Show("Usunieto wydawce");
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (!isSelected())
            {
                return;
            }
            Publisher publisher = (Publisher)_dataGrid.SelectedItem;

            PublisherForm publisherForm = new PublisherForm(publisher);

            publisherForm.Closed += CreatePublisher;

            publisherForm.ShowDialog();

            if(publisherForm.closed)
            {
                return;
            }

            DeletePublisher(publisher);
            MessageBox.Show("Zmodyfikowano wydawnictwo");

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
        private void CreatePublisher(object s, EventArgs ev)
        {
            PublisherForm publisherForm = (PublisherForm)s;
            if (publisherForm.closed)
            {
                return;
            }

            Publisher publisher = new Publisher(publisherForm._Name.Text);

            context.Publishers.Add(publisher);

            context.SaveChanges();

            publishers.Add(publisher);

            _dataGrid.Items.Refresh();
        }
        private void DeletePublisher(Publisher publisher)
        {
            publishers.Remove(publisher);

            var booksToRemove = context.Books.Where(b => b.Publisher.Id == publisher.Id).ToList();
            foreach (var book in booksToRemove)
            {
                context.Books.Remove(book);
            }

            context.Publishers.Remove(publisher);

            context.SaveChanges();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string search = _textblock_search.Text.ToLower();

            publishers = new ObservableCollection<Publisher>(context.Publishers.Where(a => a.Name.ToLower().Contains(search)).ToList());

            _dataGrid.ItemsSource = publishers;
        }
    }
}
