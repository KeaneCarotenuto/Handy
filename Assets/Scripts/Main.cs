﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public GameObject Body;
	public GameObject Arm1;
	public GameObject Arm2;
	public GameObject Equipped;

	private void OnDrawGizmos() {
		UnityEditor.Handles.color = Color.yellow - new Color(0, 0, 0, 0.5f);
		UnityEditor.Handles.DrawWireDisc(Camera.main.ScreenToWorldPoint(Input.mousePosition) - Vector3.back*10, Vector3.forward, 0.2f);
	}

	bool slow = false;
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.LeftAlt)) {
			if (slow == false) {
				slow = true;
				Time.timeScale = 0.5f;
			}
			else {
				slow = false;
				Time.timeScale = 1f;
			}
		}

		if (Input.GetKey(KeyCode.W)) {
			Body.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
		}
		if (Input.GetKey(KeyCode.A)) {
			Body.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 100);
		}
		if (Input.GetKey(KeyCode.D)) {
			Body.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
		}
		if (Input.GetKey(KeyCode.S)) {
			Body.GetComponent<Rigidbody2D>().AddForce(-Vector2.up * 100);
		}
	}

	public void SuperMode() {
		Time.timeScale = 0.5f;

		Arm1.GetComponent<ArmMove>().Force = Arm1.GetComponent<ArmMove>().DefaultForce * 2;
		Arm2.GetComponent<ArmMove>().Force = Arm2.GetComponent<ArmMove>().DefaultForce * 2;
	}

	public void StopSuper() {
		Time.timeScale = 1f;

		Arm1.GetComponent<ArmMove>().Force = Arm1.GetComponent<ArmMove>().DefaultForce;
		Arm2.GetComponent<ArmMove>().Force = Arm2.GetComponent<ArmMove>().DefaultForce;
	}
}
