using System;
using GameStateMachine;
using UniRx;
using UnityEngine;
using Zenject;

namespace Managers
{

	public class GameManager : IInitializable
	{

		public event Action PlayerNeedChangeDirection;


		public ReactiveProperty<bool> IsGamePaused = new ReactiveProperty<bool>(true);
		public ReactiveProperty<bool> IsGameStarted = new BoolReactiveProperty(false);
		
		private readonly GameStateManager gameStateManager;

		public GameManager(GameStateManager gameStateManager)
		{
			this.gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			gameStateManager.ChangeState(GameStates.Start);
		}

		public void LoseGame()
		{
			IsGamePaused.Value = true;
			IsGameStarted.Value = false;
			gameStateManager.ChangeState(GameStates.Restart);
		}

		public void PauseGame()
		{
			IsGamePaused.Value = true;
			IsGameStarted.Value = false;
			gameStateManager.ChangeState(GameStates.Pause);
		}

		public void StartGame()
		{
			IsGamePaused.Value = false;
			IsGameStarted.Value = true;
			gameStateManager.ChangeState(GameStates.Active);
		}

		public void ChangePlayerDirection()
		{
			PlayerNeedChangeDirection?.Invoke();
		}

	}

}