using UnityEngine;
using System.Collections.Generic;

public class ItemFactory {
	Enemy enemy;
	ScoreController scoreController;
	Score score;

	void Awake() {
		score = GameObject.FindGameObjectWithTag(TagConstants.SCORE).GetComponent<Score>();
		scoreController = GameObject.FindGameObjectWithTag(TagConstants.SCORECONTROLLER).GetComponent<ScoreController>();
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY).GetComponent<Enemy>();
	}

	public void CreateDress(Commandable dress) {
		dress.AddCommand(new DressCommand(score, scoreController));
	}

	public void CreateBridge(Commandable bridge) {
		bridge.AddCommand(new BridgeCommand(enemy));
	}
}
