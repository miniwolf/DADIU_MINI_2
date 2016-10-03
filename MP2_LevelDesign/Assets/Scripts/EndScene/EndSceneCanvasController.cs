using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneCanvasController : MonoBehaviour {

	GameObject fadeGO;
	private Text highScore, yourScore, motivational;
	public string[] motivationalText = new string[2];
	private float myScoreFloat, highScoreFloat;

	// Use this for initialization
	void Start () {
		
		fadeGO = GameObject.FindGameObjectWithTag("FadingObj");
		fadeGO.SetActive(true);
		StartCoroutine(FadeIn());

		highScore = GameObject.FindGameObjectWithTag(TagConstants.ENDSCREENHIGHSCORE).GetComponent<Text>();
		yourScore = GameObject.FindGameObjectWithTag(TagConstants.SCORE).GetComponent<Text>();
		motivational = GameObject.FindGameObjectWithTag(TagConstants.ENDSCREENMOTIVATIONAL).GetComponent<Text>();

		highScoreFloat = PlayerPrefs.GetFloat(PlayerPrefsConstants.HIGHSCORE);
		myScoreFloat = PlayerPrefs.GetFloat(PlayerPrefsConstants.MYSCORE);
		highScore.text = "The highscore is: " + highScoreFloat.ToString();
		yourScore.text = "Your score is: " + myScoreFloat.ToString();
		if (myScoreFloat > highScoreFloat) {
			motivational.text = motivationalText[0];
		} else {
			motivational.text = motivationalText[1];
		}
	}

	IEnumerator FadeIn (){
		Color col = Color.black;
		col.a = 1;
		fadeGO.GetComponent<Image>().color = col;
		for (int i = 0; i < 20; i++) {
			col.a -= 0.1f;
			fadeGO.GetComponent<Image>().color = col;
			yield return new WaitForSeconds(0.1f);
		}
		fadeGO.SetActive(false);
	}

	public void Restart(){
		SceneManager.LoadScene("LevelDesign");
	}
}
