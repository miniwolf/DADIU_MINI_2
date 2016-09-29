using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsControllerImpl : MonoBehaviour, SettingsController {

	private Text textToggleSound;
	private Text textLanguage;
	private Text textReturnToMain;
	private CanvasScript canvas; 

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

	public void ToggleLanguage() {

		SupportedLanguage language = TranslateApi.GetCurrentLanguage();
		if(language.Equals(SupportedLanguage.DEN)) {
			language = SupportedLanguage.ENG;
		} else {
			language = SupportedLanguage.DEN;
		}

		TranslateApi.ChangeLanguage(language);
		SetTexts();
		canvas.OnLanguageChanged();
		// todo set this language to player prefs
	}

	public void ToggleSound() {
		// todo call sound controller
	}

	public void ReturnToMainMenu() {
		canvas.ReturnToMainMenu();
	}

	private void ResolveDependencies() {
		textToggleSound = GetTextComponent(UIConstants.TEXT_TOGGLE_SOUND);
		textLanguage = GetTextComponent(UIConstants.TEXT_CHANGE_LANGUAGE);
		textReturnToMain = GetTextComponent(UIConstants.TEXT_RETURN_TO_MAIN_MENU);

		canvas =  gameObject.GetComponentInParent<CanvasScript>();
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
