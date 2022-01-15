using algo_studies;

string mapFilePath = @"D:\kbly538\source\repos\algo-studies\algo-studies\Maps\mapFile.txt";
MapLoader mapLoader = new MapLoader(mapFilePath);


//foreach (KeyValuePair<Tuple<int, int>, Cell> keyValuePair in grid)
//{
//	Console.WriteLine(keyValuePair.Key + " " + keyValuePair.Value);
//}


//map.StartBFS(mapTxt, new Cell(1, 1), new Cell(9, 30));

BFS bfs = new BFS(mapLoader);

bfs.StartBFS((1, 1), (262, 1));













