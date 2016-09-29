﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class TranslateApi {

	private static readonly object syncLock = new object();
	private static SupportedLanguage languageLoaded = SupportedLanguage.ENG;
	// todo if LocalizedString.Parse is slow, just change to plain strings and instead of translationLookupTable[key] call translationLookupTable[Key.toString()]
	private static Dictionary<LocalizedString, string> translationLookupTable = new Dictionary<LocalizedString, string>();

	public static string GetString(LocalizedString key) {
		lock(syncLock) {
			if(translationLookupTable.Count == 0) {
				LoadLanguage(languageLoaded);
			}
		}
		return translationLookupTable[key];
	}

	public static void ChangeLanguage(SupportedLanguage newLanguage) {
		if(!languageLoaded.Equals(newLanguage)) {
			lock(syncLock) {
				LoadLanguage(newLanguage);
			}
		}
	}

	private static void LoadLanguage(SupportedLanguage language)  {
		string data = System.IO.File.ReadAllText("Assets/Resources/Translations/" + language.ToString().ToLower() + ".txt");
		string [] splits = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None); // Environment.NewLine

		translationLookupTable.Clear();

		for(int i = 0; i < splits.Length; i++) {
			string split = splits[i];
			if(split.Length < 1) 
				throw new EntryPointNotFoundException("Cannot load string on line " + i);

			string [] keyValuePair = split.Split(';');
			LocalizedString key = (LocalizedString) Enum.Parse(typeof(LocalizedString), keyValuePair[0].Trim());
			string value = keyValuePair[1].Trim();

			translationLookupTable.Add(key, value);
		}
		languageLoaded = language;
	}



}
