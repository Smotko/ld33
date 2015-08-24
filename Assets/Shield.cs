using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	private float cooldown = 0;
	private SpriteRenderer sr;
	private BoxCollider2D bc;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		bc = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "enemy") {
			if (cooldown < 0) {
				other.gameObject.SendMessage("Hurt", 5);
				cooldown = 0.1f;
			}
		}
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "enemy" && cooldown < 0) {
			other.gameObject.SendMessage("Hurt", 5);
			cooldown = 0.1f;
		}
	}
	public void Enable() {
		bc.enabled = true;
		sr.enabled = true;

	}
	public void Disable() {
		bc.enabled = false;
		sr.enabled = false;
	}
	public bool IsShielded() {
		return bc.enabled;
	}
}
