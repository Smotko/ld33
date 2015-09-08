using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

	private GameObject player;
	private Attack a;
	private GameObject core;
	private GameObject target;
	private float lastAttack = 0;
	private float ATTACK_COOLDOWN = 1;
	private float TARGET_CHANGE_COOLDOWN = 2;
	private float lastTarget = 0;
	private Animator anim;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {

		core = GameObject.FindGameObjectWithTag("core");
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator>();
		a = player.GetComponent<Attack>();
		sprite = GetComponent<SpriteRenderer>();
	}

	private void ChangeTarget(GameObject newTarget) {
		if (lastTarget < 0) {
			lastTarget = TARGET_CHANGE_COOLDOWN;
			target = newTarget;
		}
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.instance.coreDestroyed) {
			return;
		}

		float playerDist = Vector3.Distance(transform.position, player.transform.position);
		float coreDist = Vector3.Distance(transform.position, core.transform.position);
		if (GameManager.instance.coreDestroyed) {
			return;
		}
		if (a.hasAttackedZergy && GameManager.instance.playerAlive) {
			// Attack player if it's closer
			if (coreDist * 2 < playerDist) {
				ChangeTarget(core);
			} else {
				ChangeTarget(player);

			}
		} else {
			ChangeTarget(core);
		}
		lastTarget -= Time.deltaTime;
		if (!target) {
			return;
		}
		float dist = Vector3.Distance(transform.position, target.transform.position);
		lastAttack -= Time.deltaTime;
		if (dist > 0.7f) {
			anim.SetFloat("speed", 4f);
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime);
		} else {
			anim.SetFloat("speed", 0f);
			if (lastAttack < 0) {
				anim.SetTrigger("attacking");
				target.SendMessage("Hurt", 10);
				lastAttack = ATTACK_COOLDOWN;
			}
		}

	}

	void Hurt(int amount) {
		target = player;

		lastTarget = TARGET_CHANGE_COOLDOWN * 10;
		sprite.color = Color.red;
		Invoke ("ResetColor", 0.1f);
	}
	void ResetColor() {
		sprite.color = Color.white;
	}
}
