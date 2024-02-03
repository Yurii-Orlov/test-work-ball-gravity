using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.GameActive
{
	public class GameActiveView : MonoBehaviour
	{
		public const string PREFAB_NAME = nameof(GameActiveView);

		public event Action PauseGameClickHandler;
		public event Action ChangePlayerDirectionClickHandler;

		[SerializeField] private Button pauseGameBtn;
		[SerializeField] private Button playerInputBtn;

		public void Init()
		{
			pauseGameBtn.onClick.AddListener(PauseGameClicked);
			playerInputBtn.onClick.AddListener(ChangePlayerDirectionClicked);
		}

		private void ChangePlayerDirectionClicked()
		{
			ChangePlayerDirectionClickHandler?.Invoke();
		}

		private void PauseGameClicked()
		{
			PauseGameClickHandler?.Invoke();
		}

		public void Dispose()
		{
			pauseGameBtn.onClick.RemoveListener(PauseGameClicked);
			playerInputBtn.onClick.RemoveListener(ChangePlayerDirectionClicked);
		}

	}
	
}


