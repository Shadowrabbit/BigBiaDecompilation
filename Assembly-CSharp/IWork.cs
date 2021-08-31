using System;

public interface IWork
{
	CardData CardData { get; set; }

	void Work(float time);
}
