using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HUDMesh : MonoBehaviour
{
	private void Awake()
	{
		this.MeshFilter = base.GetComponent<MeshFilter>();
		this.MeshRenderer = base.GetComponent<MeshRenderer>();
		if (HUDMesh.material == null)
		{
			HUDMesh.material = new Material(this.shader);
		}
		this.MeshRenderer.sharedMaterial = this.materialTest;
		this.Transform = base.transform;
		this.DrawMesh();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void DrawMesh()
	{
		Mesh mesh = new Mesh();
		mesh.name = "BackGround";
		this.MeshFilter.mesh = mesh;
		this.vertexs = new Vector3[(this.width + 1) * (this.height + 1)];
		Vector3 localScale = base.transform.localScale;
		Vector3 b = new Vector2((float)(-(float)this.width) / 2f, (float)(-(float)this.height) / 2f);
		int i = 0;
		int num = 0;
		while (i <= this.width)
		{
			int j = 0;
			while (j <= this.height)
			{
				this.vertexs[num] = new Vector3((float)i * this.unitWidth, (float)j * this.unitWidth, 0f) + b;
				j++;
				num++;
			}
			i++;
		}
		mesh.vertices = this.vertexs;
		int[] array = new int[this.width * this.height * 6];
		int k = 0;
		int num2 = 0;
		int num3 = 0;
		while (k < this.width)
		{
			int l = 0;
			while (l < this.height)
			{
				array[num3] = num2;
				array[num3 + 2] = (array[num3 + 3] = num2 + this.width + 1);
				array[num3 + 1] = (array[num3 + 4] = num2 + 1);
				array[num3 + 5] = num2 + this.width + 2;
				l++;
				num3 += 6;
				num2++;
			}
			k++;
		}
		mesh.triangles = array;
		mesh.RecalculateNormals();
	}

	private void OnDrawGizmos()
	{
		if (this.vertexs == null)
		{
			return;
		}
		for (int i = 0; i < this.vertexs.Length; i++)
		{
			Gizmos.DrawSphere(this.vertexs[i], 0.1f);
		}
	}

	public int width = 1;

	public int height = 1;

	public float unitWidth = 1f;

	public Shader shader;

	public Material materialTest;

	private static Material material;

	private MeshFilter MeshFilter;

	private MeshRenderer MeshRenderer;

	private Vector3[] vertexs;

	private Transform Transform;
}
