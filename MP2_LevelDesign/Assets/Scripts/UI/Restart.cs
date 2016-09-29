using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	public void restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
