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

            foreach (Card card in Cards) {
                if (card.Value == -1) {
                    total += 1;
                }
                else { 
                    total += card.Value;
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
