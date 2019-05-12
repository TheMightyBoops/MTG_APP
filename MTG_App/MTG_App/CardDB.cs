using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace MTG_App
{
    public class CardDB
    {
        readonly SQLiteAsyncConnection _database;

        public CardDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MTGCard>().Wait();
        }

        public Task<List<MTGCard>> GetCardsAsync()
        {
            return _database.Table<MTGCard>().ToListAsync();
        }

        public Task<MTGCard> GetCardAsync(int id)
        {
            return _database.Table<MTGCard>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCardAsync(MTGCard card)
        {
            if (card.ID != 0)
            {
                return _database.UpdateAsync(card);
            }
            else
            {
                return _database.InsertAsync(card);
            }
        }

        public Task<int> DeleteCardAsync(MTGCard card)
        {
            return _database.DeleteAsync(card);
        }

    }
}
