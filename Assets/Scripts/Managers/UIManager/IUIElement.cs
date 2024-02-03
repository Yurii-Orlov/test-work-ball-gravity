using UnityEngine;

namespace Managers
{
	public interface IUIElement
	{
		GameObject SelfPage { get; set; }
		void Show();
		void Hide();
		void Dispose();
	}
}