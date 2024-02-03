using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.StartGame
{
	public class GameStartView : MonoBehaviour
	{
		public const string PREFAB_NAME = nameof(GameStartView);

		public event Action StartGameClickHandler;

		[SerializeField] private Button startGameBtn;

		public void Init()
		{
			startGameBtn.onClick.AddListener(StartGameClicked);
		}
		
		private void StartGameClicked()
		{
			StartGameClickHandler?.Invoke();
		}

		public void Dispose()
		{
			startGameBtn.onClick.RemoveListener(StartGameClicked);
		}

	}
	
}


