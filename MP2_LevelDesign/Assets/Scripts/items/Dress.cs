using UnityEngine;
using System.Collections;

public class Dress : Item {
	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterMultiple(gameObject, TagConstants.DRESS);
	}

	override public string GetTag() {
		return TagConstants.DRESS;
	}
}
