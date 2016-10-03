using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneCanvasController : MonoBehaviour {

	private Text highScore, yourScore, motivational;
	public string[] motivationalText = new string[2];
	private float myScoreFloat, highScoreFloat;

	// Use this for initialization
	void Start () {
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
	public void Restart(){
		SceneManager.LoadScene("LevelDesign");
	}
}
