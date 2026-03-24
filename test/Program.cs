using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

//DungeonGame 클래스디자인
//기존에 만든 텍스트 던전게임 코드를 DungeonGame 클래스로 이동
//기존 Main()에서 구현한 내용을 DungeonGame 클래스에
// 함수 PlayGame()를 만들어서 이동
//기존 모든 관련 함수를 DungeonGame 클래스 내부로 이동
//Main()에서 DungeonGame를 new로 만들고 PlayGame()호출
//기존 게임과 동일하게 작동할 것.   

//***던전게임 개선하기***1111
//1.부모 클래스 (플레이어, 몬스터 공통)
// - 공통 데이터, 메소드 선언
//2.플레이어 , 몬스터 클래스 정의
// = 각각 전용 데이터 선언
//3.플레이어 전용데이터, 메소드 (함수)
// - 예) 이동시 함수 사용
//4.몬스터 전용 데이터,메소드
//5.맵 클래스 만들고 코드정리
namespace tset
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
    }

    public class Monster : Character
    {
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
