using GameStateMachine;
using UniRx;
using Zenject;

namespace Managers
{

	public class GameManager : IInitializable
	{

		public BoolReactiveProperty IsGameStarted;
		
		private readonly GameStateManager gameStateManager;

		public GameManager(GameStateManager gameStateManager)
		{
			this.gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			IsGameStarted = new BoolReactiveProperty(false);
			gameStateManager.ChangeState(GameStates.Start);
		}

		public void LoseGame()
		{
			IsGameStarted.Value = false;
		}

		public void PauseGame()
		{
			IsGameStarted.Value = false;
			gameStateManager.ChangeState(GameStates.Pause);
		}

		public void StartGame()
		{
			IsGameStarted.Value = true;
			gameStateManager.ChangeState(GameStates.Active);
		}

	}

}