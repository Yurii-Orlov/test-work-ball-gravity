using Managers;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace GameLogic.Player
{
	public class PlayerController : MonoBehaviour
	{

		private PlayerModel model;
		private PlayerInput input;

		private GameManager gameManager;
		private float speed = 5f;
		private Vector2 moveVector;
		private bool isGamePaused;

		[Inject]
		public void Init(GameManager gameManager)
		{
			this.gameManager = gameManager;
			this.gameManager.IsGamePaused.ObserveEveryValueChanged(x => x.Value).Subscribe(xs => isGamePaused = xs).AddTo(this);
			
			model = new PlayerModel();
			input = new PlayerInput(gameManager);
			
			input.MovePlayer += InputOnMovePlayer;
		}
		
		private void Update()
		{
			if (moveVector.y != 0 && isGamePaused == false)
			{
				MoveInRandomDirection();
			}
		}

		private void InputOnMovePlayer(Vector2 vectorToMove)
		{
			moveVector = vectorToMove;
		}

		private void MoveInRandomDirection()
		{
			var randomAngle = Random.Range(-55f, -75f) * moveVector.y;
			var radians = Mathf.Deg2Rad * randomAngle;

			var movement = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
			var playerTransform = transform;
			var newPosition = (Vector2)playerTransform.position + movement * speed * Time.deltaTime;

			playerTransform.position = newPosition;
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


