using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schyte : Placable {

	[SerializeField]
	private Inventory inv;

	public override void Use() {
		TriggerAttackAnimation ();
		RaycastHit hit;
		if (CheckValidPlaceable(out hit)) {
			inv.Add(hit.collider.GetComponentInParent<Patch> ().Harvest());
		}
	}

	public override void Equip() {
		base.Equip ();
		inv = GameObject.Find ("Player").GetComponent<Inventory> ();
	}

	public override bool CheckValidPlaceable(out RaycastHit hit) {
		bool didHit = CheckPlaceable (out hit);
		if (didHit) {
			return hit.collider.GetComponentInParent<Patch> ().Harvestable ();
		}
		return false;
	}


}
