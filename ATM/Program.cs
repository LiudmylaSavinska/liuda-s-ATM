Dictionary<string, (string, double)> userAccounts = new Dictionary<string, (string, double)>();
string activeUser = null;
var activeService = true;

while (activeService)
{
    Console.WriteLine("Hello, please, choose an operation you would like to perform: \n Log in, \n Sign in, \n Leave");
    var userOption = Console.ReadLine();
    switch (userOption)
    {
        case "Log in":
            LogIn();
            break;

        case "Sign in":
            SignIn();
            break;

        case "Leave":
            Console.WriteLine("Have a nice day, bye!");
            activeService = false;
            break;

        default:
            Console.WriteLine("Please, select a valid option");
            break;
    }

    while (activeUser != null)
    {
        Console.WriteLine("How can we help you today: \n Check Balance, \n Deposit, \n Withdraw, \n Log out");
        var menuATM = Console.ReadLine();
        switch (menuATM)
        {
            case "Check Balance":
                CheckBalance();
                break;

            case "Deposit":
                FinancialOperation(true);
                break;

            case "Withdraw":
                FinancialOperation(false);
                break;

            case "Log out":
                Console.Clear();
                Console.WriteLine("Thank you for using our service, good bye!");
                activeUser = null;
                break;

            default:
                Console.WriteLine("Please, select a valid option");
                break;
        }
    }
}

void CheckBalance()
{
    Console.WriteLine($"Your current balance is: ${userAccounts[activeUser].Item2}");
    Console.WriteLine("Click any button to return to the menu");
    Console.ReadKey();
}

void FinancialOperation(bool isDeposit)
{
    var correctInput = false;
    while (!correctInput)
    {
        Console.WriteLine("Please, enter the amount");
        var depositAmount = Console.ReadLine();
        if (double.TryParse(depositAmount, out double result))
        {
            if (!isDeposit && userAccounts[activeUser].Item2 - result < 0)
            {
                Console.WriteLine("You have insufficient funds on your account");
            }
            else
            {
                userAccounts[activeUser] = isDeposit
                    ? (userAccounts[activeUser].Item1, userAccounts[activeUser].Item2 + result)
                    : (userAccounts[activeUser].Item1, userAccounts[activeUser].Item2 - result);
                string operationMessage = isDeposit ? "deposited to" : "withdrawn from";
                Console.WriteLine($"{depositAmount} has been {operationMessage} your account.");
                correctInput = true;
            }
        }
        else
        {
            Console.WriteLine("Please try again");
        }
    }
}

void SignIn()
{
    var validNickname = false;
    while (!validNickname)
    {
        Console.WriteLine("Please, enter your nickname");
        var userNickname = Console.ReadLine();
        if (userAccounts.ContainsKey(userNickname))
        {
            Console.WriteLine("Your account already exists");
        }
        else
        {
            Console.WriteLine("Please, enter your password");
            var userPassword = Console.ReadLine();

            userAccounts.Add(userNickname, (userPassword, 0));
            Console.WriteLine("Thank you for your registration!");
        }
    }
}

void LogIn()
{
    var correctCredentials = false;
    while (!correctCredentials)
    {
        Console.WriteLine("Please, enter your nickname");
        var userNickname = Console.ReadLine();

        Console.WriteLine("Please, enter your password");
        var userPassword = Console.ReadLine();

        if (userAccounts[userNickname].Item1 == userPassword)
        {
            Console.WriteLine("You have successfully logged in!");
            activeUser = userNickname;
            correctCredentials = true;
        }
        else
        {
            Console.WriteLine("Please, enter valid credentials or sign in");
        }
    }
}