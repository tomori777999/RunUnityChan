using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTapped () {
		this.GetComponent<Animator>().SetTrigger("Jump");
	}

	public void OnCollidedWithObstacle () {
		this.GetComponent<Animator>().SetTrigger("Collision");
	}

	public void OnCallChangeFace () {

	}
}
