using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.GameLose
{

	public class GameLoseView : MonoBehaviour
	{
		public const string PREFAB_NAME = nameof(GameLoseView);

		public event Action RestartGameClickHandler;

		[SerializeField] private Button restartGameBtn;

		public void Init()
		{
			restartGameBtn.onClick.AddListener(RestartGameClicked);
		}
		
		private void RestartGameClicked()
		{
			RestartGameClickHandler?.Invoke();
		}

		public void Dispose()
		{
			restartGameBtn.onClick.RemoveListener(RestartGameClicked);
		}

	}

}