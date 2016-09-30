using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class UIController : MonoBehaviour {
	protected CanvasScript canvas;
	protected GameStateManager gameStateManager;

	void Start() {
		canvas = gameObject.GetComponentInParent<CanvasScript>();
		gameStateManager = GameObject.FindGameObjectWithTag(TagConstants.GAME_STATE).GetComponent<GameStateManager>() as GameStateManager;
		ResolveDependencies();
		RefreshText();
	}

	void Destroy() {
		canvas = null;
		gameStateManager = null;
	}

	/// /// <summary>
	/// This is called whenever we need to set correct texts in the canvas 
	/// (screen is rendered for the first time or we change language)
	/// </summary>
	abstract public void RefreshText();
	/// <summary>
	/// In this callback you should fetch all the views you need to manipulate
	/// </summary>
	abstract public void ResolveDependencies();
	/// <summary>
	/// Helper method for ResolveDependencies() 	/// </summary>
	/// <returns>The text component.</returns>
	/// <param name="tag">Tag.</param>
	virtual protected Text GetTextComponent(string tag) {
		return GameObject.FindGameObjectWithTag(tag).GetComponent<Text>();
	}

	virtual protected void ReturnToMainMenu() {
		canvas.ReturnToMainMenu();
	}

	/// <summary>
	/// Don't use setActive method! You cannot find the object in the scene then
	/// </summary>
	virtual public void SetVisible() {
		gameObject.transform.localScale = new Vector3(0.9f, 1, 1);
	}

	virtual public void SetInvisible() {
		gameObject.transform.localScale = new Vector3(0, 0, 0);
	}
}

