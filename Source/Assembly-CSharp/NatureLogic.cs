using System;

public class NatureLogic : CardLogic
{
	private void AddLogic(string logicName, CardData data)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.CardData = data;
		data.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(data);
	}

	private void RemoveLogic(string logicName, CardData data)
	{
		Activator.CreateInstance(Type.GetType(logicName));
		foreach (CardLogic cardLogic in data.CardLogics)
		{
			if (cardLogic.GetType().Name.Equals(logicName))
			{
				for (int i = data.CardLogicClassNames.Count - 1; i >= 0; i--)
				{
					if (data.CardLogicClassNames[i].Split(new char[]
					{
						' '
					})[0].Equals(logicName))
					{
						data.CardLogicClassNames.Remove(data.CardLogicClassNames[i]);
					}
				}
				data.CardLogics.Remove(cardLogic);
				break;
			}
		}
	}

	public bool isHappened;
}
