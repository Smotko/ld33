using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Vector3 target;
	private Vector3 NORMAL = new Vector3(0, 0, 0);
	private float speed = 5;
	private Animator animator;

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
		}
		float dist = Vector3.Distance(transform.position, target);
		if (dist > 0) {
			this.Animate();
		} else {
			animator.SetFloat("speed", 0f);
		}
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

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
