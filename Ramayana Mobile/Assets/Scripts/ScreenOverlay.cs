using UnityEngine;
using System.Collections;

public class ScreenOverlay : MonoBehaviour {

	public void Hit() {
		GetComponent<UnityEngine.UI.Image> ().color = new Color (0.8f + Random.value * 0.2f, Random.value * 0.2f, Random.value * 0.2f, 0.5f);
	}

	void Update() {
		GetComponent<UnityEngine.UI.Image> ().color = Color.Lerp (GetComponent<UnityEngine.UI.Image> ().color, new Color(0, 0, 0, 0), 0.5f * Time.deltaTime);
	}

}
