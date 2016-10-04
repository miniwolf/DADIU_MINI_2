using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsControllerImpl : UIController, SettingsController {
	private Text textToggleSound;
	private Text textLanguage;
	private Text textReturnToMain;

	void OnDestroy() {
		textToggleSound = textLanguage = textReturnToMain = null;
	}

	public void ToggleLanguage() {
		SupportedLanguage language = TranslateApi.GetCurrentLanguage().Equals(SupportedLanguage.DEN) ? SupportedLanguage.ENG : SupportedLanguage.DEN;

		TranslateApi.ChangeLanguage(language);
		canvas.OnLanguageChanged();
	}

	public void ToggleSound() {
		// todo call sound controller
	}

	public override void ResolveDependencies() {
		textToggleSound = GetTextComponent(UIConstants.TEXT_TOGGLE_SOUND);
		textLanguage = GetTextComponent(UIConstants.TEXT_CHANGE_LANGUAGE);
		textReturnToMain = GetTextComponent(UIConstants.TEXT_RETURN_TO_MAIN_MENU);

		canvas =  gameObject.GetComponentInParent<CanvasScript>();
	}

	public override void RefreshText() {
		textToggleSound.text = TranslateApi.GetString(LocalizedString.settingsToggleSound);
		textLanguage.text = TranslateApi.GetString(LocalizedString.settingsChangeLanguage);
		textReturnToMain.text = TranslateApi.GetString(LocalizedString.settingsReturnToMainMenu);
	}
}
