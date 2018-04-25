using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spade : Placable {

	[SerializeField]
	private GameObject patch;

	public override void Use() {
		TriggerAttackAnimation ();
		RaycastHit hit;
		if (CheckValidPlaceable(out hit)) {
			Instantiate (patch, new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z)), Quaternion.identity);
		}
	}

	public override void FixedUpdate() {
		GhostUpdate ();
	}


}
