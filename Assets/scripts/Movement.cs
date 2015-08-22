using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Vector3 target;
	private float speed = 4;
	private Animator animator;
	private Collider2D cl;
	private float stopAt;
	private GameObject cursor;
	public GameObject[] cursors;

	// Use this for initialization
	void Start () {
		target = transform.position;
		animator = gameObject.GetComponent<Animator>();
	}

	private Vector3 setTarget(bool attack) {

		target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		target.z = transform.position.z;

		cl = Physics2D.OverlapPoint(target);
		if (cursor != null) {
			Destroy(cursor);
		}

		cursor = Instantiate(cursors[0], target, Quaternion.identity) as GameObject;

		if (attack) {
			Animator anim = cursor.GetComponent<Animator>();
			anim.SetBool("isAttack", true);
		}

		return target;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0)) {
			setTarget(false);
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			setTarget(true);
		}

		// If we clicked on an enemy, we can start attacking from afar
		if (cl == null) {
			stopAt = 0.1f;
		} else {
			stopAt = 2f;
		}

		float dist = Vector3.Distance(transform.position, target);

		if (dist > stopAt) {
			this.Animate();
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		} else {
			animator.SetFloat("speed", 0f);
			if (cursor != null){ 
				Destroy (cursor);
			}
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
