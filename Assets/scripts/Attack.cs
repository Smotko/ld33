using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	private float BASIC_COOLDOWN = 0.5f; //seconds
	private float DIST = 2f;
	private float lastAttack = -1;
	private GameObject target;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
		lastAttack -= Time.deltaTime;
	}

	void FireBasic() {
		if (lastAttack < 0) {
			Debug.Log("FIRING");
			lastAttack = BASIC_COOLDOWN;
		}

	}

	void SetTarget(GameObject t) {
		target = t;
		Debug.Log ("Received target" + t);
	}
	void UnsetTarget() {
		target = null;
	}
}
