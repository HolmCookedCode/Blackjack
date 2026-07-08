using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model {
    public class Card {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public Suite Suite { get; set; }

        public Rank Rank { get; set; }

        public int Value { get; set; }
        public bool Revealed { get; set; }

        public Card(Suite suite, Rank rank, bool revealed = false) {
            Id = _nextId++;
            Suite = suite;
            Rank = rank;

            switch (rank) {
                case Rank.Ace:
                    Value = -1;
                    break;
                case Rank.Two:
                    Value = 2;
                    break;
                case Rank.Three:
                    Value = 3;
                    break;
                case Rank.Four:
                    Value = 4; 
                    break;
                case Rank.Five:
                    Value = 5;
                    break;
                case Rank.Six:
                    Value = 6;
                    break;
                case Rank.Seven:
                    Value = 7;
                    break;
                case Rank.Eight:
                    Value = 8;
                    break;
                case Rank.Nine:
                    Value = 9;
                    break;
                case Rank.Ten:
                    Value = 10;
                    break;
                case Rank.Jack:
                    Value = 10;
                    break;
                case Rank.Queen:
                    Value = 10;
                    break;
                case Rank.King:
                    Value = 10;
                    break;
            }

            Revealed = revealed;
        }

        public void Flip() {
            Revealed = !Revealed;
        }
    }
}
