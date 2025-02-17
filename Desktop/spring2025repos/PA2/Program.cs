// extras - reverse currency, console clears, pause clear, name prompting

// begin main
Console.Clear();
string userName = GetUserName();
string userInput = GetMenuChoice(userName);

// loop for menu
while (true){
    if (userInput == "1"){
        CurrencyConversion(userName);
    }
    if (userInput == "2"){
        ShippingInvoiceSystem();
    }
    if (userInput == "4"){
        System.Console.WriteLine($"Goodbye {userName}!");
        break;
    }
    if (userInput == "3")
        ReverseCurrencyConversion(userName);
    else{
        System.Console.WriteLine("Invalid input. Please select a valid option.");
    }
    userInput = GetMenuChoice(userName);
}

// end main

static string GetMenuChoice(string userName){
    ShowMenu(userName);
    string userInput = Console.ReadLine();
    return userInput;
}

static void ShowMenu(string userName){
    Console.Clear();
    System.Console.WriteLine($"{userName}, please make a selection.\n1 To USD Currency Conversion\n2 Shipping Invoice System\n3 From USD Currency Conversion\n4 Exit");
}

static string GetUserName(){ // prompts user for name 
    System.Console.WriteLine("Hi! Please enter your name.");
    string userName = Console.ReadLine();
    return userName; 
}

static void PauseBeforeClear(){ // clears console without clearing output
    System.Console.WriteLine("Press any key to continue...");
    Console.ReadKey(); // wait for user input before clearing the screen
    Console.Clear();
}

static void CurrencyConversion(string userName){ // currency conversion menu logic
    CurrencyConversionMenu();
    string currencyChoice = Console.ReadLine();
    while(true){
        if (currencyChoice == "1"){
            JapaneseYen();
            break;
        } 
        if (currencyChoice == "2"){
            ChineseYuan();
            break;
        }
        if (currencyChoice == "3"){
            BritishPound();
            break;
        }
        if (currencyChoice == "4"){
            Doubloons();
            break;
        }
        if (currencyChoice == "5"){
            AlgerianDinar();
            break;
        }
        if (currencyChoice == "6"){
            GetMenuChoice(userName);
        }
        else{
            System.Console.WriteLine("Selection invalid. Please try again.");
            break;
        }
    }
    PauseBeforeClear();
}

static void CurrencyConversionMenu(){
    System.Console.WriteLine("What currency would you like to convert to/from?\n1 Japanese Yen\n2 Chinese Yuan\n3 British Pound\n4 Doubloons\n5 Algerian Dinar\n6 Back to main menu");
}

static void ShippingInvoiceSystem(){
    // prompt for weight
    Console.WriteLine("How many tons does your item weigh?");
    double weight = double.Parse(Console.ReadLine());

    // calculate base price
    double pricePerTon = 220.40;
    double total = weight * pricePerTon;

    // check for perishable items
    string perishableInput;
    bool validPerishable = false;
        while (!validPerishable){
            Console.WriteLine("Is your shipment perishable? (yes/no)");
            perishableInput = Console.ReadLine().ToLower();
        if (perishableInput == "yes"){
            total += weight * 230; // add $230 per ton
            validPerishable = true; // valid input, exit loop
            }
        else if (perishableInput == "no"){
            validPerishable = true; // valid input, exit loop
            }
        else{
            Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            }
        }

    // check for express shipping
    string expressInput;
    bool validExpress = false;
        while (!validExpress){
            Console.WriteLine("Is this an express shipment? (yes/no)");
            expressInput = Console.ReadLine().ToLower();
        if (expressInput == "yes"){
            total *= 1.25; // add 25% to the total
            validExpress = true; // valid input, exit loop
            }
        else if (expressInput == "no"){
            validExpress = true; // valid input, exit loop
            }
        else{
            Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            }
        }

        // display the total
        Console.WriteLine($"Total amount due: ${total:F2}");

        // prompt for payment
        Console.WriteLine("Enter the amount paid:");
        double amountPaid = double.Parse(Console.ReadLine());

        // check if payment is enough
        if (amountPaid < total){
            Console.WriteLine("Error: Insufficient payment. Please pay the full amount.");
        }
        else{
            double change = amountPaid - total;
            Console.WriteLine($"Payment accepted. Change due: ${change:F2}");
        }
    PauseBeforeClear();
}


static void GetWeight(){
    System.Console.WriteLine("How many tons does your item weigh?");
}

