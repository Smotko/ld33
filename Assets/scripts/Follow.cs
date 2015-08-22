using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	private Transform cam;
	private Vector3 pos;


	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		cam.position = new Vector3(transform.position.x, transform.position.y, cam.position.z);
	}
}
