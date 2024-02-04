using System;
using Managers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace UIModule.GameLose
{

	public class GameLosePresenter : IInitializable, IDisposable, IUIElement
	{

		private GameLoseView view;
		
		private readonly UIManager uiManager;
		private readonly GameManager gameManager;
		
		public GameObject SelfPage { get; set; }

		public GameLosePresenter(UIManager uiManager,
		                         GameManager gameManager)
		{
			this.uiManager = uiManager;
			this.gameManager = gameManager;
			
			uiManager.AddPage<GameLosePresenter>(this);
		}
		
		public void Initialize()
		{
			SelfPage = UnityEngine.Object.Instantiate(Resources.Load<GameObject>($"{GameLoseView.PREFAB_NAME}"), 
			                                          uiManager.CanvasParent.transform, 
			                                          false);
			view = SelfPage.GetComponent<GameLoseView>();
			view.Init();
			view.RestartGameClickHandler += OnRestartGameClickHandler;
			
			Hide();
		}

		private void OnRestartGameClickHandler()
		{
			gameManager.RestartGame();
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
				view.RestartGameClickHandler -= OnRestartGameClickHandler;
			}
			
			uiManager.RemovePage<GameLosePresenter>();
			Object.Destroy(SelfPage);
		}

	}

}