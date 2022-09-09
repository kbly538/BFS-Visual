using System.Drawing;

namespace algo_studies
{
	public class BitmapMapLoader
	{

		private string imageFilePath { get; }
		private Bitmap image { get; set; }
		private char[,] imageArray { get; }

		public BitmapMapLoader(string imageFilePath)
		{
			this.imageFilePath = imageFilePath;
			LoadImage();
			this.imageArray = new char[image.Height, image.Width];
		}

		public char[,] GetMap()
		{
			return imageArray;
		}

		private Bitmap LoadImage()
		{
			try
			{
				return image = new(imageFilePath);
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine(e.Message);
				//return null;
				
			}
			Environment.Exit(-1);
			return null;
		}

		public void CreateMapFile(String outFilePath)
		{
			using (StreamWriter writer = new StreamWriter(outFilePath))
			{
				for (int j = 0; j < image.Height; j++)
				{
					
					for (int i = 0; i < image.Width; i++)
					{
						Color pxColor = image.GetPixel(i, j);
						if (CalculateColorValue(pxColor) <= 190)
						{
							imageArray[j,i] = '#';
							writer.Write(imageArray[j,i]);
						}
						else
						{
							imageArray[j,i] = ' ';
							writer.Write(imageArray[j,i]);
						}
					}
					writer.Write('\n');
				}
			}
		}

		private int CalculateColorValue(Color color) { 
			
			return (int)(color.R + color.G + color.B) / 3;
		}
	}
}
