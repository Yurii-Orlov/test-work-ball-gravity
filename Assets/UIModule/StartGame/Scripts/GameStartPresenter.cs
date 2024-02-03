using System;
using Managers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace UIModule.StartGame
{

	public class GameStartPresenter : IInitializable, IDisposable, IUIElement
	{

		private GameStartView view;
		
		private readonly UIManager uiManager;
		private readonly GameManager gameManager;
		
		public GameObject SelfPage { get; set; }

		public GameStartPresenter(UIManager uiManager,
		                          GameManager gameManager)
		{
			this.uiManager = uiManager;
			this.gameManager = gameManager;
			
			uiManager.AddPage<GameStartPresenter>(this);
		}
		
		public void Initialize()
		{
			SelfPage = UnityEngine.Object.Instantiate(Resources.Load<GameObject>($"{GameStartView.PREFAB_NAME}"), 
			                                          uiManager.CanvasParent.transform, 
			                                          false);
			view = SelfPage.GetComponent<GameStartView>();
			view.Init();
			view.StartGameClickHandler += OnStartGameClickHandler;
			
			Hide();
		}

		private void OnStartGameClickHandler()
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
				view.StartGameClickHandler -= OnStartGameClickHandler;
			}
			
			uiManager.RemovePage<GameStartPresenter>();
			Object.Destroy(SelfPage);
		}

	}

}