using UnityEngine;
using System.Collections;

public class RecieveShadows : MonoBehaviour {

	public bool castShadows = true;

	public bool recieveShadows= true;

	// Use this for initialization
	void Start () {
		if (castShadows) {
			GetComponent<Renderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
		GetComponent<Renderer> ().receiveShadows = recieveShadows;
	}

	void Update(){
		if (castShadows) {
			GetComponent<Renderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
		GetComponent<Renderer> ().receiveShadows = recieveShadows;
	}
}
