using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public float roamRadius;
	public float teleportRadius;
	public float roamDistanceError;
	public float distanceForTeleport;
	public float sphereRadius;
	static private int MAX_ITERATIONS = 10;
	private Enemy enemy;
	private GameObject player;
	private bool isRoaming;
	private bool teleport;
	Vector3 movingPosition;

	void Start () {
		roamRadius = 15.0f;
		teleportRadius = 25f;
		roamDistanceError = 0.5f;
		distanceForTeleport = 50f;
		sphereRadius = 0.5f;
		movingPosition = transform.position;
		player = GameObject.FindGameObjectWithTag(TagConstants.PLAYER);
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY).GetComponent<Enemy>();
	}

	void Update () {
		switch(enemy.GetState()) {
		case EnemyState.RandomWalk:
				FreeRoam();
				break;

			case EnemyState.WalkAway:
				WalkAway();
				break;

			case EnemyState.ObstacleHit: //hit yellow bush
				StartCoroutine(enemy.GetNavMesh().SlowDown());
				// if it was chasing the girl it stops now
				enemy.SetState(EnemyState.RandomWalk);
				FreeRoam(); 
				teleport = false;
				break;

			case EnemyState.Chasing:
				isRoaming = false;
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
	private void WalkAway() {
		enemy.GetNavMesh().Move(enemy.GetPosition() + new Vector3(10, 0, 10));
	}
	
	 private void FreeRoam() {
		if(!isRoaming) {
			Collider [] existingColliders;
			// If the new position is an object we choose another one 
			// but only try to find a new one for MAX_ITERATIONS
			for(int i = 0; i < MAX_ITERATIONS; i++) { 
				movingPosition = GetNextRandomPos(enemy.GetPosition(), roamRadius);
				existingColliders = Physics.OverlapSphere(movingPosition, sphereRadius);
				// no colliders in the sphere means no object in that position
				if(existingColliders.Length == 0) {						
					break;
				}
			}
			enemy.GetNavMesh().Move(movingPosition);
			isRoaming = true;
		}

		//if the enemy is close enough to the end position we stop roaming
		if(Vector3.Distance(enemy.GetPosition(), movingPosition) < roamDistanceError) {
			isRoaming = false;
		}
	}

	private Vector3 GetNextRandomPos(Vector3 referencePosition, float radius) {
		Vector3 newRandomPosition = new Vector3();
		float randomDirection = Random.Range(0.0f, 2*Mathf.PI);
		newRandomPosition.x = referencePosition.x + (radius * Mathf.Sin(randomDirection)) ;
		newRandomPosition.y = referencePosition.y;
		newRandomPosition.z = referencePosition.z + (radius * Mathf.Cos(randomDirection));
		return newRandomPosition;
	}

	private void Chaising() {
		// check if the troll is far away when the girl picks up laundry for the first time
		if (!teleport) {
			if(Vector3.Distance(enemy.GetPosition(), player.transform.position) > distanceForTeleport) {
				Vector3 newPosition = GetNextRandomPos(player.transform.position, teleportRadius);
				enemy.SetPosition(newPosition);
			}
			teleport = true;
		}
			
		enemy.GetNavMesh().Move(player.transform.position);
	}
}
