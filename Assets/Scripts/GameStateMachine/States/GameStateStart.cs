using UnityEngine;
using Zenject;

namespace GameStateMachine.States
{

	public class GameStateStart : GameStateEntity
	{

		public override void Start()
		{
			Debug.Log("Start game state started");
		}

		public override void Initialize()
		{

		}

		public override void Tick()
		{
		}

		public override void Dispose()
		{

		}
		
		public class Factory : PlaceholderFactory<GameStateStart>
		{
		}
	}

}