using UnityEngine;
using System.Collections;

public class Dress : Item {
	void Awake() {
		InjectionRegister.Register(this);
		//TagRegister.Register(gameObject, TagConstants.DRESS);
	}

	override public string GetTag() {
		return TagConstants.DRESS;
	}

	public void OnTriggerEnter(Collider other) {
		base.OnTriggerEnter(other);
	}
}
