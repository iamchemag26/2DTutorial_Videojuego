using UnityEngine;
using System.Collections;

public class ControlHacha : MonoBehaviour {

	ControlPersonaje ctr;

	// Use this for initialization
	void Start () {
		ctr = GameObject.Find ("orc").GetComponent<ControlPersonaje> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name.Equals ("lamp")) {
			ctr.SetControlLampara(other.gameObject.GetComponent<ControlLampara>());

		}

	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name.Equals ("lamp")) {
			ctr.SetControlLampara(null);
			}
					                   
		}
}
