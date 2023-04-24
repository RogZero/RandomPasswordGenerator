

namespace passwordM;


public class passwordGenerator
{
    static int StringToInt(string? inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString))
        {
            throw new ArgumentException("Input string is null or whitespace.", nameof(inputString));
        }

        if (!int.TryParse(inputString, out int intValue))
        {
            throw new ArgumentException("Input string is not a valid integer.", nameof(inputString));
        }

        return intValue;
    }
    static int randomCharGen(int firstNumber, int secondNumber)
    {
        Random rand = new Random();

        int randomNumber = rand.Next(firstNumber, secondNumber);

        return randomNumber;
    }
    // ~~~~~~~~~~~~~~~ Main ~~~~~~~~~~~~~~~
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the password Manager!");
        Console.Write("Input the password's length: ");

        string? readToInt = Console.ReadLine();
        int passwordLength = StringToInt(readToInt);

        Console.Write("Input the complexity of the password simple(1), moderate(2) or complex(3): ");

        readToInt = Console.ReadLine();
        int complexityOption = StringToInt(readToInt);

        string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";

        string password = ""; 

        int firstNumber = 1, lastNumber;

        if (complexityOption == 1)
        {
            lastNumber = 52;
        }
        else if (complexityOption == 2)
        {
            lastNumber = 62;
        }
        else if (complexityOption == 3)
        {
            lastNumber = 72;
        }
        else
        {
            Console.WriteLine("There's such option. Terminating program..");
            return;
        }
        
        for (int i=0; i < passwordLength; i++)
        {
            password += characters[randomCharGen(firstNumber, lastNumber)];
        }

        Console.WriteLine(password);
    }
}