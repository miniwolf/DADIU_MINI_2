using UnityEngine;
using System.Collections;

public class FogColorZone : MonoBehaviour {
	public Color fogColor = Color.white;
	public float fogChangeDuration = 1;
	public Color rimColor = Color.white;





	void OnDrawGizmos () {
		BoxCollider box = GetComponent<BoxCollider>();

		Gizmos.DrawWireCube(box.bounds.center, box.bounds.size);
	}
}
