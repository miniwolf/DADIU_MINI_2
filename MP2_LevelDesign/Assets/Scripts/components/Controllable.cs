using UnityEngine;

public interface Controllable {
	void AddController(Controller controller);
	void MoveTo(Vector3 target);
}
