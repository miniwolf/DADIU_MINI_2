using UnityEngine;
using System.Collections.Generic;

public class MouseMove : ActionHandler {
	private Player player;
	private Camera camera;
	private LayerMask layerMask;
	private RaycastHit hit;
	private Ray cameraToGround;

	public MouseMove(Player player) {
		this.player = player;
	}

	public override void DoAction() {
		cameraToGround = camera.ScreenPointToRay(Input.mousePosition);
		if ( Physics.Raycast(cameraToGround, out hit, 500f, layerMask.value) ) {
			foreach ( MoveActionImpl action in actions ) {
				action.Execute(Input.mousePosition);
			}
		}
	}
}
