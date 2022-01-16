using System.Drawing;

namespace algo_studies
{
	public class BitmapMapLoader
	{

		private string ImageFilePath { get; }
		private Bitmap Image { get; set; }
		private char[,] ImageArray { get; set; }

		public BitmapMapLoader(string imageFilePath)
		{
			this.ImageFilePath = imageFilePath;
			Image = LoadImage();
			ImageArray = CreateImageArray(Image);

		}

		public char[,] GetMap()
		{
			return ImageArray;
		}

		private Bitmap LoadImage()
		{
			return new Bitmap(ImageFilePath);
		}

		public void CreateMapFile(String outFilePath)
		{
			using (StreamWriter writer = new StreamWriter(outFilePath))
			{
				for (int j = 0; j < Image.Height; j++)
				{
					
					for (int i = 0; i < Image.Width; i++)
					{
						Color pxColor = Image.GetPixel(i, j);
						if (CalculateColorValue(pxColor) <= 190)
						{
							ImageArray[j,i] = '#';
							writer.Write(ImageArray[j,i]);
						}
						else
						{
							ImageArray[j,i] = ' ';
							writer.Write(ImageArray[j,i]);
						}
					}
					writer.Write('\n');
				}
			}
		}

		private int CalculateColorValue(Color color) { 
			
			return (int)(color.R + color.G + color.B) / 3;
		}

		private char[,] CreateImageArray(Bitmap image)
		{
			if (image == null)
			{
				Console.WriteLine("Image not found.");
				throw new ArgumentNullException("Image not found.");
			}
			return new char[image.Height, image.Width];
		}
	}
}
