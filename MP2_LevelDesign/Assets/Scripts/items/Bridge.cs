using UnityEngine;
using System.Collections;

/// <summary>
/// This represents the bridge. Look in the BridgeCommand to see the underlying mechanics.
/// </summary>
public class Bridge : Item {
	[Tooltip("Time before broken bridge disappears")]
	public float timeForBrokenBridgeToDisappear = 2f;

	void Awake() {
		InjectionRegister.Register(this);
		TagRegister.RegisterMultiple(gameObject, TagConstants.BRIDGE);
	}

	override public string GetTag() {
		return TagConstants.BRIDGE;
	}
}
