using GameStateMachine;
using Zenject;

namespace Managers
{

	public class GameManager : IInitializable
	{

		private readonly GameStateManager gameStateManager;

		public GameManager(GameStateManager gameStateManager)
		{
			this.gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			gameStateManager.ChangeState(GameStates.Start);
		}

	}

}