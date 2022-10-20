using UnityEngine;
using System.Collections;

public class ControlBala : MonoBehaviour {

	public float speed = 6;
	public float lifeTime = 2;
	public Vector3 direction = new Vector3 (-1, 0, 0);



	Vector3 stepVector;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeTime);
		rb = GetComponent<Rigidbody2D> ();
		stepVector = speed * direction.normalized;
	}
	void FixedUpdate () {
		rb.velocity = stepVector;
	}

	private void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.name.Equals("lamp")){
			ControlLampara ctr = other.gameObject.GetComponent<ControlLampara>();
			if( ctr != null) ctr.RecibirDisparo();
			Destroy(gameObject);
		 }
		if (other.gameObject.name.Equals("orc")){
			ControlPersonaje ctr = other.gameObject.GetComponent<ControlPersonaje>();
			if( ctr != null) ctr.RecibirBala();
			Destroy(gameObject);
		}


		}

}
