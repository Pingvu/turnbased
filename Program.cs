using System;
using System.Collections.Generic;
public enum gameState 
{
    Battle,
    City,
    Dead,
    MainMenu,
}
public class Enemy
{  public string name;
   public int health;
   public int attack;
   public int defense;
   public List<string> attacksType;
}
public class player
{
    public int health;
    public int attack;
    public int defense;
    public int score;
}
public class obstacle{
    public string name;
    public bool canPassThrough;
    public List<string> interactAction;
}

class program {

    public static void Main(string[] args)
    {
         gameState state = gameState.MainMenu;
         player Player = new player();
         Player.health = 100;
         Player.attack = 10;
         Player.defense = 5;
         while (state != gameState.Dead)
         {
            switch(state)
            {
                case gameState.MainMenu:
                Console.WriteLine("1. Start game");
                Console.WriteLine("2. Quit Game");
                string input = Console.ReadLine();
                if (input == "1")
                {
                      Player.score = 0;
                      state = gameState.City;
                    
                }
                else if (input == "2")
                {
                    Console.WriteLine("Goodbye!");
                }
                break;
                case gameState.City:
                Console.WriteLine("1. Fight an enemy");
                Console.WriteLine("2. Return to main menu");
                string input2 = Console.ReadLine();
                if (input2 == "1")
                {
                    state = gameState.Battle;
                }
                if (input2 == "2")
                {
                    state = gameState.MainMenu;
                }
                break; 
                case gameState.Battle:
                List<Enemy> enemies = new List<Enemy>();
                enemies.Add( new Enemy {name = "wizard", health= 30, attack = 10, defense= 3, attacksType= new List<string>{"Ranged"}});
                enemies.Add( new Enemy {name = "goblin", health= 50, attack = 7, defense= 5, attacksType= new List<string>{"Ranged","Melee"}});
                Random random = new Random();
                int index = random.Next(enemies.Count);
                Enemy enemy = enemies[index];
                Console.WriteLine("the enemy is a " + enemy.name);
                while (Player.health > 0 && enemy.health >0)
                {
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Retreat");
                    string action = Console.ReadLine();
                    if (action == "1")
                    {
                        int damage = Player.attack - enemy.defense;
                        enemy.health -= damage;
                        Console.WriteLine("You attack " + enemy.name + ", they have " + enemy.health + "HP left.");
                        if (enemy.health <= 0)
                        {
                        Console.WriteLine("You killed "+ enemy.name);
                        Player.score += 100;
                        }
                    }
                    else if (action == "2")
                    {
                        state= gameState.City;
                    }
                }
                    index = random.Next(enemy.attacksType.Count);
                    String attackType = enemy.attacksType[index]; 
                break;
            }
         }
    }
}