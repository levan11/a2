namespace Lecture10_Gr2
{
    // services implementation
    public class BookService : IBookService
    {
        // inject dbcontext
        public BookDbContext bookDbContextt { get; set; }

        public BookService(BookDbContext bookDbContext)
        {
            bookDbContextt = bookDbContext;
        }

        public List<Wigni> GetAllBooks()
        {
            var books = bookDbContextt.Wignebi;

            return books.ToList();
        }

        public Wigni GetBookById(int id)
        {
            var book = bookDbContextt.Wignebi.FirstOrDefault(x => x.Id == id);

            var bookForReturn = new Wigni()
            {
                Id = id,
                Title = "Demo",
                AuthorName = "AuthorDemo",
                CreateYear = 2010
            };

            return bookForReturn;
        }

        public void AddBook(Wigni book)
        {
            bookDbContextt.Wignebi.Add(book);

            bookDbContextt.SaveChangesAsync();
        }

        public void UpdateBook(int id, Wigni book)
        {
            var bookInDb = bookDbContextt.Wignebi.FirstOrDefault(x => x.Id == id);

            if (bookInDb != null) 
            {
                bookInDb.Title = book.Title;
                bookInDb.AuthorName = book.AuthorName;
                bookInDb.CreateYear = book.CreateYear;
            }

            bookDbContextt.SaveChangesAsync();
        }

        public void DeleteBook(int id)
        {
            var bookInDb = bookDbContextt.Wignebi.FirstOrDefault(x => x.Id == id);

            if (bookInDb != null)
            {
                bookDbContextt.Wignebi.Remove(bookInDb);
            }

            bookDbContextt.SaveChangesAsync();
        }

        public List<Wigni> GetBooksByAuthor(string AuthorName)
        {
            var booksByAuthor = bookDbContextt.Wignebi
                .Where(x => x.AuthorName == AuthorName)
                .ToList();

            return booksByAuthor;
        }

        public List<Wigni> GetBooksByTitle(string Title)
        {
            var booksByTitle = bookDbContextt.Wignebi
                .Where(x => x.Title == Title)
                .ToList();

            return booksByTitle;
        }
        public void UpdateBookName(string currentTitle, string newName)
        {
            var bookInDb = bookDbContextt.Wignebi.FirstOrDefault(x => x.Title == currentTitle);

            if (bookInDb != null)
            {
                bookInDb.Title = newName;
            }

            bookDbContextt.SaveChangesAsync();
        }
    }
}
