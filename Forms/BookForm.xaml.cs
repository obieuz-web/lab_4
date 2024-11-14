using System.Linq;
using System.Windows;
using lab_4.Classes;
using static lab_4.MainWindow;


namespace lab_4
{
    /// <summary>
    /// Logika interakcji dla klasy AuthorForm.xaml
    /// </summary>
    public partial class BookForm : Window
    {
        public bool closed { get; set; } = false;
        public BookForm(Book book)
        {
            InitializeComponent();

            InitComboBoxes(book);

            _title.Text = book.Title;

            MessageBox.Show(book.Author.ToString());
            
        }
        public BookForm()
        {
            InitializeComponent();

            InitComboBoxes(null);
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
        private void InitComboBoxes(Book book)
        {

            using (var context = new MyDbContext())
            {
                foreach (var item in context.Authors)
                {
                    _author.Items.Add(item);
                }
                foreach (var item in context.Publishers)
                {
                    _publisher.Items.Add(item);
                }
                if (book != null)
                {
                    if (book.Author != null)
                    {
                        _author.SelectedItem = context.Authors.Where(a => a.Id == book.Author.Id).First();
                    }
                    if(book.Publisher != null)
                    {
                        _publisher.SelectedItem = context.Publishers.Where(p => p.Id == book.Publisher.Id).First();
                    }
                }
            }
        }
    }
}
