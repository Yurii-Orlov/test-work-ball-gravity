using GameStateMachine.States;
using ModestTree;

namespace GameStateMachine
{

	public class GameStateFactory
	{
		private readonly GameStateActive.Factory _activeStateFactory;
		private readonly GameStateRestart.Factory _restartStateFactory;
		private readonly GameStateStart.Factory _startStateFactory;

		public GameStateFactory(GameStateActive.Factory activeStateFactory,
		                        GameStateRestart.Factory restartStateFactory,
		                        GameStateStart.Factory startStateFactory)
		{
			_activeStateFactory = activeStateFactory;
			_restartStateFactory = restartStateFactory;
			_startStateFactory = startStateFactory;
		}

		internal GameStateEntity CreateState(GameStates gameState)
		{
			switch (gameState)
			{
				case GameStates.Start:
					return _startStateFactory.Create();

				case GameStates.Active:
					return _activeStateFactory.Create();
				
				case GameStates.Restart:
					return _restartStateFactory.Create();
			}

			throw Assert.CreateException("Code should not be reached");
		}
	}

}