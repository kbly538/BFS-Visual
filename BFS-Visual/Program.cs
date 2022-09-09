using bfsvisual;
using System.Drawing;


//String rootPath = @"..\source\repos\algo-studies\algo-studies\Maps\";
String rootPath = "..\\..\\..\\Maps\\";
String textFileName = "starMap.txt";
String imageName = "hand-drawn-map.png";

String fullPthToText = rootPath + textFileName;
String fullPathToImage = rootPath + imageName;


/*
 * BFS with map from image
 */
BitmapMapLoader bml = new BitmapMapLoader(fullPathToImage); 

//Creates a text file using the image
// e.g. 
//	  x 
//	  1	####### 
//	  2	#     # 
//	  3	#   ### 
//	  4	#     #
//	  5	# #   # 
//	  6	#     # 
//	  7	#######
//      1234567 y     

bml.CreateMapFile(fullPthToText); 
BFS bfs = new BFS(bml);




// Given coords, finds the shortest path using bfs


// e.g. bfs.StartBFS((2, 2), (6, 6)); 
//
// starting point(s) : (2, 2)
// destination(d) : (6, 6)
//	
//    
//	  x 
//	  1	####### 
//	  2	#s    # 
//	  3	#   ### 
//	  4	#     #
//	  5	# #   # 
//	  6	#    d# 
//	  7	#######
//      1234567 y    
bfs.StartBFS((9, 21), (49,58));






