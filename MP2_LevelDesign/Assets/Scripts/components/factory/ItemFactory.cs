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
		CreateDressCommand(thresholdChase, thresholdSpeedUp);
		dress.AddCommand(new DressCommand(inGameController, enemy, thresholdSpeedUp, thresholdChase));
	}

	private void CreateDressCommand(int thresholdChase, int thresholdSpeedUp) {
		//throw new System.NotImplementedException();
	}

	public void CreateBridge(Commandable bridge) {
		bridge.AddCommand(new BridgeCommand(enemy));
	}

	public void CreateYellowBush(Commandable yellowBush) {
		yellowBush.AddCommand(new YellowBushCommand(enemy));
	}

	public void CreateFloatingNumberFeedback(){
		feedBackNumber.SetInGameController(inGameController);
		inGameController.SetFeedback(feedBackNumber);
	}

}
