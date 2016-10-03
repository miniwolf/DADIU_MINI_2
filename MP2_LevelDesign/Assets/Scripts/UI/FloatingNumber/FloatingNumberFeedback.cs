using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingNumberFeedback : MonoBehaviour, Value {

	private float dressesPickedUp = 0;
	public float secondsUntilDisappear = 2.5f;
	private Coroutine displayNumber;
	private bool displayNumberRunning = false;
	private Text text;
	private Transform player;
	private Camera cam;
	private Vector3 playerPosOnScreen;
	public float xOffset = 50f,yOffset = 20f;
	// Use this for initialization
	void Start () {
		TagRegister.RegisterSingle(this.gameObject, TagConstants.FEEDBACKNUMBER);
		text = GameObject.FindGameObjectWithTag(TagConstants.FEEDBACKNUMBER).GetComponent<Text>();
		player = GameObject.FindGameObjectWithTag(TagConstants.PLAYER).GetComponent<Transform>();
		cam = GameObject.FindGameObjectWithTag(TagConstants.CAMERA).GetComponent<Camera>();

		gameObject.SetActive(false);
	}
	void Update(){
		playerPosOnScreen = cam.WorldToScreenPoint(player.position);
		transform.position = new Vector3(playerPosOnScreen.x+xOffset,playerPosOnScreen.y+yOffset,playerPosOnScreen.z);
	}

	public void IncrementValue(){
		dressesPickedUp++;
		ShowNumber();
	}

	public void DecrementValue(){
		dressesPickedUp--;
	}

	public float GetValue(){
		return dressesPickedUp;
	}

	private void ResetCurrDressCount(){
		dressesPickedUp = 0f;
	}
		
	private void ShowNumber(){
		if (displayNumberRunning) {
			StopCoroutine(displayNumber);
		}
		gameObject.SetActive(true);
		displayNumber = StartCoroutine(FunctionalityOfNumber(GetValue()));
	}
	//Play anim somewhere in here
	IEnumerator FunctionalityOfNumber(float amount){
		displayNumberRunning = true;
		text.text = amount.ToString();
		yield return new WaitForSeconds(secondsUntilDisappear);
		gameObject.SetActive(false);
		ResetCurrDressCount();
		displayNumberRunning = false;
	}
}
