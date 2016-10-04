using UnityEngine;

public interface Handler {
	void SetupComponents(GameObject obj);
	void AddAction(Action action);
	void DoAction();
}
