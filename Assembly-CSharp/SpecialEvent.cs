using System;

public class SpecialEvent
{
	public SpecialEvent(string dialogName, SpecialEvent.IsAvailable isAvailable, SpecialEvent.BeforeConversation BeforeConversationFunc = null)
	{
		this.DialogName = dialogName;
		this.IsAvailableCheckFunction = isAvailable;
		this.BeforeConversationFunc = BeforeConversationFunc;
	}

	public SpecialEvent.IsAvailable IsAvailableCheckFunction;

	public SpecialEvent.BeforeConversation BeforeConversationFunc;

	public string DialogName;

	public delegate int IsAvailable();

	public delegate void BeforeConversation();
}
