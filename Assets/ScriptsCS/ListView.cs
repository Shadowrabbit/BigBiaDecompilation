// ******************************************************************
//       /\ /|       @file       ListView.cs
//       \ V/        @brief      循环列表UI组件
//       | "")       @author     Shadowrabbit, yingtu0401@gmail.com
//       /  |                    
//      /  \\        @Modified   2021-01-02 12:51:59
//    *(__\_\        @Copyright  Copyright (c) 2021, Shadowrabbit
// ******************************************************************

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListView : MonoBehaviour
{
	//布局方向
	public enum Direction
	{
		Horizontal, //水平
		Vertical, //垂直
	}

	#region FIELDS

	public float spacingX; //x间距
	public float spacingY; //y间距
	public float offsetX; //偏移量x
	public float offsetY; //偏移量y
	public GameObject protoObj; //item原型体
	public Direction direction = Direction.Vertical; //布局方向
	public int rowOrCol = 1; //垂直布局表示列的数量 水平布局表示行的数量
	public int tryDrawItemNum; //准备绘制的item数量
	private Action<GameObject, int> m_onEnable; //启用时回调 
	private Action<GameObject> m_onDisable; //禁用时回调 
	private GameObject m_viewport; //可见范围遮罩节点
	private GameObject m_content; //内容节点
	private RectTransform m_compRectTransformContent; //内容节点tran组件
	private RectTransform m_compRectTransformViewport; //遮罩节点tran组件
	private ScrollRect m_scrollRect; //滑动组件
	private float m_protoHeight; //原型体高度
	private float m_protoWidth; //原型体宽度
	private int m_cacheItemNum = -1; //当前数据中item的总数量
	private readonly List<Vector3> m_objPosList = new List<Vector3>(); //obj物体位置列表
	private readonly Stack<GameObject> m_objPool = new Stack<GameObject>(); //item物体对象池
	private bool m_hasInit; //已经初始化完成
	private Action<int> m_onLastVisitableItemIndexChanged; //最后一个可见元素的索引变化,按元素中位线算 通行证模块用到
	private int m_lastVisitableItemIndex; //最后一个可见元素的索引

	private readonly Dictionary<int, GameObject>
		m_mapCurrentObjs = new Dictionary<int, GameObject>(); //当前使用中的obj物体<索引,物体>

	[SerializeField] private bool needOnLastVisitableItemIndexChanged;

	#endregion

	/// <summary>
	/// 注册item启用回调
	/// </summary>
	/// <param name="_onItemEnable"></param>
	public void AddListenerOnItemEnable(Action<GameObject, int> _onItemEnable)
	{
		if (_onItemEnable == null)
		{
			return;
		}

		m_onEnable = _onItemEnable;
	}

	/// <summary>
	/// 注册item禁用回调
	/// </summary>
	/// <param name="_onItemDisable"></param>
	public void AddListenerOnItemDisable(Action<GameObject> _onItemDisable)
	{
		if (_onItemDisable == null)
		{
			return;
		}

		m_onDisable = _onItemDisable;
	}

	/// <summary>
	/// 注册滑动进度改变回调
	/// </summary>
	/// <param name="_onValueChanged"></param>
	public void AddListenerOnValueChanged(UnityAction<Vector2> _onValueChanged)
	{
		if (_onValueChanged == null)
		{
			return;
		}

		m_scrollRect.onValueChanged.AddListener(_onValueChanged);
	}

	/// <summary>
	/// 注册最后一个可见元素的索引变化回调
	/// </summary>
	/// <param name="_onLastVisitableItemIndexChanged"></param>
	public void AddListenerOnLastVisitableItemIndexChanged(Action<int> _onLastVisitableItemIndexChanged)
	{
		if (_onLastVisitableItemIndexChanged == null)
		{
			return;
		}

		m_onLastVisitableItemIndexChanged = _onLastVisitableItemIndexChanged;
	}

	/// <summary>
	/// 刷新
	/// </summary>
	/// <param name="_itemNum">item绘制数量</param>
	public void Refresh(int _itemNum)
	{
		tryDrawItemNum = _itemNum;
		Refresh();
	}

	/// <summary>
	/// 清空
	/// </summary>
	public void Clear()
	{
		if (!m_hasInit)
		{
			Init();
		}

		ClearItems();
	}

	/// <summary>
	/// 撤销监听
	/// </summary>
	public void RemoveAllListeners()
	{
		m_onEnable = null;
		m_onDisable = null;
		m_onLastVisitableItemIndexChanged = null;
	}

	/// <summary>
	/// 设置内容节点的位置
	/// </summary>
	/// <param name="_index"></param>
	public void SetContentPos(int _index)
	{
		if (_index > m_objPosList.Count || _index < 0)
		{
			Debug.LogError("值异常");
			return;
		}

		if (direction == Direction.Horizontal)
		{
			m_compRectTransformContent.anchoredPosition3D = new Vector3(-m_objPosList[_index].x, 0, 0);
			return;
		}

		m_compRectTransformContent.anchoredPosition3D = new Vector3(0, -m_objPosList[_index].y, 0);
	}

	/// <summary>
	/// 刷新
	/// </summary>
	private void Refresh()
	{
		if (!m_hasInit)
		{
			Init();
		}

		//原型体校验
		CheckProtoTransform();
		//尝试回收多余的item
		TryRecycleItems(tryDrawItemNum);
		//对剩余的item重新刷新
		ReEnableItemList();
		// 计算content尺寸
		CalcContentSize(tryDrawItemNum);
		//计算储存每个item坐标信息
		CalcEachItemPosition(tryDrawItemNum);
		//尝试放置item
		TrySetItems();
		//记录当前item总数量
		m_cacheItemNum = tryDrawItemNum;
	}

	/// <summary>
	/// 清空所有item
	/// </summary>
	private void ClearItems()
	{
		for (var i = m_compRectTransformContent.childCount - 1; i >= 0; i--)
		{
			TryRecycleItem(i);
			var compTransformChild = m_compRectTransformContent.GetChild(i);
			Destroy(compTransformChild.gameObject);
		}

		m_objPool.Clear();
		m_mapCurrentObjs.Clear();
		tryDrawItemNum = 0;
	}

	/// <summary>
	/// 初始化
	/// </summary>
	private void Init()
	{
		//滑动组件校验
		CheckScrollRect();
		//内容节点校验
		CheckContentTransform();
		m_scrollRect.onValueChanged.AddListener(RebuildLayout);
		if (needOnLastVisitableItemIndexChanged)
		{
			m_scrollRect.onValueChanged.AddListener(CheckLastVisitableItemIndex);
		}
		m_hasInit = true;
	}

	/// <summary>
	/// 尝试回收多余item
	/// </summary>
	/// <param name="_itemNum"></param>
	private void TryRecycleItems(int _itemNum)
	{
		//当前需要绘制的item总数大于等于缓存中的item总数
		if (_itemNum >= m_cacheItemNum)
		{
			return;
		}

		//回收多余item
		for (var i = _itemNum; i < m_cacheItemNum; i++)
		{
			TryRecycleItem(i);
		}
	}

	/// <summary>
	/// 重启Item列表
	/// </summary>
	private void ReEnableItemList()
	{
		foreach (var kvp in m_mapCurrentObjs)
		{
			m_onDisable?.Invoke(kvp.Value);
			m_onEnable?.Invoke(kvp.Value, kvp.Key);
		}
	}

	/// <summary>
	/// 尝试回收item
	/// </summary>
	private void TryRecycleItem(int _i)
	{
		m_mapCurrentObjs.TryGetValue(_i, out var obj);
		if (obj == null)
		{
			return;
		}

		//回收物体
		m_onDisable?.Invoke(obj);
		PushObj(obj);
		m_mapCurrentObjs.Remove(_i);
	}

	/// <summary>
	/// 尝试放置item
	/// </summary>  
	private void TrySetItems()
	{
		for (var i = 0; i < m_objPosList.Count; i++)
		{
			//超出可见范围
			if (IsOutOfVisitableRange(m_objPosList[i]))
			{
				//回收物体
				TryRecycleItem(i);
				continue;
			}

			//没有超出可见范围
			m_mapCurrentObjs.TryGetValue(i, out var obj);
			//物体已经存在
			if (obj != null)
			{
#if UNITY_EDITOR
				//编辑器模式调整间距时 物体在可视范围内位置可能发生了变化 运行时位置不会变
				obj.transform.localPosition = m_objPosList[i];
#endif
				continue;
			}

			//物体不存在 尝试从对象池中取出
			obj = PopObj();
			m_mapCurrentObjs.Add(i, obj);
			obj.transform.localPosition = m_objPosList[i];
			//启用回调
			m_onEnable?.Invoke(obj, i);
		}
	}

	/// <summary>
	/// 计算储存每个item坐标信息
	/// </summary>
	/// <param name="_itemNum"></param>
	private void CalcEachItemPosition(int _itemNum)
	{
		if (_itemNum < 0)
		{
			return;
		}

		//清空数据
		m_objPosList.Clear();
		for (var i = 0; i < _itemNum; i++)
		{
			float x, y;
			switch (direction)
			{
				//垂直布局情况
				case Direction.Vertical:
					//x = 该元素位于第几列 * （原型体宽度 + X间距) + X偏移量
					x = (i % rowOrCol) * (m_protoWidth + spacingX) + offsetX;
					//y = 该元素位于第几行 * （原型体高度 + Y间距）+ Y偏移量
					// ReSharper disable once PossibleLossOfFraction
					y = (i / rowOrCol) * (m_protoHeight + spacingY) + offsetY;
					break;
				case Direction.Horizontal:
					// ReSharper disable once PossibleLossOfFraction
					x = (m_protoWidth + spacingX) * (i / rowOrCol) + offsetX;
					y = (m_protoHeight + spacingY) * (i % rowOrCol) + offsetY;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			m_objPosList.Add(new Vector3(x, -y, 0));
		}
	}

	/// <summary>
	/// obj出栈
	/// </summary>
	/// <returns></returns>
	private GameObject PopObj()
	{
		GameObject obj;
		//尝试从对象池取obj 没有的话创建新实例
		if (m_objPool.Count > 0)
		{
			obj = m_objPool.Pop();
		}
		else
		{
			obj = Instantiate(protoObj, m_content.transform);
			//创建的时候根据顺序命名
			obj.name = protoObj.name + m_content.transform.childCount;
		}

		obj.transform.localScale = Vector3.one;
		obj.SetActive(true);
		return obj;
	}

	/// <summary>
	/// obj压入对象池栈
	/// </summary>
	/// <param name="_obj"></param>
	private void PushObj(GameObject _obj)
	{
		if (_obj == null)
		{
			return;
		}

		m_objPool.Push(_obj);
		_obj.SetActive(false);
	}

	/// <summary>
	/// 原型体transform校验
	/// </summary>
	private void CheckProtoTransform()
	{
		//原型体校验
		if (protoObj == null)
		{
			//PLog.LogError("找不到原型体");
			return;
		}

		var compProtoRectTransform = protoObj.GetComponent<RectTransform>();
		var rect = compProtoRectTransform.rect;
		m_protoHeight = rect.height;
		m_protoWidth = rect.width;
		compProtoRectTransform.pivot = new Vector2(0, 1);
		//锚点的情况
		if (compProtoRectTransform.anchorMin == compProtoRectTransform.anchorMax)
		{
			compProtoRectTransform.anchorMin = new Vector2(0, 1);
			compProtoRectTransform.anchorMax = new Vector2(0, 1);
			compProtoRectTransform.anchoredPosition = Vector2.zero;
			return;
		}

		//锚框的情况 自适应的item 运行时再改变锚点 不然无法保存原锚点
		if (!Application.isPlaying) return;
		compProtoRectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, m_protoWidth);
		compProtoRectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, m_protoHeight);
		compProtoRectTransform.anchoredPosition = Vector2.zero;
	}

	/// <summary>
	/// 内容节点transform校验
	/// </summary>
	private void CheckContentTransform()
	{
		m_viewport = m_scrollRect.viewport.gameObject;
		m_compRectTransformViewport =
			m_viewport.GetComponent<RectTransform>() ?? throw new Exception("找不到RectTransform组件:" + m_viewport.name);
		m_content = m_scrollRect.content.gameObject;
		m_compRectTransformContent = m_content.GetComponent<RectTransform>() ??
		                             throw new Exception("找不到RectTransform组件:" + m_compRectTransformContent.name);
		m_compRectTransformContent.pivot = new Vector2(0, 1);
		m_compRectTransformContent.anchorMin = new Vector2(0, 1);
		m_compRectTransformContent.anchorMax = new Vector2(0, 1);
	}

	/// <summary>
	/// 滑动组件校验
	/// </summary>
	private void CheckScrollRect()
	{
		m_scrollRect = GetComponent<ScrollRect>();
		if (m_scrollRect == null)
		{
			gameObject.AddComponent<ScrollRect>();
		}
	}

	/// <summary>
	/// 重绘布局 更新item
	/// </summary>
	/// <param name="_value"></param>
	private void RebuildLayout(Vector2 _value)
	{
		TrySetItems();
	}

	/// <summary>
	/// 检测最后一个可见元素的索引
	/// </summary>
	private void CheckLastVisitableItemIndex(Vector2 _value)
	{
		//垂直情况暂时不需要 需要的时候再算吧
		if (direction == Direction.Vertical)
		{
			return;
		}

		var posContent = m_compRectTransformContent.anchoredPosition; //content的坐标
		foreach (var key in m_mapCurrentObjs.Keys)
		{
			var currentX = m_objPosList[key].x + posContent.x;
			//不在最后一个可见元素元素范围内
			if (currentX < m_compRectTransformViewport.rect.width - spacingX - 3 * m_protoWidth / 2 ||
			    currentX > m_compRectTransformViewport.rect.width - m_protoWidth / 2) continue;
			if (m_lastVisitableItemIndex == key)
			{
				return;
			}

			m_lastVisitableItemIndex = key;
			m_onLastVisitableItemIndexChanged?.Invoke(key);
			return;
		}
	}

	/// <summary>
	/// 计算content尺寸
	/// </summary>
	private void CalcContentSize(int _itemNum)
	{
		if (_itemNum < 0)
		{
			//PLog.LogError("itemNum不能小于0");
			return;
		}

		var eachRowOrColNum = Mathf.Ceil((float)_itemNum / rowOrCol); //每列/行item的最大数量
		switch (direction)
		{
			//垂直布局
			case Direction.Vertical:
			{
				var contentHeight =
					(spacingY + m_protoHeight) * eachRowOrColNum + offsetY; //内容布局高 = (原型体高度 + 间隔高度) * 每列的最大item数量 + 垂直偏移
				var contentWidth =
					m_protoWidth * rowOrCol + (rowOrCol - 1) * spacingX + offsetX; //内容布局宽 = 原型体宽度 * 列数 + (列数 - 1) * 间距X + 水平偏移
				m_compRectTransformContent.sizeDelta = new Vector2(contentWidth, contentHeight);
				break;
			}
			//水平布局
			case Direction.Horizontal:
			{
				var contentWidth = (spacingX + m_protoWidth) * eachRowOrColNum + offsetX;
				var contentHeight = m_protoHeight * rowOrCol + (rowOrCol - 1) * spacingY + offsetY;
				m_compRectTransformContent.sizeDelta = new Vector2(contentWidth, contentHeight);
				break;
			}
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	/// <summary>
	/// 是否超出可见范围
	/// </summary>
	/// <param name="_position">item坐标</param>
	/// <returns></returns>
	private bool IsOutOfVisitableRange(Vector3 _position)
	{
		var posContent = m_compRectTransformContent.anchoredPosition; //content的坐标
		switch (direction)
		{
			//自身偏移+content偏移>原型体高度 顶部越界
			case Direction.Vertical when _position.y + posContent.y > m_protoHeight:
				return true;
			//自身偏移+content偏移<遮罩底部边界坐标 底部越界
			case Direction.Vertical when _position.y + posContent.y < -m_compRectTransformViewport.rect.height:
				return true;
			case Direction.Vertical:
				return false;
			//自身偏移+content偏移<原型体宽度 左部越界
			case Direction.Horizontal when _position.x + posContent.x < -m_protoWidth:
				return true;
			//自身偏移+content偏移>遮罩宽度 右部越界
			case Direction.Horizontal when _position.x + posContent.x > m_compRectTransformViewport.rect.width:
				return true;
			case Direction.Horizontal:
				return false;
			default:
				return false;
		}
	}

	#region UNITY LIFE

	private void Awake()
	{
		if (m_hasInit)
		{
			return;
		}

		Init();
	}

	private void OnDestroy()
	{
		ClearItems();
	}

	/// <summary>
	/// inspector值发生改变回调
	/// </summary>
	private void OnValidate()
	{
#if UNITY_EDITOR
		if (Application.isPlaying)
		{
			return;
		}

		if (!m_hasInit)
		{
			Init();
		}

		Refresh();
#endif
	}

	#endregion

	/// <summary>
	/// 编辑器模式清空item
	/// </summary>
	private void EditorClearItems()
	{
		for (var i = m_compRectTransformContent.childCount - 1; i >= 0; i--)
		{
			TryRecycleItem(i);
			var compTransformChild = m_compRectTransformContent.GetChild(i);
			DestroyImmediate(compTransformChild.gameObject);
		}

		m_objPool.Clear();
		m_mapCurrentObjs.Clear();
		tryDrawItemNum = 0;
		m_hasInit = false;
	}
}
