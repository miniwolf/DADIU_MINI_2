using UnityEngine;
using System.Collections.Generic;

public class ItemFactory {
	Enemy enemy;
	InGameController inGameController;
	FloatingNumberInterface feedBackNumber;

	public ItemFactory() {
		inGameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<InGameController>();
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY).GetComponent<Enemy>();
		feedBackNumber = GameObject.FindGameObjectWithTag(TagConstants.FEEDBACKNUMBER).GetComponent<FloatingNumberInterface>();
	}

	public void CreateDress(Commandable dress, int thresholdSpeedUp,int thresholdChase) {
		dress.AddCommand(new DressSound());
		dress.AddCommand(new DressAction(inGameController, enemy, thresholdSpeedUp, thresholdChase));
	}

	private void CreateDressCommand(int thresholdChase, int thresholdSpeedUp) {
	}

	public void CreateBridge(Commandable bridge) {
		bridge.AddCommand(new BridgeAction(enemy));
	}

	public void CreateYellowBush(Commandable yellowBush) {
		yellowBush.AddCommand(new YellowBushAction(enemy));
	}

	public void CreateFloatingNumberFeedback(){
		feedBackNumber.SetInGameController(inGameController);
		inGameController.SetFeedback(feedBackNumber);
	}

}
