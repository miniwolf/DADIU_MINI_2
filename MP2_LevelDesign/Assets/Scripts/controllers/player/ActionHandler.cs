using UnityEngine;
using System.Collections.Generic;

public class ActionHandler : Handler {
	protected List<Action> actions = new List<Action>();

	public void SetupComponents(GameObject obj) {
		foreach ( ItemCommand command in actions ) {
			command.Setup(obj);
		}
	}

	public virtual void DoAction() {
		foreach ( Action action in actions ) {
			action.Execute();
		}
	}

	public void AddAction(Action action) {
		actions.Add(action);
	}
}
