using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : AnimatedEquipable {

	public static Transform center;

	[SerializeField]
	private float damage;

	public override void Use() {
		Debug.Log ("Attack");
		TriggerAttackAnimation ();
		Collider[] cols = Physics.OverlapBox (center.position, new Vector3 (1f, 1.5f, 1f), transform.rotation);
		foreach(Collider col in cols) {
			if (col.tag.Equals ("Enemy")) {
				col.gameObject.GetComponent<Enemy> ().TakeHit (damage);
			}
		}
	}

	void OnDrawGizmos() {
		if (center != null) {
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube (center.position, new Vector3 (2f,3f,2f));
		}
	}
}
