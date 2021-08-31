using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelImporter
{
	[DisallowMultipleComponent]
	public abstract class VoxelBase : MonoBehaviour
	{
		public virtual bool EditorInitialize()
		{
			return false;
		}

		public virtual void SaveEditTmpData()
		{
		}

		public Vector3 importScale = Vector3.one;

		public string voxelFilePath;

		public string voxelFileGUID;

		public VoxelBase.FileType fileType;

		public VoxelBase.ImportMode importMode = VoxelBase.ImportMode.LowPoly;

		public VoxelBase.ImportFlag importFlags;

		public Vector3 importOffset;

		public Vector3 localOffset;

		[NonSerialized]
		public VoxelData voxelData;

		public const VoxelBase.Face FaceAllFlags = (VoxelBase.Face)(-1);

		public VoxelBase.Face enableFaceFlags = (VoxelBase.Face)(-1);

		public bool generateLightmapUVs;

		public bool generateMipMaps = true;

		public List<MaterialData> materialData;

		public List<int> materialIndexes;

		public bool edit_importFoldout = true;

		public bool edit_objectFoldout = true;

		[NonSerialized]
		public bool edit_afterRefresh;

		public VoxelBase.Edit_configureMode edit_configureMode;

		public int edit_configureMaterialIndex;

		public VoxelBase.Edit_MaterialMode edit_materialMode;

		public VoxelBase.Edit_MaterialTypeMode edit_materialTypeMode;

		public Mesh[] edit_enableMesh;

		[NonSerialized]
		public VoxelBase.RefreshChecker refreshChecker;

		public enum FileType
		{
			vox,
			qb,
			png
		}

		public enum ImportMode
		{
			LowTexture,
			LowPoly
		}

		[Flags]
		public enum ImportFlag
		{
			FlipX = 1,
			FlipY = 2,
			FlipZ = 4
		}

		[Flags]
		public enum Face
		{
			forward = 1,
			up = 2,
			right = 4,
			left = 8,
			down = 16,
			back = 32
		}

		public enum VoxelVertexIndex
		{
			XYZ,
			_XYZ,
			X_YZ,
			XY_Z,
			_X_YZ,
			_XY_Z,
			X_Y_Z,
			_X_Y_Z,
			Total
		}

		[Flags]
		public enum VoxelVertexFlags
		{
			XYZ = 1,
			_XYZ = 2,
			X_YZ = 4,
			XY_Z = 8,
			_X_YZ = 16,
			_XY_Z = 32,
			X_Y_Z = 64,
			_X_Y_Z = 128
		}

		public struct VoxelVertices
		{
			public void SetVertex(VoxelBase.VoxelVertexIndex index, Vector3 vertex)
			{
				switch (index)
				{
				case VoxelBase.VoxelVertexIndex.XYZ:
					this.vertexXYZ = vertex;
					return;
				case VoxelBase.VoxelVertexIndex._XYZ:
					this.vertex_XYZ = vertex;
					return;
				case VoxelBase.VoxelVertexIndex.X_YZ:
					this.vertexX_YZ = vertex;
					return;
				case VoxelBase.VoxelVertexIndex.XY_Z:
					this.vertexXY_Z = vertex;
					return;
				case VoxelBase.VoxelVertexIndex._X_YZ:
					this.vertex_X_YZ = vertex;
					return;
				case VoxelBase.VoxelVertexIndex._XY_Z:
					this.vertex_XY_Z = vertex;
					return;
				case VoxelBase.VoxelVertexIndex.X_Y_Z:
					this.vertexX_Y_Z = vertex;
					return;
				case VoxelBase.VoxelVertexIndex._X_Y_Z:
					this.vertex_X_Y_Z = vertex;
					return;
				default:
					return;
				}
			}

			public Vector3 GetVertex(VoxelBase.VoxelVertexIndex index)
			{
				switch (index)
				{
				case VoxelBase.VoxelVertexIndex.XYZ:
					return this.vertexXYZ;
				case VoxelBase.VoxelVertexIndex._XYZ:
					return this.vertex_XYZ;
				case VoxelBase.VoxelVertexIndex.X_YZ:
					return this.vertexX_YZ;
				case VoxelBase.VoxelVertexIndex.XY_Z:
					return this.vertexXY_Z;
				case VoxelBase.VoxelVertexIndex._X_YZ:
					return this.vertex_X_YZ;
				case VoxelBase.VoxelVertexIndex._XY_Z:
					return this.vertex_XY_Z;
				case VoxelBase.VoxelVertexIndex.X_Y_Z:
					return this.vertexX_Y_Z;
				case VoxelBase.VoxelVertexIndex._X_Y_Z:
					return this.vertex_X_Y_Z;
				default:
					return Vector3.zero;
				}
			}

			public Vector3 vertexXYZ;

			public Vector3 vertex_XYZ;

			public Vector3 vertexX_YZ;

			public Vector3 vertexXY_Z;

			public Vector3 vertex_X_YZ;

			public Vector3 vertex_XY_Z;

			public Vector3 vertexX_Y_Z;

			public Vector3 vertex_X_Y_Z;
		}

		public enum Edit_configureMode
		{
			None,
			Material
		}

		public enum Edit_MaterialMode
		{
			Add,
			Remove
		}

		public enum Edit_MaterialTypeMode
		{
			Voxel,
			Fill,
			Rect
		}

		public class RefreshChecker
		{
			public RefreshChecker(VoxelBase voxelBase)
			{
				this.controller = voxelBase;
			}

			public virtual void Save()
			{
				this.voxelFilePath = this.controller.voxelFilePath;
				this.voxelFileGUID = this.controller.voxelFileGUID;
				this.importMode = this.controller.importMode;
				this.importFlags = this.controller.importFlags;
				this.importScale = this.controller.importScale;
				this.importOffset = this.controller.importOffset;
				this.enableFaceFlags = this.controller.enableFaceFlags;
				this.generateLightmapUVs = this.controller.generateLightmapUVs;
				this.generateMipMaps = this.controller.generateMipMaps;
				if (this.controller.materialData != null)
				{
					this.materialData = new MaterialData[this.controller.materialData.Count];
					for (int i = 0; i < this.controller.materialData.Count; i++)
					{
						this.materialData[i] = this.controller.materialData[i].Clone();
					}
				}
				else
				{
					this.materialData = null;
				}
				this.materialIndexes = ((this.controller.materialIndexes != null) ? this.controller.materialIndexes.ToArray() : null);
			}

			public virtual bool Check()
			{
				if (this.voxelFilePath != this.controller.voxelFilePath || this.voxelFileGUID != this.controller.voxelFileGUID || this.importMode != this.controller.importMode || this.importFlags != this.controller.importFlags || this.importScale != this.controller.importScale || this.importOffset != this.controller.importOffset || this.enableFaceFlags != this.controller.enableFaceFlags || this.generateLightmapUVs != this.controller.generateLightmapUVs || this.generateMipMaps != this.controller.generateMipMaps)
				{
					return true;
				}
				if (this.materialData == null || this.controller.materialData == null)
				{
					return (this.materialData != null && this.controller.materialData == null) || (this.materialData == null && this.controller.materialData != null);
				}
				if (this.materialData.Length != this.controller.materialData.Count)
				{
					return true;
				}
				for (int i = 0; i < this.materialData.Length; i++)
				{
					if (!this.materialData[i].IsEqual(this.controller.materialData[i]))
					{
						return true;
					}
				}
				if (this.materialIndexes == null || this.controller.materialIndexes == null)
				{
					return (this.materialIndexes != null && this.controller.materialIndexes == null) || (this.materialIndexes == null && this.controller.materialIndexes != null);
				}
				if (this.materialIndexes.Length != this.controller.materialIndexes.Count)
				{
					return true;
				}
				for (int j = 0; j < this.materialIndexes.Length; j++)
				{
					if (this.materialIndexes[j] != this.controller.materialIndexes[j])
					{
						return true;
					}
				}
				return false;
			}

			public VoxelBase controller;

			public string voxelFilePath;

			public string voxelFileGUID;

			public VoxelBase.ImportMode importMode;

			public VoxelBase.ImportFlag importFlags;

			public Vector3 importScale;

			public Vector3 importOffset;

			public VoxelBase.Face enableFaceFlags;

			public bool generateLightmapUVs;

			public bool generateMipMaps;

			public MaterialData[] materialData;

			public int[] materialIndexes;
		}
	}
}
