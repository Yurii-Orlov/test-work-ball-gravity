using Zenject;

namespace GameStateMachine
{

	public class GameStateManager : ITickable
	{
		private GameStates currentGameState;
		private GameStates previousGameState;
		private GameStateFactory gameStateFactory;
		private GameStateEntity gameStateEntity;

		[Inject]
		public void Construct(GameStateFactory gameStateFactory)
		{
			this.gameStateFactory = gameStateFactory;
		}

		public void ChangeState(GameStates state)
		{
			if (gameStateEntity != null)
			{
				gameStateEntity.Dispose();
				gameStateEntity = null;
			}

			previousGameState = currentGameState;
			currentGameState = state;

			gameStateEntity = gameStateFactory.CreateState(state);
			gameStateEntity.Initialize();
			gameStateEntity.Start();
		}

		public void Tick()
		{
			gameStateEntity?.Tick();
		}
	}

}