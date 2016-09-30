using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour, AI, GameEntity {
	public float roamRadius = 15.0f;
    public float teleportRadius = 25f;
    public float teleportRange = 5f;
    public float roamDistanceError = 0.5f;
	public float distanceForTeleport = 50f;
	public float sphereRadius = 0.5f;       // radius around a point to check is is collision
	public float walkAwayDistance = 30f;

	private static int MAX_ITERATIONS = 30;
	private Enemy enemy;
	private GameObject player;
	private bool isRoaming;
	private bool teleport;
	private Vector3 movingPosition;

    void Awake() {
        InjectionRegister.Register(this);
        teleport = false;
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
                teleport = false;
                break;
			case EnemyState.WalkAway:
				enemy.SetState(EnemyState.RandomWalk);
				FreeRoam(player.transform.position, 2 * walkAwayDistance, walkAwayDistance);
                teleport = false;
                break;
			case EnemyState.ObstacleHit: //hit yellow bush
				StartCoroutine(enemy.GetNavMesh().SlowDown());
				// if it was chasing the girl it stops now
				enemy.SetState(EnemyState.RandomWalk);
				FreeRoam(enemy.GetPosition(), roamRadius); 
				teleport = false;
				break;
			case EnemyState.Chasing:
				Chaising();
				break;
			case EnemyState.GirlCaught:
				teleport = false;
				// call animation controller of enemy and caught girl that would change the state to WalkAway when it's finished
				//enemy.GetAnimController().CatchGirl(enemy);
				break;
		}
	}
	
	// for now the random walk is just the position + (100,0,100)
	private void FreeRoam(Vector3 reference, float maxRadius, float minRadius = 0) {
		if ( !isRoaming ) {
            movingPosition = GenerateRandomPosition(reference, maxRadius, minRadius);
            enemy.GetNavMesh().Move(movingPosition);
			isRoaming = true;
		}
		//if the enemy is close enough to the end position we stop roaming
		if ( Vector3.Distance(enemy.GetPosition(), movingPosition) < roamDistanceError ) {
			isRoaming = false;
		}
	}

    private Vector3 GenerateRandomPosition(Vector3 reference, float maxRadius, float minRadius = 0) {
        Collider[] existingColliders;
        Vector3 generatedPosition = Vector3.zero;
        // If the new position is an object we choose another one 
        // but only try to find a new one for MAX_ITERATIONS
        for (int i = 0; i < MAX_ITERATIONS; i++) {
            generatedPosition = GetNextRandomPos(reference, maxRadius);
            if(Distance(enemy.GetPosition(), generatedPosition) == Mathf.Infinity) {
                continue;
            }
            generatedPosition.y = reference.y;
            existingColliders = Physics.OverlapSphere(generatedPosition, sphereRadius);
            // no colliders in the sphere means no object in that position
            if (existingColliders.Length != 0) {
                continue;
            }
            if (Distance(reference, generatedPosition) > maxRadius 
                || Distance(reference,  generatedPosition) < minRadius) {
                continue;
            }
        }
        return generatedPosition;
    }

	private Vector3 GetNextRandomPos(Vector3 referencePosition, float radius) {
		NavMeshHit hit;
        Vector3 randomPoint = referencePosition + Random.insideUnitSphere * radius;
        NavMesh.SamplePosition(randomPoint, out hit, radius, NavMesh.AllAreas);
		return hit.position;
	}

    private float Distance(Vector3 v1, Vector3 v2) {
        return (Mathf.Sqrt(Mathf.Pow(Mathf.Abs(v1.x - v2.x), 2f) + Mathf.Pow(Mathf.Abs(v1.z - v2.z), 2f)));
    }

    private void Chaising() {
		// check if the troll is far away when the girl picks up laundry for the first time
		if ( !teleport ) {
            isRoaming = false;
            if ( Distance(enemy.GetPosition(), player.transform.position) > distanceForTeleport ) {
                Vector3 newPosition = GenerateRandomPosition(player.transform.position, teleportRadius + teleportRange, teleportRadius - teleportRange);
                enemy.GetNavMesh().Teleport(newPosition);
            }
			teleport = true;
		}
			
		enemy.GetNavMesh().Move(player.transform.position);
	}

	public void SetPlayer(GameObject player) {
		this.player = player;
	}

	public void SetEnemy(Enemy enemy) {
		this.enemy = enemy;
	}

	public string GetTag() {
		return TagConstants.ENEMYAI;
	}
}
