// begin main

int pointsAmount = 0;
int coinsAmount = 5;
Random rand = new Random();

Console.Write("Enter your name: ");
string playerName = Console.ReadLine();
Console.Clear();
Console.WriteLine($"Welcome, {playerName}! You start with {coinsAmount} gold coins and {pointsAmount} fishing points.");

GetMenuChoice(ref coinsAmount, ref pointsAmount, rand);

// end main

static void GetMenuChoice(ref int coinsAmount, ref int pointsAmount, Random rand)
{
    while (true)
    {
        Console.Clear();
        if (coinsAmount <= 0)
        {
            Console.WriteLine("You have run out of coins. Game Over!");
            Console.WriteLine("Press any key to restart.");
            Console.ReadKey();
            coinsAmount = 5;
            pointsAmount = 0;
            continue;
        }

        if (pointsAmount >= 15)
        {
            Console.WriteLine("Congratulations! You've earned enough points and won the game!");
            Console.WriteLine("Press any key to restart.");
            Console.ReadKey();
            coinsAmount = 5;
            pointsAmount = 0;
            continue;
        }

        DisplayMenu();
        string userInput = Console.ReadLine();

        while (!ValidMenuChoice(userInput))
        {
            Console.WriteLine("Invalid menu choice. Please try again.");
            Console.ReadKey();
            Console.Clear();
            DisplayMenu();
            userInput = Console.ReadLine();
        }

        switch (userInput)
        {
            case "1": PlayCardGame(ref coinsAmount); break;
            case "2": GoFishing(ref coinsAmount, ref pointsAmount, rand); break;
            case "3": ViewStatus(coinsAmount, pointsAmount); break;
            case "4":
                Console.WriteLine("Exiting game. Goodbye!");
                return;
        }
    }
}

static void DisplayMenu()
{
    Console.WriteLine("\nMake menu selection:");
    Console.WriteLine("1 - Play card game (earn gold)");
    Console.WriteLine("2 - Go fishing (earn points)");
    Console.WriteLine("3 - View coins and points");
    Console.WriteLine("4 - Exit");
}

static bool ValidMenuChoice(string userInput)
{
    return userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4";
}

static string[] GetCard()
{
    const int MAX_CARDS = 52;
    string[] cards = new string[MAX_CARDS];

    if (!File.Exists("cardgame.txt"))
    {
        Console.WriteLine("Error: cardgame.txt not found.");
        Console.ReadKey();
        return new string[0];
    }

    StreamReader infile = new StreamReader("cardgame.txt");
    int count = 0;

    while (!infile.EndOfStream && count < MAX_CARDS)
    {
        cards[count] = infile.ReadLine();
        count++;
    }

    infile.Close();
    return cards;
}

static string GetRandomCard()
{
    string[] cards = GetCard();
    Random rnd = new Random();
    int cardIndex = rnd.Next(0, cards.Length);
    return cards[cardIndex];
}

static string GetTwist()
{
    string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    Random rnd = new Random();
    return suits[rnd.Next(0, suits.Length)];
}

static void PlayCardGame(ref int coinsAmount)
{
    Console.Clear();
    Console.WriteLine("Welcome to the card game of War!");
    Console.Write($"Enter your bet amount (You have {coinsAmount} coins): ");

    if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0 || bet > coinsAmount)
    {
        Console.WriteLine("Invalid bet amount.");
        Console.ReadKey();
        return;
    }

    string trumpSuit = GetTwist();
    string userCard = GetRandomCard();
    string oldManCard = GetRandomCard();

    Console.WriteLine($"\nTrump Suit: {trumpSuit}");
    Console.WriteLine($"You drew: {userCard}");
    Console.WriteLine($"Old Man drew: {oldManCard}");

    if (userCard[0] > oldManCard[0])
    {
        coinsAmount += bet;
        Console.WriteLine("You won! Your coins have doubled.");
    }
    else
    {
        coinsAmount -= bet;
        Console.WriteLine("You lost! Your coins are gone.");
    }

    Console.ReadKey();
}

static void GoFishing(ref int coinsAmount, ref int pointsAmount, Random rand)
{
    Console.Clear();
    Console.WriteLine("Choose your bait:");
    Console.WriteLine("1. Normal Bait (3 gold) - For bass");
    Console.WriteLine("2. Special Bait (5 gold) - For sharks");
    Console.WriteLine("3. Super Bait (7 gold) - For whales");

    string choice = Console.ReadLine();
    int cost = choice == "1" ? 3 : choice == "2" ? 5 : choice == "3" ? 7 : 0;

    if (cost == 0 || coinsAmount < cost)
    {
        Console.WriteLine("Invalid choice or insufficient coins.");
        Console.ReadKey();
        return;
    }

    coinsAmount -= cost;
    int fishChance = rand.Next(100);
    string fish = fishChance < 50 ? "Bass" : fishChance < 80 ? "Shark" : fishChance < 95 ? "Whale" : "Golden Fish";

    if (fish == "Golden Fish")
    {
        pointsAmount = 15;
        Console.WriteLine("You caught a rare Golden Fish! You instantly win!");
    }
    else if ((fish == "Bass" && choice == "1") || (fish == "Shark" && choice == "2") || (fish == "Whale" && choice == "3"))
    {
        int pointsEarned = fish == "Bass" ? 4 : fish == "Shark" ? 6 : 10;
        pointsAmount += pointsEarned;
        Console.WriteLine($"You caught a {fish} and earned {pointsEarned} points!");
    }
    else
    {
        Console.WriteLine($"You encountered a {fish}, but had the wrong bait! It escaped.");
    }

    Console.ReadKey();
}

static void ViewStatus(int coinsAmount, int pointsAmount)
{
    Console.Clear();
    Console.WriteLine($"Gold Coins: {coinsAmount}, Fishing Points: {pointsAmount}/15");
    Console.ReadKey();
}
