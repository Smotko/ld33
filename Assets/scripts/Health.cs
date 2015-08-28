using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 100;
	public bool hasShield = false;
	public GameObject spriteComponent;
	
	private Attack attack;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		if (hasShield) {
			attack = GetComponent<Attack>();
		}
		if (spriteComponent != null) {
			sprite = spriteComponent.GetComponent<SpriteRenderer>();
		} else {
			sprite = GetComponent<SpriteRenderer>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void ResetColor() {
		sprite.color = Color.white;
	}
	void Hurt(int amount) {
		if (hasShield && attack.isShielded()) {
			return;
		}
		sprite.color = Color.red;
		Invoke ("ResetColor", 0.1f);
		if (!GameManager.instance.playerAlive) {
			amount = 500;
		}
		health -= amount;
		if (health <= 0) {
			GameManager.instance.ObjectDestroyed(gameObject);
		}
	}
}
