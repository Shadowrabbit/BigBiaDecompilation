using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingMainPart : MonoBehaviour
{
	private void Start()
	{
		this.isStart = false;
		this.isEnd = false;
		this.moveSpeed = 0.02f;
		this.enemyMoveSpeed = 0.03f;
		this.r = 3f;
		this.bias = 0.1f;
		this.mouse = false;
		this.enemies = new List<GameObject>();
		this.directions = new List<Vector3>();
	}

	private void Update()
	{
		if (this.isStart && !this.isEnd)
		{
			this.DuringTime = Time.time - this.statTime;
			if (this.enemies.Count > 0)
			{
				for (int i = 0; i < this.enemies.Count; i++)
				{
					this.enemies[i].transform.localPosition += this.directions[i].normalized * this.enemyMoveSpeed;
					if (Mathf.Abs(this.Player.transform.localPosition.x - this.enemies[i].transform.localPosition.x) + Mathf.Abs(this.Player.transform.localPosition.z - this.enemies[i].transform.localPosition.z) < 0.1f)
					{
						this.isEnd = true;
						if (this.DuringTime > GlobalController.Instance.GlobalData.HighestPointsOfDodging)
						{
							GlobalController.Instance.GlobalData.HighestPointsOfDodging = this.DuringTime;
						}
					}
					if (Mathf.Abs(this.enemies[i].transform.localPosition.x) + Mathf.Abs(this.enemies[i].transform.localPosition.z) > 1.5f * this.r)
					{
						float f = UnityEngine.Random.Range(0f, 6.28f);
						this.enemies[i].transform.localPosition = new Vector3(this.r * Mathf.Cos(f), 0f, this.r * Mathf.Sin(f));
						float x = UnityEngine.Random.Range(-this.bias, this.bias);
						float z = UnityEngine.Random.Range(-this.bias, this.bias);
						this.directions.Add(this.Player.transform.localPosition - this.enemies[i].transform.localPosition + new Vector3(x, 0f, z));
					}
				}
			}
		}
	}

	private void FixedUpdate()
	{
		if (this.isStart && !this.isEnd)
		{
			if (Input.GetKey(KeyCode.DownArrow))
			{
				this.mouse = false;
				this.Player.transform.localPosition += Vector3.back * this.moveSpeed;
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				this.mouse = false;
				this.Player.transform.localPosition += Vector3.forward * this.moveSpeed;
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				this.mouse = false;
				this.Player.transform.localPosition += Vector3.left * this.moveSpeed;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				this.mouse = false;
				this.Player.transform.localPosition += Vector3.right * this.moveSpeed;
			}
			if (this.mouse)
			{
				Vector3 vector = Camera.main.WorldToScreenPoint(this.Player.transform.position);
				Vector3 vector2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, vector.z) - vector;
				if (vector2.magnitude > 5f)
				{
					this.Player.transform.localPosition += new Vector3(vector2.normalized.x * this.moveSpeed, 0f, vector2.normalized.y * this.moveSpeed);
				}
			}
			else if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0.2f || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.2f)
			{
				this.mouse = true;
			}
			if (this.Player.transform.localPosition.x <= -2.7f)
			{
				this.Player.transform.localPosition = new Vector3(-2.7f, this.Player.transform.localPosition.y, this.Player.transform.localPosition.z);
			}
			if (this.Player.transform.localPosition.x >= 2.7f)
			{
				this.Player.transform.localPosition = new Vector3(2.7f, this.Player.transform.localPosition.y, this.Player.transform.localPosition.z);
			}
			if (this.Player.transform.localPosition.z <= -1.3f)
			{
				this.Player.transform.localPosition = new Vector3(this.Player.transform.localPosition.x, this.Player.transform.localPosition.y, -1.3f);
			}
			if (this.Player.transform.localPosition.z >= 1.3f)
			{
				this.Player.transform.localPosition = new Vector3(this.Player.transform.localPosition.x, this.Player.transform.localPosition.y, 1.3f);
			}
		}
	}

	public void OnStartButton()
	{
		this.isStart = true;
		this.Player.SetActive(true);
		this.statTime = Time.time;
		base.StartCoroutine(this.generateEnemies());
	}

	private IEnumerator generateEnemies()
	{
		int num;
		for (int i = 0; i < 5; i = num + 1)
		{
			for (int j = 0; j < 10; j++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Enemy, base.gameObject.transform);
				gameObject.SetActive(true);
				float f = UnityEngine.Random.Range(0f, 6.28f);
				gameObject.transform.localPosition = new Vector3(this.r * Mathf.Cos(f), 0f, this.r * Mathf.Sin(f));
				this.enemies.Add(gameObject);
				float x = UnityEngine.Random.Range(-this.bias, this.bias);
				float z = UnityEngine.Random.Range(-this.bias, this.bias);
				this.directions.Add(this.Player.transform.localPosition - gameObject.transform.localPosition + new Vector3(x, 0f, z));
			}
			yield return new WaitForSeconds(0.5f);
			num = i;
		}
		yield break;
	}

	public GameObject Player;

	public GameObject Enemy;

	public bool isStart;

	public bool isEnd;

	public float DuringTime;

	private List<GameObject> enemies;

	private List<Vector3> directions;

	private float statTime;

	private float moveSpeed;

	private float enemyMoveSpeed;

	private float r;

	private float bias;

	private bool mouse;
}
