using System;

public class JournalsBean
{
	public JournalsBean(string formatString, string target = null, string origin = null, string reason = null, string place = null, string time = null, JournalsBean.OnHappenFunc onHappen = null)
	{
		this.FormatString = formatString;
		this.Target = target;
		this.Origin = origin;
		this.Reason = reason;
		this.Place = place;
		this.Time = time;
		this.OnHappen = onHappen;
	}

	public JournalsBean()
	{
	}

	public override string ToString()
	{
		return this.FormatString.ToString().Replace("{origin}", "<color=yellow>[" + this.Origin + "]</color>").Replace("{target}", "<color=yellow>[" + this.Target + "]</color>").Replace("{reason}", this.Reason).Replace("{place}", this.Place).Replace("{time}", this.Time);
	}

	public string FormatString;

	public string Target;

	public string Origin;

	public string Reason;

	public string Place;

	public string Time;

	public JournalsBean.OnHappenFunc OnHappen;

	public delegate void OnHappenFunc();
}
