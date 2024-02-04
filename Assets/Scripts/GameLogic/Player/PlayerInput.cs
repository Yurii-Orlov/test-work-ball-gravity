using System;
using Managers;
using UniRx;
using UnityEngine;

namespace GameLogic.Player
{

	public class PlayerInput
	{

		public event Action<Vector2> MovePlayer;
		
		private readonly GameManager gameManager;

		private bool playerMoveUp;
		private CompositeDisposable compositeDisposable;
		private bool isGameStarted;

		public PlayerInput(GameManager gameManager)
		{
			compositeDisposable = new CompositeDisposable();
			playerMoveUp = true;
			this.gameManager = gameManager;

			this.gameManager.IsGameStarted.ObserveEveryValueChanged(x => x.Value).Subscribe(GameStartedEvent)
			    .AddTo(compositeDisposable);
			this.gameManager.PlayerNeedChangeDirection += OnPlayerNeedChangeDirection;
		}

		private void GameStartedEvent(bool isGameStarted)
		{
			this.isGameStarted = isGameStarted;
		}

		private void OnPlayerNeedChangeDirection()
		{
			if (isGameStarted == false)
			{
				return;
			}

			MovePlayer?.Invoke(playerMoveUp ? Vector2.up : Vector2.down);
			playerMoveUp = !playerMoveUp;
		}

		public void Dispose()
		{
			if (compositeDisposable != null)
			{
				compositeDisposable.Clear();
				gameManager.PlayerNeedChangeDirection -= OnPlayerNeedChangeDirection;
			}
		}

	}

}


