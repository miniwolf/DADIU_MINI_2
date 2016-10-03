using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingNumberFeedback : MonoBehaviour, Value {

	private float dressesPickedUp = 0;
	public float secondsUntilDisappear = 2.5f;
	private Coroutine displayNumber;
	private bool displayNumberRunning = false;
	private Text text;

	// Use this for initialization
	void Start () {
		TagRegister.RegisterSingle(this.gameObject, TagConstants.FEEDBACKNUMBER);
		text = GameObject.FindGameObjectWithTag(TagConstants.FEEDBACKNUMBER).GetComponent<Text>();
		gameObject.SetActive(false);
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

	IEnumerator FunctionalityOfNumber(float amount){
		displayNumberRunning = true;
		text.text = amount.ToString();
		//Play animation
		yield return new WaitForSeconds(secondsUntilDisappear);
		gameObject.SetActive(false);
		ResetCurrDressCount();
		displayNumberRunning = false;
	}
}
