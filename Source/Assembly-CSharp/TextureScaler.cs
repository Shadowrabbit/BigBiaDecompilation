using System;
using System.Threading;
using UnityEngine;

public class TextureScaler
{
	public void CutTextrue()
	{
		Application.streamingAssetsPath + "/VoxcelEditFiles/ 小弟一号蘑菇怪贼狠/ 小弟一号蘑菇怪贼狠";
	}

	public static Texture2D Point(Texture2D tex, int newWidth, int newHeight, bool flipH, bool flipV)
	{
		return TextureScaler.ThreadedScale(tex, newWidth, newHeight, false, flipH, flipV);
	}

	public static Texture2D Bilinear(Texture2D tex, int newWidth, int newHeight, bool flipH, bool flipV)
	{
		return TextureScaler.ThreadedScale(tex, newWidth, newHeight, true, flipH, flipV);
	}

	private static Texture2D ThreadedScale(Texture2D tex, int newWidth, int newHeight, bool useBilinear, bool flipH, bool flipV)
	{
		TextureScaler.texColors = tex.GetPixels();
		TextureScaler.newColors = new Color[newWidth * newHeight];
		if (useBilinear)
		{
			TextureScaler.ratioX = 1f / ((float)newWidth / (float)(tex.width - 1));
			TextureScaler.ratioY = 1f / ((float)newHeight / (float)(tex.height - 1));
		}
		else
		{
			TextureScaler.ratioX = (float)tex.width / (float)newWidth;
			TextureScaler.ratioY = (float)tex.height / (float)newHeight;
		}
		TextureScaler.w = tex.width;
		TextureScaler.w2 = newWidth;
		int num = Mathf.Min(SystemInfo.processorCount, newHeight);
		int num2 = newHeight / num;
		TextureScaler.finishCount = 0;
		if (TextureScaler.mutex == null)
		{
			TextureScaler.mutex = new Mutex(false);
		}
		if (num > 1)
		{
			int i;
			TextureScaler.ThreadData threadData;
			for (i = 0; i < num - 1; i++)
			{
				threadData = new TextureScaler.ThreadData(num2 * i, num2 * (i + 1));
				new Thread(useBilinear ? new ParameterizedThreadStart(TextureScaler.BilinearScale) : new ParameterizedThreadStart(TextureScaler.PointScale)).Start(threadData);
			}
			threadData = new TextureScaler.ThreadData(num2 * i, newHeight);
			if (useBilinear)
			{
				TextureScaler.BilinearScale(threadData);
			}
			else
			{
				TextureScaler.PointScale(threadData);
			}
			while (TextureScaler.finishCount < num)
			{
				Thread.Sleep(1);
			}
		}
		else
		{
			TextureScaler.ThreadData obj = new TextureScaler.ThreadData(0, newHeight);
			if (useBilinear)
			{
				TextureScaler.BilinearScale(obj);
			}
			else
			{
				TextureScaler.PointScale(obj);
			}
		}
		tex.Resize(newWidth, newHeight);
		tex.SetPixels(TextureScaler.newColors);
		tex.Apply();
		Texture2D texture2D = new Texture2D(tex.width, tex.height);
		if (flipV)
		{
			int width = tex.width;
			int width2 = tex.width;
			for (int j = 0; j < width; j++)
			{
				for (int k = 0; k < width2; k++)
				{
					texture2D.SetPixel(j, width2 - k - 1, tex.GetPixel(j, k));
				}
			}
			texture2D.Apply();
		}
		else if (flipH)
		{
			int width3 = tex.width;
			int width4 = tex.width;
			for (int l = 0; l < width3; l++)
			{
				for (int m = 0; m < width4; m++)
				{
					texture2D.SetPixel(width3 - l - 1, m, tex.GetPixel(l, m));
				}
			}
			texture2D.Apply();
		}
		else
		{
			texture2D = tex;
		}
		return texture2D;
	}

	public static void BilinearScale(object obj)
	{
		TextureScaler.ThreadData threadData = (TextureScaler.ThreadData)obj;
		for (int i = threadData.start; i < threadData.end; i++)
		{
			int num = (int)Mathf.Floor((float)i * TextureScaler.ratioY);
			int num2 = num * TextureScaler.w;
			int num3 = (num + 1) * TextureScaler.w;
			int num4 = i * TextureScaler.w2;
			for (int j = 0; j < TextureScaler.w2; j++)
			{
				int num5 = (int)Mathf.Floor((float)j * TextureScaler.ratioX);
				float value = (float)j * TextureScaler.ratioX - (float)num5;
				TextureScaler.newColors[num4 + j] = TextureScaler.ColorLerpUnclamped(TextureScaler.ColorLerpUnclamped(TextureScaler.texColors[num2 + num5], TextureScaler.texColors[num2 + num5 + 1], value), TextureScaler.ColorLerpUnclamped(TextureScaler.texColors[num3 + num5], TextureScaler.texColors[num3 + num5 + 1], value), (float)i * TextureScaler.ratioY - (float)num);
			}
		}
		TextureScaler.mutex.WaitOne();
		TextureScaler.finishCount++;
		TextureScaler.mutex.ReleaseMutex();
	}

	public static void PointScale(object obj)
	{
		TextureScaler.ThreadData threadData = (TextureScaler.ThreadData)obj;
		for (int i = threadData.start; i < threadData.end; i++)
		{
			int num = (int)(TextureScaler.ratioY * (float)i) * TextureScaler.w;
			int num2 = i * TextureScaler.w2;
			for (int j = 0; j < TextureScaler.w2; j++)
			{
				TextureScaler.newColors[num2 + j] = TextureScaler.texColors[(int)((float)num + TextureScaler.ratioX * (float)j)];
			}
		}
		TextureScaler.mutex.WaitOne();
		TextureScaler.finishCount++;
		TextureScaler.mutex.ReleaseMutex();
	}

	private static Color ColorLerpUnclamped(Color c1, Color c2, float value)
	{
		return new Color(c1.r + (c2.r - c1.r) * value, c1.g + (c2.g - c1.g) * value, c1.b + (c2.b - c1.b) * value, c1.a + (c2.a - c1.a) * value);
	}

	private static Color[] texColors;

	private static Color[] newColors;

	private static int w;

	private static float ratioX;

	private static float ratioY;

	private static int w2;

	private static int finishCount;

	private static Mutex mutex;

	public class ThreadData
	{
		public ThreadData(int s, int e)
		{
			this.start = s;
			this.end = e;
		}

		public int start;

		public int end;
	}
}
