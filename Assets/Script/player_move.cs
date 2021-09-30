using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    float _velocidade;
	float _girar;
	int count = 0;
	int close;
	private Animator animator_controller;

	void Start () {
		_velocidade = 10;
		_girar = 150;
		animator_controller = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Action();
		float translate = (Input.GetAxis ("Vertical") * _velocidade) * Time.deltaTime;
		float rotate = (Input.GetAxis ("Horizontal") * _girar) * Time.deltaTime;

		transform.Translate (0, 0, translate);
		transform.Rotate (0, rotate, 0);

	}

	void Action(){
		if(Input.GetKey(KeyCode.W)){
			//animator_controller.SetFloat("speed",2);
		}
		if(Input.GetKey(KeyCode.S)){
			//animator_controller.SetInteger("action",0);
		}
		if(Input.GetButtonDown("Protect")){
			animator_controller.SetInteger("action",3);
			close = 30;
		}
		if(Input.GetButtonDown("Kick")){
			animator_controller.SetInteger("action",1);
			close = 64;
		}
		if(Input.GetButtonDown("Punch")){
			animator_controller.SetInteger("action",4);
			close = 31;
		}
		if(Input.GetButtonDown("Take")){
			animator_controller.SetInteger("action",6);
			close = 141;
		}
		if(Input.GetButtonDown("Terrified")){
			animator_controller.SetInteger("action",7);
			close = 600+105+81;
		
		}else{
			count += 1;
			close-=1;
			if(count==3000){
				animator_controller.SetInteger("action",8);
				close = 250;
				count = 0;
			}else if (close<=0){
				animator_controller.SetInteger("action",-1);
				close = 0;
			}
		}
	}
}
