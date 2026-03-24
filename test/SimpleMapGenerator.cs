using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tset;

namespace test
{
	public partial class SimpleMapGenerator
	{
		private static SimpleMapGenerator instance;
		private SimpleMapGenerator() { }
		public static SimpleMapGenerator GetInstance()
		{
			if(instance == null)
			{
				instance = new SimpleMapGenerator();
			}
			return instance;
		}

		public void Outline(Map map, int row_num, int col_num)
		{
			for(int i = 0; i < map.map.GetLength(0); i++)
			{
				map.map[i, 0] = '#';
				map.map[i, map.map.GetLength(1) - 1] = '#';
			}
			for (int i = 0; i < map.map.GetLength(1); i++)
			{
				map.map[0, i] = '#';
				map.map[map.map.GetLength(0) - 1, i] = '#';
			}
		}
		public void Clear(Map map)
		{
			for(int i = 0; i < map.map.GetLength(0); i++)
			{
				for(int j = 0; j < map.map.GetLength(1); j++)
				{
					map.map[i, j] = ' ';
				}
			}
		}
		public void PlaceSingleChar(Map map, char c, int x, int y)
		{
			if(y >= 0 && y < map.map.GetLength(0) && x >= 0 && x < map.map.GetLength(1))
				map.map[y, x] = c;
		}
	}
}
