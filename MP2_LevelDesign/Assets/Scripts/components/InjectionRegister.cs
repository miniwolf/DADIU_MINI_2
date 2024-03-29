﻿using UnityEngine;
using System.Collections.Generic;

public class InjectionRegister : MonoBehaviour {
	private static List<GameEntity> components = new List<GameEntity>();
	private ControllableFactory controllableFactory;
	private ItemFactory itemFactory;

	void Awake() {
		controllableFactory = new ControllableFactory();
		itemFactory = new ItemFactory();
	}

	// Use this for initialization
	void Start() {
		InitializeComponents();
	}

	void OnDestroy() {
		components.Clear();
	}

	public static void Register(GameEntity component) {
		components.Add(component);
	}

	private void InitializeComponents() {
		foreach ( GameEntity component in components ) {
			InitializeComponent(component);
			component.SetupComponents();
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
			case TagConstants.ENEMYAI:
				controllableFactory.CreateEnemyAI((AI) component);
				break;
			case TagConstants.DRESS:
				itemFactory.CreateDress((Commandable) component);
				break;
			case TagConstants.BRIDGE:
				itemFactory.CreateBridge((Commandable) component);
				break;
			case TagConstants.YELLOWBUSH:
				itemFactory.CreateYellowBush((Commandable) component);
				break;
		}
	}
}

