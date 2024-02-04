using Managers;
using UIModule.StartGame;
using UnityEngine;
using Zenject;

namespace GameStateMachine.States
{

	public class GameStateStart : GameStateEntity
	{
		private readonly UIManager uiManager;

		public GameStateStart(UIManager uiManager)
		{
			this.uiManager = uiManager;
		}
		
		public override void Start()
		{
			Debug.Log("Start game state started");
			
			uiManager.ShowPage<GameStartPresenter>();
		}

		public override void Dispose()
		{
			uiManager.HidePage<GameStartPresenter>();
		}
		
		public class Factory : PlaceholderFactory<GameStateStart>
		{
		}
	}

}