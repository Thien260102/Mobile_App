using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace English4Kids
{
    public class Connect_Database
    {
        static SQLiteConnection _database;
        public static string dbPath { get; } =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DoAn.db");
        
        static Connect_Database()
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Word>();
            _database.CreateTable<User>();
            _database.CreateTable<Studied>();

            if (GetWord() == null)
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                using (Stream stream = assembly.GetManifestResourceStream("English4Kids.DoAn.db"))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        File.WriteAllBytes(Connect_Database.dbPath, memoryStream.ToArray());
                    }
                }

            }
        }
        public static List<Word> GetWord()
        {
            return _database.Table<Word>().ToList();
        }
        public static List<User> GetUser()
        {
            return _database.Table<User>().ToList();
        }
        public static User CheckUser(string userName)
        {
            return _database.Find<User>(userName);
        }
        public static void Signup(User user)
        {
            _database.Execute("Insert into USER Values " +
                "('" + user.USERNAME + "', '" + user.HOTEN + "', '" + user.PASSWORD + "', '" + user.EMAIL + "')");
        }
        public static void InsertStudied(Studied studied)
        {
            _database.Execute("Insert into DAHOC Values " +
                   "('" + studied.USERNAME + "', " + studied.MATU + ")");
        }
        public static List<Studied> GetStudied()
        {
            return _database.Table<Studied>().ToList();
        }
        public static List<Studied> GetStudiedByUSERNAME(string userName)
        {
            List<Studied> stuied = new List<Studied>();
            foreach (var item in GetStudied())
                if (item.USERNAME == userName)
                    stuied.Add(item);
            return stuied;
        }
        public static void DeleteAllStudied()
        {
            _database.DeleteAll<Studied>();
        }
        public static Word GetWordByMATU(int MaTu)
        {
            return _database.Find<Word>(MaTu);
        }
        //public static void DeleteAllUser()
        //{
        //    _database.DeleteAll<User>();
        //}


    }
}
