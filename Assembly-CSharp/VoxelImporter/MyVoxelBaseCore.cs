using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace VoxelImporter
{
	public abstract class MyVoxelBaseCore
	{
		public MyVoxelBaseCore(VoxelBase target)
		{
			this.voxelBase = target;
		}

		public VoxelBase voxelBase { get; set; }

		public virtual void Initialize()
		{
			this.voxelBase.EditorInitialize();
			this.voxelBase.SaveEditTmpData();
			if (!this.ReadyVoxelData())
			{
				this.voxelBase.edit_configureMode = VoxelBase.Edit_configureMode.None;
			}
			this.AutoSetSelectedWireframeHidden();
			this.RefreshCheckerClear();
			this.RefreshCheckerSave();
		}

		protected virtual void CreateChunkData()
		{
		}

		public bool Create(string path)
		{
			if (!File.Exists(path))
			{
				Debug.LogErrorFormat("<color=green>[VoxelCharacteImporter]</color> Voxel file not found. <color=red>{0}</color>", new object[]
				{
					path
				});
				return false;
			}
			this.voxelBase.voxelFilePath = path;
			this.voxelBase.voxelFileGUID = "";
			bool flag = this.LoadVoxelData();
			if (flag)
			{
				flag = this.CreateMesh();
			}
			return flag;
		}

		public bool Create(byte[] pngData)
		{
			bool flag = this.LoadVoxelData(pngData);
			if (flag)
			{
				flag = this.CreateMesh();
			}
			return flag;
		}

		public bool ReCreate()
		{
			return this.Create(this.voxelBase.voxelFilePath);
		}

		public bool IsVoxelFileExists()
		{
			return false;
		}

		public bool ReadyVoxelData()
		{
			return this.voxelBase.voxelData != null || this.LoadVoxelData();
		}

		protected bool LoadVoxelData()
		{
			bool result = false;
			if (!string.IsNullOrEmpty(this.voxelBase.voxelFilePath) && File.Exists(this.voxelBase.voxelFilePath))
			{
				using (BinaryReader binaryReader = new BinaryReader(File.Open(this.voxelBase.voxelFilePath, FileMode.Open)))
				{
					string extension = Path.GetExtension(this.voxelBase.voxelFilePath);
					if (extension == ".vox")
					{
						result = this.LoadVoxelDataFromVOX(binaryReader);
					}
					else if (extension == ".qb")
					{
						result = this.LoadVoxelDataFromQB(binaryReader);
					}
					else if (extension == ".png")
					{
						result = this.LoadVoxelDataFromPNG(binaryReader);
					}
					else
					{
						result = false;
					}
				}
			}
			return result;
		}

		protected bool LoadVoxelData(byte[] pngData)
		{
			if (pngData == null || pngData.Length == 0)
			{
				return false;
			}
			bool result = false;
			using (Stream stream = new MemoryStream(pngData))
			{
				using (BinaryReader binaryReader = new BinaryReader(stream))
				{
					result = this.LoadVoxelDataFromPNG(binaryReader);
				}
			}
			return result;
		}

		protected virtual bool LoadVoxelDataFromVOX(BinaryReader br)
		{
			Func<string, bool> func = delegate(string name)
			{
				if (br.BaseStream.Length - br.BaseStream.Position < 4L)
				{
					return false;
				}
				string b3 = new string(br.ReadChars(4));
				return name == b3;
			};
			if (!func("VOX "))
			{
				Debug.LogError("[VoxelImporter] vox file error.");
				return false;
			}
			br.BaseStream.Seek(4L, SeekOrigin.Current);
			if (!func("MAIN"))
			{
				Debug.LogError("[VoxelImporter] vox chunk error.");
				return false;
			}
			br.BaseStream.Seek(8L, SeekOrigin.Current);
			if (!func("SIZE"))
			{
				Debug.LogError("[VoxelImporter] vox chunk error.");
				return false;
			}
			br.BaseStream.Seek(8L, SeekOrigin.Current);
			int x = (int)br.ReadUInt32();
			int z = (int)br.ReadUInt32();
			int y = (int)br.ReadUInt32();
			IntVector3 intVector = new IntVector3(x, y, z);
			if (!func("XYZI"))
			{
				Debug.LogError("[VoxelImporter] vox chunk error.");
				return false;
			}
			br.BaseStream.Seek(8L, SeekOrigin.Current);
			uint num = br.ReadUInt32();
			VoxelData.Voxel[] array = new VoxelData.Voxel[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				int x2 = intVector.x - 1 - (int)br.ReadByte();
				int z2 = intVector.z - 1 - (int)br.ReadByte();
				byte y2 = br.ReadByte();
				byte b = br.ReadByte();
				array[num2] = new VoxelData.Voxel(x2, (int)y2, z2, (int)(b - 1));
				num2++;
			}
			Color[] array2;
			if (func("RGBA"))
			{
				br.BaseStream.Seek(8L, SeekOrigin.Current);
				array2 = new Color[256];
				for (int i = 0; i < 256; i++)
				{
					byte r = br.ReadByte();
					byte g = br.ReadByte();
					byte b2 = br.ReadByte();
					byte a = br.ReadByte();
					a = byte.MaxValue;
					array2[i] = new Color32(r, g, b2, a);
				}
			}
			else
			{
				Color[] array3 = new Color[]
				{
					new Color(0.988f, 0.988f, 0.988f, 1f),
					new Color(0.988f, 0.988f, 0.8f, 1f),
					new Color(0.988f, 0.988f, 0.596f, 1f),
					new Color(0.988f, 0.988f, 0.392f, 1f),
					new Color(0.988f, 0.988f, 0.188f, 1f),
					new Color(0.988f, 0.988f, 0f, 1f),
					new Color(0.988f, 0.8f, 0.988f, 1f),
					new Color(0.988f, 0.8f, 0.8f, 1f),
					new Color(0.988f, 0.8f, 0.596f, 1f),
					new Color(0.988f, 0.8f, 0.392f, 1f),
					new Color(0.988f, 0.8f, 0.188f, 1f),
					new Color(0.988f, 0.8f, 0f, 1f),
					new Color(0.988f, 0.596f, 0.988f, 1f),
					new Color(0.988f, 0.596f, 0.8f, 1f),
					new Color(0.988f, 0.596f, 0.596f, 1f),
					new Color(0.988f, 0.596f, 0.392f, 1f),
					new Color(0.988f, 0.596f, 0.188f, 1f),
					new Color(0.988f, 0.596f, 0f, 1f),
					new Color(0.988f, 0.392f, 0.988f, 1f),
					new Color(0.988f, 0.392f, 0.8f, 1f),
					new Color(0.988f, 0.392f, 0.596f, 1f),
					new Color(0.988f, 0.392f, 0.392f, 1f),
					new Color(0.988f, 0.392f, 0.188f, 1f),
					new Color(0.988f, 0.392f, 0f, 1f),
					new Color(0.988f, 0.188f, 0.988f, 1f),
					new Color(0.988f, 0.188f, 0.8f, 1f),
					new Color(0.988f, 0.188f, 0.596f, 1f),
					new Color(0.988f, 0.188f, 0.392f, 1f),
					new Color(0.988f, 0.188f, 0.188f, 1f),
					new Color(0.988f, 0.188f, 0f, 1f),
					new Color(0.988f, 0f, 0.988f, 1f),
					new Color(0.988f, 0f, 0.8f, 1f),
					new Color(0.988f, 0f, 0.596f, 1f),
					new Color(0.988f, 0f, 0.392f, 1f),
					new Color(0.988f, 0f, 0.188f, 1f),
					new Color(0.988f, 0f, 0f, 1f),
					new Color(0.8f, 0.988f, 0.988f, 1f),
					new Color(0.8f, 0.988f, 0.8f, 1f),
					new Color(0.8f, 0.988f, 0.596f, 1f),
					new Color(0.8f, 0.988f, 0.392f, 1f),
					new Color(0.8f, 0.988f, 0.188f, 1f),
					new Color(0.8f, 0.988f, 0f, 1f),
					new Color(0.8f, 0.8f, 0.988f, 1f),
					new Color(0.8f, 0.8f, 0.8f, 1f),
					new Color(0.8f, 0.8f, 0.596f, 1f),
					new Color(0.8f, 0.8f, 0.392f, 1f),
					new Color(0.8f, 0.8f, 0.188f, 1f),
					new Color(0.8f, 0.8f, 0f, 1f),
					new Color(0.8f, 0.596f, 0.988f, 1f),
					new Color(0.8f, 0.596f, 0.8f, 1f),
					new Color(0.8f, 0.596f, 0.596f, 1f),
					new Color(0.8f, 0.596f, 0.392f, 1f),
					new Color(0.8f, 0.596f, 0.188f, 1f),
					new Color(0.8f, 0.596f, 0f, 1f),
					new Color(0.8f, 0.392f, 0.988f, 1f),
					new Color(0.8f, 0.392f, 0.8f, 1f),
					new Color(0.8f, 0.392f, 0.596f, 1f),
					new Color(0.8f, 0.392f, 0.392f, 1f),
					new Color(0.8f, 0.392f, 0.188f, 1f),
					new Color(0.8f, 0.392f, 0f, 1f),
					new Color(0.8f, 0.188f, 0.988f, 1f),
					new Color(0.8f, 0.188f, 0.8f, 1f),
					new Color(0.8f, 0.188f, 0.596f, 1f),
					new Color(0.8f, 0.188f, 0.392f, 1f),
					new Color(0.8f, 0.188f, 0.188f, 1f),
					new Color(0.8f, 0.188f, 0f, 1f),
					new Color(0.8f, 0f, 0.988f, 1f),
					new Color(0.8f, 0f, 0.8f, 1f),
					new Color(0.8f, 0f, 0.596f, 1f),
					new Color(0.8f, 0f, 0.392f, 1f),
					new Color(0.8f, 0f, 0.188f, 1f),
					new Color(0.8f, 0f, 0f, 1f),
					new Color(0.596f, 0.988f, 0.988f, 1f),
					new Color(0.596f, 0.988f, 0.8f, 1f),
					new Color(0.596f, 0.988f, 0.596f, 1f),
					new Color(0.596f, 0.988f, 0.392f, 1f),
					new Color(0.596f, 0.988f, 0.188f, 1f),
					new Color(0.596f, 0.988f, 0f, 1f),
					new Color(0.596f, 0.8f, 0.988f, 1f),
					new Color(0.596f, 0.8f, 0.8f, 1f),
					new Color(0.596f, 0.8f, 0.596f, 1f),
					new Color(0.596f, 0.8f, 0.392f, 1f),
					new Color(0.596f, 0.8f, 0.188f, 1f),
					new Color(0.596f, 0.8f, 0f, 1f),
					new Color(0.596f, 0.596f, 0.988f, 1f),
					new Color(0.596f, 0.596f, 0.8f, 1f),
					new Color(0.596f, 0.596f, 0.596f, 1f),
					new Color(0.596f, 0.596f, 0.392f, 1f),
					new Color(0.596f, 0.596f, 0.188f, 1f),
					new Color(0.596f, 0.596f, 0f, 1f),
					new Color(0.596f, 0.392f, 0.988f, 1f),
					new Color(0.596f, 0.392f, 0.8f, 1f),
					new Color(0.596f, 0.392f, 0.596f, 1f),
					new Color(0.596f, 0.392f, 0.392f, 1f),
					new Color(0.596f, 0.392f, 0.188f, 1f),
					new Color(0.596f, 0.392f, 0f, 1f),
					new Color(0.596f, 0.188f, 0.988f, 1f),
					new Color(0.596f, 0.188f, 0.8f, 1f),
					new Color(0.596f, 0.188f, 0.596f, 1f),
					new Color(0.596f, 0.188f, 0.392f, 1f),
					new Color(0.596f, 0.188f, 0.188f, 1f),
					new Color(0.596f, 0.188f, 0f, 1f),
					new Color(0.596f, 0f, 0.988f, 1f),
					new Color(0.596f, 0f, 0.8f, 1f),
					new Color(0.596f, 0f, 0.596f, 1f),
					new Color(0.596f, 0f, 0.392f, 1f),
					new Color(0.596f, 0f, 0.188f, 1f),
					new Color(0.596f, 0f, 0f, 1f),
					new Color(0.392f, 0.988f, 0.988f, 1f),
					new Color(0.392f, 0.988f, 0.8f, 1f),
					new Color(0.392f, 0.988f, 0.596f, 1f),
					new Color(0.392f, 0.988f, 0.392f, 1f),
					new Color(0.392f, 0.988f, 0.188f, 1f),
					new Color(0.392f, 0.988f, 0f, 1f),
					new Color(0.392f, 0.8f, 0.988f, 1f),
					new Color(0.392f, 0.8f, 0.8f, 1f),
					new Color(0.392f, 0.8f, 0.596f, 1f),
					new Color(0.392f, 0.8f, 0.392f, 1f),
					new Color(0.392f, 0.8f, 0.188f, 1f),
					new Color(0.392f, 0.8f, 0f, 1f),
					new Color(0.392f, 0.596f, 0.988f, 1f),
					new Color(0.392f, 0.596f, 0.8f, 1f),
					new Color(0.392f, 0.596f, 0.596f, 1f),
					new Color(0.392f, 0.596f, 0.392f, 1f),
					new Color(0.392f, 0.596f, 0.188f, 1f),
					new Color(0.392f, 0.596f, 0f, 1f),
					new Color(0.392f, 0.392f, 0.988f, 1f),
					new Color(0.392f, 0.392f, 0.8f, 1f),
					new Color(0.392f, 0.392f, 0.596f, 1f),
					new Color(0.392f, 0.392f, 0.392f, 1f),
					new Color(0.392f, 0.392f, 0.188f, 1f),
					new Color(0.392f, 0.392f, 0f, 1f),
					new Color(0.392f, 0.188f, 0.988f, 1f),
					new Color(0.392f, 0.188f, 0.8f, 1f),
					new Color(0.392f, 0.188f, 0.596f, 1f),
					new Color(0.392f, 0.188f, 0.392f, 1f),
					new Color(0.392f, 0.188f, 0.188f, 1f),
					new Color(0.392f, 0.188f, 0f, 1f),
					new Color(0.392f, 0f, 0.988f, 1f),
					new Color(0.392f, 0f, 0.8f, 1f),
					new Color(0.392f, 0f, 0.596f, 1f),
					new Color(0.392f, 0f, 0.392f, 1f),
					new Color(0.392f, 0f, 0.188f, 1f),
					new Color(0.392f, 0f, 0f, 1f),
					new Color(0.188f, 0.988f, 0.988f, 1f),
					new Color(0.188f, 0.988f, 0.8f, 1f),
					new Color(0.188f, 0.988f, 0.596f, 1f),
					new Color(0.188f, 0.988f, 0.392f, 1f),
					new Color(0.188f, 0.988f, 0.188f, 1f),
					new Color(0.188f, 0.988f, 0f, 1f),
					new Color(0.188f, 0.8f, 0.988f, 1f),
					new Color(0.188f, 0.8f, 0.8f, 1f),
					new Color(0.188f, 0.8f, 0.596f, 1f),
					new Color(0.188f, 0.8f, 0.392f, 1f),
					new Color(0.188f, 0.8f, 0.188f, 1f),
					new Color(0.188f, 0.8f, 0f, 1f),
					new Color(0.188f, 0.596f, 0.988f, 1f),
					new Color(0.188f, 0.596f, 0.8f, 1f),
					new Color(0.188f, 0.596f, 0.596f, 1f),
					new Color(0.188f, 0.596f, 0.392f, 1f),
					new Color(0.188f, 0.596f, 0.188f, 1f),
					new Color(0.188f, 0.596f, 0f, 1f),
					new Color(0.188f, 0.392f, 0.988f, 1f),
					new Color(0.188f, 0.392f, 0.8f, 1f),
					new Color(0.188f, 0.392f, 0.596f, 1f),
					new Color(0.188f, 0.392f, 0.392f, 1f),
					new Color(0.188f, 0.392f, 0.188f, 1f),
					new Color(0.188f, 0.392f, 0f, 1f),
					new Color(0.188f, 0.188f, 0.988f, 1f),
					new Color(0.188f, 0.188f, 0.8f, 1f),
					new Color(0.188f, 0.188f, 0.596f, 1f),
					new Color(0.188f, 0.188f, 0.392f, 1f),
					new Color(0.188f, 0.188f, 0.188f, 1f),
					new Color(0.188f, 0.188f, 0f, 1f),
					new Color(0.188f, 0f, 0.988f, 1f),
					new Color(0.188f, 0f, 0.8f, 1f),
					new Color(0.188f, 0f, 0.596f, 1f),
					new Color(0.188f, 0f, 0.392f, 1f),
					new Color(0.188f, 0f, 0.188f, 1f),
					new Color(0.188f, 0f, 0f, 1f),
					new Color(0f, 0.988f, 0.988f, 1f),
					new Color(0f, 0.988f, 0.8f, 1f),
					new Color(0f, 0.988f, 0.596f, 1f),
					new Color(0f, 0.988f, 0.392f, 1f),
					new Color(0f, 0.988f, 0.188f, 1f),
					new Color(0f, 0.988f, 0f, 1f),
					new Color(0f, 0.8f, 0.988f, 1f),
					new Color(0f, 0.8f, 0.8f, 1f),
					new Color(0f, 0.8f, 0.596f, 1f),
					new Color(0f, 0.8f, 0.392f, 1f),
					new Color(0f, 0.8f, 0.188f, 1f),
					new Color(0f, 0.8f, 0f, 1f),
					new Color(0f, 0.596f, 0.988f, 1f),
					new Color(0f, 0.596f, 0.8f, 1f),
					new Color(0f, 0.596f, 0.596f, 1f),
					new Color(0f, 0.596f, 0.392f, 1f),
					new Color(0f, 0.596f, 0.188f, 1f),
					new Color(0f, 0.596f, 0f, 1f),
					new Color(0f, 0.392f, 0.988f, 1f),
					new Color(0f, 0.392f, 0.8f, 1f),
					new Color(0f, 0.392f, 0.596f, 1f),
					new Color(0f, 0.392f, 0.392f, 1f),
					new Color(0f, 0.392f, 0.188f, 1f),
					new Color(0f, 0.392f, 0f, 1f),
					new Color(0f, 0.188f, 0.988f, 1f),
					new Color(0f, 0.188f, 0.8f, 1f),
					new Color(0f, 0.188f, 0.596f, 1f),
					new Color(0f, 0.188f, 0.392f, 1f),
					new Color(0f, 0.188f, 0.188f, 1f),
					new Color(0f, 0.188f, 0f, 1f),
					new Color(0f, 0f, 0.988f, 1f),
					new Color(0f, 0f, 0.8f, 1f),
					new Color(0f, 0f, 0.596f, 1f),
					new Color(0f, 0f, 0.392f, 1f),
					new Color(0f, 0f, 0.188f, 1f),
					new Color(0.925f, 0f, 0f, 1f),
					new Color(0.863f, 0f, 0f, 1f),
					new Color(0.722f, 0f, 0f, 1f),
					new Color(0.659f, 0f, 0f, 1f),
					new Color(0.533f, 0f, 0f, 1f),
					new Color(0.455f, 0f, 0f, 1f),
					new Color(0.329f, 0f, 0f, 1f),
					new Color(0.267f, 0f, 0f, 1f),
					new Color(0.125f, 0f, 0f, 1f),
					new Color(0.063f, 0f, 0f, 1f),
					new Color(0f, 0.925f, 0f, 1f),
					new Color(0f, 0.863f, 0f, 1f),
					new Color(0f, 0.722f, 0f, 1f),
					new Color(0f, 0.659f, 0f, 1f),
					new Color(0f, 0.533f, 0f, 1f),
					new Color(0f, 0.455f, 0f, 1f),
					new Color(0f, 0.329f, 0f, 1f),
					new Color(0f, 0.267f, 0f, 1f),
					new Color(0f, 0.125f, 0f, 1f),
					new Color(0f, 0.063f, 0f, 1f),
					new Color(0f, 0f, 0.925f, 1f),
					new Color(0f, 0f, 0.863f, 1f),
					new Color(0f, 0f, 0.722f, 1f),
					new Color(0f, 0f, 0.659f, 1f),
					new Color(0f, 0f, 0.533f, 1f),
					new Color(0f, 0f, 0.455f, 1f),
					new Color(0f, 0f, 0.329f, 1f),
					new Color(0f, 0f, 0.267f, 1f),
					new Color(0f, 0f, 0.125f, 1f),
					new Color(0f, 0f, 0.063f, 1f),
					new Color(0.925f, 0.925f, 0.925f, 1f),
					new Color(0.863f, 0.863f, 0.863f, 1f),
					new Color(0.722f, 0.722f, 0.722f, 1f),
					new Color(0.659f, 0.659f, 0.659f, 1f),
					new Color(0.533f, 0.533f, 0.533f, 1f),
					new Color(0.455f, 0.455f, 0.455f, 1f),
					new Color(0.329f, 0.329f, 0.329f, 1f),
					new Color(0.267f, 0.267f, 0.267f, 1f),
					new Color(0.125f, 0.125f, 0.125f, 1f),
					new Color(0.063f, 0.063f, 0.063f, 1f),
					new Color(0f, 0f, 0f, 1f)
				};
				array2 = new Color[256];
				for (int j = 0; j < 256; j++)
				{
					array2[j] = array3[j];
				}
			}
			int[] array4 = new int[array2.Length];
			for (int k = 0; k < array.Length; k++)
			{
				array4[array[k].palette]++;
			}
			int[] array5 = new int[array2.Length];
			for (int l = 0; l < array4.Length; l++)
			{
				for (int m = l - 1; m >= 0; m--)
				{
					if (array4[m] == 0)
					{
						array5[l]++;
					}
				}
			}
			for (int n = 0; n < array.Length; n++)
			{
				VoxelData.Voxel[] array6 = array;
				int num3 = n;
				array6[num3].palette = array6[num3].palette - array5[array[n].palette];
			}
			List<Color> list = new List<Color>(array2.Length);
			for (int num4 = 0; num4 < array4.Length; num4++)
			{
				if (array4[num4] > 0)
				{
					list.Add(array2[num4]);
				}
			}
			array2 = list.ToArray();
			this.voxelBase.localOffset = new Vector3(-((float)intVector.x / 2f), 0f, -((float)intVector.z / 2f));
			this.voxelBase.fileType = VoxelBase.FileType.vox;
			this.voxelBase.voxelData = new VoxelData();
			this.voxelBase.voxelData.voxels = array;
			this.voxelBase.voxelData.palettes = array2;
			this.voxelBase.voxelData.voxelSize = intVector;
			this.ApplyImportFlags();
			this.voxelBase.voxelData.CreateVoxelTable();
			this.UpdateVisibleFlags();
			this.CreateChunkData();
			return true;
		}

		protected virtual bool LoadVoxelDataFromQB(BinaryReader br)
		{
			br.BaseStream.Seek(4L, SeekOrigin.Current);
			uint colorFormat = br.ReadUInt32();
			uint num = br.ReadUInt32();
			uint num2 = br.ReadUInt32();
			br.BaseStream.Seek(4L, SeekOrigin.Current);
			uint num3 = br.ReadUInt32();
			List<VoxelData.Voxel> voxelList = new List<VoxelData.Voxel>();
			Dictionary<Color, int> paletteList = new Dictionary<Color, int>();
			Dictionary<int, Dictionary<int, HashSet<int>>> doneTable = new Dictionary<int, Dictionary<int, HashSet<int>>>();
			Action<int, int, int, uint> action = delegate(int x, int y, int z, uint data)
			{
				Color color;
				if (colorFormat == 0U)
				{
					byte a = (byte)((data & 4278190080U) >> 24);
					byte b2 = (byte)((data & 16711680U) >> 16);
					byte g = (byte)((data & 65280U) >> 8);
					color = new Color32((byte)(data & 255U), g, b2, a);
				}
				else
				{
					byte a2 = (byte)((data & 4278190080U) >> 24);
					byte r = (byte)((data & 16711680U) >> 16);
					byte g2 = (byte)((data & 65280U) >> 8);
					byte b3 = (byte)(data & 255U);
					color = new Color32(r, g2, b3, a2);
				}
				if (color.a > 0f && (!doneTable.ContainsKey(x) || !doneTable[x].ContainsKey(y) || !doneTable[x][y].Contains(z)))
				{
					if (!doneTable.ContainsKey(x))
					{
						doneTable.Add(x, new Dictionary<int, HashSet<int>>());
					}
					if (!doneTable[x].ContainsKey(y))
					{
						doneTable[x].Add(y, new HashSet<int>());
					}
					doneTable[x][y].Add(z);
					color.a = 1f;
					int num23;
					if (paletteList.ContainsKey(color))
					{
						num23 = paletteList[color];
					}
					else
					{
						num23 = paletteList.Count;
						paletteList.Add(color, num23);
					}
					voxelList.Add(new VoxelData.Voxel(x, y, z, num23));
				}
			};
			int num4 = 0;
			while ((long)num4 < (long)((ulong)num3))
			{
				byte b = br.ReadByte();
				br.BaseStream.Seek((long)((ulong)b), SeekOrigin.Current);
				uint num5 = br.ReadUInt32();
				uint num6 = br.ReadUInt32();
				uint num7 = br.ReadUInt32();
				int num8 = br.ReadInt32();
				int num9 = br.ReadInt32();
				int num10 = br.ReadInt32();
				if (num2 == 0U)
				{
					int num11 = 0;
					while ((long)num11 < (long)((ulong)num7))
					{
						int num12 = 0;
						while ((long)num12 < (long)((ulong)num6))
						{
							int num13 = 0;
							while ((long)num13 < (long)((ulong)num5))
							{
								int arg = num8 + num13;
								int arg2 = num9 + num12;
								int arg3 = (num == 0U) ? (-(num10 + num11 + 1)) : (num10 + num11);
								action(arg, arg2, arg3, br.ReadUInt32());
								num13++;
							}
							num12++;
						}
						num11++;
					}
				}
				else
				{
					int num14 = 0;
					while ((long)num14 < (long)((ulong)num7))
					{
						num14++;
						int num15 = 0;
						for (;;)
						{
							uint num16 = br.ReadUInt32();
							if (num16 == 6U)
							{
								break;
							}
							if (num16 == 2U)
							{
								uint num17 = br.ReadUInt32();
								num16 = br.ReadUInt32();
								int num18 = 0;
								while ((long)num18 < (long)((ulong)num17))
								{
									int num19 = (int)((long)num15 % (long)((ulong)num5)) + 1;
									int num20 = (int)((long)num15 / (long)((ulong)num5)) + 1;
									num15++;
									int arg4 = num8 + num19 - 1;
									int arg5 = num9 + num20 - 1;
									int arg6 = (num == 0U) ? (-(num10 + num14)) : (num10 + num14 - 1);
									action(arg4, arg5, arg6, num16);
									num18++;
								}
							}
							else
							{
								int num21 = (int)((long)num15 % (long)((ulong)num5)) + 1;
								int num22 = (int)((long)num15 / (long)((ulong)num5)) + 1;
								num15++;
								int arg7 = num8 + num21 - 1;
								int arg8 = num9 + num22 - 1;
								int arg9 = (num == 0U) ? (-(num10 + num14)) : (num10 + num14 - 1);
								action(arg7, arg8, arg9, num16);
							}
						}
					}
				}
				num4++;
			}
			IntVector3 intVector = new IntVector3(int.MaxValue, int.MaxValue, int.MaxValue);
			IntVector3 value = new IntVector3(int.MinValue, int.MinValue, int.MinValue);
			for (int i = 0; i < voxelList.Count; i++)
			{
				VoxelData.Voxel voxel = voxelList[i];
				voxel.x = -voxel.x - 1;
				voxel.z = -voxel.z - 1;
				voxelList[i] = voxel;
				intVector = IntVector3.Min(intVector, voxelList[i].position);
				value = IntVector3.Max(value, voxelList[i].position);
			}
			IntVector3 voxelSize = value - intVector + IntVector3.one;
			for (int j = 0; j < voxelList.Count; j++)
			{
				VoxelData.Voxel value2 = voxelList[j];
				value2.position -= intVector;
				voxelList[j] = value2;
			}
			this.voxelBase.localOffset = new Vector3((float)intVector.x, (float)intVector.y, (float)intVector.z);
			VoxelData.Voxel[] voxels = voxelList.ToArray();
			Color[] array = new Color[paletteList.Count];
			foreach (KeyValuePair<Color, int> keyValuePair in paletteList)
			{
				array[keyValuePair.Value] = keyValuePair.Key;
			}
			this.voxelBase.fileType = VoxelBase.FileType.qb;
			this.voxelBase.voxelData = new VoxelData();
			this.voxelBase.voxelData.voxels = voxels;
			this.voxelBase.voxelData.palettes = array;
			this.voxelBase.voxelData.voxelSize = voxelSize;
			this.ApplyImportFlags();
			this.voxelBase.voxelData.CreateVoxelTable();
			this.UpdateVisibleFlags();
			this.CreateChunkData();
			return true;
		}

		protected virtual bool LoadVoxelDataFromPNG(BinaryReader br)
		{
			Texture2D texture2D = new Texture2D(4, 4, TextureFormat.ARGB32, false);
			texture2D.hideFlags = HideFlags.DontSave;
			if (!texture2D.LoadImage(br.ReadBytes((int)br.BaseStream.Length)))
			{
				return false;
			}
			IntVector3 intVector = new IntVector3(texture2D.width, 1, texture2D.height);
			List<VoxelData.Voxel> list = new List<VoxelData.Voxel>(texture2D.width * texture2D.height);
			Dictionary<Color, int> dictionary = new Dictionary<Color, int>();
			for (int i = 0; i < texture2D.width; i++)
			{
				for (int j = 0; j < texture2D.height; j++)
				{
					Color pixel = texture2D.GetPixel(i, j);
					if (pixel.a > 0f)
					{
						pixel.a = 1f;
						int num;
						if (dictionary.ContainsKey(pixel))
						{
							num = dictionary[pixel];
						}
						else
						{
							num = dictionary.Count;
							dictionary.Add(pixel, num);
						}
						list.Add(new VoxelData.Voxel(i, 0, j, num));
					}
				}
			}
			VoxelData.Voxel[] voxels = list.ToArray();
			Color[] array = new Color[dictionary.Count];
			foreach (KeyValuePair<Color, int> keyValuePair in dictionary)
			{
				array[keyValuePair.Value] = keyValuePair.Key;
			}
			this.voxelBase.localOffset = new Vector3(-((float)intVector.x / 2f), 0f, -((float)intVector.z / 2f));
			this.voxelBase.fileType = VoxelBase.FileType.png;
			this.voxelBase.voxelData = new VoxelData();
			this.voxelBase.voxelData.voxels = voxels;
			this.voxelBase.voxelData.palettes = array;
			this.voxelBase.voxelData.voxelSize = intVector;
			this.ApplyImportFlags();
			this.voxelBase.voxelData.CreateVoxelTable();
			this.UpdateVisibleFlags();
			this.CreateChunkData();
			return true;
		}

		protected void ApplyImportFlags()
		{
			VoxelData.Voxel[] array = this.voxelBase.voxelData.voxels;
			if ((this.voxelBase.importFlags & (VoxelBase.ImportFlag.FlipX | VoxelBase.ImportFlag.FlipY | VoxelBase.ImportFlag.FlipZ)) != (VoxelBase.ImportFlag)0)
			{
				array = new VoxelData.Voxel[this.voxelBase.voxelData.voxels.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.voxelBase.voxelData.voxels[i];
					if ((this.voxelBase.importFlags & VoxelBase.ImportFlag.FlipX) != (VoxelBase.ImportFlag)0)
					{
						array[i].x = this.voxelBase.voxelData.voxelSize.x - 1 - array[i].x;
					}
					if ((this.voxelBase.importFlags & VoxelBase.ImportFlag.FlipY) != (VoxelBase.ImportFlag)0)
					{
						array[i].y = this.voxelBase.voxelData.voxelSize.y - 1 - array[i].y;
					}
					if ((this.voxelBase.importFlags & VoxelBase.ImportFlag.FlipZ) != (VoxelBase.ImportFlag)0)
					{
						array[i].z = this.voxelBase.voxelData.voxelSize.z - 1 - array[i].z;
					}
				}
			}
			this.voxelBase.voxelData.voxels = array;
		}

		protected void UpdateVisibleFlags()
		{
			VoxelData.Voxel[] voxels = this.voxelBase.voxelData.voxels;
			for (int i = 0; i < voxels.Length; i++)
			{
				voxels[i].visible = (VoxelBase.Face)0;
				if (this.voxelBase.voxelData.VoxelTableContains(voxels[i].x, voxels[i].y, voxels[i].z + 1) < 0)
				{
					VoxelData.Voxel[] array = voxels;
					int num = i;
					array[num].visible = (array[num].visible | VoxelBase.Face.forward);
				}
				if (this.voxelBase.voxelData.VoxelTableContains(voxels[i].x, voxels[i].y + 1, voxels[i].z) < 0)
				{
					VoxelData.Voxel[] array2 = voxels;
					int num2 = i;
					array2[num2].visible = (array2[num2].visible | VoxelBase.Face.up);
				}
				if (this.voxelBase.voxelData.VoxelTableContains(voxels[i].x + 1, voxels[i].y, voxels[i].z) < 0)
				{
					VoxelData.Voxel[] array3 = voxels;
					int num3 = i;
					array3[num3].visible = (array3[num3].visible | VoxelBase.Face.right);
				}
				if (this.voxelBase.voxelData.VoxelTableContains(voxels[i].x - 1, voxels[i].y, voxels[i].z) < 0)
				{
					VoxelData.Voxel[] array4 = voxels;
					int num4 = i;
					array4[num4].visible = (array4[num4].visible | VoxelBase.Face.left);
				}
				if (this.voxelBase.voxelData.VoxelTableContains(voxels[i].x, voxels[i].y - 1, voxels[i].z) < 0)
				{
					VoxelData.Voxel[] array5 = voxels;
					int num5 = i;
					array5[num5].visible = (array5[num5].visible | VoxelBase.Face.down);
				}
				if (this.voxelBase.voxelData.VoxelTableContains(voxels[i].x, voxels[i].y, voxels[i].z - 1) < 0)
				{
					VoxelData.Voxel[] array6 = voxels;
					int num6 = i;
					array6[num6].visible = (array6[num6].visible | VoxelBase.Face.back);
				}
			}
		}

		public virtual string GetDefaultPath()
		{
			return Application.dataPath;
		}

		protected void CalcDataCreate(VoxelData.Voxel[] voxels)
		{
			this.materialIndexTable = new int[this.voxelBase.voxelData.voxelSize.x][][];
			for (int l = 0; l < this.voxelBase.voxelData.voxelSize.x; l++)
			{
				this.materialIndexTable[l] = new int[this.voxelBase.voxelData.voxelSize.y][];
				for (int j = 0; j < this.voxelBase.voxelData.voxelSize.y; j++)
				{
					this.materialIndexTable[l][j] = new int[this.voxelBase.voxelData.voxelSize.z];
				}
			}
			int i;
			Action<IntVector3> <>9__0;
			int i2;
			for (i = 1; i < this.voxelBase.materialData.Count; i = i2 + 1)
			{
				MaterialData materialData = this.voxelBase.materialData[i];
				Action<IntVector3> action;
				if ((action = <>9__0) == null)
				{
					action = (<>9__0 = delegate(IntVector3 pos)
					{
						this.materialIndexTable[pos.x][pos.y][pos.z] = i;
					});
				}
				materialData.AllAction(action);
				i2 = i;
			}
			this.voxelDoneFaces = new VoxelBase.Face[this.voxelBase.voxelData.voxels.Length];
			for (int k = 0; k < voxels.Length; k++)
			{
				int num = this.voxelBase.voxelData.VoxelTableContains(voxels[k].position);
				int voxelMaterialIndex = this.GetVoxelMaterialIndex(voxels[k].position);
				if ((voxels[k].visible & VoxelBase.Face.forward) == (VoxelBase.Face)0 && this.IsHiddenVoxelFace(voxels[k].position, VoxelBase.Face.forward))
				{
					int voxelMaterialIndex2 = this.GetVoxelMaterialIndex(new IntVector3(voxels[k].position.x, voxels[k].position.y, voxels[k].position.z + 1));
					if (voxelMaterialIndex == voxelMaterialIndex2 || (voxelMaterialIndex2 >= 0 && !this.voxelBase.materialData[voxelMaterialIndex2].transparent))
					{
						this.voxelDoneFaces[num] |= VoxelBase.Face.forward;
					}
				}
				if ((voxels[k].visible & VoxelBase.Face.up) == (VoxelBase.Face)0 && this.IsHiddenVoxelFace(voxels[k].position, VoxelBase.Face.up))
				{
					int voxelMaterialIndex3 = this.GetVoxelMaterialIndex(new IntVector3(voxels[k].position.x, voxels[k].position.y + 1, voxels[k].position.z));
					if (voxelMaterialIndex == voxelMaterialIndex3 || (voxelMaterialIndex3 >= 0 && !this.voxelBase.materialData[voxelMaterialIndex3].transparent))
					{
						this.voxelDoneFaces[num] |= VoxelBase.Face.up;
					}
				}
				if ((voxels[k].visible & VoxelBase.Face.right) == (VoxelBase.Face)0 && this.IsHiddenVoxelFace(voxels[k].position, VoxelBase.Face.right))
				{
					int voxelMaterialIndex4 = this.GetVoxelMaterialIndex(new IntVector3(voxels[k].position.x + 1, voxels[k].position.y, voxels[k].position.z));
					if (voxelMaterialIndex == voxelMaterialIndex4 || (voxelMaterialIndex4 >= 0 && !this.voxelBase.materialData[voxelMaterialIndex4].transparent))
					{
						this.voxelDoneFaces[num] |= VoxelBase.Face.right;
					}
				}
				if ((voxels[k].visible & VoxelBase.Face.left) == (VoxelBase.Face)0 && this.IsHiddenVoxelFace(voxels[k].position, VoxelBase.Face.left))
				{
					int voxelMaterialIndex5 = this.GetVoxelMaterialIndex(new IntVector3(voxels[k].position.x - 1, voxels[k].position.y, voxels[k].position.z));
					if (voxelMaterialIndex == voxelMaterialIndex5 || (voxelMaterialIndex5 >= 0 && !this.voxelBase.materialData[voxelMaterialIndex5].transparent))
					{
						this.voxelDoneFaces[num] |= VoxelBase.Face.left;
					}
				}
				if ((voxels[k].visible & VoxelBase.Face.down) == (VoxelBase.Face)0 && this.IsHiddenVoxelFace(voxels[k].position, VoxelBase.Face.down))
				{
					int voxelMaterialIndex6 = this.GetVoxelMaterialIndex(new IntVector3(voxels[k].position.x, voxels[k].position.y - 1, voxels[k].position.z));
					if (voxelMaterialIndex == voxelMaterialIndex6 || (voxelMaterialIndex6 >= 0 && !this.voxelBase.materialData[voxelMaterialIndex6].transparent))
					{
						this.voxelDoneFaces[num] |= VoxelBase.Face.down;
					}
				}
				if ((voxels[k].visible & VoxelBase.Face.back) == (VoxelBase.Face)0 && this.IsHiddenVoxelFace(voxels[k].position, VoxelBase.Face.back))
				{
					int voxelMaterialIndex7 = this.GetVoxelMaterialIndex(new IntVector3(voxels[k].position.x, voxels[k].position.y, voxels[k].position.z - 1));
					if (voxelMaterialIndex == voxelMaterialIndex7 || (voxelMaterialIndex7 >= 0 && !this.voxelBase.materialData[voxelMaterialIndex7].transparent))
					{
						this.voxelDoneFaces[num] |= VoxelBase.Face.back;
					}
				}
			}
		}

		protected void CalcDataRelease()
		{
			this.voxelDoneFaces = null;
			this.materialIndexTable = null;
		}

		protected void SetDoneFacesFlag(VoxelData.FaceArea faceArea, VoxelBase.Face flag)
		{
			for (int i = faceArea.min.x; i <= faceArea.max.x; i++)
			{
				for (int j = faceArea.min.y; j <= faceArea.max.y; j++)
				{
					for (int k = faceArea.min.z; k <= faceArea.max.z; k++)
					{
						int num = this.voxelBase.voxelData.VoxelTableContains(i, j, k);
						this.voxelDoneFaces[num] |= flag;
					}
				}
			}
		}

		protected int GetVoxelMaterialIndex(IntVector3 pos)
		{
			if (pos.x < 0 || pos.x >= this.voxelBase.voxelData.voxelSize.x || pos.y < 0 || pos.y >= this.voxelBase.voxelData.voxelSize.y || pos.z < 0 || pos.z >= this.voxelBase.voxelData.voxelSize.z)
			{
				return -1;
			}
			return this.materialIndexTable[pos.x][pos.y][pos.z];
		}

		protected int[] GetVoxelIndexTable(VoxelData.Voxel[] voxels)
		{
			int[] array = new int[voxels.Length];
			for (int i = 0; i < voxels.Length; i++)
			{
				int num = this.voxelBase.voxelData.VoxelTableContains(voxels[i].position);
				array[i] = num;
			}
			return array;
		}

		protected bool CreateTexture(VoxelData.FaceAreaTable faceAreaTable, Color[] palettes, ref MyVoxelBaseCore.AtlasRectTable atlasRectTable, ref Texture2D atlasTexture, ref Rect[] atlasRects)
		{
			if (this.voxelBase.importMode == VoxelBase.ImportMode.LowTexture)
			{
				return this.CreateTexture_LowTexture(palettes, ref atlasRectTable, ref atlasTexture, ref atlasRects);
			}
			return this.voxelBase.importMode == VoxelBase.ImportMode.LowPoly && this.CreateTexture_LowPoly(faceAreaTable, ref atlasRectTable, ref atlasTexture, ref atlasRects);
		}

		protected bool CreateTexture_LowTexture(Color[] palettes, ref MyVoxelBaseCore.AtlasRectTable atlasRectTable, ref Texture2D atlasTexture, ref Rect[] atlasRects)
		{
			if (this.voxelBase.voxelData == null)
			{
				return false;
			}
			Texture2D[] array = new Texture2D[palettes.Length];
			for (int i = 0; i < palettes.Length; i++)
			{
				array[i] = new Texture2D(2, 2, TextureFormat.ARGB32, false);
				array[i].hideFlags = HideFlags.DontSave;
				array[i].name = palettes[i].ToString();
				for (int j = 0; j < array[i].width; j++)
				{
					for (int k = 0; k < array[i].height; k++)
					{
						array[i].SetPixel(j, k, palettes[i]);
					}
				}
				array[i].Apply();
			}
			Texture2D texture2D = new Texture2D(4, 4, TextureFormat.ARGB32, false);
			texture2D.filterMode = FilterMode.Point;
			texture2D.wrapMode = TextureWrapMode.Clamp;
			atlasRects = texture2D.PackTextures(array, 0, 8192);
			Color[] pixels = texture2D.GetPixels();
			for (int l = 0; l < pixels.Length; l++)
			{
				pixels[l].a = 1f;
			}
			texture2D.SetPixels(pixels);
			texture2D.Apply();
			if (this.voxelBase.generateMipMaps)
			{
				Texture2D texture2D2 = new Texture2D(texture2D.width, texture2D.height, texture2D.format, true);
				texture2D2.filterMode = texture2D.filterMode;
				texture2D2.wrapMode = texture2D.wrapMode;
				texture2D2.SetPixels(texture2D.GetPixels(), 0);
				texture2D2.Apply(true);
				UnityEngine.Object.DestroyImmediate(texture2D);
				texture2D = texture2D2;
			}
			for (int m = 0; m < atlasRects.Length; m++)
			{
				Rect[] array2 = atlasRects;
				int num = m;
				array2[num].center = array2[num].center + atlasRects[m].size / 2f;
				atlasRects[m].size = Vector2.zero;
			}
			atlasTexture = texture2D;
			for (int n = 0; n < array.Length; n++)
			{
				UnityEngine.Object.DestroyImmediate(array[n]);
			}
			return true;
		}

		protected bool CreateTexture_LowPoly(VoxelData.FaceAreaTable faceAreaTable, ref MyVoxelBaseCore.AtlasRectTable atlasRectTable, ref Texture2D atlasTexture, ref Rect[] atlasRects)
		{
			if (this.voxelBase.voxelData == null)
			{
				return false;
			}
			Texture2D tex;
			Func<Color[,], MyVoxelBaseCore.TextureBoundArea, Texture2D> func = delegate(Color[,] tex, MyVoxelBaseCore.TextureBoundArea bound)
			{
				IntVector2 size = bound.Size;
				Texture2D texture2D2 = new Texture2D(size.x, size.y, TextureFormat.ARGB32, false);
				for (int num22 = 0; num22 < size.x; num22++)
				{
					for (int num23 = 0; num23 < size.y; num23++)
					{
						texture2D2.SetPixel(num22, num23, tex[bound.min.x + num22, bound.min.y + num23]);
					}
				}
				texture2D2.Apply();
				return texture2D2;
			};
			List<Texture2D> list = new List<Texture2D>();
			atlasRectTable = new MyVoxelBaseCore.AtlasRectTable();
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.forward) != (VoxelBase.Face)0)
			{
				Color[,] array = new Color[this.voxelBase.voxelData.voxelSize.x, this.voxelBase.voxelData.voxelSize.y];
				for (int i = 0; i < faceAreaTable.forward.Count; i++)
				{
					int z = faceAreaTable.forward[i].min.z;
					MyVoxelBaseCore.TextureBoundArea textureBoundArea = null;
					for (int j = faceAreaTable.forward[i].min.x; j <= faceAreaTable.forward[i].max.x; j++)
					{
						for (int k = faceAreaTable.forward[i].min.y; k <= faceAreaTable.forward[i].max.y; k++)
						{
							if (this.IsShowVoxelFace(new IntVector3(j, k, z), VoxelBase.Face.forward))
							{
								int num = this.voxelBase.voxelData.VoxelTableContains(new IntVector3(j, k, z));
								array[j, k] = this.voxelBase.voxelData.palettes[this.voxelBase.voxelData.voxels[num].palette];
								if (textureBoundArea == null)
								{
									textureBoundArea = new MyVoxelBaseCore.TextureBoundArea();
								}
								textureBoundArea.Set(new IntVector2(j, k));
							}
							else
							{
								array[j, k] = Color.clear;
							}
						}
					}
					if (textureBoundArea != null)
					{
						textureBoundArea.textureIndex = list.Count;
						list.Add(func(array, textureBoundArea));
					}
					atlasRectTable.forward.Add(textureBoundArea);
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.up) != (VoxelBase.Face)0)
			{
				Color[,] array2 = new Color[this.voxelBase.voxelData.voxelSize.x, this.voxelBase.voxelData.voxelSize.z];
				for (int l = 0; l < faceAreaTable.up.Count; l++)
				{
					int y = faceAreaTable.up[l].min.y;
					MyVoxelBaseCore.TextureBoundArea textureBoundArea2 = null;
					for (int m = faceAreaTable.up[l].min.x; m <= faceAreaTable.up[l].max.x; m++)
					{
						for (int n = faceAreaTable.up[l].min.z; n <= faceAreaTable.up[l].max.z; n++)
						{
							if (this.IsShowVoxelFace(new IntVector3(m, y, n), VoxelBase.Face.up))
							{
								int num2 = this.voxelBase.voxelData.VoxelTableContains(new IntVector3(m, y, n));
								array2[m, n] = this.voxelBase.voxelData.palettes[this.voxelBase.voxelData.voxels[num2].palette];
								if (textureBoundArea2 == null)
								{
									textureBoundArea2 = new MyVoxelBaseCore.TextureBoundArea();
								}
								textureBoundArea2.Set(new IntVector2(m, n));
							}
							else
							{
								array2[m, n] = Color.clear;
							}
						}
					}
					if (textureBoundArea2 != null)
					{
						textureBoundArea2.textureIndex = list.Count;
						list.Add(func(array2, textureBoundArea2));
					}
					atlasRectTable.up.Add(textureBoundArea2);
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.right) != (VoxelBase.Face)0)
			{
				Color[,] array3 = new Color[this.voxelBase.voxelData.voxelSize.y, this.voxelBase.voxelData.voxelSize.z];
				for (int num3 = 0; num3 < faceAreaTable.right.Count; num3++)
				{
					int x = faceAreaTable.right[num3].min.x;
					MyVoxelBaseCore.TextureBoundArea textureBoundArea3 = null;
					for (int num4 = faceAreaTable.right[num3].min.y; num4 <= faceAreaTable.right[num3].max.y; num4++)
					{
						for (int num5 = faceAreaTable.right[num3].min.z; num5 <= faceAreaTable.right[num3].max.z; num5++)
						{
							if (this.IsShowVoxelFace(new IntVector3(x, num4, num5), VoxelBase.Face.right))
							{
								int num6 = this.voxelBase.voxelData.VoxelTableContains(new IntVector3(x, num4, num5));
								array3[num4, num5] = this.voxelBase.voxelData.palettes[this.voxelBase.voxelData.voxels[num6].palette];
								if (textureBoundArea3 == null)
								{
									textureBoundArea3 = new MyVoxelBaseCore.TextureBoundArea();
								}
								textureBoundArea3.Set(new IntVector2(num4, num5));
							}
							else
							{
								array3[num4, num5] = Color.clear;
							}
						}
					}
					if (textureBoundArea3 != null)
					{
						textureBoundArea3.textureIndex = list.Count;
						list.Add(func(array3, textureBoundArea3));
					}
					atlasRectTable.right.Add(textureBoundArea3);
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.left) != (VoxelBase.Face)0)
			{
				Color[,] array4 = new Color[this.voxelBase.voxelData.voxelSize.y, this.voxelBase.voxelData.voxelSize.z];
				for (int num7 = 0; num7 < faceAreaTable.left.Count; num7++)
				{
					int x2 = faceAreaTable.left[num7].min.x;
					MyVoxelBaseCore.TextureBoundArea textureBoundArea4 = null;
					for (int num8 = faceAreaTable.left[num7].min.y; num8 <= faceAreaTable.left[num7].max.y; num8++)
					{
						for (int num9 = faceAreaTable.left[num7].min.z; num9 <= faceAreaTable.left[num7].max.z; num9++)
						{
							if (this.IsShowVoxelFace(new IntVector3(x2, num8, num9), VoxelBase.Face.left))
							{
								int num10 = this.voxelBase.voxelData.VoxelTableContains(new IntVector3(x2, num8, num9));
								array4[num8, num9] = this.voxelBase.voxelData.palettes[this.voxelBase.voxelData.voxels[num10].palette];
								if (textureBoundArea4 == null)
								{
									textureBoundArea4 = new MyVoxelBaseCore.TextureBoundArea();
								}
								textureBoundArea4.Set(new IntVector2(num8, num9));
							}
							else
							{
								array4[num8, num9] = Color.clear;
							}
						}
					}
					if (textureBoundArea4 != null)
					{
						textureBoundArea4.textureIndex = list.Count;
						list.Add(func(array4, textureBoundArea4));
					}
					atlasRectTable.left.Add(textureBoundArea4);
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.down) != (VoxelBase.Face)0)
			{
				Color[,] array5 = new Color[this.voxelBase.voxelData.voxelSize.x, this.voxelBase.voxelData.voxelSize.z];
				for (int num11 = 0; num11 < faceAreaTable.down.Count; num11++)
				{
					int y2 = faceAreaTable.down[num11].min.y;
					MyVoxelBaseCore.TextureBoundArea textureBoundArea5 = null;
					for (int num12 = faceAreaTable.down[num11].min.x; num12 <= faceAreaTable.down[num11].max.x; num12++)
					{
						for (int num13 = faceAreaTable.down[num11].min.z; num13 <= faceAreaTable.down[num11].max.z; num13++)
						{
							if (this.IsShowVoxelFace(new IntVector3(num12, y2, num13), VoxelBase.Face.down))
							{
								int num14 = this.voxelBase.voxelData.VoxelTableContains(new IntVector3(num12, y2, num13));
								array5[num12, num13] = this.voxelBase.voxelData.palettes[this.voxelBase.voxelData.voxels[num14].palette];
								if (textureBoundArea5 == null)
								{
									textureBoundArea5 = new MyVoxelBaseCore.TextureBoundArea();
								}
								textureBoundArea5.Set(new IntVector2(num12, num13));
							}
							else
							{
								array5[num12, num13] = Color.clear;
							}
						}
					}
					if (textureBoundArea5 != null)
					{
						textureBoundArea5.textureIndex = list.Count;
						list.Add(func(array5, textureBoundArea5));
					}
					atlasRectTable.down.Add(textureBoundArea5);
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.back) != (VoxelBase.Face)0)
			{
				Color[,] array6 = new Color[this.voxelBase.voxelData.voxelSize.x, this.voxelBase.voxelData.voxelSize.y];
				for (int num15 = 0; num15 < faceAreaTable.back.Count; num15++)
				{
					int z2 = faceAreaTable.back[num15].min.z;
					MyVoxelBaseCore.TextureBoundArea textureBoundArea6 = null;
					for (int num16 = faceAreaTable.back[num15].min.x; num16 <= faceAreaTable.back[num15].max.x; num16++)
					{
						for (int num17 = faceAreaTable.back[num15].min.y; num17 <= faceAreaTable.back[num15].max.y; num17++)
						{
							if (this.IsShowVoxelFace(new IntVector3(num16, num17, z2), VoxelBase.Face.back))
							{
								int num18 = this.voxelBase.voxelData.VoxelTableContains(new IntVector3(num16, num17, z2));
								array6[num16, num17] = this.voxelBase.voxelData.palettes[this.voxelBase.voxelData.voxels[num18].palette];
								if (textureBoundArea6 == null)
								{
									textureBoundArea6 = new MyVoxelBaseCore.TextureBoundArea();
								}
								textureBoundArea6.Set(new IntVector2(num16, num17));
							}
							else
							{
								array6[num16, num17] = Color.clear;
							}
						}
					}
					if (textureBoundArea6 != null)
					{
						textureBoundArea6.textureIndex = list.Count;
						list.Add(func(array6, textureBoundArea6));
					}
					atlasRectTable.back.Add(textureBoundArea6);
				}
			}
			tex = new Texture2D(4, 4, TextureFormat.ARGB32, false);
			tex.filterMode = FilterMode.Point;
			tex.wrapMode = TextureWrapMode.Clamp;
			atlasRects = tex.PackTextures(list.ToArray(), 2, 8192);
			Color color = Color.clear;
			int count = 0;
			Action<int, int> action = delegate(int xx, int yy)
			{
				Color pixel = tex.GetPixel(xx, yy);
				if (pixel.a > 0f)
				{
					color += pixel;
					int count = count;
					count++;
				}
			};
			Color[] pixels = tex.GetPixels();
			for (int num19 = 0; num19 < tex.width; num19++)
			{
				for (int num20 = 0; num20 < tex.height; num20++)
				{
					color = tex.GetPixel(num19, num20);
					if (color.a <= 0f)
					{
						color = Color.clear;
						count = 0;
						if (num19 > 0)
						{
							action(num19 - 1, num20);
						}
						if (num19 < tex.width - 1)
						{
							action(num19 + 1, num20);
						}
						if (num20 > 0)
						{
							action(num19, num20 - 1);
						}
						if (num20 < tex.height - 1)
						{
							action(num19, num20 + 1);
						}
						if (count == 0)
						{
							if (num19 > 0 && num20 > 0)
							{
								action(num19 - 1, num20 - 1);
							}
							if (num19 < tex.width - 1 && num20 > 0)
							{
								action(num19 + 1, num20 - 1);
							}
							if (num19 > 0 && num20 < tex.height - 1)
							{
								action(num19 - 1, num20 + 1);
							}
							if (num19 < tex.width - 1 && num20 < tex.height - 1)
							{
								action(num19 + 1, num20 + 1);
							}
						}
						if (count > 0)
						{
							color /= (float)count;
						}
						color.a = 1f;
						pixels[num19 + num20 * tex.width] = color;
					}
					else
					{
						color.a = 1f;
						pixels[num19 + num20 * tex.width] = color;
					}
				}
			}
			tex.SetPixels(pixels);
			tex.Apply();
			if (this.voxelBase.generateMipMaps)
			{
				Texture2D texture2D = new Texture2D(tex.width, tex.height, tex.format, true);
				texture2D.filterMode = tex.filterMode;
				texture2D.wrapMode = tex.wrapMode;
				texture2D.SetPixels(tex.GetPixels(), 0);
				texture2D.Apply(true);
				UnityEngine.Object.DestroyImmediate(tex);
				tex = texture2D;
			}
			atlasTexture = tex;
			for (int num21 = 0; num21 < list.Count; num21++)
			{
				UnityEngine.Object.DestroyImmediate(list[num21]);
			}
			return true;
		}

		protected virtual bool IsCombineVoxelFace(IntVector3 pos, IntVector3 combinePos, VoxelBase.Face face)
		{
			return true;
		}

		protected virtual bool IsHiddenVoxelFace(IntVector3 pos, VoxelBase.Face faceFlag)
		{
			return true;
		}

		protected virtual bool IsShowVoxelFace(IntVector3 pos, VoxelBase.Face faceFlag)
		{
			if (this.voxelBase.voxelData.VoxelTableContains(pos) < 0)
			{
				return false;
			}
			IntVector3 pos2 = pos;
			if (faceFlag == VoxelBase.Face.forward)
			{
				pos2.z++;
			}
			if (faceFlag == VoxelBase.Face.up)
			{
				pos2.y++;
			}
			if (faceFlag == VoxelBase.Face.right)
			{
				pos2.x++;
			}
			if (faceFlag == VoxelBase.Face.left)
			{
				pos2.x--;
			}
			if (faceFlag == VoxelBase.Face.down)
			{
				pos2.y--;
			}
			if (faceFlag == VoxelBase.Face.back)
			{
				pos2.z--;
			}
			if (this.voxelBase.voxelData.VoxelTableContains(pos2) < 0)
			{
				return true;
			}
			int voxelMaterialIndex = this.GetVoxelMaterialIndex(pos2);
			return (voxelMaterialIndex >= 0 && this.voxelBase.materialData[voxelMaterialIndex].transparent) || !this.IsHiddenVoxelFace(pos, faceFlag);
		}

		protected abstract bool CreateMesh();

		protected virtual void CreateMeshAfterFree()
		{
			this.CalcDataRelease();
		}

		protected Mesh CreateMeshOnly(Mesh result, VoxelData.FaceAreaTable faceAreaTable, Texture2D atlasTexture, Rect[] atlasRects, MyVoxelBaseCore.AtlasRectTable atlasRectTable, Vector3 extraOffset, out List<int> materialIndexes)
		{
			if (this.voxelBase.importMode == VoxelBase.ImportMode.LowTexture)
			{
				return this.CreateMeshOnly_LowTexture(result, faceAreaTable, atlasTexture, atlasRects, atlasRectTable, extraOffset, out materialIndexes);
			}
			if (this.voxelBase.importMode == VoxelBase.ImportMode.LowPoly)
			{
				return this.CreateMeshOnly_LowPoly(result, faceAreaTable, atlasTexture, atlasRects, atlasRectTable, extraOffset, out materialIndexes);
			}
			materialIndexes = new List<int>();
			return null;
		}

		protected Mesh CreateMeshOnly_LowTexture(Mesh result, VoxelData.FaceAreaTable faceAreaTable, Texture2D atlasTexture, Rect[] atlasRects, MyVoxelBaseCore.AtlasRectTable atlasRectTable, Vector3 extraOffset, out List<int> materialIndexes)
		{
			materialIndexes = new List<int>();
			if (result == null)
			{
				result = new Mesh();
			}
			else
			{
				result.ClearBlendShapes();
				result.Clear(false);
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector3> list3 = new List<Vector3>();
			List<BoneWeight> list4 = this.isHaveBoneWeight ? new List<BoneWeight>() : null;
			List<int>[] array = new List<int>[this.voxelBase.materialData.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new List<int>();
			}
			Vector3 b = this.voxelBase.localOffset + this.voxelBase.importOffset + extraOffset;
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.forward) != (VoxelBase.Face)0)
			{
				for (int j = 0; j < faceAreaTable.forward.Count; j++)
				{
					VoxelData.FaceArea faceArea = faceAreaTable.forward[j];
					Vector3 b2 = Vector3.Scale(this.voxelBase.importScale, faceArea.minf + b);
					float x = (float)faceArea.size.x * this.voxelBase.importScale.x;
					float y = (float)faceArea.size.y * this.voxelBase.importScale.y;
					int count = list.Count;
					list.Add(new Vector3(0f, y, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(0f, 0f, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(x, 0f, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(x, y, this.voxelBase.importScale.z) + b2);
					array[faceArea.material].Add(count);
					array[faceArea.material].Add(count + 1);
					array[faceArea.material].Add(count + 2);
					array[faceArea.material].Add(count);
					array[faceArea.material].Add(count + 2);
					array[faceArea.material].Add(count + 3);
					for (int k = 0; k < 4; k++)
					{
						if (faceArea.palette >= 0)
						{
							list2.Add(atlasRects[faceArea.palette].position);
						}
						list3.Add(Vector3.forward);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.up) != (VoxelBase.Face)0)
			{
				for (int l = 0; l < faceAreaTable.up.Count; l++)
				{
					VoxelData.FaceArea faceArea2 = faceAreaTable.up[l];
					Vector3 b3 = Vector3.Scale(this.voxelBase.importScale, faceArea2.minf + b);
					float x2 = (float)faceArea2.size.x * this.voxelBase.importScale.x;
					float z = (float)faceArea2.size.z * this.voxelBase.importScale.z;
					int count2 = list.Count;
					list.Add(new Vector3(0f, this.voxelBase.importScale.y, 0f) + b3);
					list.Add(new Vector3(0f, this.voxelBase.importScale.y, z) + b3);
					list.Add(new Vector3(x2, this.voxelBase.importScale.y, z) + b3);
					list.Add(new Vector3(x2, this.voxelBase.importScale.y, 0f) + b3);
					array[faceArea2.material].Add(count2);
					array[faceArea2.material].Add(count2 + 1);
					array[faceArea2.material].Add(count2 + 2);
					array[faceArea2.material].Add(count2);
					array[faceArea2.material].Add(count2 + 2);
					array[faceArea2.material].Add(count2 + 3);
					for (int m = 0; m < 4; m++)
					{
						if (faceArea2.palette >= 0)
						{
							list2.Add(atlasRects[faceArea2.palette].position);
						}
						list3.Add(Vector3.up);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.right) != (VoxelBase.Face)0)
			{
				for (int n = 0; n < faceAreaTable.right.Count; n++)
				{
					VoxelData.FaceArea faceArea3 = faceAreaTable.right[n];
					Vector3 b4 = Vector3.Scale(this.voxelBase.importScale, faceArea3.minf + b);
					float y2 = (float)faceArea3.size.y * this.voxelBase.importScale.y;
					float z2 = (float)faceArea3.size.z * this.voxelBase.importScale.z;
					int count3 = list.Count;
					list.Add(new Vector3(this.voxelBase.importScale.x, 0f, 0f) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, y2, 0f) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, y2, z2) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, 0f, z2) + b4);
					array[faceArea3.material].Add(count3);
					array[faceArea3.material].Add(count3 + 1);
					array[faceArea3.material].Add(count3 + 2);
					array[faceArea3.material].Add(count3);
					array[faceArea3.material].Add(count3 + 2);
					array[faceArea3.material].Add(count3 + 3);
					for (int num = 0; num < 4; num++)
					{
						if (faceArea3.palette >= 0)
						{
							list2.Add(atlasRects[faceArea3.palette].position);
						}
						list3.Add(Vector3.right);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.left) != (VoxelBase.Face)0)
			{
				for (int num2 = 0; num2 < faceAreaTable.left.Count; num2++)
				{
					VoxelData.FaceArea faceArea4 = faceAreaTable.left[num2];
					Vector3 b5 = Vector3.Scale(this.voxelBase.importScale, faceArea4.minf + b);
					float y3 = (float)faceArea4.size.y * this.voxelBase.importScale.y;
					float z3 = (float)faceArea4.size.z * this.voxelBase.importScale.z;
					int count4 = list.Count;
					list.Add(new Vector3(0f, 0f, z3) + b5);
					list.Add(new Vector3(0f, 0f, 0f) + b5);
					list.Add(new Vector3(0f, y3, 0f) + b5);
					list.Add(new Vector3(0f, y3, z3) + b5);
					array[faceArea4.material].Add(count4 + 2);
					array[faceArea4.material].Add(count4 + 1);
					array[faceArea4.material].Add(count4);
					array[faceArea4.material].Add(count4 + 3);
					array[faceArea4.material].Add(count4 + 2);
					array[faceArea4.material].Add(count4);
					for (int num3 = 0; num3 < 4; num3++)
					{
						if (faceArea4.palette >= 0)
						{
							list2.Add(atlasRects[faceArea4.palette].position);
						}
						list3.Add(Vector3.left);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.down) != (VoxelBase.Face)0)
			{
				for (int num4 = 0; num4 < faceAreaTable.down.Count; num4++)
				{
					VoxelData.FaceArea faceArea5 = faceAreaTable.down[num4];
					Vector3 b6 = Vector3.Scale(this.voxelBase.importScale, faceArea5.minf + b);
					float x3 = (float)faceArea5.size.x * this.voxelBase.importScale.x;
					float z4 = (float)faceArea5.size.z * this.voxelBase.importScale.z;
					int count5 = list.Count;
					list.Add(new Vector3(x3, 0f, 0f) + b6);
					list.Add(new Vector3(0f, 0f, 0f) + b6);
					list.Add(new Vector3(0f, 0f, z4) + b6);
					list.Add(new Vector3(x3, 0f, z4) + b6);
					array[faceArea5.material].Add(count5 + 2);
					array[faceArea5.material].Add(count5 + 1);
					array[faceArea5.material].Add(count5);
					array[faceArea5.material].Add(count5 + 3);
					array[faceArea5.material].Add(count5 + 2);
					array[faceArea5.material].Add(count5);
					for (int num5 = 0; num5 < 4; num5++)
					{
						if (faceArea5.palette >= 0)
						{
							list2.Add(atlasRects[faceArea5.palette].position);
						}
						list3.Add(Vector3.down);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.back) != (VoxelBase.Face)0)
			{
				for (int num6 = 0; num6 < faceAreaTable.back.Count; num6++)
				{
					VoxelData.FaceArea faceArea6 = faceAreaTable.back[num6];
					Vector3 b7 = Vector3.Scale(this.voxelBase.importScale, faceArea6.minf + b);
					float x4 = (float)faceArea6.size.x * this.voxelBase.importScale.x;
					float y4 = (float)faceArea6.size.y * this.voxelBase.importScale.y;
					int count6 = list.Count;
					list.Add(new Vector3(0f, 0f, 0f) + b7);
					list.Add(new Vector3(x4, 0f, 0f) + b7);
					list.Add(new Vector3(x4, y4, 0f) + b7);
					list.Add(new Vector3(0f, y4, 0f) + b7);
					array[faceArea6.material].Add(count6 + 2);
					array[faceArea6.material].Add(count6 + 1);
					array[faceArea6.material].Add(count6);
					array[faceArea6.material].Add(count6 + 3);
					array[faceArea6.material].Add(count6 + 2);
					array[faceArea6.material].Add(count6);
					for (int num7 = 0; num7 < 4; num7++)
					{
						if (faceArea6.palette >= 0)
						{
							list2.Add(atlasRects[faceArea6.palette].position);
						}
						list3.Add(Vector3.back);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
					}
				}
			}
			if (list.Count > 65000)
			{
				Debug.LogWarningFormat("<color=green>[VoxelCharacteImporter]</color> Mesh.vertices is too large. A mesh may not have more than 65000 vertices. <color=red>{0} / 65000</color>", new object[]
				{
					list.Count
				});
				list.RemoveRange(64999, list.Count - 64999);
				if (list2.Count > 64999)
				{
					list2.RemoveRange(64999, list2.Count - 64999);
				}
				if (list3.Count > 64999)
				{
					list3.RemoveRange(64999, list3.Count - 64999);
				}
				if (this.isHaveBoneWeight && list4.Count > 64999)
				{
					list4.RemoveRange(64999, list4.Count - 64999);
				}
				for (int num8 = 0; num8 < array.Length; num8++)
				{
					for (int num9 = array[num8].Count - 1; num9 >= 0; num9--)
					{
						if (array[num8][num9] < 64999)
						{
							int num10 = num9 / 3 * 3;
							array[num8].RemoveRange(num10, array[num8].Count - num10);
							break;
						}
					}
				}
			}
			result.vertices = list.ToArray();
			result.uv = list2.ToArray();
			result.normals = list3.ToArray();
			if (this.isHaveBoneWeight)
			{
				result.boneWeights = list4.ToArray();
				result.bindposes = this.GetBindposes();
			}
			int num11 = 0;
			for (int num12 = 0; num12 < array.Length; num12++)
			{
				if (array[num12].Count > 0)
				{
					num11++;
				}
			}
			result.subMeshCount = num11;
			int num13 = 0;
			for (int num14 = 0; num14 < array.Length; num14++)
			{
				if (array[num14].Count > 0)
				{
					materialIndexes.Add(num14);
					result.SetTriangles(array[num14].ToArray(), num13++);
				}
			}
			result.RecalculateBounds();
			result.Optimize();
			return result;
		}

		protected Mesh CreateMeshOnly_LowPoly(Mesh result, VoxelData.FaceAreaTable faceAreaTable, Texture2D atlasTexture, Rect[] atlasRects, MyVoxelBaseCore.AtlasRectTable atlasRectTable, Vector3 extraOffset, out List<int> materialIndexes)
		{
			materialIndexes = new List<int>();
			if (result == null)
			{
				result = new Mesh();
			}
			else
			{
				result.ClearBlendShapes();
				result.Clear(false);
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector3> list3 = new List<Vector3>();
			List<BoneWeight> list4 = this.isHaveBoneWeight ? new List<BoneWeight>() : null;
			List<int>[] array = new List<int>[this.voxelBase.materialData.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new List<int>();
			}
			Vector3 b = this.voxelBase.localOffset + this.voxelBase.importOffset + extraOffset;
			Vector2 vector = new Vector2(1f / (float)atlasTexture.width, 1f / (float)atlasTexture.height);
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.forward) != (VoxelBase.Face)0)
			{
				for (int j = 0; j < faceAreaTable.forward.Count; j++)
				{
					VoxelData.FaceArea faceArea = faceAreaTable.forward[j];
					Vector3 b2 = Vector3.Scale(this.voxelBase.importScale, faceArea.minf + b);
					float x = (float)faceArea.size.x * this.voxelBase.importScale.x;
					float y = (float)faceArea.size.y * this.voxelBase.importScale.y;
					int count = list.Count;
					list.Add(new Vector3(0f, y, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(0f, 0f, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(x, 0f, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(x, y, this.voxelBase.importScale.z) + b2);
					array[faceArea.material].Add(count);
					array[faceArea.material].Add(count + 1);
					array[faceArea.material].Add(count + 2);
					array[faceArea.material].Add(count);
					array[faceArea.material].Add(count + 2);
					array[faceArea.material].Add(count + 3);
					for (int k = 0; k < 4; k++)
					{
						list3.Add(Vector3.forward);
					}
					if (faceArea.palette >= 0)
					{
						MyVoxelBaseCore.TextureBoundArea textureBoundArea = atlasRectTable.forward[j];
						list2.Add(new Vector2(atlasRects[textureBoundArea.textureIndex].position.x + (float)(faceArea.min.x - textureBoundArea.min.x) * vector.x, atlasRects[textureBoundArea.textureIndex].position.y + atlasRects[textureBoundArea.textureIndex].size.y - (float)(textureBoundArea.max.y - faceArea.max.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea.textureIndex].position.x + (float)(faceArea.min.x - textureBoundArea.min.x) * vector.x, atlasRects[textureBoundArea.textureIndex].position.y + (float)(faceArea.min.y - textureBoundArea.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea.textureIndex].position.x + atlasRects[textureBoundArea.textureIndex].size.x - (float)(textureBoundArea.max.x - faceArea.max.x) * vector.x, atlasRects[textureBoundArea.textureIndex].position.y + (float)(faceArea.min.y - textureBoundArea.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea.textureIndex].position.x + atlasRects[textureBoundArea.textureIndex].size.x - (float)(textureBoundArea.max.x - faceArea.max.x) * vector.x, atlasRects[textureBoundArea.textureIndex].position.y + atlasRects[textureBoundArea.textureIndex].size.y - (float)(textureBoundArea.max.y - faceArea.max.y) * vector.y));
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.up) != (VoxelBase.Face)0)
			{
				for (int l = 0; l < faceAreaTable.up.Count; l++)
				{
					VoxelData.FaceArea faceArea2 = faceAreaTable.up[l];
					Vector3 b3 = Vector3.Scale(this.voxelBase.importScale, faceArea2.minf + b);
					float x2 = (float)faceArea2.size.x * this.voxelBase.importScale.x;
					float z = (float)faceArea2.size.z * this.voxelBase.importScale.z;
					int count2 = list.Count;
					list.Add(new Vector3(0f, this.voxelBase.importScale.y, 0f) + b3);
					list.Add(new Vector3(0f, this.voxelBase.importScale.y, z) + b3);
					list.Add(new Vector3(x2, this.voxelBase.importScale.y, z) + b3);
					list.Add(new Vector3(x2, this.voxelBase.importScale.y, 0f) + b3);
					array[faceArea2.material].Add(count2);
					array[faceArea2.material].Add(count2 + 1);
					array[faceArea2.material].Add(count2 + 2);
					array[faceArea2.material].Add(count2);
					array[faceArea2.material].Add(count2 + 2);
					array[faceArea2.material].Add(count2 + 3);
					for (int m = 0; m < 4; m++)
					{
						list3.Add(Vector3.up);
					}
					if (faceArea2.palette >= 0)
					{
						MyVoxelBaseCore.TextureBoundArea textureBoundArea2 = atlasRectTable.up[l];
						list2.Add(new Vector2(atlasRects[textureBoundArea2.textureIndex].position.x + (float)(faceArea2.min.x - textureBoundArea2.min.x) * vector.x, atlasRects[textureBoundArea2.textureIndex].position.y + (float)(faceArea2.min.z - textureBoundArea2.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea2.textureIndex].position.x + (float)(faceArea2.min.x - textureBoundArea2.min.x) * vector.x, atlasRects[textureBoundArea2.textureIndex].position.y + atlasRects[textureBoundArea2.textureIndex].size.y - (float)(textureBoundArea2.max.y - faceArea2.max.z) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea2.textureIndex].position.x + atlasRects[textureBoundArea2.textureIndex].size.x - (float)(textureBoundArea2.max.x - faceArea2.max.x) * vector.x, atlasRects[textureBoundArea2.textureIndex].position.y + atlasRects[textureBoundArea2.textureIndex].size.y - (float)(textureBoundArea2.max.y - faceArea2.max.z) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea2.textureIndex].position.x + atlasRects[textureBoundArea2.textureIndex].size.x - (float)(textureBoundArea2.max.x - faceArea2.max.x) * vector.x, atlasRects[textureBoundArea2.textureIndex].position.y + (float)(faceArea2.min.z - textureBoundArea2.min.y) * vector.y));
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.right) != (VoxelBase.Face)0)
			{
				for (int n = 0; n < faceAreaTable.right.Count; n++)
				{
					VoxelData.FaceArea faceArea3 = faceAreaTable.right[n];
					Vector3 b4 = Vector3.Scale(this.voxelBase.importScale, faceArea3.minf + b);
					float y2 = (float)faceArea3.size.y * this.voxelBase.importScale.y;
					float z2 = (float)faceArea3.size.z * this.voxelBase.importScale.z;
					int count3 = list.Count;
					list.Add(new Vector3(this.voxelBase.importScale.x, 0f, 0f) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, y2, 0f) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, y2, z2) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, 0f, z2) + b4);
					array[faceArea3.material].Add(count3);
					array[faceArea3.material].Add(count3 + 1);
					array[faceArea3.material].Add(count3 + 2);
					array[faceArea3.material].Add(count3);
					array[faceArea3.material].Add(count3 + 2);
					array[faceArea3.material].Add(count3 + 3);
					for (int num = 0; num < 4; num++)
					{
						list3.Add(Vector3.right);
					}
					if (faceArea3.palette >= 0)
					{
						MyVoxelBaseCore.TextureBoundArea textureBoundArea3 = atlasRectTable.right[n];
						list2.Add(new Vector2(atlasRects[textureBoundArea3.textureIndex].position.x + (float)(faceArea3.min.y - textureBoundArea3.min.x) * vector.x, atlasRects[textureBoundArea3.textureIndex].position.y + (float)(faceArea3.min.z - textureBoundArea3.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea3.textureIndex].position.x + atlasRects[textureBoundArea3.textureIndex].size.x - (float)(textureBoundArea3.max.x - faceArea3.max.y) * vector.x, atlasRects[textureBoundArea3.textureIndex].position.y + (float)(faceArea3.min.z - textureBoundArea3.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea3.textureIndex].position.x + atlasRects[textureBoundArea3.textureIndex].size.x - (float)(textureBoundArea3.max.x - faceArea3.max.y) * vector.x, atlasRects[textureBoundArea3.textureIndex].position.y + atlasRects[textureBoundArea3.textureIndex].size.y - (float)(textureBoundArea3.max.y - faceArea3.max.z) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea3.textureIndex].position.x + (float)(faceArea3.min.y - textureBoundArea3.min.x) * vector.x, atlasRects[textureBoundArea3.textureIndex].position.y + atlasRects[textureBoundArea3.textureIndex].size.y - (float)(textureBoundArea3.max.y - faceArea3.max.z) * vector.y));
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.left) != (VoxelBase.Face)0)
			{
				for (int num2 = 0; num2 < faceAreaTable.left.Count; num2++)
				{
					VoxelData.FaceArea faceArea4 = faceAreaTable.left[num2];
					Vector3 b5 = Vector3.Scale(this.voxelBase.importScale, faceArea4.minf + b);
					float y3 = (float)faceArea4.size.y * this.voxelBase.importScale.y;
					float z3 = (float)faceArea4.size.z * this.voxelBase.importScale.z;
					int count4 = list.Count;
					list.Add(new Vector3(0f, 0f, z3) + b5);
					list.Add(new Vector3(0f, 0f, 0f) + b5);
					list.Add(new Vector3(0f, y3, 0f) + b5);
					list.Add(new Vector3(0f, y3, z3) + b5);
					array[faceArea4.material].Add(count4 + 2);
					array[faceArea4.material].Add(count4 + 1);
					array[faceArea4.material].Add(count4);
					array[faceArea4.material].Add(count4 + 3);
					array[faceArea4.material].Add(count4 + 2);
					array[faceArea4.material].Add(count4);
					for (int num3 = 0; num3 < 4; num3++)
					{
						list3.Add(Vector3.left);
					}
					if (faceArea4.palette >= 0)
					{
						MyVoxelBaseCore.TextureBoundArea textureBoundArea4 = atlasRectTable.left[num2];
						list2.Add(new Vector2(atlasRects[textureBoundArea4.textureIndex].position.x + (float)(faceArea4.min.y - textureBoundArea4.min.x) * vector.x, atlasRects[textureBoundArea4.textureIndex].position.y + atlasRects[textureBoundArea4.textureIndex].size.y - (float)(textureBoundArea4.max.y - faceArea4.max.z) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea4.textureIndex].position.x + (float)(faceArea4.min.y - textureBoundArea4.min.x) * vector.x, atlasRects[textureBoundArea4.textureIndex].position.y + (float)(faceArea4.min.z - textureBoundArea4.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea4.textureIndex].position.x + atlasRects[textureBoundArea4.textureIndex].size.x - (float)(textureBoundArea4.max.x - faceArea4.max.y) * vector.x, atlasRects[textureBoundArea4.textureIndex].position.y + (float)(faceArea4.min.z - textureBoundArea4.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea4.textureIndex].position.x + atlasRects[textureBoundArea4.textureIndex].size.x - (float)(textureBoundArea4.max.x - faceArea4.max.y) * vector.x, atlasRects[textureBoundArea4.textureIndex].position.y + atlasRects[textureBoundArea4.textureIndex].size.y - (float)(textureBoundArea4.max.y - faceArea4.max.z) * vector.y));
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.down) != (VoxelBase.Face)0)
			{
				for (int num4 = 0; num4 < faceAreaTable.down.Count; num4++)
				{
					VoxelData.FaceArea faceArea5 = faceAreaTable.down[num4];
					Vector3 b6 = Vector3.Scale(this.voxelBase.importScale, faceArea5.minf + b);
					float x3 = (float)faceArea5.size.x * this.voxelBase.importScale.x;
					float z4 = (float)faceArea5.size.z * this.voxelBase.importScale.z;
					int count5 = list.Count;
					list.Add(new Vector3(x3, 0f, 0f) + b6);
					list.Add(new Vector3(0f, 0f, 0f) + b6);
					list.Add(new Vector3(0f, 0f, z4) + b6);
					list.Add(new Vector3(x3, 0f, z4) + b6);
					array[faceArea5.material].Add(count5 + 2);
					array[faceArea5.material].Add(count5 + 1);
					array[faceArea5.material].Add(count5);
					array[faceArea5.material].Add(count5 + 3);
					array[faceArea5.material].Add(count5 + 2);
					array[faceArea5.material].Add(count5);
					for (int num5 = 0; num5 < 4; num5++)
					{
						list3.Add(Vector3.down);
					}
					if (faceArea5.palette >= 0)
					{
						MyVoxelBaseCore.TextureBoundArea textureBoundArea5 = atlasRectTable.down[num4];
						list2.Add(new Vector2(atlasRects[textureBoundArea5.textureIndex].position.x + atlasRects[textureBoundArea5.textureIndex].size.x - (float)(textureBoundArea5.max.x - faceArea5.max.x) * vector.x, atlasRects[textureBoundArea5.textureIndex].position.y + (float)(faceArea5.min.z - textureBoundArea5.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea5.textureIndex].position.x + (float)(faceArea5.min.x - textureBoundArea5.min.x) * vector.x, atlasRects[textureBoundArea5.textureIndex].position.y + (float)(faceArea5.min.z - textureBoundArea5.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea5.textureIndex].position.x + (float)(faceArea5.min.x - textureBoundArea5.min.x) * vector.x, atlasRects[textureBoundArea5.textureIndex].position.y + atlasRects[textureBoundArea5.textureIndex].size.y - (float)(textureBoundArea5.max.y - faceArea5.max.z) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea5.textureIndex].position.x + atlasRects[textureBoundArea5.textureIndex].size.x - (float)(textureBoundArea5.max.x - faceArea5.max.x) * vector.x, atlasRects[textureBoundArea5.textureIndex].position.y + atlasRects[textureBoundArea5.textureIndex].size.y - (float)(textureBoundArea5.max.y - faceArea5.max.z) * vector.y));
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.back) != (VoxelBase.Face)0)
			{
				for (int num6 = 0; num6 < faceAreaTable.back.Count; num6++)
				{
					VoxelData.FaceArea faceArea6 = faceAreaTable.back[num6];
					Vector3 b7 = Vector3.Scale(this.voxelBase.importScale, faceArea6.minf + b);
					float x4 = (float)faceArea6.size.x * this.voxelBase.importScale.x;
					float y4 = (float)faceArea6.size.y * this.voxelBase.importScale.y;
					int count6 = list.Count;
					list.Add(new Vector3(0f, 0f, 0f) + b7);
					list.Add(new Vector3(x4, 0f, 0f) + b7);
					list.Add(new Vector3(x4, y4, 0f) + b7);
					list.Add(new Vector3(0f, y4, 0f) + b7);
					array[faceArea6.material].Add(count6 + 2);
					array[faceArea6.material].Add(count6 + 1);
					array[faceArea6.material].Add(count6);
					array[faceArea6.material].Add(count6 + 3);
					array[faceArea6.material].Add(count6 + 2);
					array[faceArea6.material].Add(count6);
					for (int num7 = 0; num7 < 4; num7++)
					{
						list3.Add(Vector3.back);
					}
					if (faceArea6.palette >= 0)
					{
						MyVoxelBaseCore.TextureBoundArea textureBoundArea6 = atlasRectTable.back[num6];
						list2.Add(new Vector2(atlasRects[textureBoundArea6.textureIndex].position.x + (float)(faceArea6.min.x - textureBoundArea6.min.x) * vector.x, atlasRects[textureBoundArea6.textureIndex].position.y + (float)(faceArea6.min.y - textureBoundArea6.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea6.textureIndex].position.x + atlasRects[textureBoundArea6.textureIndex].size.x - (float)(textureBoundArea6.max.x - faceArea6.max.x) * vector.x, atlasRects[textureBoundArea6.textureIndex].position.y + (float)(faceArea6.min.y - textureBoundArea6.min.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea6.textureIndex].position.x + atlasRects[textureBoundArea6.textureIndex].size.x - (float)(textureBoundArea6.max.x - faceArea6.max.x) * vector.x, atlasRects[textureBoundArea6.textureIndex].position.y + atlasRects[textureBoundArea6.textureIndex].size.y - (float)(textureBoundArea6.max.y - faceArea6.max.y) * vector.y));
						list2.Add(new Vector2(atlasRects[textureBoundArea6.textureIndex].position.x + (float)(faceArea6.min.x - textureBoundArea6.min.x) * vector.x, atlasRects[textureBoundArea6.textureIndex].position.y + atlasRects[textureBoundArea6.textureIndex].size.y - (float)(textureBoundArea6.max.y - faceArea6.max.y) * vector.y));
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
					}
				}
			}
			if (list.Count > 65000)
			{
				Debug.LogWarningFormat("<color=green>[VoxelCharacteImporter]</color> Mesh.vertices is too large. A mesh may not have more than 65000 vertices. <color=red>{0} / 65000</color>", new object[]
				{
					list.Count
				});
				list.RemoveRange(64999, list.Count - 64999);
				if (list2.Count > 64999)
				{
					list2.RemoveRange(64999, list2.Count - 64999);
				}
				if (list3.Count > 64999)
				{
					list3.RemoveRange(64999, list3.Count - 64999);
				}
				if (this.isHaveBoneWeight && list4.Count > 64999)
				{
					list4.RemoveRange(64999, list4.Count - 64999);
				}
				for (int num8 = 0; num8 < array.Length; num8++)
				{
					for (int num9 = array[num8].Count - 1; num9 >= 0; num9--)
					{
						if (array[num8][num9] < 64999)
						{
							int num10 = num9 / 3 * 3;
							array[num8].RemoveRange(num10, array[num8].Count - num10);
							break;
						}
					}
				}
			}
			result.vertices = list.ToArray();
			result.uv = list2.ToArray();
			result.normals = list3.ToArray();
			if (this.isHaveBoneWeight)
			{
				result.boneWeights = list4.ToArray();
				result.bindposes = this.GetBindposes();
			}
			int num11 = 0;
			for (int num12 = 0; num12 < array.Length; num12++)
			{
				if (array[num12].Count > 0)
				{
					num11++;
				}
			}
			result.subMeshCount = num11;
			int num13 = 0;
			for (int num14 = 0; num14 < array.Length; num14++)
			{
				if (array[num14].Count > 0)
				{
					materialIndexes.Add(num14);
					result.SetTriangles(array[num14].ToArray(), num13++);
				}
			}
			result.RecalculateBounds();
			result.Optimize();
			return result;
		}

		public virtual void SetRendererCompornent()
		{
		}

		public abstract Mesh[] Edit_CreateMesh(List<VoxelData.Voxel> voxels, List<MyVoxelBaseCore.Edit_VerticesInfo> dstList = null, bool combine = true);

		public Mesh Edit_CreateMeshOnly(List<VoxelData.Voxel> voxels, Rect[] atlasRects, List<MyVoxelBaseCore.Edit_VerticesInfo> dstList = null, bool combine = true)
		{
			VoxelData.FaceAreaTable tmpFaceAreaTable = this.Edit_CreateMeshOnly_FaceArea(voxels, combine);
			return this.Edit_CreateMeshOnly_Mesh(tmpFaceAreaTable, atlasRects, dstList);
		}

		public VoxelData.FaceAreaTable Edit_CreateMeshOnly_FaceArea(List<VoxelData.Voxel> voxels, bool combine = true)
		{
			MyVoxelBaseCore.<>c__DisplayClass45_0 CS$<>8__locals1 = new MyVoxelBaseCore.<>c__DisplayClass45_0();
			CS$<>8__locals1.voxels = voxels;
			CS$<>8__locals1.combine = combine;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.tmpVoxelTable = new DataTable3<int>(this.voxelBase.voxelData.voxelSize.x, this.voxelBase.voxelData.voxelSize.y, this.voxelBase.voxelData.voxelSize.z);
			for (int i = 0; i < CS$<>8__locals1.voxels.Count; i++)
			{
				CS$<>8__locals1.tmpVoxelTable.Set(CS$<>8__locals1.voxels[i].position, i);
			}
			CS$<>8__locals1.TmpVoxelTableContains = delegate(int x, int y, int z)
			{
				if (!CS$<>8__locals1.tmpVoxelTable.Contains(x, y, z))
				{
					return -1;
				}
				return CS$<>8__locals1.tmpVoxelTable.Get(x, y, z);
			};
			VoxelBase.Face[] voxelDoneFaces = new VoxelBase.Face[CS$<>8__locals1.voxels.Count];
			for (int j = 0; j < CS$<>8__locals1.voxels.Count; j++)
			{
				if (CS$<>8__locals1.TmpVoxelTableContains(CS$<>8__locals1.voxels[j].x, CS$<>8__locals1.voxels[j].y, CS$<>8__locals1.voxels[j].z + 1) >= 0)
				{
					voxelDoneFaces[j] |= VoxelBase.Face.forward;
				}
				if (CS$<>8__locals1.TmpVoxelTableContains(CS$<>8__locals1.voxels[j].x, CS$<>8__locals1.voxels[j].y + 1, CS$<>8__locals1.voxels[j].z) >= 0)
				{
					voxelDoneFaces[j] |= VoxelBase.Face.up;
				}
				if (CS$<>8__locals1.TmpVoxelTableContains(CS$<>8__locals1.voxels[j].x + 1, CS$<>8__locals1.voxels[j].y, CS$<>8__locals1.voxels[j].z) >= 0)
				{
					voxelDoneFaces[j] |= VoxelBase.Face.right;
				}
				if (CS$<>8__locals1.TmpVoxelTableContains(CS$<>8__locals1.voxels[j].x - 1, CS$<>8__locals1.voxels[j].y, CS$<>8__locals1.voxels[j].z) >= 0)
				{
					voxelDoneFaces[j] |= VoxelBase.Face.left;
				}
				if (CS$<>8__locals1.TmpVoxelTableContains(CS$<>8__locals1.voxels[j].x, CS$<>8__locals1.voxels[j].y - 1, CS$<>8__locals1.voxels[j].z) >= 0)
				{
					voxelDoneFaces[j] |= VoxelBase.Face.down;
				}
				if (CS$<>8__locals1.TmpVoxelTableContains(CS$<>8__locals1.voxels[j].x, CS$<>8__locals1.voxels[j].y, CS$<>8__locals1.voxels[j].z - 1) >= 0)
				{
					voxelDoneFaces[j] |= VoxelBase.Face.back;
				}
			}
			Action<VoxelData.FaceArea, VoxelBase.Face> action = delegate(VoxelData.FaceArea faceArea, VoxelBase.Face flag)
			{
				for (int num3 = faceArea.min.x; num3 <= faceArea.max.x; num3++)
				{
					for (int num4 = faceArea.min.y; num4 <= faceArea.max.y; num4++)
					{
						for (int num5 = faceArea.min.z; num5 <= faceArea.max.z; num5++)
						{
							int num6 = CS$<>8__locals1.TmpVoxelTableContains(num3, num4, num5);
							voxelDoneFaces[num6] |= flag;
						}
					}
				}
			};
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int palette = CS$<>8__locals1.voxels[baseIndex].palette;
				int x = CS$<>8__locals1.voxels[baseIndex].x;
				int y = CS$<>8__locals1.voxels[baseIndex].y;
				int z = CS$<>8__locals1.voxels[baseIndex].z;
				VoxelData.FaceArea faceArea8 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = CS$<>8__locals1.voxels[baseIndex].palette
				};
				if (CS$<>8__locals1.combine)
				{
					int num3 = z - 1;
					for (;;)
					{
						int num4 = CS$<>8__locals1.TmpVoxelTableContains(x, y, num3);
						if (num4 < 0 || CS$<>8__locals1.voxels[num4].palette != palette || (voxelDoneFaces[num4] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num4].position, flag))
						{
							break;
						}
						faceArea8.min.z = num3;
						num3--;
					}
					int num5 = z + 1;
					for (;;)
					{
						int num6 = CS$<>8__locals1.TmpVoxelTableContains(x, y, num5);
						if (num6 < 0 || CS$<>8__locals1.voxels[num6].palette != palette || (voxelDoneFaces[num6] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num6].position, flag))
						{
							break;
						}
						faceArea8.max.z = num5;
						num5++;
					}
					int num7 = y - 1;
					for (;;)
					{
						bool flag2 = true;
						for (int num8 = faceArea8.min.z; num8 <= faceArea8.max.z; num8++)
						{
							int num9 = CS$<>8__locals1.TmpVoxelTableContains(x, num7, num8);
							if (num9 < 0 || CS$<>8__locals1.voxels[num9].palette != palette || (voxelDoneFaces[num9] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num9].position, flag))
							{
								flag2 = false;
								break;
							}
						}
						if (!flag2)
						{
							break;
						}
						faceArea8.min.y = num7;
						num7--;
					}
					int num10 = y + 1;
					for (;;)
					{
						bool flag3 = true;
						for (int num11 = faceArea8.min.z; num11 <= faceArea8.max.z; num11++)
						{
							int num12 = CS$<>8__locals1.TmpVoxelTableContains(x, num10, num11);
							if (num12 < 0 || CS$<>8__locals1.voxels[num12].palette != palette || (voxelDoneFaces[num12] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num12].position, flag))
							{
								flag3 = false;
								break;
							}
						}
						if (!flag3)
						{
							break;
						}
						faceArea8.max.y = num10;
						num10++;
					}
				}
				return faceArea8;
			};
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func2 = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int palette = CS$<>8__locals1.voxels[baseIndex].palette;
				int x = CS$<>8__locals1.voxels[baseIndex].x;
				int y = CS$<>8__locals1.voxels[baseIndex].y;
				int z = CS$<>8__locals1.voxels[baseIndex].z;
				VoxelData.FaceArea faceArea8 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = CS$<>8__locals1.voxels[baseIndex].palette
				};
				if (CS$<>8__locals1.combine)
				{
					int num3 = z - 1;
					for (;;)
					{
						int num4 = CS$<>8__locals1.TmpVoxelTableContains(x, y, num3);
						if (num4 < 0 || CS$<>8__locals1.voxels[num4].palette != palette || (voxelDoneFaces[num4] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num4].position, flag))
						{
							break;
						}
						faceArea8.min.z = num3;
						num3--;
					}
					int num5 = z + 1;
					for (;;)
					{
						int num6 = CS$<>8__locals1.TmpVoxelTableContains(x, y, num5);
						if (num6 < 0 || CS$<>8__locals1.voxels[num6].palette != palette || (voxelDoneFaces[num6] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num6].position, flag))
						{
							break;
						}
						faceArea8.max.z = num5;
						num5++;
					}
					int num7 = x - 1;
					for (;;)
					{
						bool flag2 = true;
						for (int num8 = faceArea8.min.z; num8 <= faceArea8.max.z; num8++)
						{
							int num9 = CS$<>8__locals1.TmpVoxelTableContains(num7, y, num8);
							if (num9 < 0 || CS$<>8__locals1.voxels[num9].palette != palette || (voxelDoneFaces[num9] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num9].position, flag))
							{
								flag2 = false;
								break;
							}
						}
						if (!flag2)
						{
							break;
						}
						faceArea8.min.x = num7;
						num7--;
					}
					int num10 = x + 1;
					for (;;)
					{
						bool flag3 = true;
						for (int num11 = faceArea8.min.z; num11 <= faceArea8.max.z; num11++)
						{
							int num12 = CS$<>8__locals1.TmpVoxelTableContains(num10, y, num11);
							if (num12 < 0 || CS$<>8__locals1.voxels[num12].palette != palette || (voxelDoneFaces[num12] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num12].position, flag))
							{
								flag3 = false;
								break;
							}
						}
						if (!flag3)
						{
							break;
						}
						faceArea8.max.x = num10;
						num10++;
					}
				}
				return faceArea8;
			};
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func3 = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int palette = CS$<>8__locals1.voxels[baseIndex].palette;
				int x = CS$<>8__locals1.voxels[baseIndex].x;
				int y = CS$<>8__locals1.voxels[baseIndex].y;
				int z = CS$<>8__locals1.voxels[baseIndex].z;
				VoxelData.FaceArea faceArea8 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = CS$<>8__locals1.voxels[baseIndex].palette
				};
				if (CS$<>8__locals1.combine)
				{
					int num3 = y - 1;
					for (;;)
					{
						int num4 = CS$<>8__locals1.TmpVoxelTableContains(x, num3, z);
						if (num4 < 0 || CS$<>8__locals1.voxels[num4].palette != palette || (voxelDoneFaces[num4] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num4].position, flag))
						{
							break;
						}
						faceArea8.min.y = num3;
						num3--;
					}
					int num5 = y + 1;
					for (;;)
					{
						int num6 = CS$<>8__locals1.TmpVoxelTableContains(x, num5, z);
						if (num6 < 0 || CS$<>8__locals1.voxels[num6].palette != palette || (voxelDoneFaces[num6] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num6].position, flag))
						{
							break;
						}
						faceArea8.max.y = num5;
						num5++;
					}
					int num7 = x - 1;
					for (;;)
					{
						bool flag2 = true;
						for (int num8 = faceArea8.min.y; num8 <= faceArea8.max.y; num8++)
						{
							int num9 = CS$<>8__locals1.TmpVoxelTableContains(num7, num8, z);
							if (num9 < 0 || CS$<>8__locals1.voxels[num9].palette != palette || (voxelDoneFaces[num9] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num9].position, flag))
							{
								flag2 = false;
								break;
							}
						}
						if (!flag2)
						{
							break;
						}
						faceArea8.min.x = num7;
						num7--;
					}
					int num10 = x + 1;
					for (;;)
					{
						bool flag3 = true;
						for (int num11 = faceArea8.min.y; num11 <= faceArea8.max.y; num11++)
						{
							int num12 = CS$<>8__locals1.TmpVoxelTableContains(num10, num11, z);
							if (num12 < 0 || CS$<>8__locals1.voxels[num12].palette != palette || (voxelDoneFaces[num12] & flag) != (VoxelBase.Face)0 || !CS$<>8__locals1.<>4__this.IsCombineVoxelFace(CS$<>8__locals1.voxels[baseIndex].position, CS$<>8__locals1.voxels[num12].position, flag))
							{
								flag3 = false;
								break;
							}
						}
						if (!flag3)
						{
							break;
						}
						faceArea8.max.x = num10;
						num10++;
					}
				}
				return faceArea8;
			};
			VoxelData.FaceAreaTable faceAreaTable = new VoxelData.FaceAreaTable();
			for (int k = 0; k < CS$<>8__locals1.voxels.Count; k++)
			{
				if ((voxelDoneFaces[k] & VoxelBase.Face.forward) == (VoxelBase.Face)0)
				{
					VoxelData.FaceArea faceArea7 = func3(k, VoxelBase.Face.forward);
					action(faceArea7, VoxelBase.Face.forward);
					faceAreaTable.forward.Add(faceArea7);
				}
			}
			for (int l = 0; l < CS$<>8__locals1.voxels.Count; l++)
			{
				if ((voxelDoneFaces[l] & VoxelBase.Face.up) == (VoxelBase.Face)0)
				{
					VoxelData.FaceArea faceArea2 = func2(l, VoxelBase.Face.up);
					action(faceArea2, VoxelBase.Face.up);
					faceAreaTable.up.Add(faceArea2);
				}
			}
			for (int m = 0; m < CS$<>8__locals1.voxels.Count; m++)
			{
				if ((voxelDoneFaces[m] & VoxelBase.Face.right) == (VoxelBase.Face)0)
				{
					VoxelData.FaceArea faceArea3 = func(m, VoxelBase.Face.right);
					action(faceArea3, VoxelBase.Face.right);
					faceAreaTable.right.Add(faceArea3);
				}
			}
			for (int n = 0; n < CS$<>8__locals1.voxels.Count; n++)
			{
				if ((voxelDoneFaces[n] & VoxelBase.Face.left) == (VoxelBase.Face)0)
				{
					VoxelData.FaceArea faceArea4 = func(n, VoxelBase.Face.left);
					action(faceArea4, VoxelBase.Face.left);
					faceAreaTable.left.Add(faceArea4);
				}
			}
			for (int num = 0; num < CS$<>8__locals1.voxels.Count; num++)
			{
				if ((voxelDoneFaces[num] & VoxelBase.Face.down) == (VoxelBase.Face)0)
				{
					VoxelData.FaceArea faceArea5 = func2(num, VoxelBase.Face.down);
					action(faceArea5, VoxelBase.Face.down);
					faceAreaTable.down.Add(faceArea5);
				}
			}
			for (int num2 = 0; num2 < CS$<>8__locals1.voxels.Count; num2++)
			{
				if ((voxelDoneFaces[num2] & VoxelBase.Face.back) == (VoxelBase.Face)0)
				{
					VoxelData.FaceArea faceArea6 = func3(num2, VoxelBase.Face.back);
					action(faceArea6, VoxelBase.Face.back);
					faceAreaTable.back.Add(faceArea6);
				}
			}
			return faceAreaTable;
		}

		public Mesh Edit_CreateMeshOnly_Mesh(VoxelData.FaceAreaTable tmpFaceAreaTable, Rect[] atlasRects, List<MyVoxelBaseCore.Edit_VerticesInfo> dstList = null)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector3> list3 = new List<Vector3>();
			List<BoneWeight> list4 = this.isHaveBoneWeight ? new List<BoneWeight>() : null;
			List<int> list5 = new List<int>();
			Vector3 b = this.voxelBase.localOffset + this.voxelBase.importOffset;
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.forward) != (VoxelBase.Face)0)
			{
				for (int i = 0; i < tmpFaceAreaTable.forward.Count; i++)
				{
					VoxelData.FaceArea faceArea = tmpFaceAreaTable.forward[i];
					Vector3 b2 = Vector3.Scale(this.voxelBase.importScale, faceArea.minf + b);
					float x = (float)faceArea.size.x * this.voxelBase.importScale.x;
					float y = (float)faceArea.size.y * this.voxelBase.importScale.y;
					int count = list.Count;
					list.Add(new Vector3(0f, y, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(0f, 0f, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(x, 0f, this.voxelBase.importScale.z) + b2);
					list.Add(new Vector3(x, y, this.voxelBase.importScale.z) + b2);
					list5.Add(count);
					list5.Add(count + 1);
					list5.Add(count + 2);
					list5.Add(count);
					list5.Add(count + 2);
					list5.Add(count + 3);
					for (int j = 0; j < 4; j++)
					{
						if (faceArea.palette >= 0)
						{
							list2.Add(atlasRects[faceArea.palette].position);
						}
						list3.Add(Vector3.forward);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
					}
					if (dstList != null)
					{
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea.Get(VoxelBase.VoxelVertexIndex._XYZ),
							vertexIndex = VoxelBase.VoxelVertexIndex._XYZ
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea.Get(VoxelBase.VoxelVertexIndex._X_YZ),
							vertexIndex = VoxelBase.VoxelVertexIndex._X_YZ
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea.Get(VoxelBase.VoxelVertexIndex.X_YZ),
							vertexIndex = VoxelBase.VoxelVertexIndex.X_YZ
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea.Get(VoxelBase.VoxelVertexIndex.XYZ),
							vertexIndex = VoxelBase.VoxelVertexIndex.XYZ
						});
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.up) != (VoxelBase.Face)0)
			{
				for (int k = 0; k < tmpFaceAreaTable.up.Count; k++)
				{
					VoxelData.FaceArea faceArea2 = tmpFaceAreaTable.up[k];
					Vector3 b3 = Vector3.Scale(this.voxelBase.importScale, faceArea2.minf + b);
					float x2 = (float)faceArea2.size.x * this.voxelBase.importScale.x;
					float z = (float)faceArea2.size.z * this.voxelBase.importScale.z;
					int count2 = list.Count;
					list.Add(new Vector3(0f, this.voxelBase.importScale.y, 0f) + b3);
					list.Add(new Vector3(0f, this.voxelBase.importScale.y, z) + b3);
					list.Add(new Vector3(x2, this.voxelBase.importScale.y, z) + b3);
					list.Add(new Vector3(x2, this.voxelBase.importScale.y, 0f) + b3);
					list5.Add(count2);
					list5.Add(count2 + 1);
					list5.Add(count2 + 2);
					list5.Add(count2);
					list5.Add(count2 + 2);
					list5.Add(count2 + 3);
					for (int l = 0; l < 4; l++)
					{
						if (faceArea2.palette >= 0)
						{
							list2.Add(atlasRects[faceArea2.palette].position);
						}
						list3.Add(Vector3.up);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea2.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
					}
					if (dstList != null)
					{
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea2.Get(VoxelBase.VoxelVertexIndex._XY_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex._XY_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea2.Get(VoxelBase.VoxelVertexIndex._XYZ),
							vertexIndex = VoxelBase.VoxelVertexIndex._XYZ
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea2.Get(VoxelBase.VoxelVertexIndex.XYZ),
							vertexIndex = VoxelBase.VoxelVertexIndex.XYZ
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea2.Get(VoxelBase.VoxelVertexIndex.XY_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex.XY_Z
						});
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.right) != (VoxelBase.Face)0)
			{
				for (int m = 0; m < tmpFaceAreaTable.right.Count; m++)
				{
					VoxelData.FaceArea faceArea3 = tmpFaceAreaTable.right[m];
					Vector3 b4 = Vector3.Scale(this.voxelBase.importScale, faceArea3.minf + b);
					float y2 = (float)faceArea3.size.y * this.voxelBase.importScale.y;
					float z2 = (float)faceArea3.size.z * this.voxelBase.importScale.z;
					int count3 = list.Count;
					list.Add(new Vector3(this.voxelBase.importScale.x, 0f, 0f) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, y2, 0f) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, y2, z2) + b4);
					list.Add(new Vector3(this.voxelBase.importScale.x, 0f, z2) + b4);
					list5.Add(count3);
					list5.Add(count3 + 1);
					list5.Add(count3 + 2);
					list5.Add(count3);
					list5.Add(count3 + 2);
					list5.Add(count3 + 3);
					for (int n = 0; n < 4; n++)
					{
						if (faceArea3.palette >= 0)
						{
							list2.Add(atlasRects[faceArea3.palette].position);
						}
						list3.Add(Vector3.right);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.XYZ))], VoxelBase.VoxelVertexIndex.XYZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea3.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
					}
					if (dstList != null)
					{
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea3.Get(VoxelBase.VoxelVertexIndex.X_Y_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex.X_Y_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea3.Get(VoxelBase.VoxelVertexIndex.XY_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex.XY_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea3.Get(VoxelBase.VoxelVertexIndex.XYZ),
							vertexIndex = VoxelBase.VoxelVertexIndex.XYZ
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea3.Get(VoxelBase.VoxelVertexIndex.X_YZ),
							vertexIndex = VoxelBase.VoxelVertexIndex.X_YZ
						});
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.left) != (VoxelBase.Face)0)
			{
				for (int num = 0; num < tmpFaceAreaTable.left.Count; num++)
				{
					VoxelData.FaceArea faceArea4 = tmpFaceAreaTable.left[num];
					Vector3 b5 = Vector3.Scale(this.voxelBase.importScale, faceArea4.minf + b);
					float y3 = (float)faceArea4.size.y * this.voxelBase.importScale.y;
					float z3 = (float)faceArea4.size.z * this.voxelBase.importScale.z;
					int count4 = list.Count;
					list.Add(new Vector3(0f, 0f, z3) + b5);
					list.Add(new Vector3(0f, 0f, 0f) + b5);
					list.Add(new Vector3(0f, y3, 0f) + b5);
					list.Add(new Vector3(0f, y3, z3) + b5);
					list5.Add(count4 + 2);
					list5.Add(count4 + 1);
					list5.Add(count4);
					list5.Add(count4 + 3);
					list5.Add(count4 + 2);
					list5.Add(count4);
					for (int num2 = 0; num2 < 4; num2++)
					{
						if (faceArea4.palette >= 0)
						{
							list2.Add(atlasRects[faceArea4.palette].position);
						}
						list3.Add(Vector3.left);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea4.Get(VoxelBase.VoxelVertexIndex._XYZ))], VoxelBase.VoxelVertexIndex._XYZ));
					}
					if (dstList != null)
					{
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea4.Get(VoxelBase.VoxelVertexIndex._X_YZ),
							vertexIndex = VoxelBase.VoxelVertexIndex._X_YZ
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea4.Get(VoxelBase.VoxelVertexIndex._X_Y_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex._X_Y_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea4.Get(VoxelBase.VoxelVertexIndex._XY_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex._XY_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea4.Get(VoxelBase.VoxelVertexIndex._XYZ),
							vertexIndex = VoxelBase.VoxelVertexIndex._XYZ
						});
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.down) != (VoxelBase.Face)0)
			{
				for (int num3 = 0; num3 < tmpFaceAreaTable.down.Count; num3++)
				{
					VoxelData.FaceArea faceArea5 = tmpFaceAreaTable.down[num3];
					Vector3 b6 = Vector3.Scale(this.voxelBase.importScale, faceArea5.minf + b);
					float x3 = (float)faceArea5.size.x * this.voxelBase.importScale.x;
					float z4 = (float)faceArea5.size.z * this.voxelBase.importScale.z;
					int count5 = list.Count;
					list.Add(new Vector3(x3, 0f, 0f) + b6);
					list.Add(new Vector3(0f, 0f, 0f) + b6);
					list.Add(new Vector3(0f, 0f, z4) + b6);
					list.Add(new Vector3(x3, 0f, z4) + b6);
					list5.Add(count5 + 2);
					list5.Add(count5 + 1);
					list5.Add(count5);
					list5.Add(count5 + 3);
					list5.Add(count5 + 2);
					list5.Add(count5);
					for (int num4 = 0; num4 < 4; num4++)
					{
						if (faceArea5.palette >= 0)
						{
							list2.Add(atlasRects[faceArea5.palette].position);
						}
						list3.Add(Vector3.down);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex._X_YZ))], VoxelBase.VoxelVertexIndex._X_YZ));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea5.Get(VoxelBase.VoxelVertexIndex.X_YZ))], VoxelBase.VoxelVertexIndex.X_YZ));
					}
					if (dstList != null)
					{
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea5.Get(VoxelBase.VoxelVertexIndex.X_Y_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex.X_Y_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea5.Get(VoxelBase.VoxelVertexIndex._X_Y_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex._X_Y_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea5.Get(VoxelBase.VoxelVertexIndex._X_YZ),
							vertexIndex = VoxelBase.VoxelVertexIndex._X_YZ
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea5.Get(VoxelBase.VoxelVertexIndex.X_YZ),
							vertexIndex = VoxelBase.VoxelVertexIndex.X_YZ
						});
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.back) != (VoxelBase.Face)0)
			{
				for (int num5 = 0; num5 < tmpFaceAreaTable.back.Count; num5++)
				{
					VoxelData.FaceArea faceArea6 = tmpFaceAreaTable.back[num5];
					Vector3 b7 = Vector3.Scale(this.voxelBase.importScale, faceArea6.minf + b);
					float x4 = (float)faceArea6.size.x * this.voxelBase.importScale.x;
					float y4 = (float)faceArea6.size.y * this.voxelBase.importScale.y;
					int count6 = list.Count;
					list.Add(new Vector3(0f, 0f, 0f) + b7);
					list.Add(new Vector3(x4, 0f, 0f) + b7);
					list.Add(new Vector3(x4, y4, 0f) + b7);
					list.Add(new Vector3(0f, y4, 0f) + b7);
					list5.Add(count6 + 2);
					list5.Add(count6 + 1);
					list5.Add(count6);
					list5.Add(count6 + 3);
					list5.Add(count6 + 2);
					list5.Add(count6);
					for (int num6 = 0; num6 < 4; num6++)
					{
						if (faceArea6.palette >= 0)
						{
							list2.Add(atlasRects[faceArea6.palette].position);
						}
						list3.Add(Vector3.back);
					}
					if (this.isHaveBoneWeight)
					{
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex._X_Y_Z))], VoxelBase.VoxelVertexIndex._X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex.X_Y_Z))], VoxelBase.VoxelVertexIndex.X_Y_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex.XY_Z))], VoxelBase.VoxelVertexIndex.XY_Z));
						list4.Add(this.GetBoneWeight(ref this.voxelBase.voxelData.voxels[this.voxelBase.voxelData.VoxelTableContains(faceArea6.Get(VoxelBase.VoxelVertexIndex._XY_Z))], VoxelBase.VoxelVertexIndex._XY_Z));
					}
					if (dstList != null)
					{
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea6.Get(VoxelBase.VoxelVertexIndex._X_Y_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex._X_Y_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea6.Get(VoxelBase.VoxelVertexIndex.X_Y_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex.X_Y_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea6.Get(VoxelBase.VoxelVertexIndex.XY_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex.XY_Z
						});
						dstList.Add(new MyVoxelBaseCore.Edit_VerticesInfo
						{
							position = faceArea6.Get(VoxelBase.VoxelVertexIndex._XY_Z),
							vertexIndex = VoxelBase.VoxelVertexIndex._XY_Z
						});
					}
				}
			}
			Mesh mesh = new Mesh();
			if (list.Count > 65000)
			{
				list.RemoveRange(64999, list.Count - 64999);
				if (list2.Count > 64999)
				{
					list2.RemoveRange(64999, list2.Count - 64999);
				}
				if (list3.Count > 64999)
				{
					list3.RemoveRange(64999, list3.Count - 64999);
				}
				if (this.isHaveBoneWeight && list4.Count > 64999)
				{
					list4.RemoveRange(64999, list4.Count - 64999);
				}
				for (int num7 = list5.Count - 1; num7 >= 0; num7--)
				{
					if (list5[num7] < 64999)
					{
						int num8 = num7 / 3 * 3;
						list5.RemoveRange(num8, list5.Count - num8);
						break;
					}
				}
				if (dstList != null)
				{
					dstList.RemoveRange(64999, dstList.Count - 64999);
				}
			}
			mesh.vertices = list.ToArray();
			mesh.uv = list2.ToArray();
			mesh.normals = list3.ToArray();
			if (this.isHaveBoneWeight)
			{
				mesh.boneWeights = list4.ToArray();
				mesh.bindposes = this.GetBindposes();
			}
			mesh.triangles = list5.ToArray();
			mesh.RecalculateBounds();
			mesh.hideFlags = HideFlags.DontSave;
			return mesh;
		}

		protected VoxelData.FaceAreaTable CreateFaceArea(VoxelData.Voxel[] voxels)
		{
			VoxelData.FaceAreaTable result;
			if (this.voxelBase.importMode == VoxelBase.ImportMode.LowTexture)
			{
				result = this.CreateFaceArea_LowTexture(voxels);
			}
			else if (this.voxelBase.importMode == VoxelBase.ImportMode.LowPoly)
			{
				result = this.CreateFaceData_LowPoly(voxels);
			}
			else
			{
				result = new VoxelData.FaceAreaTable();
			}
			return result;
		}

		protected VoxelData.FaceAreaTable CreateFaceArea_LowTexture(VoxelData.Voxel[] voxels)
		{
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int x = voxels[baseIndex].x;
				int y = voxels[baseIndex].y;
				int z = voxels[baseIndex].z;
				int palette = voxels[baseIndex].palette;
				int num = this.materialIndexTable[x][y][z];
				VoxelData.FaceArea faceArea7 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = palette,
					material = num
				};
				int num2 = z - 1;
				for (;;)
				{
					int num3 = this.voxelBase.voxelData.VoxelTableContains(x, y, num2);
					if (num3 < 0 || this.voxelBase.voxelData.voxels[num3].palette != palette || this.materialIndexTable[x][y][num2] != num || (this.voxelDoneFaces[num3] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num3].position, flag))
					{
						break;
					}
					faceArea7.min.z = num2;
					num2--;
				}
				int num4 = z + 1;
				for (;;)
				{
					int num5 = this.voxelBase.voxelData.VoxelTableContains(x, y, num4);
					if (num5 < 0 || this.voxelBase.voxelData.voxels[num5].palette != palette || this.materialIndexTable[x][y][num4] != num || (this.voxelDoneFaces[num5] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num5].position, flag))
					{
						break;
					}
					faceArea7.max.z = num4;
					num4++;
				}
				int num6 = y - 1;
				for (;;)
				{
					bool flag2 = true;
					for (int num7 = faceArea7.min.z; num7 <= faceArea7.max.z; num7++)
					{
						int num8 = this.voxelBase.voxelData.VoxelTableContains(x, num6, num7);
						if (num8 < 0 || this.voxelBase.voxelData.voxels[num8].palette != palette || this.materialIndexTable[x][num6][num7] != num || (this.voxelDoneFaces[num8] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num8].position, flag))
						{
							flag2 = false;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					faceArea7.min.y = num6;
					num6--;
				}
				int num9 = y + 1;
				for (;;)
				{
					bool flag3 = true;
					for (int num10 = faceArea7.min.z; num10 <= faceArea7.max.z; num10++)
					{
						int num11 = this.voxelBase.voxelData.VoxelTableContains(x, num9, num10);
						if (num11 < 0 || this.voxelBase.voxelData.voxels[num11].palette != palette || this.materialIndexTable[x][num9][num10] != num || (this.voxelDoneFaces[num11] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num11].position, flag))
						{
							flag3 = false;
							break;
						}
					}
					if (!flag3)
					{
						break;
					}
					faceArea7.max.y = num9;
					num9++;
				}
				return faceArea7;
			};
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func2 = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int x = voxels[baseIndex].x;
				int y = voxels[baseIndex].y;
				int z = voxels[baseIndex].z;
				int palette = voxels[baseIndex].palette;
				int num = this.materialIndexTable[x][y][z];
				VoxelData.FaceArea faceArea7 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = palette,
					material = num
				};
				int num2 = z - 1;
				for (;;)
				{
					int num3 = this.voxelBase.voxelData.VoxelTableContains(x, y, num2);
					if (num3 < 0 || this.voxelBase.voxelData.voxels[num3].palette != palette || this.materialIndexTable[x][y][num2] != num || (this.voxelDoneFaces[num3] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num3].position, flag))
					{
						break;
					}
					faceArea7.min.z = num2;
					num2--;
				}
				int num4 = z + 1;
				for (;;)
				{
					int num5 = this.voxelBase.voxelData.VoxelTableContains(x, y, num4);
					if (num5 < 0 || this.voxelBase.voxelData.voxels[num5].palette != palette || this.materialIndexTable[x][y][num4] != num || (this.voxelDoneFaces[num5] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num5].position, flag))
					{
						break;
					}
					faceArea7.max.z = num4;
					num4++;
				}
				int num6 = x - 1;
				for (;;)
				{
					bool flag2 = true;
					for (int num7 = faceArea7.min.z; num7 <= faceArea7.max.z; num7++)
					{
						int num8 = this.voxelBase.voxelData.VoxelTableContains(num6, y, num7);
						if (num8 < 0 || this.voxelBase.voxelData.voxels[num8].palette != palette || this.materialIndexTable[num6][y][num7] != num || (this.voxelDoneFaces[num8] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num8].position, flag))
						{
							flag2 = false;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					faceArea7.min.x = num6;
					num6--;
				}
				int num9 = x + 1;
				for (;;)
				{
					bool flag3 = true;
					for (int num10 = faceArea7.min.z; num10 <= faceArea7.max.z; num10++)
					{
						int num11 = this.voxelBase.voxelData.VoxelTableContains(num9, y, num10);
						if (num11 < 0 || this.voxelBase.voxelData.voxels[num11].palette != palette || this.materialIndexTable[num9][y][num10] != num || (this.voxelDoneFaces[num11] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num11].position, flag))
						{
							flag3 = false;
							break;
						}
					}
					if (!flag3)
					{
						break;
					}
					faceArea7.max.x = num9;
					num9++;
				}
				return faceArea7;
			};
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func3 = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int x = voxels[baseIndex].x;
				int y = voxels[baseIndex].y;
				int z = voxels[baseIndex].z;
				int palette = voxels[baseIndex].palette;
				int num = this.materialIndexTable[x][y][z];
				VoxelData.FaceArea faceArea7 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = palette,
					material = num
				};
				int num2 = y - 1;
				for (;;)
				{
					int num3 = this.voxelBase.voxelData.VoxelTableContains(x, num2, z);
					if (num3 < 0 || this.voxelBase.voxelData.voxels[num3].palette != palette || this.materialIndexTable[x][num2][z] != num || (this.voxelDoneFaces[num3] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num3].position, flag))
					{
						break;
					}
					faceArea7.min.y = num2;
					num2--;
				}
				int num4 = y + 1;
				for (;;)
				{
					int num5 = this.voxelBase.voxelData.VoxelTableContains(x, num4, z);
					if (num5 < 0 || this.voxelBase.voxelData.voxels[num5].palette != palette || this.materialIndexTable[x][num4][z] != num || (this.voxelDoneFaces[num5] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num5].position, flag))
					{
						break;
					}
					faceArea7.max.y = num4;
					num4++;
				}
				int num6 = x - 1;
				for (;;)
				{
					bool flag2 = true;
					for (int num7 = faceArea7.min.y; num7 <= faceArea7.max.y; num7++)
					{
						int num8 = this.voxelBase.voxelData.VoxelTableContains(num6, num7, z);
						if (num8 < 0 || this.voxelBase.voxelData.voxels[num8].palette != palette || this.materialIndexTable[num6][num7][z] != num || (this.voxelDoneFaces[num8] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num8].position, flag))
						{
							flag2 = false;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					faceArea7.min.x = num6;
					num6--;
				}
				int num9 = x + 1;
				for (;;)
				{
					bool flag3 = true;
					for (int num10 = faceArea7.min.y; num10 <= faceArea7.max.y; num10++)
					{
						int num11 = this.voxelBase.voxelData.VoxelTableContains(num9, num10, z);
						if (num11 < 0 || this.voxelBase.voxelData.voxels[num11].palette != palette || this.materialIndexTable[num9][num10][z] != num || (this.voxelDoneFaces[num11] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num11].position, flag))
						{
							flag3 = false;
							break;
						}
					}
					if (!flag3)
					{
						break;
					}
					faceArea7.max.x = num9;
					num9++;
				}
				return faceArea7;
			};
			VoxelData.FaceAreaTable faceAreaTable = new VoxelData.FaceAreaTable();
			int[] voxelIndexTable = this.GetVoxelIndexTable(voxels);
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.forward) != (VoxelBase.Face)0)
			{
				for (int i = 0; i < voxels.Length; i++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[i]] & VoxelBase.Face.forward) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea = func3(i, VoxelBase.Face.forward);
						this.SetDoneFacesFlag(faceArea, VoxelBase.Face.forward);
						faceAreaTable.forward.Add(faceArea);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.up) != (VoxelBase.Face)0)
			{
				for (int j = 0; j < voxels.Length; j++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[j]] & VoxelBase.Face.up) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea2 = func2(j, VoxelBase.Face.up);
						this.SetDoneFacesFlag(faceArea2, VoxelBase.Face.up);
						faceAreaTable.up.Add(faceArea2);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.right) != (VoxelBase.Face)0)
			{
				for (int k = 0; k < voxels.Length; k++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[k]] & VoxelBase.Face.right) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea3 = func(k, VoxelBase.Face.right);
						this.SetDoneFacesFlag(faceArea3, VoxelBase.Face.right);
						faceAreaTable.right.Add(faceArea3);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.left) != (VoxelBase.Face)0)
			{
				for (int l = 0; l < voxels.Length; l++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[l]] & VoxelBase.Face.left) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea4 = func(l, VoxelBase.Face.left);
						this.SetDoneFacesFlag(faceArea4, VoxelBase.Face.left);
						faceAreaTable.left.Add(faceArea4);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.down) != (VoxelBase.Face)0)
			{
				for (int m = 0; m < voxels.Length; m++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[m]] & VoxelBase.Face.down) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea5 = func2(m, VoxelBase.Face.down);
						this.SetDoneFacesFlag(faceArea5, VoxelBase.Face.down);
						faceAreaTable.down.Add(faceArea5);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.back) != (VoxelBase.Face)0)
			{
				for (int n = 0; n < voxels.Length; n++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[n]] & VoxelBase.Face.back) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea6 = func3(n, VoxelBase.Face.back);
						this.SetDoneFacesFlag(faceArea6, VoxelBase.Face.back);
						faceAreaTable.back.Add(faceArea6);
					}
				}
			}
			return faceAreaTable;
		}

		protected VoxelData.FaceAreaTable CreateFaceData_LowPoly(VoxelData.Voxel[] voxels)
		{
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int x = voxels[baseIndex].x;
				int y = voxels[baseIndex].y;
				int z = voxels[baseIndex].z;
				int palette = voxels[baseIndex].palette;
				int num = this.materialIndexTable[x][y][z];
				VoxelData.FaceArea faceArea7 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = palette,
					material = num
				};
				int num2 = z - 1;
				for (;;)
				{
					int num3 = this.voxelBase.voxelData.VoxelTableContains(x, y, num2);
					if (num3 < 0 || this.materialIndexTable[x][y][num2] != num || (this.voxelDoneFaces[num3] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num3].position, flag))
					{
						break;
					}
					faceArea7.min.z = num2;
					num2--;
				}
				int num4 = z + 1;
				for (;;)
				{
					int num5 = this.voxelBase.voxelData.VoxelTableContains(x, y, num4);
					if (num5 < 0 || this.materialIndexTable[x][y][num4] != num || (this.voxelDoneFaces[num5] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num5].position, flag))
					{
						break;
					}
					faceArea7.max.z = num4;
					num4++;
				}
				int num6 = y - 1;
				for (;;)
				{
					bool flag2 = true;
					for (int num7 = faceArea7.min.z; num7 <= faceArea7.max.z; num7++)
					{
						int num8 = this.voxelBase.voxelData.VoxelTableContains(x, num6, num7);
						if (num8 < 0 || this.materialIndexTable[x][num6][num7] != num || (this.voxelDoneFaces[num8] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num8].position, flag))
						{
							flag2 = false;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					faceArea7.min.y = num6;
					num6--;
				}
				int num9 = y + 1;
				for (;;)
				{
					bool flag3 = true;
					for (int num10 = faceArea7.min.z; num10 <= faceArea7.max.z; num10++)
					{
						int num11 = this.voxelBase.voxelData.VoxelTableContains(x, num9, num10);
						if (num11 < 0 || this.materialIndexTable[x][num9][num10] != num || (this.voxelDoneFaces[num11] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num11].position, flag))
						{
							flag3 = false;
							break;
						}
					}
					if (!flag3)
					{
						break;
					}
					faceArea7.max.y = num9;
					num9++;
				}
				return faceArea7;
			};
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func2 = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int x = voxels[baseIndex].x;
				int y = voxels[baseIndex].y;
				int z = voxels[baseIndex].z;
				int palette = voxels[baseIndex].palette;
				int num = this.materialIndexTable[x][y][z];
				VoxelData.FaceArea faceArea7 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = palette,
					material = num
				};
				int num2 = z - 1;
				for (;;)
				{
					int num3 = this.voxelBase.voxelData.VoxelTableContains(x, y, num2);
					if (num3 < 0 || this.materialIndexTable[x][y][num2] != num || (this.voxelDoneFaces[num3] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num3].position, flag))
					{
						break;
					}
					faceArea7.min.z = num2;
					num2--;
				}
				int num4 = z + 1;
				for (;;)
				{
					int num5 = this.voxelBase.voxelData.VoxelTableContains(x, y, num4);
					if (num5 < 0 || this.materialIndexTable[x][y][num4] != num || (this.voxelDoneFaces[num5] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num5].position, flag))
					{
						break;
					}
					faceArea7.max.z = num4;
					num4++;
				}
				int num6 = x - 1;
				for (;;)
				{
					bool flag2 = true;
					for (int num7 = faceArea7.min.z; num7 <= faceArea7.max.z; num7++)
					{
						int num8 = this.voxelBase.voxelData.VoxelTableContains(num6, y, num7);
						if (num8 < 0 || this.materialIndexTable[num6][y][num7] != num || (this.voxelDoneFaces[num8] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num8].position, flag))
						{
							flag2 = false;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					faceArea7.min.x = num6;
					num6--;
				}
				int num9 = x + 1;
				for (;;)
				{
					bool flag3 = true;
					for (int num10 = faceArea7.min.z; num10 <= faceArea7.max.z; num10++)
					{
						int num11 = this.voxelBase.voxelData.VoxelTableContains(num9, y, num10);
						if (num11 < 0 || this.materialIndexTable[num9][y][num10] != num || (this.voxelDoneFaces[num11] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num11].position, flag))
						{
							flag3 = false;
							break;
						}
					}
					if (!flag3)
					{
						break;
					}
					faceArea7.max.x = num9;
					num9++;
				}
				return faceArea7;
			};
			Func<int, VoxelBase.Face, VoxelData.FaceArea> func3 = delegate(int baseIndex, VoxelBase.Face flag)
			{
				int x = voxels[baseIndex].x;
				int y = voxels[baseIndex].y;
				int z = voxels[baseIndex].z;
				int palette = voxels[baseIndex].palette;
				int num = this.materialIndexTable[x][y][z];
				VoxelData.FaceArea faceArea7 = new VoxelData.FaceArea
				{
					min = new IntVector3(x, y, z),
					max = new IntVector3(x, y, z),
					palette = palette,
					material = num
				};
				int num2 = y - 1;
				for (;;)
				{
					int num3 = this.voxelBase.voxelData.VoxelTableContains(x, num2, z);
					if (num3 < 0 || this.materialIndexTable[x][num2][z] != num || (this.voxelDoneFaces[num3] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num3].position, flag))
					{
						break;
					}
					faceArea7.min.y = num2;
					num2--;
				}
				int num4 = y + 1;
				for (;;)
				{
					int num5 = this.voxelBase.voxelData.VoxelTableContains(x, num4, z);
					if (num5 < 0 || this.materialIndexTable[x][num4][z] != num || (this.voxelDoneFaces[num5] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num5].position, flag))
					{
						break;
					}
					faceArea7.max.y = num4;
					num4++;
				}
				int num6 = x - 1;
				for (;;)
				{
					bool flag2 = true;
					for (int num7 = faceArea7.min.y; num7 <= faceArea7.max.y; num7++)
					{
						int num8 = this.voxelBase.voxelData.VoxelTableContains(num6, num7, z);
						if (num8 < 0 || this.materialIndexTable[num6][num7][z] != num || (this.voxelDoneFaces[num8] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num8].position, flag))
						{
							flag2 = false;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					faceArea7.min.x = num6;
					num6--;
				}
				int num9 = x + 1;
				for (;;)
				{
					bool flag3 = true;
					for (int num10 = faceArea7.min.y; num10 <= faceArea7.max.y; num10++)
					{
						int num11 = this.voxelBase.voxelData.VoxelTableContains(num9, num10, z);
						if (num11 < 0 || this.materialIndexTable[num9][num10][z] != num || (this.voxelDoneFaces[num11] & flag) != (VoxelBase.Face)0 || !this.IsCombineVoxelFace(voxels[baseIndex].position, this.voxelBase.voxelData.voxels[num11].position, flag))
						{
							flag3 = false;
							break;
						}
					}
					if (!flag3)
					{
						break;
					}
					faceArea7.max.x = num9;
					num9++;
				}
				return faceArea7;
			};
			VoxelData.FaceAreaTable faceAreaTable = new VoxelData.FaceAreaTable();
			int[] voxelIndexTable = this.GetVoxelIndexTable(voxels);
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.forward) != (VoxelBase.Face)0)
			{
				for (int i = 0; i < voxels.Length; i++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[i]] & VoxelBase.Face.forward) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea = func3(i, VoxelBase.Face.forward);
						this.SetDoneFacesFlag(faceArea, VoxelBase.Face.forward);
						faceAreaTable.forward.Add(faceArea);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.up) != (VoxelBase.Face)0)
			{
				for (int j = 0; j < voxels.Length; j++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[j]] & VoxelBase.Face.up) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea2 = func2(j, VoxelBase.Face.up);
						this.SetDoneFacesFlag(faceArea2, VoxelBase.Face.up);
						faceAreaTable.up.Add(faceArea2);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.right) != (VoxelBase.Face)0)
			{
				for (int k = 0; k < voxels.Length; k++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[k]] & VoxelBase.Face.right) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea3 = func(k, VoxelBase.Face.right);
						this.SetDoneFacesFlag(faceArea3, VoxelBase.Face.right);
						faceAreaTable.right.Add(faceArea3);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.left) != (VoxelBase.Face)0)
			{
				for (int l = 0; l < voxels.Length; l++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[l]] & VoxelBase.Face.left) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea4 = func(l, VoxelBase.Face.left);
						this.SetDoneFacesFlag(faceArea4, VoxelBase.Face.left);
						faceAreaTable.left.Add(faceArea4);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.down) != (VoxelBase.Face)0)
			{
				for (int m = 0; m < voxels.Length; m++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[m]] & VoxelBase.Face.down) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea5 = func2(m, VoxelBase.Face.down);
						this.SetDoneFacesFlag(faceArea5, VoxelBase.Face.down);
						faceAreaTable.down.Add(faceArea5);
					}
				}
			}
			if ((this.voxelBase.enableFaceFlags & VoxelBase.Face.back) != (VoxelBase.Face)0)
			{
				for (int n = 0; n < voxels.Length; n++)
				{
					if ((this.voxelDoneFaces[voxelIndexTable[n]] & VoxelBase.Face.back) == (VoxelBase.Face)0)
					{
						VoxelData.FaceArea faceArea6 = func3(n, VoxelBase.Face.back);
						this.SetDoneFacesFlag(faceArea6, VoxelBase.Face.back);
						faceAreaTable.back.Add(faceArea6);
					}
				}
			}
			return faceAreaTable;
		}

		protected virtual bool isHaveBoneWeight
		{
			get
			{
				return false;
			}
		}

		protected virtual Matrix4x4[] GetBindposes()
		{
			return null;
		}

		protected virtual BoneWeight GetBoneWeight(ref VoxelData.Voxel voxel, VoxelBase.VoxelVertexIndex index)
		{
			return default(BoneWeight);
		}

		public Vector3 GetVoxelRatePosition(IntVector3 pos, Vector3 rate)
		{
			Vector3 b = new Vector3((float)pos.x, (float)pos.y, (float)pos.z);
			return Vector3.Scale(this.voxelBase.localOffset + this.voxelBase.importOffset + rate + b, this.voxelBase.importScale);
		}

		public Vector3 GetVoxelCenterPosition(IntVector3 pos)
		{
			return this.GetVoxelRatePosition(pos, new Vector3(0.5f, 0.5f, 0.5f));
		}

		public VoxelBase.VoxelVertices GetVoxelVertices(IntVector3 pos)
		{
			Vector3 voxelRatePosition = this.GetVoxelRatePosition(pos, Vector3.zero);
			Vector3 voxelRatePosition2 = this.GetVoxelRatePosition(pos, Vector3.one);
			return new VoxelBase.VoxelVertices
			{
				vertexXYZ = new Vector3(voxelRatePosition2.x, voxelRatePosition2.y, voxelRatePosition2.z),
				vertex_XYZ = new Vector3(voxelRatePosition.x, voxelRatePosition2.y, voxelRatePosition2.z),
				vertexX_YZ = new Vector3(voxelRatePosition2.x, voxelRatePosition.y, voxelRatePosition2.z),
				vertexXY_Z = new Vector3(voxelRatePosition2.x, voxelRatePosition2.y, voxelRatePosition.z),
				vertex_X_YZ = new Vector3(voxelRatePosition.x, voxelRatePosition.y, voxelRatePosition2.z),
				vertex_XY_Z = new Vector3(voxelRatePosition.x, voxelRatePosition2.y, voxelRatePosition.z),
				vertexX_Y_Z = new Vector3(voxelRatePosition2.x, voxelRatePosition.y, voxelRatePosition.z),
				vertex_X_Y_Z = new Vector3(voxelRatePosition.x, voxelRatePosition.y, voxelRatePosition.z)
			};
		}

		public Bounds GetVoxelBounds(IntVector3 pos)
		{
			Bounds result = default(Bounds);
			result.SetMinMax(this.GetVoxelRatePosition(pos, Vector3.zero), this.GetVoxelRatePosition(pos, Vector3.one));
			return result;
		}

		public BoundingSphere GetVoxelBoundingSphere(IntVector3 pos)
		{
			Vector3 voxelRatePosition = this.GetVoxelRatePosition(pos, Vector3.zero);
			Vector3 voxelRatePosition2 = this.GetVoxelRatePosition(pos, Vector3.one);
			return new BoundingSphere(Vector3.Lerp(voxelRatePosition, voxelRatePosition2, 0.5f), (voxelRatePosition2 - voxelRatePosition).magnitude * 0.5f);
		}

		public Vector3 GetVoxelPosition(Vector3 localPosition)
		{
			return new Vector3(localPosition.x / this.voxelBase.importScale.x, localPosition.y / this.voxelBase.importScale.y, localPosition.z / this.voxelBase.importScale.z) - (this.voxelBase.localOffset + this.voxelBase.importOffset);
		}

		public void AutoSetSelectedWireframeHidden()
		{
			this.SetSelectedWireframeHidden(this.voxelBase.edit_configureMode > VoxelBase.Edit_configureMode.None);
		}

		public virtual void SetSelectedWireframeHidden(bool hidden)
		{
			if (this.voxelBase != null)
			{
				this.voxelBase.GetComponent<Renderer>() != null;
			}
		}

		protected virtual void RefreshCheckerCreate()
		{
			this.voxelBase.refreshChecker = new VoxelBase.RefreshChecker(this.voxelBase);
		}

		public void RefreshCheckerClear()
		{
			this.voxelBase.refreshChecker = null;
		}

		public void RefreshCheckerSave()
		{
			if (this.voxelBase.refreshChecker == null)
			{
				this.RefreshCheckerCreate();
			}
			this.voxelBase.refreshChecker.Save();
		}

		public bool RefreshCheckerCheck()
		{
			return this.voxelBase.refreshChecker != null && this.voxelBase.refreshChecker.Check();
		}

		protected int[][][] materialIndexTable;

		protected VoxelBase.Face[] voxelDoneFaces;

		protected class TextureBoundArea
		{
			public TextureBoundArea()
			{
				this.textureIndex = -1;
				this.min = new IntVector2(int.MaxValue, int.MaxValue);
				this.max = new IntVector2(int.MinValue, int.MinValue);
			}

			public void Set(IntVector2 pos)
			{
				this.min = IntVector2.Min(this.min, pos);
				this.max = IntVector2.Max(this.max, pos);
			}

			public IntVector2 Size
			{
				get
				{
					return this.max - this.min + IntVector2.one;
				}
			}

			public int textureIndex;

			public IntVector2 min;

			public IntVector2 max;
		}

		protected class AtlasRectTable
		{
			public List<MyVoxelBaseCore.TextureBoundArea> forward = new List<MyVoxelBaseCore.TextureBoundArea>();

			public List<MyVoxelBaseCore.TextureBoundArea> up = new List<MyVoxelBaseCore.TextureBoundArea>();

			public List<MyVoxelBaseCore.TextureBoundArea> right = new List<MyVoxelBaseCore.TextureBoundArea>();

			public List<MyVoxelBaseCore.TextureBoundArea> left = new List<MyVoxelBaseCore.TextureBoundArea>();

			public List<MyVoxelBaseCore.TextureBoundArea> down = new List<MyVoxelBaseCore.TextureBoundArea>();

			public List<MyVoxelBaseCore.TextureBoundArea> back = new List<MyVoxelBaseCore.TextureBoundArea>();
		}

		protected struct ChunkArea
		{
			public Vector3 minf
			{
				get
				{
					return new Vector3((float)this.min.x, (float)this.min.y, (float)this.min.z);
				}
			}

			public Vector3 maxf
			{
				get
				{
					return new Vector3((float)this.max.x, (float)this.max.y, (float)this.max.z);
				}
			}

			public Vector3 centerf
			{
				get
				{
					return Vector3.Lerp(this.minf, this.maxf, 0.5f);
				}
			}

			public IntVector3 min;

			public IntVector3 max;
		}

		public struct Edit_VerticesInfo
		{
			public IntVector3 position;

			public VoxelBase.VoxelVertexIndex vertexIndex;
		}
	}
}
