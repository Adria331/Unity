using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTorre : MonoBehaviour {
	public Rigidbody bala;
	public GameObject balapos;
	public GameObject apuntador;
	float time = 0;
	float seconds = 0.1f;
	public LayerMask enemy;

	GameObject[] targets = new GameObject[100];
	GameObject actualtarget = null;
	// Use this for initialization
	void Start () {
	}
	

 //////////////////////////////////////////////////////////

	void Update () {

		if (actualtarget == null) {
			choose ();
		}


		if (actualtarget != null) {
			apuntar ();
			if (time >= seconds) {
				Shoot ();
				seconds = seconds + 1;
			}
			time += Time.deltaTime;
		}

		targetup ();
	}



	void targetup(){
		if (!inTarget (actualtarget))
			actualtarget = null;
	}
	//////////////////////////////////////////////////////////
	void Shoot(){
		Rigidbody balanova = Instantiate(bala, balapos.transform.position, apuntador.transform.rotation) as Rigidbody;
		balanova.velocity = apuntador.transform.TransformDirection (new Vector3(0,0,-20));

	}


	//////////////////////////////////////////////////////////
	void OnTriggerEnter(Collider col){
		if (col.tag == "enemy") {
			if (!inTarget(col.gameObject)) {
				add(col.gameObject);
			}
		}
			
	}
	void OnTriggerExit(Collider col){
		remove(col.gameObject);
	}


	//////////////////////////////////////////////////////////
	bool inTarget(GameObject g){
		for (int i = 0; i < 100; i++) {
			if (targets [i] == g) {
				return true;
			}
		}
		return false;
	}

	void add(GameObject g){
		for (int i = 0; i < 100; i++) {
			if (targets [i] == null) {
				targets [i] = g;
				return;
			}
		}
	}

	void remove(GameObject g){
		for (int i = 0; i < 100; i++) {
			if (targets [i] == g) {
				targets [i] = null;
				return;
			}
		}
	}
	//////////////////////////////////////////////////////////
	void choose(){
		for(int i = 0; i<100;i++){
			if (targets [i] != null){
				actualtarget = targets [i];
				return;
			}
		}
	}

	void apuntar(){
		transform.LookAt (actualtarget.transform.position);
	}
}
