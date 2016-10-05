using UnityEngine;
using System.Collections;

public class TextureScrollOffset : MonoBehaviour {
	Vector3 startPos ;
	Material material;
	Vector2 textureScale;



	// Use this for initialization
	void Start () {
		startPos = transform.position;
		material = GetComponent<Renderer>().material;
		textureScale = new Vector2( 1f/transform.localScale.x, 1f/transform.localScale.y);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 materialOffset = transform.position - startPos;
		material.mainTextureOffset = new Vector2 (materialOffset.x * textureScale.x, materialOffset.z * textureScale.y);
	}
}
