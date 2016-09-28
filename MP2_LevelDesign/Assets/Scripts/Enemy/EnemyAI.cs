using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private Enemy enemy;
	private GameObject player;
	public float roamRadius;
	public float roamDistanceError;
	private bool isRoaming;
	Vector3 movingPosition;

	void Start () {
		roamRadius = 15.0f;
		roamDistanceError = 2.5f;
		movingPosition = transform.position;
		player = GameObject.FindGameObjectWithTag(TagConstants.PLAYER);
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY).GetComponent<Enemy>();
	}

	void Update () {
		switch(enemy.GetState()) {
			case EnemyState.RandomWalk:
				//enemy.GetNavMesh().Move(new Vector3(22, transform.position.y, 17));
				FreeRoam();
				break;

			case EnemyState.WalkAway:
				WalkAway();
				break;

			case EnemyState.ObstacleHit:
				StartCoroutine(enemy.GetNavMesh().SlowDown());
				enemy.SetState(EnemyState.RandomWalk);
				FreeRoam();
				break;

			case EnemyState.Chasing:
				enemy.GetNavMesh().Move(player.transform.position);
				break;

			case EnemyState.GirlCaught:
				// call animation controller of enemy and caught girl that would change the state to WalkAway
				//enemy.GetAnimController().CatchGirl(enemy);
				break;
		}
	}
	

	// for now the random walk is just the position + (100,0,100)
	private void WalkAway() {
		enemy.GetNavMesh().Move(enemy.GetPosition() + new Vector3(10, 10, 0));
	}
	
	 private void FreeRoam() {
		if(!isRoaming) {
			Collider [] existingColliders;

			for(int i = 0; i < 10; i++) { 
				movingPosition = GetNextRoamingPos();
				existingColliders = Physics.OverlapSphere(movingPosition, 1f);

				if(existingColliders.Length == 0) {
					Debug.Log("iterations: " + i);							
					break;
				}
			}
			enemy.GetNavMesh().Move(movingPosition);
			isRoaming = true;
			//print(transform.position+ " "+ movingPosition);
		}

		//if the enemy is close enough to the end position we stop roaming
		if(Vector3.Distance(transform.position, movingPosition) < roamDistanceError) {
			isRoaming = false;
		}
	}
	 
	private Vector3 GetNextRoamingPos() {
		Vector3 newRoamingPosition = new Vector3();
		float randomDirection = Random.Range(0.0f, 2*Mathf.PI);
		newRoamingPosition.x = transform.position.x + (roamRadius * Mathf.Sin(randomDirection)) ;
		newRoamingPosition.y = transform.position.y;
		newRoamingPosition.z = transform.position.z + (roamRadius * Mathf.Cos(randomDirection));
		return newRoamingPosition;
	}
}
