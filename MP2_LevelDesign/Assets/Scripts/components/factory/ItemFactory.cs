using UnityEngine;
using System.Collections.Generic;

public class ItemFactory {
	Enemy enemy;
	InGameController inGameController;

	public ItemFactory() {
		inGameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<InGameController>();
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY).GetComponent<Enemy>();
	}

	public void CreateDress(Commandable dress) {
		dress.AddCommand(new DressCommand(inGameController, enemy)); // todo uncomment and connect to InGameController
	}

	public void CreateBridge(Commandable bridge) {
		bridge.AddCommand(new BridgeCommand(enemy));
	}

	public void CreateYellowBush(Commandable yellowBush) {
		yellowBush.AddCommand(new YellowBushCommand(enemy));
	}
}
