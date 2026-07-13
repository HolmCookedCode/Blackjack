using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model {
    public class Table {
        public List<Player> Players { get; set; } = new List<Player>();

        public Player Dealer { get; set; } = new Player(0);

        public Deck Deck { get; set; } = new Deck();

        public void SetupGame() {
            Deck.Shuffle();

            foreach (var player in Players) { 
                Deck.Deal(player);
            }

            Deck.Deal(Dealer);

            foreach (var player in Players) {
                Deck.Deal(player);
            }

            Deck.Deal(Dealer, false);
        }

        public void PlaceBets() {
            foreach (Player player in Players) {
                player.Bet();
            }
        }

        public void DisplayDealerCards() {
            Console.WriteLine("Dealer Cards:");
            Dealer.DisplayCards();
        }
    }
}
