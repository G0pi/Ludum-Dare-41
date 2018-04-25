using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Placable : AnimatedEquipable {

	[SerializeField]
	protected LayerMask layerMask;
	[SerializeField]
	protected string validPlaceTag;
	[SerializeField]
	protected float placeDistance = 3f;
	[SerializeField]
	private bool ghosting = true;
	[SerializeField]
	private GameObject ghostPrefab;
	[SerializeField]
	private Color32 validPlace = new Color32 (255, 255, 255, 100);
	[SerializeField]
	private Color32 invalidPlace = new Color32 (255, 0, 0, 100);

	private GameObject ghost;
	private Material ghostMaterial;

	public override void Equip() {
		base.Equip ();
		if (ghosting) {
			ghost = Instantiate (ghostPrefab) as GameObject;
			ghost.SetActive (false);
			ghostMaterial = ghost.GetComponent<MeshRenderer> ().material;
		}
	}

	public override void Unequip() {
		if (ghosting) {
			Destroy (ghost);
			ghost = null;
			ghostMaterial = null;
		}
		base.Unequip ();
	}

	public void GhostUpdate() {
		if (!ghosting) {
			Debug.LogError ("You haven't enabled ghosting");
			return;
		}
		RaycastHit hit;
		bool didHit = CheckPlaceable (out hit);

		if (didHit) {
			ghost.SetActive (true);
			ghost.transform.position = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
			if (CheckValidPlaceable(out hit)) {
				ghostMaterial.color = validPlace;
			} else {
				ghostMaterial.color = invalidPlace;
			}
		} else {
			ghost.SetActive (false);
		}
	}

	public virtual bool CheckPlaceable(out RaycastHit hit) {
		return Physics.Raycast(
			Camera.main.ScreenPointToRay (
				new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2)), 
			out hit, 
			placeDistance,
			layerMask);
	}

	public virtual bool CheckValidPlaceable(out RaycastHit hit) {
		bool didHit = CheckPlaceable (out hit);
		if (didHit && hit.collider.tag.Equals (validPlaceTag)) {
			return true;
		}
		return false;
	}
}
