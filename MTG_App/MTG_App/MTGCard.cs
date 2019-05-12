using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MTG_App
{
   
    public class MTGCard
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string name { get; set; }
        public string imageURL { get; set; }
    }
}
