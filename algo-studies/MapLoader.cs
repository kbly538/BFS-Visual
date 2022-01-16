using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_studies
{
	public class MapLoader
	{
		
		public char[,] Map { get; set; }

		/// <summary>
		/// Reads the text file and assign every char to the corresponding row, column.
		/// </summary>
		/// <param name="filePath">Path for the text file to be loaded.</param>
		public MapLoader(string filePath)
		{
			

			char[] mapData = File.ReadAllText(filePath).ToCharArray();

			IEnumerable<String> mapFile = File.ReadLines(filePath);
			Map = new char[mapFile.Count(), mapData.Length / mapFile.Count()];


			for (int i = 0; i < mapFile.Count(); i++)
			{
				for (int j = 0; j < mapFile.ElementAt(i).Length; j++)
				{
					Map[i, j] = mapFile.ElementAt(i)[j];
				}
			}

		}
		/// <summary>
		/// Draws the map on the console.
		/// </summary>
		public void DrawMap()
		{
			for (int i = 0; i < Map.GetLength(0); i++)
			{
				for (int j = 0; j < Map.GetLength(1); j++)
				{
					Console.Write(Map[i,j]);
				}

				Console.WriteLine();
			}
		}
	}
}
