using System;

namespace RPGGame
{
    class Program
    {
        public const int MapWidth = 20;
        public const int MapHeight = 10;
        public int RndX = 0;
        public int RndY = 0;
        public bool IfInsideMap(int x, int y){
            if(x >= 0 && y >=0 && x < MapWidth && y < MapHeight){
                return true;
            }
            return false;
        }
        public void GeneratePosition(){
            Random r = new Random();
            Program p = new Program();
            int a = 0;
            int b = 0;
            while(!(a>0 && a<MapWidth)){
                a = r.Next(MapWidth);
            }
            while(!(b>0 && b<MapHeight)){
                b = r.Next(MapHeight);
            }
            p.RndX = a;
            p.RndY = b;
        }

        static void Main(string[] args)
        {
            bool loop1 = true;
            bool loop2 = true;

            char[,] GameMap =
            {
                {'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x'},
                {'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'}
            };

            Program p = new Program();

            do
            {
                p.GeneratePosition();
            } while (GameMap[p.RndY, p.RndX] == 'x');

            Monster Monster1 = new Monster("Zombie Knight", p.RndX, p.RndY);
            do
            {
                p.GeneratePosition();
            } while (GameMap[p.RndY, p.RndX] == 'x');

            Monster Monster2 = new Monster("Leprechaun", p.RndX, p.RndY);
            do
            {
                p.GeneratePosition();
            } while (GameMap[p.RndY, p.RndX] == 'x');

            Monster Monster3 = new Monster("Grumpy the Dwarf", p.RndX, p.RndY);
            do
            {
                p.GeneratePosition();
            } while (GameMap[p.RndY, p.RndX] == 'x');

            Monster Monster4 = new Monster("Flying Shoe", p.RndX, p.RndY);
            do
            {
                p.GeneratePosition();
            } while (GameMap[p.RndY, p.RndX] == 'x');

            Monster Monster5 = new Monster("Nakamura", p.RndX, p.RndY);



            Console.WriteLine("\n\n\n\n\nWELCOME TO THE DUNGEON\n\n\n\n\n");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Input player name: ");
            string PlayerName = Console.ReadLine();
            Player Player = new Player(PlayerName);


            int PlayerX = 1;
            int PlayerY = 1;
            int DisplayX = 0;
            int DisplayY = 0;
            char temp = GameMap[PlayerY, PlayerX];
            bool BattleState = false;
            while (loop2)
            {
                while (loop1)
                {
                    var ch = Console.ReadKey(false).Key;
                    switch (ch)
                    {
                        case ConsoleKey.UpArrow:
                            //if new coord will hit wall, dont do anything
                            if (GameMap[PlayerY - 1, PlayerX] == 'x')
                            {
                            }
                            else if (GameMap[PlayerY - 1, PlayerX] == '@')
                            {
                                BattleState = true;
                            }
                            else
                            {
                                temp = GameMap[PlayerY - 1, PlayerX];
                                GameMap[PlayerY, PlayerX] = temp;
                                if (p.IfInsideMap(PlayerX, PlayerY - 2))
                                {
                                    if (GameMap[PlayerY - 2, PlayerX] == 'x')
                                    {

                                    }
                                    else
                                    {
                                        DisplayY -= 1;
                                    }
                                }


                                PlayerY -= 1;

                            }

                            break;
                        case ConsoleKey.DownArrow:
                            if (GameMap[PlayerY + 1, PlayerX] == 'x')
                            {
                            }
                            else if (GameMap[PlayerY + 1, PlayerX] == '@')
                            {
                                BattleState = true;
                            }
                            else
                            {
                                temp = GameMap[PlayerY + 1, PlayerX];
                                GameMap[PlayerY, PlayerX] = temp;
                                if (p.IfInsideMap(PlayerX, PlayerY + 2))
                                {
                                    if (GameMap[PlayerY + 2, PlayerX] == 'x')
                                    {

                                    }
                                    else
                                    {
                                        DisplayY += 1;
                                    }
                                }

                                PlayerY += 1;
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            if (GameMap[PlayerY, PlayerX - 1] == 'x')
                            {
                            }
                            else if (GameMap[PlayerY, PlayerX - 1] == '@')
                            {
                                BattleState = true;
                            }
                            else
                            {
                                temp = GameMap[PlayerY, PlayerX - 1];
                                GameMap[PlayerY, PlayerX] = temp;
                                if (p.IfInsideMap(PlayerX - 2, PlayerY))
                                {
                                    if (GameMap[PlayerY, PlayerX - 2] == 'x')
                                    {

                                    }
                                    else
                                    {
                                        DisplayX -= 1;
                                    }
                                }

                                PlayerX -= 1;
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            if (GameMap[PlayerY, PlayerX + 1] == 'x')
                            {
                            }
                            else if (GameMap[PlayerY, PlayerX + 1] == '@')
                            {
                                BattleState = true;
                            }
                            else
                            {
                                temp = GameMap[PlayerY, PlayerX + 1];
                                GameMap[PlayerY, PlayerX] = temp;
                                if (p.IfInsideMap(PlayerX + 2, PlayerY))
                                {
                                    if (GameMap[PlayerY, PlayerX + 2] == 'x')
                                    {

                                    }
                                    else
                                    {
                                        DisplayX += 1;
                                    }
                                }

                                PlayerX += 1;
                            }

                            break;
                        case ConsoleKey.Escape:
                            loop1 = false;
                            loop2 = false;
                            break;
                    }

                    GameMap[PlayerY, PlayerX] = 'o';
                    GameMap[Monster1.MonsterY, Monster1.MonsterX] = '@';
                    GameMap[Monster2.MonsterY, Monster2.MonsterX] = '@';
                    GameMap[Monster3.MonsterY, Monster3.MonsterX] = '@';
                    GameMap[Monster4.MonsterY, Monster4.MonsterX] = '@';
                    GameMap[Monster5.MonsterY, Monster5.MonsterX] = '@';
                    Console.Clear();
                    Console.WriteLine("\n\n");
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            Console.Write(GameMap[i, j]);
                        }

                        Console.Write("\n");
                    }
                }
            }
        }
    }
}