using UnityEngine;
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
	private Player player;
	private Actionable actionablePlayer;
	private Actionable actionableEnemy;

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
				actionableEnemy.ExecuteAction(Actions.ROAM);
                break;
			case EnemyState.Chasing:
				Chaising();
				break;
			case EnemyState.GirlCaught:
				GetComponent<SphereCollider>().enabled = false;
				break;
			case EnemyState.StartChase: 
				TeleportToGirl();
				break;
		}
	}
	
	// for now the random walk is just the position + (100,0,100)
	private void FreeRoam(Vector3 reference, float maxRadius, float minRadius = 0) {
		//if the enemy is close enough to the end position we stop roaming
		if ( Vector3.Distance(enemy.GetPosition(), enemy.GetDestination()) < roamDistanceError) {
			movingPosition = GenerateRandomPosition(reference, maxRadius, minRadius);
			enemy.SetDestination(movingPosition);
			actionableEnemy.ExecuteAction(Actions.MOVE);
		}
	}

    private Vector3 GenerateRandomPosition(Vector3 reference, float maxRadius, float minRadius = 0) {
		Collider[] existingColliders = new Collider[0];
        Vector3 generatedPosition = Vector3.zero;
        // If the new position is an object we choose another one 
        // but only try to find a new one for MAX_ITERATIONS
		int i = 0;
		do {
			generatedPosition = GetNextRandomPos(reference, maxRadius);
			if ( Vector3.Distance(enemy.GetPosition(), generatedPosition) == Mathf.Infinity ) {
				continue;
			}

			generatedPosition.y = reference.y;
			existingColliders = Physics.OverlapSphere(generatedPosition, sphereRadius);
			if ( i > 300 ) {
				break;
			}
			i++;
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
		if ( Distance(enemy.GetPosition(), player.GetPosition()) > distanceForTeleport ) {
			Vector3 newPosition = GenerateRandomPosition(player.GetPosition(), teleportRadius + teleportRange, teleportRadius - teleportRange);
			enemy.SetDestination(newPosition);
			actionableEnemy.ExecuteAction(Actions.WARP);
		}
		actionableEnemy.ExecuteAction(Actions.CHASE);
	}

    private void Chaising() {
		enemy.SetDestination(player.GetPosition());
		actionableEnemy.ExecuteAction(Actions.MOVE);
		GetComponent<SphereCollider>().enabled = true;
	}

	/*
	private void CatchGirl() {
		if ( Distance(enemy.GetPosition(), player.GetPosition()) < catchDistance ) {
			actionablePlayer.ExecuteAction(Actions.CAUGHT);
            enemy.SetState(EnemyState.GirlCaught);
        }
    }*/

    private float Distance(Vector3 from, Vector3 to) {
        return Mathf.Sqrt((from.x - to.x) * (from.x - to.x) + (from.z - to.z) * (from.z - to.z));
    }

    public void SetPlayer(Player player) {
		this.player = player;
	}

	public void SetActionablePlayer(Actionable actionablePlayer) {
		this.actionablePlayer = actionablePlayer;
	}

	public void SetActionableEnemy(Actionable actionableEnemy) {
		this.actionableEnemy = actionableEnemy;
	}

	public void SetEnemy(Enemy enemy) {
		this.enemy = enemy;
	}

	public string GetTag() {
		return TagConstants.ENEMYAI;
	}
}
