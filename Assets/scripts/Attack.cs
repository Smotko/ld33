using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public GameObject basicAttack;
	public AudioClip[] attackSounds;

	private AudioSource audioSource;
	private float BASIC_COOLDOWN = 0.5f; //seconds
	private float MULTI_COOLDOWN = 5f;
	private float SHIELD_COOLDOWN = 5f;
	private float SHIELD_DURATION = 2f;
	private float DIST = 2f;
	private float lastAttack = -1;
	private float lastShield = -1;
	private float shieldDuration = -1;
	private GameObject target;
	private Animator anim;
	public bool hasAttackedZergy = false;
	private float multiAttack = -1;
	private Shield shield;


	public bool isShielded() {
		return shield.IsShielded();
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		foreach(Transform child in transform){
			if(child.gameObject.tag == "shield"){
				shield = child.GetComponent<Shield>();
			}
		}
		audioSource = GetComponents<AudioSource>()[1];
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.W)) {
			FireMulti();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			Shield();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevelName);
		}

		lastAttack -= Time.deltaTime;
		multiAttack -= Time.deltaTime;
		lastShield -= Time.deltaTime;
		shieldDuration -= Time.deltaTime;
		if (shieldDuration < 0) {
			shield.Disable();
		}
		if (target == null) {
			return;
		}
		float dist = Vector3.Distance(transform.position, target.transform.position);
		// We need to stop
		if (dist < DIST) {
			gameObject.SendMessage("Stop");
			// And Fire
			FireBasic();
		}


	}

	void Shield() {
		if (lastShield < 0) {
			shield.Enable();
			lastShield = SHIELD_COOLDOWN;
			shieldDuration = SHIELD_DURATION;
		}
	}
	void FireBasic() {
		if (lastAttack < 0) {
			anim.SetTrigger("attacking");
			GameObject g = Instantiate(basicAttack, transform.position, Quaternion.identity) as GameObject;
			hasAttackedZergy = true;
			g.SendMessage("SetTarget", target);
			lastAttack = BASIC_COOLDOWN;
			audioSource.clip = attackSounds[Random.Range(0, attackSounds.Length)];
			audioSource.Play();
		}

	}
	void FireMulti() {
		if (multiAttack < 0) {
			audioSource.clip = attackSounds[Random.Range(0, attackSounds.Length)];
			audioSource.Play();
			GameObject[] all = GameObject.FindGameObjectsWithTag("enemy");
			for (int i = 0; i < all.Length; i++) {
				anim.SetTrigger("attacking");
				GameObject g = Instantiate(basicAttack, transform.position, Quaternion.identity) as GameObject;
				hasAttackedZergy = true;
				g.SendMessage("SetTarget", all[i]);
				multiAttack = MULTI_COOLDOWN;
			}
		}
	}

	void SetTarget(object[] t) {
		bool force = (bool)t[1];
		if (target == null || force) {
			target = t[0] as GameObject;
		}
	}
	void UnsetTarget() {
		target = null;
	}
}
