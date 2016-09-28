using UnityEngine;
using System.Collections;

public class TagRegister : MonoBehaviour {
	private static Hashtable tags = new Hashtable();

	public static void Register(GameObject obj, string tag) {
		tags.Add(tag, obj);
	}

	void Start() {
		foreach ( string s in tags.Keys ) {
			GameObject obj = (GameObject) tags[s];
			if ( obj.transform.tag != s ) {
				Debug.LogError("Game object: '" + obj.name + "' is missing the tag '" + s + "' please add it.");
				Application.Quit();
			}
		}
	}
}

