using UnityEngine;
using System.Collections.Generic;

public class ItemFactory {
	Enemy enemy;
	InGameController inGameController;
	FloatingNumberInterface feedBackNumber;

	CoroutineDelegateContainer container;

	public ItemFactory(CoroutineDelegateContainer container) {
		inGameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<InGameController>();
		enemy = GameObject.FindGameObjectWithTag(TagConstants.ENEMY).GetComponent<Enemy>();
		feedBackNumber = GameObject.FindGameObjectWithTag(TagConstants.FEEDBACKNUMBER).GetComponent<FloatingNumberInterface>();
		this.container = container;
	}

	public void CreateDress(Commandable dress) {
		dress.AddCommand(new DressSound());
		dress.AddCommand(new DressAction(inGameController, (Actionable) enemy, enemy));
	}

	private void CreateDressCommand(int thresholdChase, int thresholdSpeedUp) {
	}

	public void CreateBridge(Commandable bridge) {
		bridge.AddCommand(new BridgeAction(enemy, container, (Actionable) enemy));
	}

	public void CreateYellowBush(Commandable yellowBush) {
		yellowBush.AddCommand(new YellowBushAction(enemy, (Actionable) enemy));
	}

	public void CreateFloatingNumberFeedback(){
		feedBackNumber.SetInGameController(inGameController);
		inGameController.SetFeedback(feedBackNumber);
	}

}
