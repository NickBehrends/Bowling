using System.Collections.Generic;
using Bowling.Persistence.Singleton.Tables;

namespace Bowling.Persistence.Singleton
{
    public class Database
    {
        private static Database _instance;

        public static Database Instance => _instance ??= new Database();

        public List<Game> Games { get; set; }

        private Database()
        {
            Games = new();
        }
    }
}
