using UnityEngine;
using System.Collections.Generic;

public interface MovableCommand {
	void Execute(Collider other);
}

