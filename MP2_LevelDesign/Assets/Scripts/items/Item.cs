using UnityEngine;
using System.Collections.Generic;

public abstract class Item : MonoBehaviour, GameEntity, Commandable {
	private List<ItemCommand> commands = new List<ItemCommand>();

	void Start() {
		if ( gameObject.GetComponent<Collider>() == null ) {
			Debug.LogError("This item should have a collider on it, to interact with moveable objects");
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

	public abstract string GetTag();
}
