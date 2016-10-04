using UnityEngine;

public interface ItemCommand {
	/// <summary>
	/// Called from the Start in MonoBehaviour
	/// </summary>
	void Setup(GameObject gameObject);

	/// <summary>
	/// Command to be executed
	/// </summary>
	void Execute(Collider other);
}
