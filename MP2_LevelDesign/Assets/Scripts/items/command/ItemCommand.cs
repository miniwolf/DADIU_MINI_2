using UnityEngine;

interface ItemCommand {
	/// <summary>
	/// Command to be executed
	/// </summary>
	void Execute(Collision other);
}
