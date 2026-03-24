using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class DungeonGame
    {
        int a = 10;
        Map gameMap = new Map();
        Player player = new Player();

        //int[] aaa = new int[5];
        //int[] aaa = new int[5];
        //int[] aaa = new int[5];    
        //char[] ccc = new char[5];
        //GameData[] ddd = new GameData[5];

        //List<GameData> stages = new List<GameData>();
        //GameData data = new GameData("Intro",1);

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
                        //gameMap.map[player.row, player.col] = ' ';
                        //player.row += dirR;
                        //player.col += dirC;
                        //gameMap.map[player.row, player.col] = 'P';
                    }

                    gameMap.PrintMap();
                }
            }
        }
    }
}
