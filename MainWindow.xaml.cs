using lab_4.Classes;
using lab_4.Windows;
using System.Data.Entity;
using System.Windows;


namespace lab_4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class MyDbContext : DbContext
        {
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Publisher> Publishers { get; set; }
        }

        private void NavigateToAuthors(object sender, RoutedEventArgs e)
        {
            Authors authors_window = new Authors();
            authors_window.Show();
        }

        private void NavigateToPublishers(object sender, RoutedEventArgs e)
        {
            Publishers publishers_window = new Publishers();
            publishers_window.Show();
        }

        private void NavigateToBooks(object sender, RoutedEventArgs e)
        {
            Books books_window = new Books();
            books_window.Show();
        }
    }
}
