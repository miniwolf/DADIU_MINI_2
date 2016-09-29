using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private GameObject player;
	private Vector3 cameraPosition;
	private float offset = 12f;
	public float cameraDelayTime = 0.5f;

	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag(TagConstants.PLAYER);
	}

	// Update is called once per frame
	void Update() {
		StartCoroutine(DelayMove());
	}

	IEnumerator DelayMove() {
		Vector3 playerPos = player.transform.position;
		
		yield return new WaitForSeconds(cameraDelayTime);
		//cameraPosition = new Vector3(player.transform.position.x - offset, offset, player.transform.position.z - offset);
		//transform.position = cameraPosition;
		transform.position = new Vector3(playerPos.x, offset, playerPos.z - offset);

	}
}