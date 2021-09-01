using System;
using UnityEngine;

namespace Cinemachine.Examples
{
	[AddComponentMenu("")]
	public class ExampleHelpWindow : MonoBehaviour
	{
		private void OnGUI()
		{
			if (this.mShowingHelpWindow)
			{
				Vector2 vector = GUI.skin.label.CalcSize(new GUIContent(this.m_Description));
				Vector2 vector2 = vector * 0.5f;
				float maxWidth = Mathf.Min((float)Screen.width - 40f, vector.x);
				float x = (float)Screen.width * 0.5f - maxWidth * 0.5f;
				float y = (float)Screen.height * 0.4f - vector2.y;
				Rect screenRect = new Rect(x, y, maxWidth, vector.y);
				GUILayout.Window(400, screenRect, delegate(int id)
				{
					this.DrawWindow(id, maxWidth);
				}, this.m_Title, Array.Empty<GUILayoutOption>());
			}
		}

		private void DrawWindow(int id, float maxWidth)
		{
			GUILayout.BeginVertical(GUI.skin.box, Array.Empty<GUILayoutOption>());
			GUILayout.Label(this.m_Description, Array.Empty<GUILayoutOption>());
			GUILayout.EndVertical();
			if (GUILayout.Button("Got it!", Array.Empty<GUILayoutOption>()))
			{
				this.mShowingHelpWindow = false;
			}
		}

		public string m_Title;

		[TextArea(10, 50)]
		public string m_Description;

		private bool mShowingHelpWindow = true;

		private const float kPadding = 40f;
	}
}
