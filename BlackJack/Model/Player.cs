using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model {
    public class Player {
        private int _nextId = 1;
        public int Id { get; private set; }

        public List<Card> Cards { get; set; } = new List<Card>();

        public decimal Bankroll { get; set; }

        public Player(decimal bankRoll) {
            Id = _nextId++;
            Bankroll = bankRoll;
        }

        public void Bet() {
            DisplayBankroll();
            Bankroll -= 10M;
            Console.WriteLine("Bet $10.00.\n");
        }

        public void DisplayCards() {
            foreach (Card card in Cards) {
                if (card.Revealed) {
                    Console.WriteLine($"{card.Rank} of {card.Suite}");
                }
                else {
                    Console.WriteLine("<<Facedown card>>");
                }
            }
            Console.WriteLine();
        }

        public void DisplayBankroll() {
            Console.WriteLine($"Available bankroll: ${Bankroll}");
        }

        public int CalculateHandValue() {
            int total = 0;
            int acesCount = 0;

            foreach (Card card in Cards) {
                if (card.Value == -1) {
                    acesCount++;
                }
                else { 
                    total += card.Value;
                }
            }

            for (int i = 0; i < acesCount; i++) {
                if (total + 11 <= 21) {
                    total += 11;
                }
                else {
                    total++;
                }
            }

            return total;
        }

        public void DiscardHand(Deck deck) {
            foreach (Card card in Cards) {
                deck.DiscardPile.Add(card);
            }

            Cards.Clear();
        }
    }
}
