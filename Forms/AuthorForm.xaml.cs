using System.Windows;
using lab_4.Classes;


namespace lab_4
{
    /// <summary>
    /// Logika interakcji dla klasy AuthorForm.xaml
    /// </summary>
    public partial class AuthorForm : Window
    {
        public bool closed { get; set; } = false;
        public AuthorForm(Author author)
        {
            InitializeComponent();

            _firstName.Text = author.FirstName;
            _lastName.Text = author.LastName;
        }
        public AuthorForm()
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
