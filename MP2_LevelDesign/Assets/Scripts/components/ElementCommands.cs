using UnityEngine;
using System.Collections.Generic;

public class ElementCommands : MonoBehaviour, MovableCommandable {
	List<MovableCommand> commands = new List<MovableCommand>();

	public void OnTriggerEnter(Collider other) {
		foreach ( MovableCommand command in commands ) {
			command.Execute(other);
		}
	}

	public void AddCommand(MovableCommand command) {
		commands.Add(command);
	}
}

