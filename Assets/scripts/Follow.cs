using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public GameObject mark;
	private Vector3 pos;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		pos = mark.transform.position;
		transform.position = new Vector3(pos.x, pos.y, transform.position.z);
	}
}
