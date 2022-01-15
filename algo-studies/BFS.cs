using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_studies
{
	public class BFS
	{
		public List<List<char>> Map { get; set; }
		public Dictionary<(int, int), Cell> grid = new Dictionary<(int, int), Cell>();
		HashSet<(int, int)> VisitedCells = new HashSet<(int, int)>();
		Queue<(int, int)> ToBeVisitedCells = new Queue<(int, int)>();


		public BFS(MapLoader mapLoader)
		{
			Map = mapLoader.Map;
			FillGrid();
		}

		private void FillGrid()
		{
			for (int i = 0; i < Map.Count; i++)
			{
				for (int j = 0; j < Map[i].Count; j++)
				{

					if (Map[i][j] == ' ')
					{
						grid.Add((i, j), new Cell(i, j));
					}
				}
			}
		}


		// TODO Modify
		private bool IsTargetReached(Cell currentPosition, Cell destination)
		{
			return currentPosition.IsSamePos(destination);
		}


		public void StartBFS((int, int) startingPosition, (int, int) destination)
		{

			if (!grid.ContainsKey(destination))
			{
				Console.WriteLine("Target doesnt exist.");
				return;
			}


			ToBeVisitedCells.Enqueue(startingPosition);
			List<Cell> Shortestpath = new();

			while (ToBeVisitedCells.Count > 0)
			{
				(int, int) currentPosition = ToBeVisitedCells.Dequeue();

				if (currentPosition.Equals(destination))
				{
					Console.WriteLine("Target Found");
					Console.WriteLine("Shortest path is: ");
					List<(int, int)> ShortestPath = new List<(int, int)>();

					ShortestPath.Add(currentPosition);

					while (grid[currentPosition].prev != (-1, -1))
					{
						ShortestPath.Add(grid[currentPosition].prev);
						currentPosition = grid[currentPosition].prev;
					}


					Console.WriteLine(currentPosition);

					foreach ((int, int) coord in ShortestPath.Reverse<(int, int)>())
					{
						Console.Write($"({coord.Item1},{coord.Item2})");
					}


					DrawMap(ShortestPath);
					return;
				}

				VisitedCells.Add(currentPosition);

				CheckNeighbours(currentPosition);



			}

			Console.WriteLine("Target nor found");



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
				&& !VisitedCells.Contains(neighbour))
				{
					ToBeVisitedCells.Enqueue(neighbour);
					grid[neighbour].prev = currentCell;
				}
			}

		}

		public void DrawMap(List<(int, int)> path)
		{
			Console.Read();

			foreach ((int, int) c in path.Reverse<(int, int)>())
			{
				Console.Clear();
				Map[c.Item1][c.Item2] = '0';
				Console.WriteLine();
				for (int i = 0; i < Map.Count; i++)
				{
					for (int j = 0; j < Map[i].Count; j++)
					{
						Console.Write(Map[i][j]);
					}
					Console.WriteLine();

				}
				//Console.Read();
				Thread.Sleep(25);

			}
			Console.Read();


		}
	}
}
