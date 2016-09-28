using UnityEngine;
using System.Collections.Generic;

public class ItemFactory {
	GameObject enemy, score, scoreController;

	public ItemFactory() {
		score = GameObject.FindGameObjectWithTag(TagConstants.SCORE);
		scoreController = GameObject.FindGameObjectWithTag(TagConstants.SCORECONTROLLER);
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY);
	}

	public void CreateDress(Commandable dress) {
		dress.AddCommand(new DressCommand(score, scoreController));
	}

	public void CreateBridge(Commandable bridge) {
		bridge.AddCommand(new BridgeCommand(enemy));
	}
}
