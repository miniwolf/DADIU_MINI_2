using UnityEngine;
using System.Collections;

public interface SettingsController {

	void ToggleLanguage();
	void ToggleSound();
	void ReturnToMainMenu();
	void SetTexts();

//	SupportedLanguage GetCurrentLanguage();
//	bool IsSoundOn();
}