static void JapaneseYen(){
    // create variables 
    double yen = 0;
    double usd = 0;
    double yenConversion = 0.0064;

    // prompt user for amount $$$
    System.Console.WriteLine("How much money do you have in yen?");

    // actual conversion math 
    yen = double.Parse(Console.ReadLine());
    usd = yen * yenConversion;

    //display total amount $$$
    System.Console.WriteLine($"You have ${usd} in USD.");
    
    PauseBeforeClear();
} // currency conversion process is same for all types

static void ChineseYuan(){
    double yuan = 0;
    double usd = 0;
    double yuanConversion = 0.14;
    System.Console.WriteLine("How much money do you have in yuan?");
    yuan = double.Parse(Console.ReadLine());
    usd = yuan * yuanConversion;
    System.Console.WriteLine($"You have ${usd} in USD.");
    PauseBeforeClear();
}

static void BritishPound(){
    double pound = 0;
    double usd = 0;
    double poundConversion = 1.22;
    System.Console.WriteLine("How much money do you have in pounds?");
    pound = double.Parse(Console.ReadLine());
    usd = pound * poundConversion;
    System.Console.WriteLine($"You have ${usd} in USD.");
    PauseBeforeClear();
}

static void Doubloons(){
    double doubloon = 0;
    double usd = 0;
    double doubloonConversion = 8.40;
    System.Console.WriteLine("How many doubloons do you have?");
    doubloon = double.Parse(Console.ReadLine());
    usd = doubloon * doubloonConversion;
    System.Console.WriteLine($"You have ${usd} in USD.");
    PauseBeforeClear();
}

static void AlgerianDinar(){
    double dinar = 0;
    double usd = 0;
    double dinarConversion = 0.0074;
    System.Console.WriteLine("How much money do you have in dinar?");
    dinar = double.Parse(Console.ReadLine());
    usd = dinar * dinarConversion;
    System.Console.WriteLine($"You have ${usd} in USD.");
    PauseBeforeClear();
}

static void ReverseCurrencyConversion(string userName){ // reverse currency conversion menu logic
    CurrencyConversionMenu();
    string currencyChoice = Console.ReadLine();
    while(true){
        if (currencyChoice == "1"){
            ReverseJapaneseYen();
            break;
        } 
        if (currencyChoice == "2"){
            ReverseChineseYuan();
            break;
        }
        if (currencyChoice == "3"){
            ReverseBritishPound();
            break;
        }
        if (currencyChoice == "4"){
            ReverseDoubloons();
            break;
        }
        if (currencyChoice == "5"){
            ReverseAlgerianDinar();
            break;
        }
        if (currencyChoice == "6"){
            GetMenuChoice(userName);
        }
        else{
            System.Console.WriteLine("Selection invalid. Please try again.");
            break;
        }
    }
    PauseBeforeClear();
}

static void ReverseJapaneseYen(){
    // create variables 
    double yen = 0;
    double usd = 0;
    double yenConversion = 156.25;

    // prompt user for amount $$$
    System.Console.WriteLine("How much money do you have in USD?");

    // actual conversion math 
    yen = double.Parse(Console.ReadLine());
    usd = yen * yenConversion;

    //display total amount $$$
    System.Console.WriteLine($"You have ${usd} in yen.");

    PauseBeforeClear();
} // currency conversion process is same for all types

static void ReverseChineseYuan(){
    double yuan = 0;
    double usd = 0;
    double yuanConversion = 7.14;
    System.Console.WriteLine("How much money do you have in USD?");
    yuan = double.Parse(Console.ReadLine());
    usd = yuan * yuanConversion;
    System.Console.WriteLine($"You have ${usd} in yuan.");
    PauseBeforeClear();
}

static void ReverseBritishPound(){
    double pound = 0;
    double usd = 0;
    double poundConversion = 0.82;
    System.Console.WriteLine("How much money do you have in USD?");
    pound = double.Parse(Console.ReadLine());
    usd = pound * poundConversion;
    System.Console.WriteLine($"You have ${usd} in pounds.");
    PauseBeforeClear();
}

static void ReverseDoubloons(){
    double doubloon = 0;
    double usd = 0;
    double doubloonConversion = 0.12;
    System.Console.WriteLine("How much money do you have in USD?");
    doubloon = double.Parse(Console.ReadLine());
    usd = doubloon * doubloonConversion;
    System.Console.WriteLine($"You have ${usd} doubloons.");
    PauseBeforeClear();
}

static void ReverseAlgerianDinar(){
    double dinar = 0;
    double usd = 0;
    double dinarConversion = 135.14;
    System.Console.WriteLine("How much money do you have in USD?");
    dinar = double.Parse(Console.ReadLine());
    usd = dinar * dinarConversion;
    System.Console.WriteLine($"You have ${usd} in dinar.");
    PauseBeforeClear();
}