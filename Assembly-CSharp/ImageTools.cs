using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImageTools
{
	public static Sprite ReadImage(string FileName)
	{
		byte[] data = File.ReadAllBytes(Application.persistentDataPath + "/PaiPai/" + FileName + ".png");
		Texture2D texture2D = new Texture2D(800, 600);
		texture2D.LoadImage(data);
		return Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), Vector2.zero);
	}

	public static Texture2D ClipBlank(Texture2D origin)
	{
		Texture2D result;
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = origin.width;
			int num4 = origin.height;
			for (int i = 0; i < origin.width; i++)
			{
				bool flag = false;
				for (int j = 0; j < origin.height; j++)
				{
					if ((double)Math.Abs(origin.GetPixel(i, j).a) > 1E-06)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					num = i;
					break;
				}
			}
			for (int k = origin.width - 1; k >= 0; k--)
			{
				bool flag2 = false;
				for (int l = 0; l < origin.height; l++)
				{
					if ((double)Math.Abs(origin.GetPixel(k, l).a) > 1E-06)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					num3 = k;
					break;
				}
			}
			for (int m = 0; m < origin.height; m++)
			{
				bool flag3 = false;
				for (int n = 0; n < origin.width; n++)
				{
					if ((double)Math.Abs(origin.GetPixel(n, m).a) > 1E-06)
					{
						flag3 = true;
						break;
					}
				}
				if (flag3)
				{
					num2 = m;
					break;
				}
			}
			for (int num5 = origin.height - 1; num5 >= 0; num5--)
			{
				bool flag4 = false;
				for (int num6 = 0; num6 < origin.width; num6++)
				{
					if ((double)Math.Abs(origin.GetPixel(num6, num5).a) > 1E-06)
					{
						flag4 = true;
						break;
					}
				}
				if (flag4)
				{
					num4 = num5;
					break;
				}
			}
			int num7 = num3 - num + 1;
			int num8 = num4 - num2 + 1;
			Texture2D texture2D = new Texture2D(num7, num8, TextureFormat.ARGB32, false);
			texture2D.anisoLevel = 0;
			texture2D.filterMode = FilterMode.Point;
			Color[] pixels = origin.GetPixels(num, num2, num7, num8);
			texture2D.SetPixels(0, 0, num7, num8, pixels);
			texture2D.Apply();
			result = texture2D;
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
			result = null;
		}
		return result;
	}

	public static Texture2D NormalizeTo256(Texture2D origin, Color32[] ClearColors, int style = 0)
	{
		Texture2D texture2D = new Texture2D(16, 16, TextureFormat.ARGB32, false);
		texture2D.anisoLevel = 0;
		texture2D.filterMode = FilterMode.Point;
		texture2D.SetPixels32(ClearColors);
		int x = (16 - origin.width) / 2;
		int y;
		if (style == 1)
		{
			y = 0;
		}
		else
		{
			y = (16 - origin.height) / 2;
		}
		texture2D.SetPixels32(x, y, origin.width, origin.height, origin.GetPixels32());
		texture2D.Apply();
		return texture2D;
	}

	public static Texture2D mergeTexture(Texture2D origin, Texture2D target)
	{
		Color32[] pixels = origin.GetPixels32();
		Color32[] pixels2 = target.GetPixels32();
		Color32[] array = new Color32[pixels.Length];
		for (int i = 0; i < pixels.Length; i++)
		{
			if ((float)pixels2[i].a > 0.5f)
			{
				array[i] = new Color32(pixels2[i].r, pixels2[i].g, pixels2[i].b, pixels2[i].a);
			}
			else
			{
				array[i] = new Color32(pixels[i].r, pixels[i].g, pixels[i].b, pixels[i].a);
			}
		}
		Texture2D texture2D = new Texture2D(16, 16);
		texture2D.anisoLevel = 0;
		texture2D.filterMode = FilterMode.Point;
		texture2D.SetPixels32(array);
		texture2D.Apply();
		return texture2D;
	}

	public static Vector2 movePixelsInTexture(Texture2D origin, Vector2 moveDir)
	{
		Vector2 vector = Vector2.zero;
		int num = 0;
		while ((float)num < Mathf.Abs(moveDir.x))
		{
			Color32[] pixels = origin.GetPixels32();
			Color32[] array = new Color32[pixels.Length];
			Vector2 vector2;
			if (moveDir.x > 0f)
			{
				vector2 = Vector2.right;
			}
			else
			{
				vector2 = Vector2.left;
			}
			if (vector2.x < 0f)
			{
				bool flag = false;
				for (int i = 0; i < pixels.Length; i += 16)
				{
					if ((float)pixels[i].a > 0.5f)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (vector2.x > 0f)
			{
				bool flag2 = false;
				for (int j = 15; j < pixels.Length; j += 16)
				{
					if ((float)pixels[j].a > 0.5f)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					break;
				}
			}
			vector += vector2;
			for (int k = 0; k < pixels.Length; k++)
			{
				int num2 = k % 16;
				int num3 = k / 16;
				if ((float)num2 - vector2.x >= 16f || (float)num2 - vector2.x < 0f || (float)num3 - vector2.y >= 16f || (float)num3 - vector2.y < 0f)
				{
					array[num3 * 16 + num2] = Color.clear;
				}
				else
				{
					array[num3 * 16 + num2] = pixels[num2 - (int)vector2.x + (num3 - (int)vector2.y) * 16];
				}
			}
			origin.SetPixels32(array);
			origin.Apply();
			num++;
		}
		int num4 = 0;
		while ((float)num4 < Mathf.Abs(moveDir.y))
		{
			Color32[] pixels2 = origin.GetPixels32();
			Color32[] array2 = new Color32[pixels2.Length];
			Vector2 vector3;
			if (moveDir.y > 0f)
			{
				vector3 = Vector2.up;
			}
			else
			{
				vector3 = Vector2.down;
			}
			if (vector3.y > 0f)
			{
				bool flag3 = false;
				for (int l = 240; l < pixels2.Length; l++)
				{
					if ((float)pixels2[l].a > 0.5f)
					{
						flag3 = true;
						break;
					}
				}
				if (flag3)
				{
					break;
				}
			}
			if (vector3.y < 0f)
			{
				bool flag4 = false;
				for (int m = 0; m < 16; m++)
				{
					if ((float)pixels2[m].a > 0.5f)
					{
						flag4 = true;
						break;
					}
				}
				if (flag4)
				{
					break;
				}
			}
			vector += vector3;
			for (int n = 0; n < pixels2.Length; n++)
			{
				int num5 = n % 16;
				int num6 = n / 16;
				if ((float)num5 - vector3.x >= 16f || (float)num5 - vector3.x < 0f || (float)num6 - vector3.y >= 16f || (float)num6 - vector3.y < 0f)
				{
					array2[num6 * 16 + num5] = Color.clear;
				}
				else
				{
					array2[num6 * 16 + num5] = pixels2[num5 - (int)vector3.x + (num6 - (int)vector3.y) * 16];
				}
			}
			origin.SetPixels32(array2);
			origin.Apply();
			num4++;
		}
		return vector;
	}

	public static void rotateTexture(Texture2D origin)
	{
		new Texture2D(origin.width, origin.height);
		origin.SetPixels32(ImageTools.RotateImage(origin.GetPixels32()));
		origin.Apply();
	}

	public static Color32[] RotateImage(Color32[] arr)
	{
		Color32[] array = new Color32[arr.Length];
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				array[i * 16 + j] = arr[j * 16 + 16 - i - 1];
			}
		}
		return array;
	}

	public static string Texture2dToBase64(string texture2d_path)
	{
		FileStream fileStream = new FileStream(texture2d_path, FileMode.Open, FileAccess.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, (int)fileStream.Length);
		return Convert.ToBase64String(array);
	}

	public static void SplitTextureToParts(Texture2D origin, out List<Texture2D> connections, out List<Texture2D> separations)
	{
		connections = new List<Texture2D>();
		separations = new List<Texture2D>();
		Color32[] pixels = origin.GetPixels32();
		int[] array = new int[pixels.Length];
		int width = origin.width;
		int height = origin.height;
		for (int i = 0; i < pixels.Length; i++)
		{
			if (pixels[i].a != 0)
			{
				array[i] = i;
			}
			else
			{
				array[i] = -1;
			}
		}
		for (int j = 1; j < height - 1; j++)
		{
			for (int k = 1; k < width - 1; k++)
			{
				if (pixels[j * width + k].a != 0)
				{
					if (array[(j - 1) * width + k - 1] != -1)
					{
						ImageTools.add(j * width + k, (j - 1) * width + k - 1, array);
					}
					if (array[(j - 1) * width + k] != -1)
					{
						ImageTools.add(j * width + k, (j - 1) * width + k, array);
					}
					if (array[(j - 1) * width + k + 1] != -1)
					{
						ImageTools.add(j * width + k, (j - 1) * width + k + 1, array);
					}
					if (array[j * width + k - 1] != -1)
					{
						ImageTools.add(j * width + k, j * width + k - 1, array);
					}
					if (array[j * width + k + 1] != -1)
					{
						ImageTools.add(j * width + k, j * width + k + 1, array);
					}
					if (array[(j + 1) * width + k - 1] != -1)
					{
						ImageTools.add(j * width + k, (j + 1) * width + k - 1, array);
					}
					if (array[(j + 1) * width + k] != -1)
					{
						ImageTools.add(j * width + k, (j + 1) * width + k, array);
					}
					if (array[(j + 1) * width + k + 1] != -1)
					{
						ImageTools.add(j * width + k, (j + 1) * width + k + 1, array);
					}
				}
			}
		}
		for (int l = 0; l < pixels.Length; l++)
		{
			if (array[l] == l)
			{
				Texture2D texture2D = new Texture2D(16, 16);
				Color32[] array2 = new Color32[pixels.Length];
				bool flag = false;
				for (int m = 0; m < pixels.Length; m++)
				{
					if (array[m] == l)
					{
						array2[m] = pixels[m];
						if (m < width || m > pixels.Length - width || m % width == 0 || m % width == width - 1)
						{
							flag = true;
						}
					}
				}
				texture2D.SetPixels32(array2);
				texture2D.Apply();
				if (flag)
				{
					connections.Add(texture2D);
				}
				else
				{
					separations.Add(texture2D);
				}
			}
		}
	}

	private static void add(int a, int b, int[] father)
	{
		if (ImageTools.find(a, father) == ImageTools.find(b, father))
		{
			return;
		}
		if (ImageTools.find(a, father) < ImageTools.find(b, father))
		{
			father[ImageTools.find(b, father)] = ImageTools.find(a, father);
			return;
		}
		father[ImageTools.find(a, father)] = ImageTools.find(b, father);
	}

	private static int find(int i, int[] father)
	{
		if (father[i] != i)
		{
			father[i] = ImageTools.find(father[i], father);
		}
		return father[i];
	}
}
