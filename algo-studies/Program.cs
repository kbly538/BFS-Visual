using algo_studies;

String rootPath = @"D:\kbly538\source\repos\algo-studies\algo-studies\Maps\";
String textFileName = "starMap.txt";
String imageName = "hand-drawn-map.png";

String fullPthToText = rootPath + textFileName;
String fullPathToImage = rootPath + imageName;


/// <summary>
/// Creating ascii map from bitmap
/// </summary>
//BitmapMapLoader bml = new BitmapMapLoader(fullPathToImage);
//bml.CreateMapFile(fullPthToText);

MapLoader mapLoader = new MapLoader(fullPthToText);
BFS bfs = new BFS(mapLoader);


bfs.StartBFS((9, 21), (49,58));






