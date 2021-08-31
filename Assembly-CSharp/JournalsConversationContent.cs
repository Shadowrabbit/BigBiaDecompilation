using System;
using System.Collections;

public class JournalsConversationContent
{
	public JournalsConversationContent(int roleNum, string content, IEnumerator callBackFunc = null)
	{
		this.RoleNum = roleNum;
		this.Content = content;
		this.CallBackFunc = callBackFunc;
	}

	public int RoleNum;

	public string Content;

	public IEnumerator CallBackFunc;
}
