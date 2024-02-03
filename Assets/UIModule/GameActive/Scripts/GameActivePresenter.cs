using System;
using Managers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace UIModule.GameActive
{
	public class GameActivePresenter : IInitializable, IDisposable, IUIElement
	{

		private GameActiveView view;
		
		private readonly UIManager uiManager;
		private readonly GameManager gameManager;
		
		public GameObject SelfPage { get; set; }

		public GameActivePresenter(UIManager uiManager,
		                           GameManager gameManager)
		{
			this.uiManager = uiManager;
			this.gameManager = gameManager;
			
			uiManager.AddPage<GameActivePresenter>(this);
		}
		
		public void Initialize()
		{
			SelfPage = UnityEngine.Object.Instantiate(Resources.Load<GameObject>($"{GameActiveView.PREFAB_NAME}"), 
			                                          uiManager.CanvasParent.transform, 
			                                          false);
			view = SelfPage.GetComponent<GameActiveView>();
			view.Init();
			view.PauseGameClickHandler += OnPauseGameClickHandler;
			
			Hide();
		}

		private void OnPauseGameClickHandler()
		{
			gameManager.PauseGame();
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
				view.PauseGameClickHandler -= OnPauseGameClickHandler;
			}
			
			uiManager.RemovePage<GameActivePresenter>();
			Object.Destroy(SelfPage);
		}

	}

}