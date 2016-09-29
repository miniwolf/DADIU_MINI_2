using UnityEngine;
using System.Collections;

/// <summary>
/// This represents the bridge. Look in the BridgeCommand to see the underlying mechanics.
/// </summary>
public class Bridge : Item {
	public Bridge() {
		InjectionRegister.Register(this);
		TagRegister.Register(gameObject, TagConstants.BRIDGE);
	}

	override public string GetTag() {
		return TagConstants.BRIDGE;
	}
}
