using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsControllerImpl : MonoBehaviour, SettingsController {

	private Text textToggleSound;
	private Text textLanguage;
	private Text textReturnToMain;

	void Start() {
		ResolveDependencies();
		SetTexts();
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	void OnDestroy() {
		textToggleSound = textLanguage = textReturnToMain = null;
	}

	public void ChangeLanguage(SupportedLanguage newLanguage) {
		TranslateApi.ChangeLanguage(newLanguage);
		SetTexts();		
	}

	public void ToggleSound(bool soundOn) {
		// todo call sound controller
	}

	public void ReturnToMainMenu() {
		CanvasScript script =  gameObject.GetComponentInParent<CanvasScript>();
		script.ReturnToMainMenu();
	}

	private void ResolveDependencies() {
		textToggleSound = GetTextComponent(UIConstants.TEXT_TOGGLE_SOUND);
		textLanguage = GetTextComponent(UIConstants.TEXT_CHANGE_LANGUAGE);
		textReturnToMain = GetTextComponent(UIConstants.TEXT_RETURN_TO_MAIN_MENU);
	}

	private Text GetTextComponent(string tag) {
		return GameObject.FindGameObjectWithTag(tag).GetComponent<Text>();
	}

	private void SetTexts() {
		textToggleSound.text = TranslateApi.GetString(LocalizedString.settingsToggleSound);
		textLanguage.text = TranslateApi.GetString(LocalizedString.settingsChangeLanguage);
		textReturnToMain.text = TranslateApi.GetString(LocalizedString.settingsReturnToMainMenu);
	}
}
