using Managers;
using UIModule.GameActive;
using UnityEngine;
using Zenject;

namespace GameStateMachine.States
{

	public class GameStateActive : GameStateEntity
	{
		private readonly UIManager uiManager;

		public GameStateActive(UIManager uiManager)
		{
			this.uiManager = uiManager;
		}
		
		public override void Start()
		{
			Debug.Log("Active game state started");
			
			uiManager.ShowPage<GameActivePresenter>();
		}

		public override void Dispose()
		{
			uiManager.HidePage<GameActivePresenter>();
		}
		
		public class Factory : PlaceholderFactory<GameStateActive>
		{
		}
	}

}