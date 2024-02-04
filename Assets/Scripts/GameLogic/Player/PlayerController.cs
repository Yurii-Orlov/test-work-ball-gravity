using Managers;
using UniRx;
using UnityEngine;
using Zenject;

namespace GameLogic.Player
{
	public class PlayerController : MonoBehaviour
	{

		private PlayerModel model;
		private PlayerInput input;
		private PlayerMove move;

		private GameManager gameManager;
		private Vector2 moveVector;
		private bool isGamePaused;

		[Inject]
		public void Init(GameManager gameManager)
		{
			this.gameManager = gameManager;
			this.gameManager.IsGamePaused.ObserveEveryValueChanged(x => x.Value).Subscribe(xs => isGamePaused = xs).AddTo(this);
			
			model = new PlayerModel()
			{
				IsDead = false,
				Speed = 5
			};
			input = new PlayerInput(gameManager);
			move = new PlayerMove(model.Speed, transform);
			
			input.MovePlayer += InputOnMovePlayer;
		}
		
		private void Update()
		{
			if (moveVector.y != 0 && isGamePaused == false)
			{
				move.MoveInRandomForwardAngle(moveVector);
			}
		}

		private void InputOnMovePlayer(Vector2 vectorToMove)
		{
			moveVector = vectorToMove;
		}

		private void OnDestroy()
		{
			if (input != null)
			{
				input.Dispose();
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Block"))
			{
				moveVector = Vector2.zero;
			}
			
			if (other.CompareTag("Lose"))
			{
				moveVector = Vector2.zero;
				gameManager.LoseGame();
			}
		}

	}
}


