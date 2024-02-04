using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.BlockSpawn
{

	public class ContinuousBlocks : MonoBehaviour
	{

		[SerializeField] private GameObject blockPrefab;
		[SerializeField] private Vector2 blockYPosition;
		[SerializeField] private float minBlockLength = 1f;
		[SerializeField] private float maxBlockLength = 3f;
		[SerializeField] private float minDistance = 1f;
		[SerializeField] private float maxDistance = 3f;

		private readonly List<GameObject> blocks = new();
		private float lastCameraX;
		private float screenWidth;
		private Camera mainCamera;

		private void Start()
		{
			mainCamera = Camera.main;
			
			screenWidth = GetScreenWidth();

			if (mainCamera != null)
			{
				lastCameraX = mainCamera.transform.position.x;
			}

			GenerateBlocks();
		}

		private void Update()
		{
			if (mainCamera == null || blocks.Count == 0)
			{
				return;
			}

			var cameraX = mainCamera.transform.position.x;

			var distanceMoved = cameraX - lastCameraX;
			
			var leftmostBlock = blocks[0];
			var leftmostBlockLength = leftmostBlock.transform.localScale.x;
			var leftmostBlockPosition = leftmostBlock.transform.position;

			if (distanceMoved > 0 &&
			    leftmostBlockPosition.x + leftmostBlockLength / 2 < lastCameraX - screenWidth / 2 + minDistance)
			{
				leftmostBlockPosition.x += screenWidth + minDistance;
				leftmostBlock.transform.position = leftmostBlockPosition;
				
				blocks.RemoveAt(0);
				blocks.Add(leftmostBlock);
			}

			lastCameraX = cameraX;
		}
		
		private float GetScreenWidth()
		{
			if (mainCamera != null)
			{
				var cameraHeight = mainCamera.orthographicSize * 2f;
				var cameraWidth = cameraHeight * mainCamera.aspect;

				return cameraWidth;
			}

			return 0;
		}

		private void GenerateBlocks()
		{
			var leftBoundary = lastCameraX - screenWidth / 2;
			var rightBoundary = lastCameraX + screenWidth / 2;

			var nextBlockPosition = leftBoundary;

			while (nextBlockPosition < rightBoundary)
			{
				var blockLength = Random.Range(minBlockLength, maxBlockLength);
				var distance = Random.Range(minDistance, maxDistance);

				var blockPosition = new Vector3(nextBlockPosition + blockLength / 2, blockYPosition.y, 0);

				var newBlock = Instantiate(blockPrefab, blockPosition, Quaternion.identity);
				newBlock.transform.SetParent(transform);
				newBlock.transform.localScale = new Vector3(blockLength, newBlock.transform.localScale.y, 1f);

				blocks.Add(newBlock);

				nextBlockPosition += blockLength + distance;
			}
		}

	}

}