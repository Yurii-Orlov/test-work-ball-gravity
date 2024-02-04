using System;
using Managers;
using UIModule.GameActive;
using UIModule.GameLose;
using UIModule.GamePause;
using UIModule.StartGame;
using Zenject;

namespace SceneBindings
{

	public class GameUIBindings : MonoInstaller
	{
		public override void InstallBindings()
		{
			InitUiViews();
		}
		
		private void InitUiViews()
		{
			Container.Bind(typeof(IInitializable), typeof(IDisposable), typeof(IUIElement)).To<GameStartPresenter>().AsSingle();
			Container.Bind(typeof(IInitializable), typeof(IDisposable), typeof(IUIElement)).To<GameActivePresenter>().AsSingle();
			Container.Bind(typeof(IInitializable), typeof(IDisposable), typeof(IUIElement)).To<GamePausePresenter>().AsSingle();
			Container.Bind(typeof(IInitializable), typeof(IDisposable), typeof(IUIElement)).To<GameLosePresenter>().AsSingle();
		}
		
	}

}