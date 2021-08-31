using System;
using UnityEngine;

public class DemoShooting : MonoBehaviour
{
	private void Start()
	{
		if (Screen.dpi < 1f)
		{
			this.windowDpi = 1f;
		}
		if (Screen.dpi < 200f)
		{
			this.windowDpi = 1f;
		}
		else
		{
			this.windowDpi = Screen.dpi / 200f;
		}
		this.Counter(0);
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Prefabs[this.Prefab], this.FirePoint.transform.position, this.FirePoint.transform.rotation);
		}
		if (Input.GetMouseButton(1) && this.fireCountdown <= 0f)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Prefabs[this.Prefab], this.FirePoint.transform.position, this.FirePoint.transform.rotation);
			this.fireCountdown = 0f;
			this.fireCountdown += this.hSliderValue;
		}
		this.fireCountdown -= Time.deltaTime;
		if ((Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0f) && this.buttonSaver >= 0.4f)
		{
			this.buttonSaver = 0f;
			this.Counter(-1);
		}
		if ((Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0f) && this.buttonSaver >= 0.4f)
		{
			this.buttonSaver = 0f;
			this.Counter(1);
		}
		this.buttonSaver += Time.deltaTime;
		if (this.Cam != null)
		{
			Vector3 mousePosition = Input.mousePosition;
			this.RayMouse = this.Cam.ScreenPointToRay(mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(this.RayMouse.origin, this.RayMouse.direction, out raycastHit, this.MaxLength))
			{
				this.RotateToMouseDirection(base.gameObject, raycastHit.point);
				return;
			}
		}
		else
		{
			Debug.Log("No camera");
		}
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(10f * this.windowDpi, 5f * this.windowDpi, 400f * this.windowDpi, 20f * this.windowDpi), "Use left mouse button to single shoot!");
		GUI.Label(new Rect(10f * this.windowDpi, 25f * this.windowDpi, 400f * this.windowDpi, 20f * this.windowDpi), "Use and hold the right mouse button for quick shooting!");
		GUI.Label(new Rect(10f * this.windowDpi, 45f * this.windowDpi, 400f * this.windowDpi, 20f * this.windowDpi), "Fire rate:");
		this.hSliderValue = GUI.HorizontalSlider(new Rect(70f * this.windowDpi, 50f * this.windowDpi, 100f * this.windowDpi, 20f * this.windowDpi), this.hSliderValue, 0f, 1f);
		GUI.Label(new Rect(10f * this.windowDpi, 65f * this.windowDpi, 400f * this.windowDpi, 20f * this.windowDpi), "Use the keyboard buttons A/<- and D/-> to change projectiles!");
	}

	private void Counter(int count)
	{
		this.Prefab += count;
		if (this.Prefab > this.Prefabs.Length - 1)
		{
			this.Prefab = 0;
			return;
		}
		if (this.Prefab < 0)
		{
			this.Prefab = this.Prefabs.Length - 1;
		}
	}

	private void RotateToMouseDirection(GameObject obj, Vector3 destination)
	{
		this.direction = destination - obj.transform.position;
		this.rotation = Quaternion.LookRotation(this.direction);
		obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, this.rotation, 1f);
	}

	public GameObject FirePoint;

	public Camera Cam;

	public float MaxLength;

	public GameObject[] Prefabs;

	private Ray RayMouse;

	private Vector3 direction;

	private Quaternion rotation;

	[Header("GUI")]
	private float windowDpi;

	private int Prefab;

	private GameObject Instance;

	private float hSliderValue = 0.1f;

	private float fireCountdown;

	private float buttonSaver;
}
