using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	private ItemCommand command;

	public Item(ItemCommand command) {
		this.command = command;
	}

	void Start() {
		if ( gameObject.GetComponent<Collider>() == null ) {
			Debug.LogError("This item should have a collider on it, to interact with moveable objects");
		}
		command.Setup(gameObject);
	}

	void OnCollisionEnter(Collision other) {
		command.Execute(other);
	}
}
