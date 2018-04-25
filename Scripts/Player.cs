using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Equipable currEquip;
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float mouseSense = 5f;
	[SerializeField]
	private Vector2 yLookInterval = new Vector2(-90, 90);
	private float xLook;
	private Transform cam;
	private PlayerController pc;
	private Animator anim;
	private Inventory inv;


	// Use this for initialization
	void Start () {
		cam = Camera.main.gameObject.transform;
		pc = GetComponent<PlayerController> ();
		anim = GetComponentInChildren<Animator> ();
		xLook = 0f;
		inv = GetComponent<Inventory> ();
		SwitchEquipable (inv.GetCurrentWeapon());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Movement
		transform.Translate(new Vector3(pc.input.x, 0, pc.input.y) * speed * Time.fixedDeltaTime);
		xLook -= pc.mouseMovement.y * mouseSense * Time.fixedDeltaTime;
		xLook = Mathf.Clamp (xLook, yLookInterval.x, yLookInterval.y);
		cam.eulerAngles = new Vector3 (xLook, cam.eulerAngles.y, cam.eulerAngles.z);
		transform.Rotate (Vector3.up, pc.mouseMovement.x * mouseSense * Time.fixedDeltaTime);

		// Attack
		if (pc.attacking) {
			Attack ();
		}

		// Switch Weapon Handler
		if (pc.equipableSwitch < 0) {
			SwitchEquipable (inv.Prev ());
			pc.equipableSwitch++;
		} else if(pc.equipableSwitch > 0) {
			SwitchEquipable (inv.Next ());
			pc.equipableSwitch--;
		}

		// Animations
		if (!pc.input.Equals (Vector2.zero)) {
			anim.SetBool ("Walking", true);
		} else {
			anim.SetBool ("Walking", false);
		}

		// Call currEquip FixedUpdate
		if (currEquip != null) {
			currEquip.FixedUpdate ();
		}
	}

	void Attack() {
		if(currEquip != null) 
			currEquip.Use ();
	}

	void SwitchEquipable (Equipable equipable) {
		if (currEquip != null) {
			currEquip.Unequip();
		}
		currEquip = equipable;
		if (equipable != null) {
			equipable.Equip ();
		}
	}


}
