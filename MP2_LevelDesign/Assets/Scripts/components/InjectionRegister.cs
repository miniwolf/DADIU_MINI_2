using UnityEngine;
using System.Collections.Generic;

public class InjectionRegister : MonoBehaviour {
	private static List<GameEntity> components = new List<GameEntity>();
	private ControllableFactory controllableFactory = new ControllableFactory();
	private ItemFactory itemFactory = new ItemFactory();

	// Use this for initialization
	void Start() {
		InitializeComponents();
	}

	public static void Register(GameEntity component) {
		components.Add(component);
	}

	private void InitializeComponents() {
		foreach ( GameEntity component in components ) {
			InitializeComponent(component);
		}
	}

	private void InitializeComponent(GameEntity component) {
		switch ( component.GetTag() ) {
			case TagConstants.PLAYER:
				controllableFactory.CreatePlayer((Controllable) component);
				break;
			case TagConstants.ENEMY:
				controllableFactory.CreateEnemy((Controllable) component);
				break;
			case TagConstants.DRESS:
				itemFactory.CreateDress((Commandable) component);
				break;
			case TagConstants.BRIDGE:
				itemFactory.CreateBridge((Commandable) component);
				break;
		}
	}
}

