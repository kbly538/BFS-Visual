using algo_studies;
using System.Drawing;


String rootPath = @"D:\kbly538\source\repos\algo-studies\algo-studies\Maps\";
String textFileName = "starMap.txt";
String imageName = "hand-drawn-map.png";

String fullPthToText = rootPath + textFileName;
String fullPathToImage = rootPath + imageName;




/*
 * BFS with textMapLoader
 */
//MapLoader mapLoader = new MapLoader(fullPthToText);
//mapLoader.DrawMap();
//BFS bfs = new BFS(mapLoader);
//bfs.StartBFS((1, 1), (5, 60));


/*
 * BFS with map from image
 */
BitmapMapLoader bml = new BitmapMapLoader(fullPathToImage);
bml.CreateMapFile(fullPthToText);
BFS bfs = new BFS(bml);


bfs.StartBFS((9, 21), (49,58));






