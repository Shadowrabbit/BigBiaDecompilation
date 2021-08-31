﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace XLuaTest
{
	public class MessageBox : MonoBehaviour
	{
		public static void ShowAlertBox(string message, string title, Action onFinished = null)
		{
			Transform alertPanel = GameObject.Find("Canvas").transform.Find("AlertBox");
			if (alertPanel == null)
			{
				alertPanel = (UnityEngine.Object.Instantiate(Resources.Load("AlertBox")) as GameObject).transform;
				alertPanel.gameObject.name = "AlertBox";
				alertPanel.SetParent(GameObject.Find("Canvas").transform);
				alertPanel.localPosition = new Vector3(-6f, -6f, 0f);
			}
			alertPanel.Find("title").GetComponent<Text>().text = title;
			alertPanel.Find("message").GetComponent<Text>().text = message;
			Button button = alertPanel.Find("alertBtn").GetComponent<Button>();
			UnityAction call = delegate()
			{
				if (onFinished != null)
				{
					onFinished();
				}
				button.onClick.RemoveAllListeners();
				alertPanel.gameObject.SetActive(false);
			};
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(call);
			alertPanel.gameObject.SetActive(true);
		}

		public static void ShowConfirmBox(string message, string title, Action<bool> onFinished = null)
		{
			Transform confirmPanel = GameObject.Find("Canvas").transform.Find("ConfirmBox");
			if (confirmPanel == null)
			{
				confirmPanel = (UnityEngine.Object.Instantiate(Resources.Load("ConfirmBox")) as GameObject).transform;
				confirmPanel.gameObject.name = "ConfirmBox";
				confirmPanel.SetParent(GameObject.Find("Canvas").transform);
				confirmPanel.localPosition = new Vector3(-8f, -18f, 0f);
			}
			confirmPanel.Find("confirmTitle").GetComponent<Text>().text = title;
			confirmPanel.Find("conmessage").GetComponent<Text>().text = message;
			Button confirmBtn = confirmPanel.Find("confirmBtn").GetComponent<Button>();
			Button cancelBtn = confirmPanel.Find("cancelBtn").GetComponent<Button>();
			Action cleanup = delegate()
			{
				confirmBtn.onClick.RemoveAllListeners();
				cancelBtn.onClick.RemoveAllListeners();
				confirmPanel.gameObject.SetActive(false);
			};
			UnityAction call = delegate()
			{
				if (onFinished != null)
				{
					onFinished(true);
				}
				cleanup();
			};
			UnityAction call2 = delegate()
			{
				if (onFinished != null)
				{
					onFinished(false);
				}
				cleanup();
			};
			confirmBtn.onClick.RemoveAllListeners();
			confirmBtn.onClick.AddListener(call);
			cancelBtn.onClick.RemoveAllListeners();
			cancelBtn.onClick.AddListener(call2);
			confirmPanel.gameObject.SetActive(true);
		}
	}
}
