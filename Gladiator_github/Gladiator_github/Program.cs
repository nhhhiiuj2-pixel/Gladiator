using System;
using System.Diagnostics;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
internal class Program
{
    static Dictionary<string, int> attacks = new()
        {
            {"kick",20},
            {"tackle",15},
            {"punch",12},
            {"gamble", Random.Shared.Next(5,30)}
        };

    private static void Main(string[] args)
    {
        /*
        planning:
        Pokemonlike game with player vs bot
        4 attacks with diffrent dammage and 
         */

        Console.Write("while the hp both gladiators will have: ");
        int player_hp = int.Parse(Console.ReadLine()!);
        int npc_hp = player_hp;
        Console.Write("What is the name of your gladiator: ");
        string player_name = Console.ReadLine()!;
        Console.Clear();
        int total_attacks = 0;

        while (player_hp > 0 && npc_hp > 0)
        {
            Console.WriteLine($"{player_name} HP: {player_hp} \nNpc HP: {npc_hp}");
            foreach (string key in attacks.Keys)
            {
                Console.WriteLine(key);
            }
            Console.Write("Choose attack: ");
            string current_attack = Console.ReadLine()!.ToLower();
            Console.WriteLine($"Attack dealt {attack(current_attack)} damage");
            npc_hp = npc_hp - attack(current_attack);
            Console.ReadKey();
            Console.Clear();
            int npc_attack;
            if (npc_hp > 0)
            {
                npc_attack = Random.Shared.Next(0, 3);
                if (npc_attack == 0)
                {
                    current_attack = "kick";
                }
                else if (npc_attack == 1)
                {
                    current_attack = "tackle";
                }
                else if (npc_attack == 2)
                {
                    current_attack = "punch";
                }
                else { current_attack = "gamble"; }
                Console.WriteLine($"Npc used {current_attack} it dealt {attack(current_attack)} damage");
                player_hp = player_hp - attack(current_attack);
            }
            else { Console.WriteLine("Npc died"); }



            Console.ReadKey();
            Console.Clear();
            total_attacks++;
        }
        if (npc_hp <= 0)
        {
            Console.WriteLine($"{player_name} won and have {player_hp} hp left.\nIt took {total_attacks} attacks to win");
        }
        else
        {
            Console.WriteLine($"The Npc won and have {npc_hp} hp left.\nIt took {total_attacks} attacks to kill you");




            /*int test = 0;
            while (test <= 2)
            {
                Console.WriteLine("write kick, tackle, punch, gamble: ");
                string attackName = Console.ReadLine()!.ToLower();

                Console.WriteLine($"{attackName} deal {attack(attackName)} damage");
                test++;
            }*/
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString()!;
    }

    static int attack(string attackName)
    {

        var random = Random.Shared;

        attacks["gamble"] = random.Next(5, 30);

        return attacks[attackName];
    }
}