using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Vector3 target;
	private Vector3 NORMAL = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		target = transform.position;
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
		}
		transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);

	}

	private void Animate() {
		if (transform.position.x - target.x < 0) {
			transform.localEulerAngles = Vector3.zero;
		} else {
			transform.localEulerAngles = new Vector3(0, 180, 0);
		}
	}
}
