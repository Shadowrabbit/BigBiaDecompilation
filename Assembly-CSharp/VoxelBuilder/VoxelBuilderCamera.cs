using System;
using UnityEngine;

namespace VoxelBuilder
{
	public class VoxelBuilderCamera : MonoBehaviour
	{
		private void Start()
		{
			this.rotation = Vector3.zero;
			this.selfRotateAngle_x = base.transform.eulerAngles.x;
			this.selfRotateAngle_y = base.transform.eulerAngles.y;
		}

		private void Update()
		{
			if (BuilderHelper.IsHitUI())
			{
				return;
			}
			if (Input.GetMouseButton(2))
			{
				base.transform.position -= base.transform.right * Input.GetAxis("Mouse X") * this.moveHorizontalSensitive;
				base.transform.position -= base.transform.up * Input.GetAxis("Mouse Y") * this.moveHorizontalSensitive;
			}
			else if (Input.GetMouseButton(1))
			{
				float axis = Input.GetAxis("Mouse X");
				float num = -Input.GetAxis("Mouse Y");
				float num2 = this.selfRotateAngle_x;
				this.selfRotateAngle_x += num * this.focusRotateSensitive;
				this.selfRotateAngle_x = this.ClampAngle(this.selfRotateAngle_x, -90f, 90f);
				float angle = this.selfRotateAngle_x - num2;
				this.MyRotateAround(Vector3.zero, Vector3.up, axis * this.focusRotateSensitive);
				this.MyRotateAround(Vector3.zero, base.transform.right, angle);
			}
			else if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) & Input.GetMouseButton(1))
			{
				base.transform.position += base.transform.forward * Input.GetAxis("Mouse X");
				base.transform.position -= base.transform.forward * Input.GetAxis("Mouse Y");
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				Vector3 b = new Vector3(0f, 0f, base.transform.forward.z);
				base.transform.position += b;
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				Vector3 b2 = new Vector3(0f, 0f, base.transform.forward.z);
				base.transform.position -= b2;
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				Vector3 b3 = new Vector3(base.transform.right.x, 0f, 0f);
				base.transform.position -= b3;
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				Vector3 b4 = new Vector3(base.transform.right.x, 0f, 0f);
				base.transform.position += b4;
			}
			float axis2 = Input.GetAxis("Mouse ScrollWheel");
			base.transform.position += base.transform.forward * axis2 * this.camScrollSensitive;
		}

		private float ClampAngle(float angle, float min, float max)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
			return Mathf.Clamp(angle, min, max);
		}

		private void OnPostRender()
		{
			if (!VoxelBuilderCamera.isShowLines || VoxelBuilderMgr.Instance == null)
			{
				return;
			}
			if (VoxelBuilderMgr.IsReadMode)
			{
				return;
			}
			Vector3Int editLimit = VoxelBuilderMgr.Instance.EditLimit;
			float num = (float)((editLimit.x - 1) / 2) + 0.5f;
			float num2 = (float)((editLimit.y - 1) / 2) + 0.5f;
			float num3 = (float)((editLimit.z - 1) / 2) + 0.5f;
			this.lineMat.SetPass(0);
			GL.PushMatrix();
			GL.Begin(1);
			GL.Vertex(new Vector3(-num, num2, -num3));
			GL.Vertex(new Vector3(-num, num2, num3));
			GL.Vertex(new Vector3(-num, num2, num3));
			GL.Vertex(new Vector3(num, num2, num3));
			GL.Vertex(new Vector3(num, num2, num3));
			GL.Vertex(new Vector3(num, num2, -num3));
			GL.Vertex(new Vector3(num, num2, -num3));
			GL.Vertex(new Vector3(-num, num2, -num3));
			GL.Vertex(new Vector3(-num, num2, -num3));
			GL.Vertex(new Vector3(-num, -num2, -num3));
			GL.Vertex(new Vector3(-num, num2, num3));
			GL.Vertex(new Vector3(-num, -num2, num3));
			GL.Vertex(new Vector3(num, num2, num3));
			GL.Vertex(new Vector3(num, -num2, num3));
			GL.Vertex(new Vector3(num, num2, -num3));
			GL.Vertex(new Vector3(num, -num2, -num3));
			GL.Vertex(new Vector3(-num, -num2, -num3));
			GL.Vertex(new Vector3(-num, -num2, num3));
			GL.Vertex(new Vector3(-num, -num2, num3));
			GL.Vertex(new Vector3(num, -num2, num3));
			GL.Vertex(new Vector3(num, -num2, num3));
			GL.Vertex(new Vector3(num, -num2, -num3));
			GL.Vertex(new Vector3(num, -num2, -num3));
			GL.Vertex(new Vector3(-num, -num2, -num3));
			GL.End();
			GL.PopMatrix();
		}

		private void MyRotateAround(Vector3 center, Vector3 axis, float angle)
		{
			Vector3 position = base.transform.position;
			Quaternion lhs = Quaternion.AngleAxis(angle, axis);
			Vector3 vector = position - center;
			vector = lhs * vector;
			base.transform.position = center + vector;
			Quaternion rhs = base.transform.rotation;
			base.transform.rotation = lhs * rhs;
		}

		public static bool isShowLines = true;

		public Material lineMat;

		public float moveVerticalSensitive = 1f;

		public float moveHorizontalSensitive = 5f;

		public float rotateSensitive = 2f;

		public float focusRotateSensitive = 5f;

		public float camScrollSensitive = 20f;

		private bool IsCastRay;

		private Vector3 rotation;

		private float selfRotateAngle_x;

		private float selfRotateAngle_y;

		private Vector3 selfVector;
	}
}
