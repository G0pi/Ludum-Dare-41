using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Placable {

	[SerializeField]
	Plant plant;

	public override void Use() {
		TriggerAttackAnimation ();
		RaycastHit hit;
		if (CheckValidPlaceable (out hit)) {
			hit.collider.GetComponent<Patch> ().PlantSeed (plant);
		}
	}

	public override void FixedUpdate() {
		GhostUpdate ();
	}

	public override bool CheckValidPlaceable(out RaycastHit hit) {
		bool didHit = CheckPlaceable (out hit);
		if (didHit) {
			return hit.collider.GetComponent<Patch> ().Plantable ();
		}

		return false;
	}
}
