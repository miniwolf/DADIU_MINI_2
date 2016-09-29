using UnityEngine;
using System.Collections;

public class IsGroundLayered : MonoBehaviour {

	void Awake(){
		if (gameObject.layer != LayerConstants.GroundLayer) {
			Debug.LogError(gameObject.name + " is missing the layer GroundLayer, on position 8");
		}
	}
}
