using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private void Update()
	{
		if (this.noBoundarySpecialToy.IsStart)
		{
			base.GetComponent<Rigidbody>().useGravity = true;
		}
	}

	private void OnMouseDrag()
	{
		if (!this.noBoundarySpecialToy.IsStart || this.noBoundarySpecialToy.IsEnd)
		{
			return;
		}
		base.GetComponent<Rigidbody>().useGravity = false;
		this.startPos = base.transform.position;
		this.lastPos = CameraUtils.MyScreenPointToWorldPoint(Input.mousePosition, base.transform);
		this.endPos = CameraUtils.MyScreenPointToWorldPoint(Input.mousePosition, base.transform);
		this.offset = (this.endPos - this.lastPos + 2f * this.offset) / 3f;
		this.offset.y = 0f;
		base.transform.position = new Vector3(this.endPos.x, base.transform.position.y, this.endPos.z);
		this.lastPos = this.endPos;
	}

	private void OnMouseUp()
	{
		base.GetComponent<Rigidbody>().useGravity = true;
	}

	public NoBoundarySpecialToy noBoundarySpecialToy;

	private Vector3 startPos;

	private Vector3 lastPos;

	private Vector3 endPos;

	private Vector3 offset;
}
