using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector2 mouseMovement { get; private set; }
	public Vector2 input { get; private set; }
	public bool attacking { get; private set; }
	public int equipableSwitch { get; set; }


	// Use this for initialization
	void Start () {
		mouseMovement = Input.mousePosition;
		input = Vector2.zero;
		attacking = false;
		equipableSwitch = 0;
	}

	// Update is called once per frame
	void Update () {
		input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		attacking = Input.GetButtonDown ("Fire1");

		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		if (scroll < 0)
			equipableSwitch--;
		else if (scroll > 0)
			equipableSwitch++;


	}
}
