using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private GameObject target;
	private float speed = 6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			//Destroy (gameObject);
		
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		}
		
	}

	void SetTarget(GameObject t) {
		target = t;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "enemy") {
			other.SendMessage("Hurt", 10);
			Destroy (gameObject);
		}
	}

}
