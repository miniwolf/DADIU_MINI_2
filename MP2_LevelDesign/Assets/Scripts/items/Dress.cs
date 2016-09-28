using UnityEngine;
using System.Collections;

public class Dress : Item {
	public Dress() {
		InjectionRegister.Register(this);
		TagRegister.Register(gameObject, TagConstants.DRESS);
	}

	override public string GetTag() {
		return TagConstants.DRESS;
	}
}
