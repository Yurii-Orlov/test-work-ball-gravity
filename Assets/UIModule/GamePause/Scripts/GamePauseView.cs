using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.GamePause
{

	public class GamePauseView : MonoBehaviour
	{
		public const string PREFAB_NAME = nameof(GamePauseView);

		public event Action ResumeGameClickHandler;

		[SerializeField] private Button resumeGameBtn;

		public void Init()
		{
			resumeGameBtn.onClick.AddListener(ResumeGameClicked);
		}
		
		private void ResumeGameClicked()
		{
			ResumeGameClickHandler?.Invoke();
		}

		public void Dispose()
		{
			resumeGameBtn.onClick.RemoveListener(ResumeGameClicked);
		}

	}

}