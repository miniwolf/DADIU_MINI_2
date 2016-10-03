using UnityEngine;
using System.Collections;

public class EnemyAnimControllerImpl : EnemyAnimController {

	private Animator animator;

	public EnemyAnimControllerImpl(Animator animator) {
		this.animator = animator;
	}

	public void CatchGirl(Enemy enemy) {

		/*if (enemy.animation.GetBool("trigger saying that animation is finished") == true) {
			enemy.SetState(EnemyState.WalkAway);
		}
		*/
	}

	public void HitObstacle(GameObject obstacle) {
		/*if (enemy.animation.GetBool("trigger to random walk") == true) {
						enemy.SetState(EnemyState.RandomWalk);
		}
		*/
	}

	public void Move(Vector3 moveTo) {
	
	}

    public void Idle() {

    }

    public void Resume() {

    }



}
