using System;
using System.Collections.Generic;

[Serializable]
public class ItemData
{
	public ItemData.ItemTypes ItemType { get; set; }

	public int GetIntAttr(string name)
	{
		if (this.Attrs.ContainsKey(name))
		{
			return Convert.ToInt32(this.Attrs[name]);
		}
		return 0;
	}

	public float GetFloatAttr(string name)
	{
		if (this.Attrs.ContainsKey(name))
		{
			return Convert.ToSingle(this.Attrs[name]);
		}
		return 0f;
	}

	public bool GetBoolAttr(string name)
	{
		if (this.Attrs.ContainsKey(name))
		{
			return Convert.ToBoolean(this.Attrs[name]);
		}
		return this.HiddenAttrs.ContainsKey(name) && Convert.ToBoolean(this.HiddenAttrs[name]);
	}

	public string GetAttr(string name)
	{
		if (this.Attrs.ContainsKey(name))
		{
			return this.Attrs[name].ToString();
		}
		if (this.HiddenAttrs.ContainsKey(name))
		{
			return this.HiddenAttrs[name].ToString();
		}
		return "";
	}

	public void SetBoolAttr(string name, bool value)
	{
		if (!this.Attrs.ContainsKey(name))
		{
			this.Attrs.Add(name, value.ToString());
			return;
		}
		this.Attrs[name] = value.ToString();
	}

	public void SetAttr(string name, string value)
	{
		if (!this.Attrs.ContainsKey(name))
		{
			this.Attrs.Add(name, value);
			return;
		}
		this.Attrs[name] = value;
	}

	public bool HasAttr(string name)
	{
		return this.Attrs.ContainsKey(name) || this.HiddenAttrs.ContainsKey(name);
	}

	public string ModID;

	public string Name;

	public string ID;

	public float DisplayPositionX;

	public float DisplayPositionY;

	public float DisplayRotationY;

	public string Model;

	public string Detail;

	public string AreaModel;

	public Dictionary<string, object> Attrs = new Dictionary<string, object>();

	public Dictionary<string, object> HiddenAttrs = new Dictionary<string, object>();

	public enum ItemTypes
	{
		normal,
		Custom,
		material
	}
}
