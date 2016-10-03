using UnityEngine;
using System.Collections;

public interface Player {
	void SetState(PlayerState state);
	PlayerState GetState();
    Vector3 GetPosition();
    void GetCaught();
}
