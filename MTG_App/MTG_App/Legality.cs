﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MTG_App
{
    public class Legality
    {
        public string format { get; set; }
        public string legality { get; set; }
    }

    public class Card
    {
        public string name { get; set; }
        public string manaCost { get; set; }
        public double cmc { get; set; }
        public List<string> colors { get; set; }
        public List<string> colorIdentity { get; set; }
        public string type { get; set; }
        public List<object> supertypes { get; set; }
        public List<string> types { get; set; }
        public List<object> subtypes { get; set; }
        public string rarity { get; set; }
        public string set { get; set; }
        public string setName { get; set; }
        public string text { get; set; }
        public string artist { get; set; }
        public string number { get; set; }
        public string layout { get; set; }
        public int multiverseid { get; set; }
        public string imageUrl { get; set; }
        public string loyalty { get; set; }
        public List<object> rulings { get; set; }
        public List<object> foreignNames { get; set; }
        public List<string> printings { get; set; }
        public string originalText { get; set; }
        public string originalType { get; set; }
        public List<Legality> legalities { get; set; }
        public string id { get; set; }
        public string flavor { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public string watermark { get; set; }
        public List<object> names { get; set; }
    }

    public class RootObject
    {
        public List<Card> cards { get; set; }
    }
}
