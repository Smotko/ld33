using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	private Transform camera;
	private Vector3 pos;


	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		camera.position = new Vector3(transform.position.x, transform.position.y, camera.position.z);
	}
}
