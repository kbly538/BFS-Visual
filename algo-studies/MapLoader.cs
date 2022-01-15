using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_studies
{
	public class MapLoader
	{
		public List<List<char>> Map { get; set; }

		public MapLoader(string filePath)
		{
			List<List<char>> prepMap = new List<List<char>>();

			char[] mapData = File.ReadAllText(filePath).ToCharArray();

			IEnumerable<String> mapFile = File.ReadLines(filePath);
			foreach (string s in mapFile)
			{
				prepMap.Add(s.ToList<char>());
			}


			Map = prepMap;
		}

		public void DrawMap()
		{
			for (int i = 0; i < Map.Count; i++)
			{
				for (int j = 0; j < Map[i].Count; j++)
				{
					Console.Write(Map[i][j]);
				}

				Console.WriteLine();
			}
		}
	}
}
