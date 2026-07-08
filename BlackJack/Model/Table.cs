using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model {
    public class Table {
        public List<Player> Players { get; set; }

        public Deck Deck { get; set; }

        public void SetupGame() {
            Deck.Shuffle();

            foreach (var player in Players) { 
                
            }
        }
    }
}
