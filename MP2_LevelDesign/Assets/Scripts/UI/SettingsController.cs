using UnityEngine;
using System.Collections;

public interface SettingsController {

	void ChangeLanguage(SupportedLanguage newLanguage);
	void ToggleSound(bool soundOn);
	void ReturnToMainMenu();

//	SupportedLanguage GetCurrentLanguage();
//	bool IsSoundOn();
}
