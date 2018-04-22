using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipable : MonoBehaviour {

	public static Transform equipableParent;

	[SerializeField]
	private string equipableName;
	[SerializeField]
	private GameObject equipable;
	private GameObject instantiatedEquipable;

	public void Equip() {
		instantiatedEquipable = Instantiate (equipable, equipableParent) as GameObject;
	}

	public void Unequip () {
		Destroy (instantiatedEquipable);
	}

	public abstract void Use ();

}
