using SQLite;
using Novela.Resources.Models;
using Novela.Resources.Models.Book_Models;

namespace Novela.Resources.Services;

public class Service_Database
{
    private static Service_Database _instance;
    public static Service_Database  Instance => _instance ??= new Service_Database();
    
    private readonly SQLiteConnection _database;
    public SQLiteConnection database => _database;
    
    // Constructor
    private Service_Database()
    {
        var dbPath = Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "novela.db3" );
        
        _database = new SQLiteConnection(dbPath);
        
        InitializeTables();
    }
    
        private void InitializeTables()
        {
            _database.CreateTable<User>();
            _database.CreateTable<Book>();
            _database.CreateTable<Book_Character>();
            
            _database.CreateTable<Book_Section>();
                _database.CreateTable<Book_Chapter>();
        
            // _database.CreateTable<Book_Era>();
            //     _database.CreateTable<Book_Event>();
            //     
            // _database.CreateTable<Book_AppendixCategory>();
            //     _database.CreateTable<Book_AppendixCategory>();
            //         _database.CreateTable<Book_AppendixItem>();
        }
    
    
    
}