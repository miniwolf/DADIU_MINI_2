using UnityEngine;
using System.Collections;

public class NavMeshController : Controller {
	private NavMeshAgent agent;
	private NavMeshPath path = new NavMeshPath();
	private float slowdown = 1.5f;
	private int slowdownTime = 3;
	private float speedup = 1.5f;
	private float maxSpeedOnTroll = 0;

	public NavMeshController(NavMeshAgent agent) {
		this.agent = agent;
		this.maxSpeedOnTroll = 8000f;
	}

	public NavMeshController(NavMeshAgent agent, float maxSpeedOnTroll) {
		this.agent = agent;
		this.maxSpeedOnTroll = maxSpeedOnTroll;
	}

	/// <summary>
	/// We move the agent by using the NavMeshAgent given in the constructor
	/// </summary>
	/// <param name="moveTo">Move to.</param>
	public void Move(Vector3 moveTo) {
		agent.SetDestination(moveTo);
/*		if(agent.CalculatePath(moveTo,path)){
			agent.SetPath(path);
		}*/
	}

    /// <summary>
    /// Stopping the agent from moving
    /// </summary>
    public void Idle() {
        agent.Stop();
    }

    public void Resume() {
        agent.SetDestination(agent.transform.position);
        agent.Resume();
    }

    public void Teleport(Vector3 position) {
        agent.Warp(position);
    }

    public void HitObstacle(GameObject obstacle) {
		//Do stun or smth
	}
	
	public IEnumerator SlowDown() {
		agent.speed -= slowdown;
		yield return new WaitForSeconds(slowdownTime);
		agent.speed += slowdown;
	}

	public void SpeedUp() {
		if (agent.speed < maxSpeedOnTroll) {
			agent.speed += speedup;
		}
	}
}