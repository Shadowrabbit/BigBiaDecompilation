using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VoxelBuilder
{
	public static class BuilderMeshHelper
	{
		public static int FaceCount
		{
			get
			{
				return BuilderMeshHelper.faceCount;
			}
		}

		public static Texture2D CubeTexture
		{
			get
			{
				if (BuilderMeshHelper.texture == null)
				{
					BuilderMeshHelper.texture = BuilderMeshHelper.CreateTexture(BuilderHelper.ColorConfig);
				}
				return BuilderMeshHelper.texture;
			}
		}

		public static Dictionary<Vector3, int> MeshDatas
		{
			get
			{
				return BuilderMeshHelper.cubeColors;
			}
		}

		public static void BuildCube(BuilderMeshHelper.CubeOperateOption option, Vector3 buildPos, int colorIndex, ref MeshFilter meshFilter)
		{
			switch (option)
			{
			case BuilderMeshHelper.CubeOperateOption.Add:
				BuilderMeshHelper.AddDatas(buildPos, colorIndex);
				break;
			case BuilderMeshHelper.CubeOperateOption.Remove:
				BuilderMeshHelper.RemoveDatas(buildPos);
				break;
			case BuilderMeshHelper.CubeOperateOption.ChangeColor:
				BuilderMeshHelper.cubeColors[buildPos] = colorIndex;
				break;
			}
			Mesh mesh = new Mesh();
			BuilderMeshHelper.FaceDatasToMesh(ref mesh);
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			meshFilter.mesh = mesh;
		}

		public static void BuildCube(BuilderMeshHelper.CubeOperateOption option, Dictionary<Vector3, int> meshDatas, ref MeshFilter meshFilter)
		{
			foreach (KeyValuePair<Vector3, int> keyValuePair in meshDatas)
			{
				Vector3 key = keyValuePair.Key;
				int value = keyValuePair.Value;
				switch (option)
				{
				case BuilderMeshHelper.CubeOperateOption.Add:
					BuilderMeshHelper.AddDatas(key, value);
					break;
				case BuilderMeshHelper.CubeOperateOption.Remove:
					BuilderMeshHelper.RemoveDatas(key);
					break;
				case BuilderMeshHelper.CubeOperateOption.ChangeColor:
					BuilderMeshHelper.cubeColors[key] = value;
					break;
				}
			}
			Mesh mesh = new Mesh();
			BuilderMeshHelper.FaceDatasToMesh(ref mesh);
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			meshFilter.mesh = mesh;
		}

		public static int GetCubeColor(Vector3 buildPos)
		{
			return BuilderMeshHelper.cubeColors[buildPos];
		}

		public static void ClearData()
		{
			BuilderMeshHelper.faceCount = 0;
			BuilderMeshHelper.faceDatas.Clear();
			BuilderMeshHelper.cubeColors.Clear();
		}

		public static void CutMeshToCardMode(int cardSize, ref MeshFilter meshFilter)
		{
			int num = (int)((double)cardSize * 0.5);
			Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
			for (int i = BuilderMeshHelper.cubeColors.Count - 1; i >= 0; i--)
			{
				KeyValuePair<Vector3, int> keyValuePair = BuilderMeshHelper.cubeColors.ElementAt(i);
				Vector3 key = keyValuePair.Key;
				if (Mathf.Abs(key.x) >= (float)num || Mathf.Abs(key.z) >= (float)num || key.y < 0f)
				{
					dictionary.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
			BuilderMeshHelper.BuildCube(BuilderMeshHelper.CubeOperateOption.Remove, dictionary, ref meshFilter);
		}

		private static void FaceDatasToMesh(ref Mesh mesh)
		{
			Vector3[] array = new Vector3[BuilderMeshHelper.faceCount * 4];
			int[] array2 = new int[BuilderMeshHelper.faceCount * 6];
			Vector2[] array3 = new Vector2[BuilderMeshHelper.faceCount * 4];
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<Vector3, List<BuilderMeshHelper.CubeFaceType>> keyValuePair in BuilderMeshHelper.faceDatas)
			{
				Vector3 key = keyValuePair.Key;
				foreach (BuilderMeshHelper.CubeFaceType faceType in keyValuePair.Value)
				{
					Vector3[] array4 = BuilderMeshHelper.LeftUpVerticlePosToFullFaceVerticlePositions(key, faceType);
					array[num] = array4[0];
					array[num + 1] = array4[1];
					array[num + 2] = array4[2];
					array[num + 3] = array4[3];
					array2[num2++] = num;
					array2[num2++] = num + 2;
					array2[num2++] = num + 1;
					array2[num2++] = num + 2;
					array2[num2++] = num + 3;
					array2[num2++] = num + 1;
					int num3 = BuilderMeshHelper.cubeColors[BuilderMeshHelper.LeftUpVerticlePosToCubeCenterPos(key, faceType)];
					array3[num] = (new Vector2(0.1f, 0.9f) + new Vector2((float)num3, (float)num3)) * (1f / (float)BuilderHelper.ColorConfig.Count);
					array3[num + 1] = (new Vector2(0.1f, 0.1f) + new Vector2((float)num3, (float)num3)) * (1f / (float)BuilderHelper.ColorConfig.Count);
					array3[num + 2] = (new Vector2(0.9f, 0.9f) + new Vector2((float)num3, (float)num3)) * (1f / (float)BuilderHelper.ColorConfig.Count);
					array3[num + 3] = (new Vector2(0.9f, 0.1f) + new Vector2((float)num3, (float)num3)) * (1f / (float)BuilderHelper.ColorConfig.Count);
					num += 4;
				}
			}
			mesh.vertices = array;
			mesh.triangles = array2;
			mesh.uv = array3;
		}

		private static void AddDatas(Vector3 cubeBuildPos, int colorIndex)
		{
			BuilderMeshHelper.cubeColors.Add(cubeBuildPos, colorIndex);
			Vector3 leftUpVerticlePos = new Vector3(cubeBuildPos.x - BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z - BuilderMeshHelper.HalfCubeSize);
			Vector3 leftUpVerticlePos2 = new Vector3(cubeBuildPos.x - BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y - BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z - BuilderMeshHelper.HalfCubeSize);
			Vector3 leftUpVerticlePos3 = new Vector3(cubeBuildPos.x + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z - BuilderMeshHelper.HalfCubeSize);
			Vector3 leftUpVerticlePos4 = new Vector3(cubeBuildPos.x + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z + BuilderMeshHelper.HalfCubeSize);
			Vector3 leftUpVerticlePos5 = new Vector3(cubeBuildPos.x - BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z + BuilderMeshHelper.HalfCubeSize);
			BuilderMeshHelper.AddFaceData(leftUpVerticlePos, BuilderMeshHelper.CubeFaceType.Back);
			BuilderMeshHelper.AddFaceData(leftUpVerticlePos3, BuilderMeshHelper.CubeFaceType.Right);
			BuilderMeshHelper.AddFaceData(leftUpVerticlePos4, BuilderMeshHelper.CubeFaceType.Forward);
			BuilderMeshHelper.AddFaceData(leftUpVerticlePos5, BuilderMeshHelper.CubeFaceType.Left);
			BuilderMeshHelper.AddFaceData(leftUpVerticlePos5, BuilderMeshHelper.CubeFaceType.Top);
			BuilderMeshHelper.AddFaceData(leftUpVerticlePos2, BuilderMeshHelper.CubeFaceType.Bottom);
		}

		private static void RemoveDatas(Vector3 cubeBuildPos)
		{
			BuilderMeshHelper.cubeColors.Remove(cubeBuildPos);
			Vector3 leftUpVerticlePos = new Vector3(cubeBuildPos.x - BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z - BuilderMeshHelper.HalfCubeSize);
			Vector3 leftUpVerticlePos2 = new Vector3(cubeBuildPos.x - BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y - BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z - BuilderMeshHelper.HalfCubeSize);
			Vector3 leftUpVerticlePos3 = new Vector3(cubeBuildPos.x + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z - BuilderMeshHelper.HalfCubeSize);
			Vector3 leftUpVerticlePos4 = new Vector3(cubeBuildPos.x + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z + BuilderMeshHelper.HalfCubeSize);
			Vector3 leftUpVerticlePos5 = new Vector3(cubeBuildPos.x - BuilderMeshHelper.HalfCubeSize, cubeBuildPos.y + BuilderMeshHelper.HalfCubeSize, cubeBuildPos.z + BuilderMeshHelper.HalfCubeSize);
			BuilderMeshHelper.RemoveFaceData(leftUpVerticlePos, BuilderMeshHelper.CubeFaceType.Back);
			BuilderMeshHelper.RemoveFaceData(leftUpVerticlePos3, BuilderMeshHelper.CubeFaceType.Right);
			BuilderMeshHelper.RemoveFaceData(leftUpVerticlePos4, BuilderMeshHelper.CubeFaceType.Forward);
			BuilderMeshHelper.RemoveFaceData(leftUpVerticlePos5, BuilderMeshHelper.CubeFaceType.Left);
			BuilderMeshHelper.RemoveFaceData(leftUpVerticlePos5, BuilderMeshHelper.CubeFaceType.Top);
			BuilderMeshHelper.RemoveFaceData(leftUpVerticlePos2, BuilderMeshHelper.CubeFaceType.Bottom);
		}

		private static void AddFaceData(Vector3 leftUpVerticlePos, BuilderMeshHelper.CubeFaceType faceType)
		{
			bool flag = false;
			Vector3 oppositeFaceLeftUpVerticlePos = BuilderMeshHelper.GetOppositeFaceLeftUpVerticlePos(leftUpVerticlePos, faceType);
			BuilderMeshHelper.CubeFaceType oppositeFaceType = BuilderMeshHelper.GetOppositeFaceType(faceType);
			if (BuilderMeshHelper.faceDatas.ContainsKey(oppositeFaceLeftUpVerticlePos))
			{
				List<BuilderMeshHelper.CubeFaceType> list = BuilderMeshHelper.faceDatas[oppositeFaceLeftUpVerticlePos];
				if (list.Contains(oppositeFaceType))
				{
					list.Remove(oppositeFaceType);
					BuilderMeshHelper.faceCount--;
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				if (BuilderMeshHelper.faceDatas.ContainsKey(leftUpVerticlePos))
				{
					BuilderMeshHelper.faceDatas[leftUpVerticlePos].Add(faceType);
					BuilderMeshHelper.faceCount++;
					return;
				}
				BuilderMeshHelper.faceDatas.Add(leftUpVerticlePos, new List<BuilderMeshHelper.CubeFaceType>
				{
					faceType
				});
				BuilderMeshHelper.faceCount++;
			}
		}

		private static void RemoveFaceData(Vector3 leftUpVerticlePos, BuilderMeshHelper.CubeFaceType faceType)
		{
			if (BuilderMeshHelper.faceDatas.ContainsKey(leftUpVerticlePos))
			{
				List<BuilderMeshHelper.CubeFaceType> list = BuilderMeshHelper.faceDatas[leftUpVerticlePos];
				if (list.Contains(faceType))
				{
					list.Remove(faceType);
					BuilderMeshHelper.faceCount--;
					return;
				}
			}
			Vector3 oppositeFaceLeftUpVerticlePos = BuilderMeshHelper.GetOppositeFaceLeftUpVerticlePos(leftUpVerticlePos, faceType);
			BuilderMeshHelper.CubeFaceType oppositeFaceType = BuilderMeshHelper.GetOppositeFaceType(faceType);
			if (BuilderMeshHelper.faceDatas.ContainsKey(oppositeFaceLeftUpVerticlePos))
			{
				BuilderMeshHelper.faceDatas[oppositeFaceLeftUpVerticlePos].Add(oppositeFaceType);
				BuilderMeshHelper.faceCount++;
				return;
			}
			BuilderMeshHelper.faceDatas.Add(oppositeFaceLeftUpVerticlePos, new List<BuilderMeshHelper.CubeFaceType>
			{
				oppositeFaceType
			});
			BuilderMeshHelper.faceCount++;
		}

		private static Vector3 GetOppositeFaceLeftUpVerticlePos(Vector3 leftUpVerticlePos, BuilderMeshHelper.CubeFaceType faceType)
		{
			switch (faceType)
			{
			case BuilderMeshHelper.CubeFaceType.Forward:
				return leftUpVerticlePos + Vector3.left * BuilderMeshHelper.CubeSize;
			case BuilderMeshHelper.CubeFaceType.Back:
				return leftUpVerticlePos + Vector3.right * BuilderMeshHelper.CubeSize;
			case BuilderMeshHelper.CubeFaceType.Left:
				return leftUpVerticlePos + Vector3.back * BuilderMeshHelper.CubeSize;
			case BuilderMeshHelper.CubeFaceType.Right:
				return leftUpVerticlePos + Vector3.forward * BuilderMeshHelper.CubeSize;
			case BuilderMeshHelper.CubeFaceType.Top:
				return leftUpVerticlePos + Vector3.back * BuilderMeshHelper.CubeSize;
			case BuilderMeshHelper.CubeFaceType.Bottom:
				return leftUpVerticlePos + Vector3.forward * BuilderMeshHelper.CubeSize;
			default:
				throw new Exception("Fatal Error!");
			}
		}

		private static BuilderMeshHelper.CubeFaceType GetOppositeFaceType(BuilderMeshHelper.CubeFaceType faceType)
		{
			switch (faceType)
			{
			case BuilderMeshHelper.CubeFaceType.Forward:
				return BuilderMeshHelper.CubeFaceType.Back;
			case BuilderMeshHelper.CubeFaceType.Back:
				return BuilderMeshHelper.CubeFaceType.Forward;
			case BuilderMeshHelper.CubeFaceType.Left:
				return BuilderMeshHelper.CubeFaceType.Right;
			case BuilderMeshHelper.CubeFaceType.Right:
				return BuilderMeshHelper.CubeFaceType.Left;
			case BuilderMeshHelper.CubeFaceType.Top:
				return BuilderMeshHelper.CubeFaceType.Bottom;
			case BuilderMeshHelper.CubeFaceType.Bottom:
				return BuilderMeshHelper.CubeFaceType.Top;
			default:
				throw new Exception("Fatal Error!");
			}
		}

		private static Vector3[] LeftUpVerticlePosToFullFaceVerticlePositions(Vector3 leftUpVerticlePos, BuilderMeshHelper.CubeFaceType faceType)
		{
			Vector3[] array = new Vector3[4];
			array[0] = leftUpVerticlePos;
			switch (faceType)
			{
			case BuilderMeshHelper.CubeFaceType.Forward:
				array[1] = leftUpVerticlePos + Vector3.down * BuilderMeshHelper.CubeSize;
				array[2] = leftUpVerticlePos + Vector3.left * BuilderMeshHelper.CubeSize;
				array[3] = array[1] + Vector3.left * BuilderMeshHelper.CubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Back:
				array[1] = leftUpVerticlePos + Vector3.down * BuilderMeshHelper.CubeSize;
				array[2] = leftUpVerticlePos + Vector3.right * BuilderMeshHelper.CubeSize;
				array[3] = array[1] + Vector3.right * BuilderMeshHelper.CubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Left:
				array[1] = leftUpVerticlePos + Vector3.down * BuilderMeshHelper.CubeSize;
				array[2] = leftUpVerticlePos + Vector3.back * BuilderMeshHelper.CubeSize;
				array[3] = array[1] + Vector3.back * BuilderMeshHelper.CubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Right:
				array[1] = leftUpVerticlePos + Vector3.down * BuilderMeshHelper.CubeSize;
				array[2] = leftUpVerticlePos + Vector3.forward * BuilderMeshHelper.CubeSize;
				array[3] = array[1] + Vector3.forward * BuilderMeshHelper.CubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Top:
				array[1] = leftUpVerticlePos + Vector3.back * BuilderMeshHelper.CubeSize;
				array[2] = leftUpVerticlePos + Vector3.right * BuilderMeshHelper.CubeSize;
				array[3] = array[1] + Vector3.right * BuilderMeshHelper.CubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Bottom:
				array[1] = leftUpVerticlePos + Vector3.forward * BuilderMeshHelper.CubeSize;
				array[2] = leftUpVerticlePos + Vector3.right * BuilderMeshHelper.CubeSize;
				array[3] = array[1] + Vector3.right * BuilderMeshHelper.CubeSize;
				break;
			default:
				throw new Exception("Fatal Error!");
			}
			return array;
		}

		private static Vector3 LeftUpVerticlePosToCubeCenterPos(Vector3 leftUpVerticlePos, BuilderMeshHelper.CubeFaceType faceType)
		{
			Vector3 b = Vector3.zero;
			switch (faceType)
			{
			case BuilderMeshHelper.CubeFaceType.Forward:
				b = (Vector3.left + Vector3.back + Vector3.down) * BuilderMeshHelper.HalfCubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Back:
				b = (Vector3.right + Vector3.forward + Vector3.down) * BuilderMeshHelper.HalfCubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Left:
				b = (Vector3.right + Vector3.back + Vector3.down) * BuilderMeshHelper.HalfCubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Right:
				b = (Vector3.left + Vector3.forward + Vector3.down) * BuilderMeshHelper.HalfCubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Top:
				b = (Vector3.right + Vector3.back + Vector3.down) * BuilderMeshHelper.HalfCubeSize;
				break;
			case BuilderMeshHelper.CubeFaceType.Bottom:
				b = (Vector3.right + Vector3.forward + Vector3.up) * BuilderMeshHelper.HalfCubeSize;
				break;
			}
			return leftUpVerticlePos + b;
		}

		private static Texture2D CreateTexture(List<Color> ColorConfig)
		{
			Texture2D texture2D = new Texture2D(1, ColorConfig.Count, TextureFormat.RGBA32, false, false);
			int num = 0;
			foreach (Color color in ColorConfig)
			{
				texture2D.SetPixel(0, num++, color);
			}
			texture2D.filterMode = FilterMode.Point;
			texture2D.Apply();
			return texture2D;
		}

		public static Texture2D CreateCardPng(int x, int z)
		{
			Texture2D texture2D = new Texture2D(x, z, TextureFormat.RGBA32, false, false);
			texture2D.filterMode = FilterMode.Point;
			foreach (KeyValuePair<Vector3, int> keyValuePair in BuilderMeshHelper.cubeColors)
			{
				Vector3 key = keyValuePair.Key;
				Color color = BuilderHelper.ColorConfig[keyValuePair.Value];
				int x2 = (int)key.x + x / 2;
				int y = (int)key.z + z / 2;
				texture2D.SetPixel(x2, y, color);
			}
			texture2D.Apply();
			return texture2D;
		}

		public static Texture2D CreateSculpturePng(int x, int y)
		{
			Texture2D texture2D = new Texture2D(x, y, TextureFormat.RGBA32, false, false);
			texture2D.filterMode = FilterMode.Point;
			Dictionary<Vector2, float> dictionary = new Dictionary<Vector2, float>();
			foreach (Vector3 vector in BuilderMeshHelper.cubeColors.Keys)
			{
				Vector2 key = new Vector2(vector.x, vector.y);
				if (dictionary.ContainsKey(key))
				{
					if (vector.z < dictionary[key])
					{
						dictionary[key] = vector.z;
					}
				}
				else
				{
					dictionary.Add(key, vector.z);
				}
			}
			foreach (KeyValuePair<Vector2, float> keyValuePair in dictionary)
			{
				Vector3 key2 = new Vector3(keyValuePair.Key.x, keyValuePair.Key.y, keyValuePair.Value);
				Color color = BuilderHelper.ColorConfig[BuilderMeshHelper.cubeColors[key2]];
				int x2 = (int)keyValuePair.Key.x + x / 2;
				int y2 = (int)keyValuePair.Key.y + y / 2;
				texture2D.SetPixel(x2, y2, color);
			}
			texture2D.Apply();
			return texture2D;
		}

		private static float CubeSize = 1f;

		private static float HalfCubeSize = BuilderMeshHelper.CubeSize * 0.5f;

		private static Dictionary<Vector3, List<BuilderMeshHelper.CubeFaceType>> faceDatas = new Dictionary<Vector3, List<BuilderMeshHelper.CubeFaceType>>();

		private static Dictionary<Vector3, int> cubeColors = new Dictionary<Vector3, int>();

		private static int faceCount = 0;

		private static Texture2D texture;

		private enum CubeFaceType
		{
			Forward,
			Back,
			Left,
			Right,
			Top,
			Bottom
		}

		public enum CubeOperateOption
		{
			Add,
			Remove,
			ChangeColor
		}
	}
}
