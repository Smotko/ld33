using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Vector3 target;
	private Vector3 NORMAL = new Vector3(0, 0, 0);
	private float speed = 5;
	private Animator animator;
	private Collider2D cl;
	private float stopAt;

	// Use this for initialization
	void Start () {
		target = transform.position;
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;

			cl = Physics2D.OverlapPoint(target);
		}

		// If we clicked on an enemy, we can start attacking from afar
		Debug.Log (cl == null);
		if (cl == null) {
			stopAt = 0.1f;
		} else {
			stopAt = 2f;
		}
		Debug.Log (stopAt);

		float dist = Vector3.Distance(transform.position, target);

		if (dist > stopAt) {
			this.Animate();
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		} else {
			animator.SetFloat("speed", 0f);
		}
	}

	private void Animate() {
		if (transform.position.x - target.x < 0) {
			transform.localEulerAngles = Vector3.zero;
		} else {
			transform.localEulerAngles = new Vector3(0, 180, 0);
		}
		animator.SetFloat ("speed", speed);

	}
}
