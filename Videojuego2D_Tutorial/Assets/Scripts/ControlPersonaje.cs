using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlPersonaje : MonoBehaviour {
	Rigidbody2D rgb;
	Animator anim;
	public float maxVel = 5f;
	bool haciaDerecha = true;


	public Slider slider;
	public Text txt;
	public float energy = 100;
	public int costoBala = 20;

	public int costoGolpeAire = 1;
	public int costoGolpeLamp = 3;
	public int premioArbol = 15;
	Transform retroalimentacionSpawnPoint;

	bool enFire1 = false;
	ControlLampara ctrLampara=null;

	public GameObject hacha= null;

	public bool jumping = false;
	public bool isOnTheFloor = false;
	public float yJumpForce = 200;
	Vector2 jumpForce;

	public GameObject RetroalimentacionEnergia;

	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		hacha = GameObject.Find ("/orc/orc_body/orc _R_arm/orc _R_hand/orc_weapon");
		retroalimentacionSpawnPoint = GameObject.Find ("spawnPoint").transform;
		energy = 100;

		jumpForce = new Vector2 (0, 0);
	}

	void Update () {
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("muriendo")) {
			if (energy <= 0){
				energy = 0;
				anim.SetTrigger("morir");
			}
		} else 
			return;


		if (Mathf.Abs (Input.GetAxis ("Fire1")) > 0.01f) {
			if (enFire1 == false) {
				enFire1 = true;
				hacha.GetComponent<CircleCollider2D>().enabled = false;
				anim.SetTrigger ("attack");
				if (ctrLampara != null) {
					if (ctrLampara.GolpeOrco()){
						energy += premioArbol;
						if (energy >100)
							energy = 100;
					}
					else{
						energy -= costoGolpeLamp;
					}
				}
				else{
					energy -= costoGolpeAire;
				}
			}
		} else {
			enFire1 = false;
		}
		slider.value = energy;
		txt.text = energy.ToString ();
	}
	private void IncrementarEnergia(int incremento) {
		energy += incremento;
		InstanciarRetroalimentacionEnergia(incremento);
	}
	
	private void InstanciarRetroalimentacionEnergia(int incremento) {
		GameObject retroalimentcionGO = null;
		if (retroalimentacionSpawnPoint!=null)
			retroalimentcionGO = (GameObject)Instantiate(RetroalimentacionEnergia, retroalimentacionSpawnPoint.position, retroalimentacionSpawnPoint.rotation);
		else
			retroalimentcionGO = (GameObject)Instantiate(RetroalimentacionEnergia, transform.position, transform.rotation);
		
		retroalimentcionGO.GetComponent<RetroalimentacionEnergia>().cantidadCambiodeEnergia = incremento;
	}
	// Update is called once per frame
	void FixedUpdate () {
		float v = Input.GetAxis ("Horizontal");
		Vector2 vel = new Vector2 (0, rgb.velocity.y);
		v *= maxVel;
		vel.x = v;
		rgb.velocity = vel;

		anim.SetFloat ("speed", vel.x);

		if (haciaDerecha && v < 0) {
			haciaDerecha = false;
			Flip ();
		} else if (!haciaDerecha && v > 0) {
			haciaDerecha = true;
			Flip ();
		}
	   
		VerificarInputParaSaltar ();
	}

	private void VerificarInputParaSaltar(){
		isOnTheFloor = rgb.velocity.y == 0;

		if (Input.GetAxis ("Jump") > 0.01f) {
			
			if (!jumping && isOnTheFloor) {
				jumping = true;
				jumpForce.x = 0f;
				jumpForce.y = yJumpForce;
				rgb.AddForce (jumpForce);
			}
		} else 
			jumping = false;

	}

		
	

	
		void Flip(){
			var s = transform.localScale;
			s.x *= -1;
			transform.localScale = s;
		}

	public void HabilitarTriggerHacha(){
		hacha.GetComponent<CircleCollider2D> ().enabled = true;

	}
	public void SetControlLampara(ControlLampara ctr){
		ctrLampara = ctr;
	    }


	public void RecibirBala(){
		energy -= costoBala;

	     }
	}
		

