using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VoxelBuilder;

public static class UIPanelHelper
{
	public static void AddTriggerListener(GameObject obj, EventTriggerType eventTriggerType, CustomEventTrriger.TriggerAction action)
	{
		CustomEventTrriger customEventTrriger = obj.GetComponent<CustomEventTrriger>();
		if (customEventTrriger == null)
		{
			customEventTrriger = obj.AddComponent<CustomEventTrriger>();
		}
		customEventTrriger.AddListener(eventTriggerType, action);
	}

	public static void ClearTriggerListener(GameObject obj, EventTriggerType eventTriggerType)
	{
		CustomEventTrriger component = obj.GetComponent<CustomEventTrriger>();
		if (component != null)
		{
			component.ClearListener(eventTriggerType);
		}
	}

	public static void ClearTriggerListener(GameObject obj)
	{
		CustomEventTrriger component = obj.GetComponent<CustomEventTrriger>();
		if (component != null)
		{
			component.ClearListener();
		}
	}

	public static void CellUpdatePoor<T>(List<T> datas, Transform root, GameObject prefab, Action<GameObject, T> updateAction)
	{
		List<Transform> childs = root.GetChilds();
		for (int i = 0; i < datas.Count; i++)
		{
			GameObject gameObject;
			if (i >= childs.Count)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab, root);
			}
			else
			{
				gameObject = childs[i].gameObject;
			}
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			updateAction(gameObject, datas[i]);
		}
		if (childs.Count > datas.Count)
		{
			for (int j = datas.Count; j < childs.Count; j++)
			{
				childs[j].gameObject.SetActive(false);
			}
		}
	}

	internal static void CellUpdatePoor(List<MatchItem> list, GameObject loadCellPrefab, object onCellUpdated)
	{
		throw new NotImplementedException();
	}
}
