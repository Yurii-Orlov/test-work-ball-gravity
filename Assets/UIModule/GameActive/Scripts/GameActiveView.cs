using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.GameActive
{
	public class GameActiveView : MonoBehaviour
	{
		public const string PREFAB_NAME = nameof(GameActiveView);

		public event Action PauseGameClickHandler;

		[SerializeField] private Button pauseGameBtn;

		public void Init()
		{
			pauseGameBtn.onClick.AddListener(PauseGameClicked);
		}
		
		private void PauseGameClicked()
		{
			PauseGameClickHandler?.Invoke();
		}

		public void Dispose()
		{
			pauseGameBtn.onClick.RemoveListener(PauseGameClicked);
		}

	}
	
}


