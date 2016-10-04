using UnityEngine;
using System.Collections;

public class FootStepsSound : MonoBehaviour {
	//public Collider Foot1;
	//public Collider Foot2;
	public string eventName;


	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Ground") {
			AkSoundEngine.PostEvent("auntieFootsteps ", this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
