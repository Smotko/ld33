using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private float STOP_AT = 0.1f;
	private Vector3 moveTo;
	private GameObject target;
	private float speed = 4;
	private Animator animator;
	private Collider2D cl;
	private GameObject cursor;
	private bool isAttackMove;
	public GameObject[] cursors;


	// Use this for initialization
	void Start () {
		moveTo = transform.position;
		animator = gameObject.GetComponent<Animator>();
	}
	void Update() {

		if (!GameManager.instance.playerAlive) {
			return;
		}

		if (Input.GetMouseButtonDown(0)) {
			setMoveTo(false);
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			setMoveTo(true);
		}
		
		float dist = Vector3.Distance(transform.position, moveTo);
		
		if (dist > STOP_AT) {
			Move();
		} else {
			StopMove();
		}
	}
	private Vector3 setMoveTo(bool attack) {

		moveTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		moveTo.z = transform.position.z;

		cl = null;
		foreach(Collider2D coll in Physics2D.OverlapCircleAll(moveTo, 0.5f)){
			if (coll.gameObject.tag == "enemy") {
				cl = coll;
			}
		}

		bool attackingTarget = cl != null;
		if (attackingTarget) {
			gameObject.SendMessage("SetTarget", new object[] {cl.gameObject, true});
		}
		else if(!attack) {
			gameObject.SendMessage("UnsetTarget");
		}

		// Remove previous cursor if applicable
		if (cursor != null) {
			Destroy(cursor);
		}
		// Set new cursor
		cursor = Instantiate(cursors[0], moveTo, Quaternion.identity) as GameObject;
		cursor.SendMessage("ShowAt", attackingTarget || attack);

		isAttackMove = attack;
		return moveTo;
	}
	
	private void Move() {
		// Turn the character left or right
		if (transform.position.x - moveTo.x < 0) {
			transform.localEulerAngles = Vector3.zero;
		} else {
			transform.localEulerAngles = new Vector3(0, 180, 0);
		}
		// Make the character move
		animator.SetFloat("speed", speed);
		transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
	}
	private void StopMove() {
		animator.SetFloat("speed", 0f);
		if (cursor != null){ 
			Destroy(cursor, 0.5f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (isAttackMove && other.gameObject.tag == "enemy") {
			gameObject.SendMessage("SetTarget", new object[] {other.gameObject, false});
		}
	}
	void OnTriggerStay2D(Collider2D other) {

	}

	void Stop() {
		moveTo = transform.position;
	}
}
