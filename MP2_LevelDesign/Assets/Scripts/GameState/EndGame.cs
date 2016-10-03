using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	GameObject fadeGO;
	bool isFading = false;

	void Start(){
		fadeGO = GameObject.FindGameObjectWithTag("FadingObj");
		fadeGO.SetActive(false);
	}

	public void BeginFade(){
		fadeGO.SetActive(true);
		if (!isFading) {
			StartCoroutine(StartFade());
		}
	}

	IEnumerator StartFade (){
		isFading = true;
		Color col = Color.black;
		col.a = 0;
		fadeGO.GetComponent<Image>().color = col;
		for (int i = 0; i < 13; i++) {
			col.a += 0.1f;
			fadeGO.GetComponent<Image>().color = col;
			yield return new WaitForSeconds(0.1f);
		}
		SceneManager.LoadScene("EndScene");
	}
}
