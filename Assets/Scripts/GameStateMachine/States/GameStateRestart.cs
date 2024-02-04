using Managers;
using UIModule.GameLose;
using UnityEngine;
using Zenject;

namespace GameStateMachine.States
{

	public class GameStateRestart : GameStateEntity
	{
		private readonly UIManager uiManager;

		public GameStateRestart(UIManager uiManager)
		{
			this.uiManager = uiManager;
		}
		
		public override void Start()
		{
			Debug.Log("Restart game state started");
			
			uiManager.ShowPage<GameLosePresenter>();
		}

		public override void Dispose()
		{
			uiManager.HidePage<GameLosePresenter>();
		}
		
		public class Factory : PlaceholderFactory<GameStateRestart>
		{
		}
	}

}