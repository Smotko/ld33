using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public GameObject basicAttack;
	private float BASIC_COOLDOWN = 0.5f; //seconds
	private float DIST = 2f;
	private float lastAttack = -1;
	private GameObject target;
	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			anim.SetBool("attacking", false);
			return;
		}
		float dist = Vector3.Distance(transform.position, target.transform.position);
		// We need to stop
		if (dist < DIST) {
			gameObject.SendMessage("Stop");
			// And Fire
			FireBasic();
		} else {
			anim.SetBool("attacking", false);
		}
		lastAttack -= Time.deltaTime;
	}

	void FireBasic() {
		if (lastAttack < 0) {
			anim.SetBool("attacking", true);
			GameObject g = Instantiate(basicAttack, transform.position, Quaternion.identity) as GameObject;
			g.SendMessage("SetTarget", target);
			lastAttack = BASIC_COOLDOWN;
		} else {

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
