using UnityEngine;
using System.Collections;

public class FogColorController : MonoBehaviour {
	public Material[] rimMaterials;
	public Color rimColor;


	void Awake () {
		for (int i = 0; i < rimMaterials.Length; i++) {
			rimMaterials[i].SetColor("_RimColor", rimColor);
		}
	}

	void OnTriggerEnter (Collider other) {
		FogColorZone zone = other.GetComponent<FogColorZone>();

		if (zone != null) {
			StopAllCoroutines();
			StartCoroutine(ChangeFogColor(zone.fogColor, zone.rimColor, zone.fogChangeDuration));
		}
	}

	IEnumerator ChangeFogColor (Color endColorFog, Color endColorRim, float duration) {
		Color startColorFog = RenderSettings.fogColor;
		Color startColorRim = rimColor;
		float startTime = Time.time;
		float t = 0;

		while (t < 1) {
			t = (Time.time - startTime) / duration;
			RenderSettings.fogColor = Color.Lerp(startColorFog, endColorFog, t);
			rimColor = Color.Lerp(startColorRim, endColorRim, t);

			for (int i = 0; i < rimMaterials.Length; i++) {
				rimMaterials[i].SetColor("_RimColor", rimColor);
			}
			yield return null;
		}

		RenderSettings.fogColor = endColorFog;

		rimColor = endColorRim;

		for (int i = 0; i < rimMaterials.Length; i++) {
			rimMaterials[i].SetColor("_RimColor", rimColor);
		}
	}
}
