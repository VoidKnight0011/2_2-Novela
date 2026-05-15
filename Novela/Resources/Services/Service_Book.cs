using CommunityToolkit.Maui.Converters;
using SQLite;
using Novela.Resources.Models.Book_Models;
using Novela.Resources.Enums;

namespace Novela.Resources.Services;

public class Service_Book
{
    private static Service_Book _instance;
    public static Service_Book Instance => _instance ??= new Service_Book();
    
    private readonly SQLiteConnection _database;

    // Constructor
    private Service_Book()
    {
        _database = Service_Database.Instance.database;
    }
    
    public Book CurrentBook {get; set;}
    
    #region GetBooks
        public List<Book> get_userbooks(int userId)
        {
            return _database.Table<Book>()
                .Where(n => n.user_id == userId)
                .ToList();
        }

        public List<Book> get_userbooks_status(int userId, Status status)
        {
            return _database.Table<Book>()
                .Where(n => n.user_id == userId && n.book_status == status)
                .ToList();
        }
    #endregion
    
        // #region SearchBooks
        //
        // public List<Book> get_userbook_search(int userId, string search)
        // {
        //     if (string.IsNullOrWhiteSpace(search)) return get_userbooks(userId);
        //     return _database.Table<Book>()
        //         .Where(n => n.user_id == userId
        //                     && n.book_title.ToLower().Contains(search.ToLower()))
        //         .ToList();
        // }
        // #endregion
    
    #region CreateBooks
        public int create_book(Book book)
        {
            return _database.Insert(book);
        }
    #endregion
    
    #region UpdateBooks

        public int update_book(Book book)
        {
            return _database.Update(book);
        }
    #endregion
    
    #region DeleteBooks

        public int delete_book(int bookId)
        {
            return _database.Delete<Book>(bookId);
        }
    #endregion
}