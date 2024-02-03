using System;
using Managers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace UIModule.GamePause
{

	public class GamePausePresenter : IInitializable, IDisposable, IUIElement
	{

		private GamePauseView view;
		
		private readonly UIManager uiManager;
		private readonly GameManager gameManager;
		
		public GameObject SelfPage { get; set; }

		public GamePausePresenter(UIManager uiManager,
		                          GameManager gameManager)
		{
			this.uiManager = uiManager;
			this.gameManager = gameManager;
			
			uiManager.AddPage<GamePausePresenter>(this);
		}
		
		public void Initialize()
		{
			SelfPage = UnityEngine.Object.Instantiate(Resources.Load<GameObject>($"{GamePauseView.PREFAB_NAME}"), 
			                                          uiManager.CanvasParent.transform, 
			                                          false);
			view = SelfPage.GetComponent<GamePauseView>();
			view.Init();
			view.ResumeGameClickHandler += OnResumeGameClickHandler;
			
			Hide();
		}

		private void OnResumeGameClickHandler()
		{
			gameManager.StartGame();
		}

		public void Show()
		{
			SelfPage.SetActive(true);
		}

		public void Hide()
		{
			if (SelfPage != null)
			{
				SelfPage.SetActive(false);
			}
		}

		public void Dispose()
		{
			if (view != null)
			{
				view.Dispose();
				view.ResumeGameClickHandler -= OnResumeGameClickHandler;
			}
			
			uiManager.RemovePage<GamePausePresenter>();
			Object.Destroy(SelfPage);
		}

	}

}