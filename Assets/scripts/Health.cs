using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 100;
	public bool hasShield = false;
	public GameObject spriteComponent;
	public GameObject dead;
	public AudioClip[] hurtSounds;

	private AudioSource audioSource;	
	private Attack attack;
	private SpriteRenderer sprite;
	private ParticleSystem blood;

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
		blood = GetComponentInChildren<ParticleSystem>();
		audioSource = GetComponent<AudioSource>();

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

		blood.Play();
		if (!GameManager.instance.playerAlive) {
			amount = 500;
		}
		audioSource.clip = hurtSounds[Random.Range(0, hurtSounds.Length)];
		audioSource.Play();

		health -= amount;
		if (health <= 0) {
			GameManager.instance.ObjectDestroyed(gameObject);
			if (dead) {
				Instantiate(dead, transform.position, Quaternion.identity);
			}
		}
	}
}
