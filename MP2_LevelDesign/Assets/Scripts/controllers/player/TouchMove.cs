using UnityEngine;
using System.Collections.Generic;

public class TouchMove : ActionHandler {
	private Camera camera;
	private LayerMask layerMask = 1 << LayerConstants.GroundLayer;
	private RaycastHit hit;
	private Ray cameraToGround;

	private List<MoveAction> moveActions = new List<MoveAction>();

	public TouchMove(Camera camera) {
		this.camera = camera;
	}

	public override void SetupComponents(GameObject obj) {
		foreach ( MoveAction action in moveActions ) {
			action.Setup(obj);
		}
		base.SetupComponents(obj);
	}

	public void AddMoveAction(MoveAction action) {
		moveActions.Add(action);
	}

	public override void DoAction() {
		foreach ( Touch touch in Input.touches ) {
			cameraToGround = camera.ScreenPointToRay(touch.position);
			if ( Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value) ) {
				foreach ( MoveAction action in moveActions ) {
					action.Execute(hit.point);
				}
				foreach ( Action action in actions ) {
					action.Execute();
				}
			}
		}
	}
}
