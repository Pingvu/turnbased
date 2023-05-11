using System;
using System.Collections.Generic;
using System.IO;
public enum gameState 
{
    Battle,
    City,
    Dead,
    MainMenu,
    Obstacle,
}
public class Enemy
{  public string name;
   public int health;
   public int attack;
   public int defense;
   public List<string> attacksType;
   public Enemy(string name, int health,int attack,int defense, List<string> attacksType)
   {
    this.name = name;
    this.health = health;
    this.attack = attack;
    this.defense = defense;
    this.attacksType = attacksType;
   }
}
public class player
{
    public int health;
    public int attack;
    public int defense;
    public int score;
}


class program {

    public static void Main(string[] args)
    {
         gameState state = gameState.MainMenu;
         player Player = new player();
         Player.health = 50;
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
                    Environment.Exit(0);
                }
                else 
                {
                    Console.WriteLine("Invalid input");
                }
                break;
                case gameState.City:
                Console.WriteLine("1. Fight an enemy");
                Console.WriteLine("2. Encounter an obstacle");
                Console.WriteLine("3. Remaining HP");
                Console.WriteLine("4. Quit game");
                string input2 = Console.ReadLine();
                if (input2 == "1")
                {
                    state = gameState.Battle;
                }
                if (input2 == "2")
                {
                    state = gameState.Obstacle;
                }
                if (input2 == "3")
                {
                    Console.WriteLine(Player.health);
                }
                if (input2=="4")
                {
                    Environment.Exit(0);
                }
                else 
                {
                    Console.WriteLine("Invalid input");
                }
                break; 
                case gameState.Battle:
                List<Enemy> enemies = new List<Enemy>();
                enemies.Add( new Enemy ( "wizard", 30,   10,  3, new List<string>{"Ranged"}));
                enemies.Add( new Enemy ( "goblin", 50, 7, 5, new List<string>{"Ranged","Melee"}));
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
                        Console.WriteLine("You attack " + enemy.name + ", it has " + enemy.health + "HP left.");
                        if (enemy.health <= 0)
                        {
                        Console.WriteLine("You killed "+ enemy.name);
                        Player.score += 100;
                        state = gameState.City;
                        break;
                        }
                    index = random.Next(enemy.attacksType.Count);
                    String attackType = enemy.attacksType[index]; 
                    int enemyDamage = enemy.attack - Player.defense;
                    Player.health -= enemyDamage;
                    Console.WriteLine(enemy.name + "attacked you, you have "+ Player.health + "HP left.");
                    if (Player.health <= 0)
                    {
                        Console.WriteLine("you died");
                        state = gameState.Dead;
                        break;
                    }
                    }

                    else if (action == "2")
                    {
                        state= gameState.City;
                        break;
                    }
                    else 
                {
                    Console.WriteLine("Invalid input");
                }
                }
                    
                break;
                case gameState.Obstacle:
                Console.WriteLine("You have encountered an obstacle!");
                Console.WriteLine("1. Try to open the door");
                Console.WriteLine("2. Look for another way around");
                Console.WriteLine("3. Ignore it");
                string input3 = Console.ReadLine();
                if (input3 == "1")
                {
                Console.WriteLine("You try to open the door...");
                bool doorOpen = false;
        if (doorOpen)
        {
            Console.WriteLine("You successfully opened the door!");
            state = gameState.City;
        }
        else
        {
            Console.WriteLine("The door is locked. You need a key to open it.");
        }
    }
    else if (input3 == "2")
    {
        Console.WriteLine("You look for another way around...");
        Random random2 = new Random();
        bool foundPath = (random2.Next(2) == 0);
        if (foundPath)
        {
            Console.WriteLine("You found another path and continue on your journey.");
            state = gameState.City;
        }
        else
        {
            Console.WriteLine("You couldn't find another way around. You are stuck here for now.");
        }
    }
    else if (input3 == "3")
    {
        Console.WriteLine("You ignore the obstacle for now...");
        state = gameState.City;
    }
    else 
                {
                    Console.WriteLine("Invalid input");
                }
    break;
            }
        if (state == gameState.Dead)
        {
                string fileName = "highscores.txt";
                StreamWriter sw = new StreamWriter(fileName, true);
                sw.WriteLine(Player.score.ToString());
                sw.Close();
                break;
        }
         }
    }
}