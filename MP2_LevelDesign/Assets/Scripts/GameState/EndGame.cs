using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	GameObject fadeGO;
	bool isFading = false;
	Vector3 origPos;

	void Start(){
		fadeGO = GameObject.FindGameObjectWithTag("FadingObj");
		Color color = Color.black;
		color.a = 0f;
		fadeGO.GetComponent<Image>().color = color;
		origPos = fadeGO.transform.position;
		fadeGO.transform.position += new Vector3(100000f, 100000f, 100000f);
	}

	public void BeginFade(){
		fadeGO.transform.position = origPos;
		Time.timeScale = 1;
		if (!isFading) {
			StartCoroutine(StartFade());
		}
	}

	IEnumerator StartFade (){
		isFading = true		;
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
