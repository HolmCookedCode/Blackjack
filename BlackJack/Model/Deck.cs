using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model {
    public class Deck {
        public int Id { get; set; }

        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck() {
            // Create all 52 cards
            foreach (Suite suite in Enum.GetValues(typeof(Suite))) {
                foreach (Rank rank in Enum.GetValues(typeof(Rank))) {
                    Cards.Add(new Card(suite, rank));
                }
            }
        }
        public void Deal(Player player, bool faceUp) { 
            // TODO
        }

        public void Hit() { 
            // TODO
        }

        public void Shuffle() {
            // Fisher-Yates shuffle
            Random r = new Random();
            int endPointer = Cards.Count;

            while (endPointer > 1) {
                endPointer--;
                int randSpot = r.Next(endPointer + 1);
                var cardValue = Cards[randSpot]; 
                Cards[randSpot] = Cards[endPointer]; 
                Cards[endPointer] = cardValue; 
            }
        }

        public void Display() {
            foreach (Card card in Cards) {
                Console.WriteLine($"{card.Rank} of {card.Suite}");
            }
        }
    }
}
