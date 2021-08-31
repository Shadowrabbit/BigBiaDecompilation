using System;
using UnityEngine;

[Serializable]
public struct SerializableVector3
{
	public SerializableVector3(float rX, float rY, float rZ)
	{
		this.x = rX;
		this.y = rY;
		this.z = rZ;
	}

	public override string ToString()
	{
		return string.Format("[{0}, {1}, {2}]", this.x, this.y, this.z);
	}

	public static implicit operator Vector3(SerializableVector3 rValue)
	{
		return new Vector3(rValue.x, rValue.y, rValue.z);
	}

	public static implicit operator SerializableVector3(Vector3 rValue)
	{
		return new SerializableVector3(rValue.x, rValue.y, rValue.z);
	}

	public float x;

	public float y;

	public float z;
}
