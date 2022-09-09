using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_studies
{
	public class BFS
	{
	
			
		public char[,] Map { get; set; }
		public Dictionary<(int, int), Cell> grid = new Dictionary<(int, int), Cell>();
		HashSet<(int, int)> VisitedCells = new HashSet<(int, int)>();
		Queue<(int, int)> ToBeVisitedCells = new Queue<(int, int)>();


		public BFS(MapLoader mapLoader)
		{
			Map = mapLoader.Map;
			FillGrid();
		}

		public BFS(BitmapMapLoader bitmapMapLoader)
		{
			Map = bitmapMapLoader.GetMap();
			FillGrid();
		}

		private void FillGrid()
		{
			for (int i = 0; i < Map.GetLength(0); i++)
			{
				for (int j = 0; j < Map.GetLength(1); j++)
				{

					if (Map[i,j] == ' ')
					{
						int[] origin = { -1, -1 };
						grid.Add((i, j), new Cell(i, j));
					}
				}
			}
		}


		public void StartBFS((int, int) startingPosition, (int, int) destination)
		{

			if (!grid.ContainsKey(destination))
			{
				Console.WriteLine("Target doesnt exist.");
				return;
			}

			ToBeVisitedCells.Enqueue(startingPosition);

			while (ToBeVisitedCells.Count > 0)
			{
				(int, int) currentPosition = ToBeVisitedCells.Dequeue();
				if (IsSuccess(currentPosition, destination))
				{
					List<(int, int)> path = GetPath(currentPosition);
					DrawPath(path, startingPosition, destination);
					return;
				}
				

				VisitedCells.Add(currentPosition);

				CheckNeighbours(currentPosition);


			}
			Console.WriteLine("Target not found.");
		}

		private void CheckNeighbours((int, int) currentCell)
		{
			(int, int) up = (currentCell.Item1 - 1, currentCell.Item2);
			(int, int) down = (currentCell.Item1 + 1, currentCell.Item2);
			(int, int) left = (currentCell.Item1, currentCell.Item2 - 1);
			(int, int) right = (currentCell.Item1, currentCell.Item2 + 1);

			List<(int, int)> neightbours = new List<(int, int)>() { up, down, left, right };

			foreach ((int, int) neighbour in neightbours)
			{
				if (grid.ContainsKey(neighbour)
				&& !VisitedCells.Contains(neighbour)  
				&& !ToBeVisitedCells.Contains(neighbour))
				{
					ToBeVisitedCells.Enqueue(neighbour);
					grid[neighbour].prev = currentCell;
	
				}
			}

		}

		private bool IsSuccess((int, int) currentPosition, (int,int) destination)
		{
			return currentPosition.Equals(destination);
		}

		private List<(int, int)> GetPath((int, int) currentPosition)
		{
			List<(int, int)> shortestPath = new List<(int, int)>();

			shortestPath.Add(currentPosition);

			while (grid[currentPosition].prev != (-1, -1))
			{
				shortestPath.Add(grid[currentPosition].prev);
				currentPosition = grid[currentPosition].prev;
			}

			return shortestPath;
		} 

		public void DrawPath(List<(int, int)> path, (int, int) startingPosition, (int, int) destination)
		{
			//Console.Read();

			foreach ((int, int) c in path.Reverse<(int, int)>())
			{
				//Console.Clear();
	
				Map[c.Item1,c.Item2] = '0';
				

			}
			//Console.Read();
			for (int i = 0; i < Map.GetLength(0); i++)
			{
				for (int j = 0; j < Map.GetLength(1); j++)
				{
					
					if (Map[i,j] == '0' && grid.ContainsKey((i, j))
						&&  (startingPosition.Equals((grid[(i, j)].x, grid[(i, j)].y))
						||  destination.Equals((grid[(i, j)].x, grid[(i, j)].y))))
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write(Map[i,j]);
					}
					else if (Map[i,j] == '0')
					{
						
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write(Map[i,j]);
					}
					else
					{
						Console.ForegroundColor= ConsoleColor.DarkGray;
						Console.Write(Map[i,j]);
					}
				}
				Console.WriteLine();
			}
		}
	}
}
