namespace lab_4.Migrations
{
    using lab_4.Classes;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<lab_4.MainWindow.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(lab_4.MainWindow.MyDbContext context)
        {
            context.Authors.AddOrUpdate(
                new Author("John", "Doe"),
                new Author("Jane", "Smith"),
                new Author("Emily", "Johnson"),
                new Author("Michael", "Brown"),
                new Author("Jessica", "Williams"),
                new Author("Daniel", "Jones"),
                new Author("Laura", "Garcia"),
                new Author("David", "Martinez"),
                new Author("Sarah", "Rodriguez"),
                new Author("James", "Hernandez")
            );
            context.Publishers.AddOrUpdate(
                new Publisher("Penguin Random House"),
                new Publisher("HarperCollins"),
                new Publisher("Simon & Schuster"),
                new Publisher("Hachette Livre"),
                new Publisher("Macmillan Publishers"),
                new Publisher("Scholastic"),
                new Publisher("Pearson"),
                new Publisher("Wiley"),
                new Publisher("Springer Nature"),
                new Publisher("Oxford University Press")
            );

            Author[] authors = context.Authors.ToArray();
            Publisher[] publishers = context.Publishers.ToArray();

            context.Books.AddOrUpdate(
                new Book("Book Title 1", new Author("John", "Doe"), new Publisher("Penguin Random House")),
                new Book("Book Title 2", new Author("Michael", "Brown"), new Publisher("Penguin Random House")),
                new Book("Book Title 3", new Author("Michael", "Brown"), new Publisher("Penguin Random House")),
                new Book("Book Title 4", new Author("John", "Doe"), new Publisher("Pearson")),
                new Book("Book Title 5", new Author("David", "Martinez"), new Publisher("Pearson")),
                new Book("Book Title 6", new Author("David", "Martinez"), new Publisher("Penguin Random House")),
                new Book("Book Title 7", new Author("Sarah", "Rodriguez"), new Publisher("Pearson")),
                new Book("Book Title 8", new Author("Sarah", "Rodriguez"), new Publisher("Penguin Random House")),
                new Book("Book Title 9", new Author("Sarah", "Rodriguez"), new Publisher("Oxford University Press"))
                );
        }
    }
}
