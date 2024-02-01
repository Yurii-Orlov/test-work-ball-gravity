using GameStateMachine;
using GameStateMachine.States;
using Managers;
using Zenject;

namespace SceneBindings
{
	public class GameSceneBindings : MonoInstaller
	{

		public override void InstallBindings()
		{
			BindGameStateMachine();

			BindManagers();
		}

		private void BindGameStateMachine()
		{
			Container.Bind<GameStateFactory>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameStateManager>().AsSingle();

			Container.BindFactory<GameStateActive, GameStateActive.Factory>().WhenInjectedInto<GameStateFactory>();
			Container.BindFactory<GameStateRestart, GameStateRestart.Factory>().WhenInjectedInto<GameStateFactory>();
			Container.BindFactory<GameStateStart, GameStateStart.Factory>().WhenInjectedInto<GameStateFactory>();
		}

		private void BindManagers()
		{
			Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
		}

	}
	
}

