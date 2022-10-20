﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlenemigo: MonoBehaviour {
	
		public float vel = -1f;
		Rigidbody2D rgb;
		Animator anim;
	    public GameObject bulletPrototype;
	    
	
	public Slider slider;
	public Text txt;
	public float energy = 100;
	public float energi = 20;
		// Use this for initialization
		void Start () {
			rgb = GetComponent<Rigidbody2D> ();
			anim = GetComponent<Animator> ();
		}
		

	void Update () {
	if (energy <= 0) {
			energy = 0;
			anim.SetTrigger("morir");
		}
		slider.value = energy;
		txt.text = energy.ToString ();
	}
		// Update is called once per frame
		void FixedUpdate () {
			Vector2 v = new Vector2 (vel, 0);
			rgb.velocity = v;

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Caminandi") && Random.value < 1f / (68f * 3f)) {
				anim.SetTrigger ("apuntar");
			} else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Apuntando")) {
				if (Random.value < 1f / (3f)) {
					anim.SetTrigger ("disparar");
				} else {
					anim.SetTrigger ("caminar");
				}
			}
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

	public  void Disparar(){
			anim.SetTrigger ("apuntar");
		}
	 
	public void EmitirBala(){
			GameObject bulletCopy = Instantiate(bulletPrototype);
			bulletCopy.transform.position = new Vector3(transform.position.x,transform.position.y, -1f);
			bulletCopy.GetComponent<ControlBala>().direction = new Vector3(transform.localScale.x, 0, 0);


		energy--;
		}


	public void BajarPuntosOrcoCerca(){
		energy -= energi;
		
	}




}
