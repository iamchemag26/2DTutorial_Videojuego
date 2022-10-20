using UnityEngine;
using System.Collections;

public class controldetective : MonoBehaviour {

	public float vel = -1f;
	Rigidbody2D rgb1;
	
	// Use this for initialization
	void Start () {
		rgb1 = GetComponent<Rigidbody2D> ();

      
	}

	void OnTriggerEnter2D(Collider2D other) {
		Flip ();
	}

	void Flip(){
		vel *= -1;

		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
}
}
