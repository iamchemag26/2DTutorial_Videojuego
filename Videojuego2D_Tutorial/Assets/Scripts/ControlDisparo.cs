using UnityEngine;
using System.Collections;

public class ControlDisparo : MonoBehaviour {
	Collider2D disparandoA = null;
	public float probabilidadDeDisparo = 1f;



	controlenemigo ctr;
	// Use this for initialization
	void Start () {
		ctr = GameObject.Find ("Enemigo").GetComponent<controlenemigo> ();
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals ("lamp") && disparandoA == null) { 
			DecidaSiDispara (other);
		}

		if (other.gameObject.name.Equals ("orc") && disparandoA == null) { 
			Disparar();
			disparandoA = other;
			
		}
	}
	
		
		void OnTriggerExit2D (Collider2D other){
		if (other == disparandoA) {
			disparandoA = null;
		}
	}
	void DecidaSiDispara( Collider2D other ) {
		if (Random.value < probabilidadDeDisparo) {
			Disparar ();
			disparandoA = other;
		}
	}

	void Disparar() {
		ctr.Disparar ();
	}

	void Update () {
	
	}
}
