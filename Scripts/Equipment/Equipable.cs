using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipable : MonoBehaviour {

	public static Transform equipableParent;

	[SerializeField]
	private string equipableName;
	[SerializeField]
	private GameObject equipable;
	[SerializeField]
	private Vector3 uiRotation = new Vector3(-130, -90, 90);
	[SerializeField]
	private Vector3 uiScale = new Vector3(3, 3, 3);

	private GameObject instantiatedEquipable;

	public virtual void Equip() {
		instantiatedEquipable = Instantiate (equipable, equipableParent) as GameObject;
	}

	public virtual void Unequip () {
		Destroy (instantiatedEquipable);
	}
		
	public GameObject getEquipableGameObject() {
		return equipable;
	}

	public Vector3 getUIRotation() {
		return uiRotation;
	}

	public Vector3 getUIScale() {
		return uiScale;
	}

	public abstract void Use ();

	public virtual void FixedUpdate() {}

}
