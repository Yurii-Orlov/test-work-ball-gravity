using Managers;
using UIModule.StartGame;
using UnityEngine;
using Zenject;

namespace GameStateMachine.States
{

	public class GameStateStart : GameStateEntity
	{
		private readonly GameStateManager gameStateManager;
		private readonly UIManager uiManager;

		public GameStateStart(GameStateManager gameStateManager, UIManager uiManager)
		{
			this.gameStateManager = gameStateManager;
			this.uiManager = uiManager;
		}
		
		public override void Start()
		{
			Debug.Log("Start game state started");
			
			uiManager.ShowPage<GameStartPresenter>();
		}

		public override void Initialize()
		{

		}

		public override void Tick()
		{
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