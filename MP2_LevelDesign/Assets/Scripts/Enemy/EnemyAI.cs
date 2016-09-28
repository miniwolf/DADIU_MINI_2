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
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
	}

	void Update () {
		switch(enemy.GetState()) {
			case EnemyState.RandomWalk:
				//enemy.GetNavMesh().Move(new Vector3(74, transform.position.y, -3));
				FreeRoam();
				break;

			case EnemyState.WalkAway:
				WalkAway();
				break;

			case EnemyState.ObstacleHit:
				enemy.GetNavMesh().Idle();
				// wait for the animation to finish 
				/*if (enemy.animation.GetBool("trigger to random walk") == true) {
					enemy.SetState(EnemyState.RandomWalk);
				}
				*/
				break;

			case EnemyState.Chasing:
				enemy.GetNavMesh().Move(player.transform.position);
				break;

			case EnemyState.GirlCaught:
				enemy.GetNavMesh().Idle();
				// wait for the animation to finish 
				/*if (enemy.animation.GetBool("trigger to walk away") == true) {
					enemy.SetState(EnemyState.WalkAway);
				}
				*/
				break;
		}
	}
	

	// for now the random walk is just the position + (10,10,0)
	private void WalkAway() {
		enemy.GetNavMesh().Move(enemy.transform.position + new Vector3(10, 10, 0));
	}

	private void FreeRoam() {
		
		if(!isRoaming) {
			Vector3 newRoamingPosition = new Vector3();
			float randomDirection = Random.Range(0.0f, 2*Mathf.PI);
			newRoamingPosition.x = transform.position.x + (roamRadius * Mathf.Sin(randomDirection)) ;
			newRoamingPosition.y = transform.position.y;
			newRoamingPosition.z = transform.position.z + (roamRadius * Mathf.Cos(randomDirection));
			movingPosition = newRoamingPosition;
			enemy.GetNavMesh().Move(movingPosition);
			isRoaming = true;
			print(transform.position+ " "+ movingPosition);
		}

		//if the enemy is close enough to the end position we stop roaming
		if(Vector3.Distance(transform.position, movingPosition) < roamDistanceError) {
			isRoaming = false;
		}

	}
}
