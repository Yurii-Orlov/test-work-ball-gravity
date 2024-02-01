using Zenject;

namespace GameStateMachine
{

	public class GameStateManager : ITickable
	{
		private GameStates _currentGameState;
		private GameStates _previousGameState;
		private GameStateFactory _gameStateFactory;
		private GameStateEntity _gameStateEntity;

		[Inject]
		public void Construct(GameStateFactory gameStateFactory)
		{
			_gameStateFactory = gameStateFactory;
		}

		public void ChangeState(GameStates state)
		{
			if (_gameStateEntity != null)
			{
				_gameStateEntity.Dispose();
				_gameStateEntity = null;
			}

			_previousGameState = _currentGameState;
			_currentGameState = state;

			_gameStateEntity = _gameStateFactory.CreateState(state);
			_gameStateEntity.Initialize();
			_gameStateEntity.Start();
		}

		public void Tick()
		{
			_gameStateEntity?.Tick();
		}
	}

}