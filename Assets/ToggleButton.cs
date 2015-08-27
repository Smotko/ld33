using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleButton : MonoBehaviour {

	public float timeOut;
	public string key;
	public Sprite up;
	public Sprite down;

	private bool inactive;
	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(key) && !inactive) {
			inactive = true;
			image.sprite = down;
			Invoke ("Deactivate", timeOut);
		}
	}
	void Deactivate() {
		image.sprite = up;
		inactive = false;
	}
}
