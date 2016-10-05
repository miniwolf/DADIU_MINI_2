using UnityEngine;
using System.Collections.Generic;

public class MouseMove : ActionHandler {
	private Camera camera;
	private LayerMask layerMask = 1 << LayerConstants.GroundLayer;
	private RaycastHit hit;
	private Ray cameraToGround;

	private List<MoveAction> moveActions = new List<MoveAction>();

	public MouseMove(Camera camera) {
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
		if ( Input.GetMouseButtonDown(0) ) {	
			cameraToGround = camera.ScreenPointToRay(Input.mousePosition);
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
