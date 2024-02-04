using UnityEngine;

namespace GameLogic.Player
{

	public class PlayerMove
	{

		private readonly float speed;
		private readonly Transform playerTransform;

		public PlayerMove(float speed, Transform playerTransform)
		{
			this.speed = speed;
			this.playerTransform = playerTransform;
		}

		public void MoveInRandomForwardAngle(Vector2 upDownVector)
		{
			var randomAngle = Random.Range(-55f, -75f) * upDownVector.y;
			var radians = Mathf.Deg2Rad * randomAngle;

			var movement = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

			var newPosition = (Vector2)playerTransform.position + movement * speed * Time.deltaTime;

			playerTransform.position = newPosition;
		}

	}

}