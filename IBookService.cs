namespace Lecture10_Gr2
{
    // services interface
    public interface IBookService
    {
        public List<Wigni> GetAllBooks();
        public Wigni GetBookById(int id);
        public void AddBook(Wigni book);
        public void UpdateBook(int id, Wigni book);
        public void DeleteBook(int id);
        public List <Wigni> GetBooksByAuthor(string AuthorName);
        public List<Wigni> GetBooksByTitle(string Title);
        public void UpdateBookName(string currentTitle, string newName);
    }
}
