using Novela.Resources.Models;
using System.Security.Cryptography;
using Android.Bluetooth;
using SQLite;
using Novela.Resources.Enums;

namespace Novela.Resources.Services;

public class Service_Auth
{
    private static Service_Auth _instance;
    public static Service_Auth Instance => _instance ??= new Service_Auth();
    
    private readonly SQLiteConnection  _database;
    
    public User CurrentUser { get; private set; }
    // public bool IsAuthenticated => CurrentUser != null;
    
    // Constructor
    private Service_Auth()
    {
        _database = Service_Database.Instance.database;
    }
    
    #region REGISTER
        public (bool success, string message) Register(string username, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
                return (false, "Username must be at least 3 characters");
            
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                return (false, "Password must be at least 6 characters");
            
            if (password != confirmPassword)
                return (false, "Passwords do not match");
            
            var existingUser = _database.Table<User>()
                .FirstOrDefault(u => u.user_name == username);
            
            if (existingUser != null)
                return (false, "Username already exists");
            
            var newUser = new User
            {
                user_name = username,
                user_pass = password,
                user_theme = User_Theme.Dark
            };
            
            _database.Insert(newUser);
            return (true, "Registration successful!");
        }
    #endregion
    
    #region LOG IN/OUT
        public (bool success, string message) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return (false, "Please enter username and password");
            
            var user = _database.Table<User>()
                .FirstOrDefault(u => u.user_name == username);
            
            if (user == null)
                return (false, "User not found");
            
            if (password != user.user_pass)  return (false, "Incorrect password");
            
            CurrentUser = user;
            return (true, "Login successful!");
        }
    
        public void Logout()
        {
            CurrentUser = null;
        }
    #endregion
    
    
}