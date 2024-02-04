using UnityEngine;
using Cinemachine;

namespace GameLogic
{
	[ExecuteInEditMode] [SaveDuringPlay]
	public class LockCameraY : CinemachineExtension
	{
		[Tooltip("Lock the camera's Y position to this value")]
		public float yPosition = 0;
 
		protected override void PostPipelineStageCallback(
			CinemachineVirtualCameraBase vcam,
			CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
			if (stage == CinemachineCore.Stage.Body)
			{
				var pos = state.RawPosition;
				pos.y = yPosition;
				state.RawPosition = pos;
			}
		}
	}
}

