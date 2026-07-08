using BlackJack.Model;

Table table  = new Table();
Player player = new Player(100M);
table.SetupGame();

bool playing = true;
while (playing) {
    table.PlaceBets();
    player.DisplayCards();

    while (true) {
        Console.WriteLine();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("h = Hit. s = Stay.");
        var input = Console.ReadLine();
        switch (input) {
            case "h":
                table.Deck.Deal(player);
                break;
            case "s":
                break;
            default:
                Console.WriteLine("Unrecognized command.");
                break;
        }
    }
}