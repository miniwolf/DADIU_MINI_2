using UnityEngine;
using System.Collections;

public interface Player {
	void SetState(PlayerState state);
	PlayerState GetState();
	Life GetLife();
}
