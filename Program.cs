using System.Text;

namespace passwordM;


public class passwordGenerator
{ 
      // ~~~~~~~~~~~~~~~ Converts a string to integer ~~~~~~~~~~~~~~~
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
    // ~~~~~~~~~~~~~~~ Genetates a random number between two integer parameters ~~~~~~~~~~~~~~~
    static int GenerateRandomNumber(int firstNumber, int secondNumber)
    {
        Random rand = new Random();

        int randomNumber = rand.Next(firstNumber, secondNumber);

        return randomNumber;
    }
    //~~~~~~~~~~~~~~~ Genetates a random password using the random number generator. It has two parameteres: (1) the desired password length and (2) the password complexity ~~~~~~~~~~~~~~~
    static string GeneratePassword(int passwordLength, int complexityOption)
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            StringBuilder passwordBuilder = new StringBuilder();

            int minimumCharacterIndex = 0;
            int maximumCharacterIndex = 0;

            switch (complexityOption)
            {
                case 1:
                    maximumCharacterIndex = 52;
                    break;
                case 2:
                    maximumCharacterIndex = 62;
                    break;
                case 3:
                    maximumCharacterIndex = 72;
                    break;
                default:
                    throw new ArgumentException("Invalid complexity option.");
            }

            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = GenerateRandomNumber(minimumCharacterIndex, maximumCharacterIndex);
                char randomCharacter = characters[randomIndex];
                passwordBuilder.Append(randomCharacter);
            }

            string password = passwordBuilder.ToString();
            return password;
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

        try
        {
            string password = GeneratePassword(passwordLength, complexityOption);
            Console.WriteLine(password);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
