using UnityEngine;
using System.Collections;

public class SortLayerFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "foreground";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
