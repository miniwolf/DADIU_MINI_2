using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	public Image mainMenu;
	public Image settingsMenu;
	public Image inGameMenu;
	public Image howToPlayMenu;

	private GameStateManager gameStateManager;

	private UIController settingsController;
	private UIController menuController;
	private UIController inGameController;
	private UIController howToPlayController;

	void Awake() {
		gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>();

		settingsController = GameObject.FindGameObjectWithTag(UIConstants.SETTINGS_MENU).GetComponent<UIController>();
		menuController = GameObject.FindGameObjectWithTag(UIConstants.MAIN_MENU).GetComponent<UIController>();
		inGameController = GameObject.FindGameObjectWithTag(UIConstants.IN_GAME_MENU).GetComponent<UIController>();

		ShowMainMenu();
	}

	void Start() {
		Action menuMusic = new MenuMusic();
		menuMusic.Setup(gameObject);
		menuMusic.Execute();
		Action soundScape = new SoundScapeMusic();
		soundScape.Setup(gameObject);
		soundScape.Execute();
	}

	void Update(){
		if (Input.GetKey(KeyCode.K)) {
			GameEnded();
		}
	}

	public void ShowMainMenu() {
		menuController.SetVisible();
		settingsController.SetInvisible();
		inGameController.SetInvisible();

		howToPlayMenu.gameObject.SetActive(false);

		gameStateManager.NewState(new GameState.Paused());
		Action menuMusic = new MenuMusic();
		menuMusic.Setup(gameObject);
		menuMusic.Execute();
		Action soundScape = new SoundScapeMusic();
		soundScape.Setup(gameObject);
		soundScape.Execute();
	}

	public void ShowSettings() {
		menuController.SetInvisible();
		settingsController.SetVisible();
		inGameController.SetInvisible();

		howToPlayMenu.gameObject.SetActive(false);
		Action action = new ForwardMenuFeedbackSound();
		action.Setup(gameObject);
		action.Execute();
		gameStateManager.NewState(new GameState.Paused());
	}

	public void ShowPlayGame() {
		menuController.SetInvisible();
		settingsController.SetInvisible();
		inGameController.SetVisible();

		howToPlayMenu.gameObject.SetActive(false);


		Action soundScape = new SoundScapeMusic();
		soundScape.Setup(gameObject);
		soundScape.Execute();
		gameStateManager.NewState(new GameState.Playing());
	}

	public void ShowHowToPlayMenu() {
		menuController.SetInvisible();
		settingsController.SetInvisible();
		inGameController.SetInvisible();
		howToPlayMenu.gameObject.SetActive(true);
		Action action = new ForwardMenuFeedbackSound();
		action.Setup(gameObject);
		action.Execute();

		gameStateManager.NewState(new GameState.Paused());
	}

	public void ReturnToMainMenu() {
		Action action = new BackwardMenuFeedbackSound();
		action.Setup(gameObject);
		action.Execute();
		ShowMainMenu();
	}

	public void OnLanguageChanged() {
		settingsController.RefreshText();
		menuController.RefreshText();
		inGameController.RefreshText();
		// todo on how to play menu
	}

	public void GameEnded() {
		gameStateManager.NewState(new GameState.Ended());
	}
}
