using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	float hitpoints = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeHit(float damage) {
		hitpoints -= damage;
		if (hitpoints <= 0) {
			Destroy (gameObject);
		}
	}
}
