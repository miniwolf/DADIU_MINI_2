using UnityEngine;
using System.Collections.Generic;

public abstract class Item : MonoBehaviour, GameEntity, Commandable {
	private List<ItemCommand> commands = new List<ItemCommand>();

	void Start() {
		Collider collider = gameObject.GetComponent<Collider>();
		if ( collider == null ) {
			Debug.LogError("This item should have a collider on it, to interact with moveable objects");
			return;
		}
		if ( !collider.isTrigger ) {
			Debug.LogError("Gameobject '" + gameObject + "' is has a collider but is not set to trigger");
		}
	}

	public void SetupComponents() {
		foreach ( ItemCommand command in commands ) {
			command.Setup(gameObject);
		}
	}

	public void OnTriggerEnter(Collider other) {
		foreach ( ItemCommand command in commands ) {
			command.Execute(other);
		}
	}

	public void AddCommand(ItemCommand command) {
		commands.Add(command);
	}

	void OnDestroy() {
		commands.Clear();
	}

	public abstract string GetTag();
}
