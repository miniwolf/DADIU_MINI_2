using UnityEngine;

public class TouchMove : ActionHandler {
	private Camera camera;
	private LayerMask layerMask;
	private RaycastHit hit;
	private Ray cameraToGround;

	public override void DoAction() {
		foreach ( Touch touch in Input.touches ) {
			cameraToGround = camera.ScreenPointToRay(touch.position);
			if ( Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value) ) {
				foreach ( MoveActionImpl action in actions ) {
					action.Execute(touch.position);
				}
			}
		}
	}
}
