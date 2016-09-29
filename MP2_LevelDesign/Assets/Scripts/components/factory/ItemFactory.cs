using UnityEngine;
using System.Collections.Generic;

public class ItemFactory {
	Enemy enemy;
	ScoreController scoreController;
	Score score;

	public ItemFactory() {
		//score = GameObject.FindGameObjectWithTag(TagConstants.SCORE).GetComponent<Score>();
		//scoreController = GameObject.FindGameObjectWithTag(TagConstants.SCORECONTROLLER).GetComponent<ScoreController>();
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY).GetComponent<Enemy>();
		Debug.Log("2");
	}

	public void CreateDress(Commandable dress) {
		dress.AddCommand(new DressCommand(score, scoreController, enemy));
	}

	public void CreateBridge(Commandable bridge) {
		bridge.AddCommand(new BridgeCommand(enemy));
	}
}
