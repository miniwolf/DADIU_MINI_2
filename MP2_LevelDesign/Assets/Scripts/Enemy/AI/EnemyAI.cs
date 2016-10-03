﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour, AI, GameEntity {
	public float roamRadius = 15.0f;
    public float teleportRadius = 25f;
    public float teleportRange = 5f;
    public float roamDistanceError = 0.5f;
    public float distanceForTeleport = 50f;
    public float catchDistance = 5f;
    public float sphereRadius = 10f;       // radius around a point to check is is collision
	public float walkAwayDistance = 30f;

	private Enemy enemy;
	private Controllable controllableEnemy;
	private Player player;
	private bool isRoaming;
	private Vector3 movingPosition;

    void Awake() {
        InjectionRegister.Register(this);
    }

    public void SetupComponents() {
		movingPosition = enemy.GetPosition();
	}

	void Update() {
		if ( enemy == null ) {
			return;
		}
		switch ( enemy.GetState() ) {
			case EnemyState.RandomWalk:
				FreeRoam(enemy.GetPosition(), roamRadius);
                break;
			case EnemyState.WalkAway:
				FreeRoam(player.GetPosition(), 2 * walkAwayDistance, walkAwayDistance);
				enemy.SetState(EnemyState.RandomWalk);
                break;
			case EnemyState.Chasing:
				Chaising();
				break;
			case EnemyState.GirlCaught:
                GirlCaught();
				// call animation controller of enemy and caught girl that would change the state to WalkAway when it's finished
				//enemy.GetAnimController().CatchGirl(enemy);
				break;
			case EnemyState.CatchGirl:
				TeleportToGirl();
				break;
		}
	}
	
	// for now the random walk is just the position + (100,0,100)
	private void FreeRoam(Vector3 reference, float maxRadius, float minRadius = 0) {
		if ( !isRoaming ) {
            movingPosition = GenerateRandomPosition(reference, maxRadius, minRadius);
			controllableEnemy.MoveTo(movingPosition);
			isRoaming = true;
		}
		//if the enemy is close enough to the end position we stop roaming
		if ( Vector3.Distance(enemy.GetPosition(), movingPosition) < roamDistanceError ) {
			isRoaming = false;
		}
	}

    private Vector3 GenerateRandomPosition(Vector3 reference, float maxRadius, float minRadius = 0) {
		Collider[] existingColliders = new Collider[0];
        Vector3 generatedPosition = Vector3.zero;
        // If the new position is an object we choose another one 
        // but only try to find a new one for MAX_ITERATIONS
		do {
			generatedPosition = GetNextRandomPos(reference, maxRadius);
			if ( Vector3.Distance(enemy.GetPosition(), generatedPosition) == Mathf.Infinity ) {
				continue;
			}

			generatedPosition.y = reference.y;
			existingColliders = Physics.OverlapSphere(generatedPosition, sphereRadius);
		} while ( existingColliders.Length != 0
		          || Vector3.Distance(reference, generatedPosition) > maxRadius
		          || Vector3.Distance(reference, generatedPosition) < minRadius );
        return generatedPosition;
    }

	private Vector3 GetNextRandomPos(Vector3 referencePosition, float radius) {
		NavMeshHit hit;
        Vector3 randomPoint = referencePosition + Random.insideUnitSphere * radius;
        NavMesh.SamplePosition(randomPoint, out hit, radius, NavMesh.AllAreas);
        return hit.position;
	}

	private void TeleportToGirl() {
		// check if the troll is far away when the girl picks up laundry for the first time
		if ( Vector3.Distance(enemy.GetPosition(), player.GetPosition()) > distanceForTeleport ) {
			Vector3 newPosition = GenerateRandomPosition(player.GetPosition(), teleportRadius + teleportRange, teleportRadius - teleportRange);
			enemy.Warp(newPosition);
		}
		enemy.SetState(EnemyState.Chasing);
	}

    private void Chaising() {
		controllableEnemy.MoveTo(player.GetPosition());
	}

    private void CatchGirl() {
        if (Vector3.Distance(enemy.GetPosition(), player.GetPosition()) < catchDistance) {
            player.GetCaught();
            enemy.SetState(EnemyState.GirlCaught);
        }
    }

    private void GirlCaught() {
        if (Input.GetKeyDown(KeyCode.R)) {
            enemy.SetState(EnemyState.WalkAway);
        }
    }

    public void SetPlayer(Player player) {
		this.player = player;
	}

	public void SetEnemy(Enemy enemy) {
		this.enemy = enemy;
	}

	public void SetControllable(Controllable controllableEnemy) {
		this.controllableEnemy = controllableEnemy;
	}

	public string GetTag() {
		return TagConstants.ENEMYAI;
	}
}
