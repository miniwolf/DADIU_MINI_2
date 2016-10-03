using UnityEngine;
using System.Collections.Generic;

public class ItemFactory {
	Enemy enemy;
	InGameController inGameController;
	Value feedBackNumber;

	public ItemFactory() {
		inGameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<InGameController>();
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY).GetComponent<Enemy>();
		feedBackNumber = GameObject.FindGameObjectWithTag(TagConstants.FEEDBACKNUMBER).GetComponent<Value>();
	}

	public void CreateDress(Commandable dress, int thresholdSpeedUp) {
		dress.AddCommand(new DressCommand(inGameController, enemy, feedBackNumber, thresholdSpeedUp));
	}

	public void CreateBridge(Commandable bridge) {
		bridge.AddCommand(new BridgeCommand(enemy));
	}

	public void CreateYellowBush(Commandable yellowBush) {
		yellowBush.AddCommand(new YellowBushCommand(enemy));
	}
}
