using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {

	public Sprite[] sprites;
	private SpriteRenderer sr;

	void Start () {
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = sprites[Random.Range (0, sprites.Length)];
	}
	void Update() {

	}

}
