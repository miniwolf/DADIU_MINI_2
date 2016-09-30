using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TagRegister : MonoBehaviour {
	private static Hashtable singleTags = new Hashtable();
	private static List<MultiTag> multiObjects = new List<MultiTag>();

	private class MultiTag {
		private GameObject obj;
		private string tag;

		public MultiTag(GameObject obj, string tag) {
			this.obj = obj;
			this.tag = tag;
		}

		public GameObject GetObject() {
			return obj;
		}

		public string GetTag() {
			return tag;
		}
	}

	public static void RegisterSingle(GameObject obj, string tag) {
		if ( singleTags.ContainsKey(tag) ) {
			Debug.Log("Game object : '" + obj.name + "' needs the tag '" + tag + "'. However the tag already is assigned as a single tag. Note that this component will not be initialized with the scripts and features");
			return;
		}
		singleTags.Add(tag, obj);
	}

	public static void RegisterMultiple(GameObject obj, string tag) {
		multiObjects.Add(new MultiTag(obj, tag));
	}

	void Start() {
		foreach ( string s in singleTags.Keys ) {
			testTagReference((GameObject) singleTags[s], s);
		}
		foreach ( MultiTag mt in multiObjects ) {
			testTagReference(mt.GetObject(), mt.GetTag());
		}
	}

	private void testTagReference(GameObject obj, string tag) {
		if ( obj.transform.tag != tag ) {
			Debug.LogError("Game object: '" + obj.name + "' is missing the tag '" + tag + "' please add it.");
			Application.Quit();
		}
	}
}


