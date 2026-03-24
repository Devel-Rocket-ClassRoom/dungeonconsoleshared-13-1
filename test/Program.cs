using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data;


namespace test
{

    public class branche_test_class
    {
        //pull-request-test
    }
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
}
