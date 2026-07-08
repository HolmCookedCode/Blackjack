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
    }
}
