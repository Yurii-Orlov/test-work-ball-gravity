using GameStateMachine.States;
using ModestTree;

namespace GameStateMachine
{

	public class GameStateFactory
	{
		private readonly GameStateActive.Factory activeStateFactory;
		private readonly GameStateRestart.Factory restartStateFactory;
		private readonly GameStateStart.Factory startStateFactory;
		private readonly GameStatePause.Factory pauseStateFactory;

		public GameStateFactory(GameStateActive.Factory activeStateFactory,
		                        GameStateRestart.Factory restartStateFactory,
		                        GameStateStart.Factory startStateFactory,
		                        GameStatePause.Factory pauseStateFactory)
		{
			this.activeStateFactory = activeStateFactory;
			this.restartStateFactory = restartStateFactory;
			this.startStateFactory = startStateFactory;
			this.pauseStateFactory = pauseStateFactory;
		}

		internal GameStateEntity CreateState(GameStates gameState)
		{
			switch (gameState)
			{
				case GameStates.Start:
					return startStateFactory.Create();

				case GameStates.Active:
					return activeStateFactory.Create();
				
				case GameStates.Restart:
					return restartStateFactory.Create();
				
				case GameStates.Pause:
					return pauseStateFactory.Create();
			}

			throw Assert.CreateException("Code should not be reached");
		}
	}

}