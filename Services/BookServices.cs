using _03_onlinelibrary_api.Entities;

namespace _03_onlinelibrary_api.Services;

public class BookServices
{
  public readonly List<Book> _books = [];

  public List<Book> GetBooks() => _books;

  public void AddBook(Book book) => _books.Add(book);

  public Book GetBookById(int id)
  {
    var book = _books.FirstOrDefault(book => book.Id == id) ?? throw new Exception("Book not found");

    return book;
  }
}
