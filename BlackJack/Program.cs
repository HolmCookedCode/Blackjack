using BlackJack.Model;

Table table  = new Table();
Player player = new Player(100M);
table.Players.Add(player);

bool playing = true;

while (playing) {
    // place bet, deal starting cards
    table.SetupGame();
    table.PlaceBets();
    table.DisplayDealerCards();

    bool hitOrStand = true;
    bool busted = false;

    while (hitOrStand) {
        // offer hit or stand, update player's hand
        player.DisplayCards();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("h: Hit. s: Stand.");

        var input = Console.ReadLine();
        switch (input) {
            case "h":
                // hit
                table.Deck.Deal(player);
                if (player.CalculateHandValue() > 21) {
                    busted = true;
                    hitOrStand = false;
                }
                break;
            case "s":
                // stand
                hitOrStand = false;
                break;
            default:
                Console.WriteLine("Unrecognized input.");
                break;
        }
    }

    if (busted) {
        // player busted — no need for the dealer to even play
        Console.WriteLine("Busted. Bet lost.");
    }
    else {

        table.Dealer.Cards[1].Revealed = true;

        while (table.Dealer.CalculateHandValue() < 17) {
            // dealer draws automatically, no choice involved
            table.Deck.Deal(table.Dealer);
        }

        // compare final hands — ONE check, not a loop
        int dealerHandValue = table.Dealer.CalculateHandValue();
        bool dealerBusted = dealerHandValue > 21;
        int playerHandValue = player.CalculateHandValue();
        if (dealerBusted || dealerHandValue < playerHandValue) {
            Console.WriteLine("You win!");
            player.Bankroll += 20M;
        }
        else if (dealerHandValue == playerHandValue) {
            Console.WriteLine("Draw. Bet returned.");
            player.Bankroll += 10M;
        }
        else {
            Console.WriteLine("Beat by dealer. Bet lost.");
        }
    }

    bool continueCheck = true;
    player.DisplayBankroll();
    while (continueCheck) {
        Console.WriteLine("Another round? Y/N");
        var input = Console.ReadLine();

        switch (input.ToUpper()) {
            case "Y":
                continueCheck = false;
                break;
            case "N":
                continueCheck = false;
                playing = false;
                break;
            default:
                Console.WriteLine("Unrecognized input.");
                break;
        }
    }
}