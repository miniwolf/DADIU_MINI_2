using UnityEngine;
using System.Collections;

/// <summary>
/// This represents the yellow bush. Look in the YellowBushCommand to see the underlying mechanics.
/// </summary>
public class YellowBush : Item {
	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterMultiple(gameObject, TagConstants.YELLOWBUSH);
	}

	override public string GetTag() {
		return TagConstants.YELLOWBUSH;
	}
}
