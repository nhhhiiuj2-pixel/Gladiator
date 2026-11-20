using System.Diagnostics;
using System.Globalization;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
internal class Program
{
    private static void Main(string[] args)
    {
        /*
        planning:
        Pokemonlike game with player vs bot
        4 attacks with diffrent dammage and 
         */

        int test = 0;
        while (test <= 2)
        {
            Console.WriteLine("write kick, tackle, punch, gamble: ");
            string attackName = Console.ReadLine().ToLower();

            Console.WriteLine($"{attackName} deal {attack(attackName)} damage");
            test++;
        }
    }
    static int attack(string attackName)
    {
        var random = Random.Shared;
        Dictionary<string, int> attacks = new()
        {
            {"kick",20},
            {"tackle",15},
            {"punch",12},
            {"gamble",random.Next(5,30)}
        };

        return attacks[attackName];
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}