using UnityEngine;
using System.Collections;

public class MakeDressLookAtCam : MonoBehaviour {

	GameObject cam;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag(TagConstants.CAMERA);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (new Vector3(cam.transform.position.x,transform.rotation.y,cam.transform.position.z));
		transform.Rotate (new Vector3(0,180f,0));
	}
}
