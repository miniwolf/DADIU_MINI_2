using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private Enemy enemy;
	private Player player;
	public float roamRadius;
	private bool isRoaming;
	Vector3 movingPosition;

	void Start () {
		roamRadius = 15.0f;
		movingPosition = transform.position;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
	}

	void Update () {
		switch(enemy.GetState()) {
			case EnemyState.RandomWalk:
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
			Vector3 randomDirection = Random.insideUnitSphere * roamRadius + enemy.transform.position;
			NavMeshHit hit;
			NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
			movingPosition = hit.position;
			movingPosition.y = enemy.transform.position.y;
			enemy.GetNavMesh().Move(movingPosition);
			isRoaming = true;
			print(enemy.transform.position+ " "+ movingPosition);
		}

		//if the enemy is close enough to the end position we stop roaming
		if(Vector3.Distance(transform.position, movingPosition) < 0.07f) {
			isRoaming = false;
		}

	}
}
