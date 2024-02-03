using Managers;
using UIModule.GamePause;
using UIModule.StartGame;
using UnityEngine;
using Zenject;

namespace GameStateMachine.States
{

	public class GameStatePause : GameStateEntity
	{
		private readonly GameStateManager gameStateManager;
		private readonly UIManager uiManager;

		public GameStatePause(GameStateManager gameStateManager, UIManager uiManager)
		{
			this.gameStateManager = gameStateManager;
			this.uiManager = uiManager;
		}
		
		public override void Start()
		{
			Debug.Log("Pause game state started");
			
			uiManager.ShowPage<GamePausePresenter>();
		}

		public override void Initialize()
		{

		}

		public override void Tick()
		{
		}

		public override void Dispose()
		{
			uiManager.HidePage<GamePausePresenter>();
		}
		
		public class Factory : PlaceholderFactory<GameStatePause>
		{
		}
	}

}