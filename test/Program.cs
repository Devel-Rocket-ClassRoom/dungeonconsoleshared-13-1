using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DungeonGame game = new DungeonGame("던전", 1);

            game.PlayGame(5);
        }
    }

    public struct GameData
    {
        public string stageName;
        public int dungeonCount;

        public GameData(string name, int count)
        {
            stageName = name;
            dungeonCount = count;
        }
    }

    public class Character
    {
        public int row;
        public int col;

    }


    public class Player : Character
    {
        public int Hp = 10;
        public string Name;

        public Player()
        {

        }
    }

    public class Monster : Character
    {
        public enum MonsterType
        {
            Slime,
            Goblin,
            Orc,
            Dragon
        }
        public Monster(int r, int c)
        {

        }

    }

    public class Map
    {
        public char[,] map;
        public int rows;
        public int cols;

        public (int, int) FindPlayer()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (map[r, c] == 'P') return (r, c);
                }
            }
            return (1, 1);
        }
        public void SetPlayer(int newR, int newC, Player p)
        {
            map[p.row, p.col] = ' ';
            p.row += newR;
            p.col += newC;
            map[p.row, p.col] = 'P';
        }
        public bool IsWall(int r, int c)
        {
            if (map[r, c] == '#')
            {
                return true;
            }
            return false;
        }
        public bool IsMonster(int r, int c)
        {
            if (map[r, c] == 'M')
            {
                return true;
            }
            return false;
        }
        public void PrintMap()
        {

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(map[r, c]);
                }
                Console.WriteLine();

            }
        }
        public Map()
        {
            map = new char[,] {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', 'P', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#', ' ', '#' },
            { '#', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', ' ', '#', '#', '#', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
            { '#', ' ', '#', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' }, 
            { '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', 'M', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            };
            rows = map.GetLength(0);
            cols = map.GetLength(1);
        }
    }
    public class DungeonGame //던전 클래스
    {
        int a = 10;
        Map gameMap = new Map();
        Player player = new Player();

        public DungeonGame(string name, int count)
        {


        }
       
        public void PlayGame(int stageCount)
        {

            for (int i = 0; i < stageCount; i++)
            {
                Console.WriteLine();
                gameMap.PrintMap();

                var P = gameMap.FindPlayer();
                player.row = P.Item1;
                player.col = P.Item2;
                
                bool playing = true;
                while (playing)
                {

                    Console.Write("이동 명령 (w, a, s, d): ");
                    Console.Write("P는 플레이어 M은 몬스터");
                    for (int h = 0; h < 2; h++)
                    {
                        Console.Write("*");
                        Console.WriteLine("한칸 이동하였습니다");
                    }

                    string cmd = Console.ReadLine();

                    // 이동 명령 (L, R, U, D): 


                    int dirR = 0;
                    int dirC = 0;

                    //map[R + dirR, C + dirC] == '#'

                    switch (cmd)
                    {
                        case "a":
                            dirC = -1;
                            break;

                        case "d":
                            dirC = 1;
                            break;

                        case "w":
                            dirR = -1;
                            break;

                        case "s":
                            dirR = 1;
                            break;
                    }


                    //if (gameMap.map[R + dirR, C + dirC] == '#')
                    if (gameMap.IsWall(player.row + dirR, player.col + dirC))
                    {
                        Console.WriteLine("이동 못함");

                    }
                   
                    else if (gameMap.map[player.row + dirR, player.col + dirC] == 'M')
                    {
                        Console.WriteLine("게임종료");
                        return;
                    }
                    else
                    {
                        gameMap.SetPlayer(dirR, dirC, player);
                    }

                    gameMap.PrintMap();
                }
            }
        }
    }
}
