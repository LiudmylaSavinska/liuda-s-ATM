Dictionary<string, string> userAccount = new Dictionary<string, string>();

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
        break;

    default:
        Console.WriteLine("Please, select a valid option");
        break;
}

void SignIn()
{
    Console.WriteLine("Please, enter your nickname");
    var userNickname = Console.ReadLine();

    Console.WriteLine("Please, enter your password");
    var userPassword = Console.ReadLine();

    userAccount.Add(userNickname, userPassword);
    Console.WriteLine("Thank you for your registration!");
}

void LogIn()
{
    Console.WriteLine("Please, enter your nickname");
    var userNickname = Console.ReadLine();

    Console.WriteLine("Please, enter your password");
    var userPassword = Console.ReadLine();

    if (userAccount[userNickname] == userPassword)
    {
        Console.WriteLine("You have successfully logged in!");
    }
    else
    {
        Console.WriteLine("Please, enter valid credentials");
    }
}
