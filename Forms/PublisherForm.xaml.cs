using System.Windows;
using lab_4.Classes;


namespace lab_4
{
    /// <summary>
    /// Logika interakcji dla klasy AuthorForm.xaml
    /// </summary>
    public partial class PublisherForm : Window
    {
        public bool closed { get; set; } = false;
        public PublisherForm(Publisher publisher)
        {
            InitializeComponent();

            _Name.Text = publisher.Name;
        }
        public PublisherForm()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, RoutedEventArgs args)
        {
            closed = true;
            this.Close();
        }
        private void Dodaj(object sender, RoutedEventArgs args)
        {
            this.Close();
        }
    }
}
