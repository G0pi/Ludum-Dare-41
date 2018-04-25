using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	[SerializeField]
	private Equipable[] inventory = new Equipable[10];
	private GameObject[] uiInv = new GameObject[10];
	[SerializeField]
	private Transform invParent;
	[SerializeField]
	private RectTransform invUiSelect;
	[SerializeField]
	private int inventoryIndex = 0;

	void Start() {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] != null) {
				SetUIInventory(i, inventory[i]);
			}
		}
	}

	public void Add(Equipable equipable) {
		for(int i = 0; i < inventory.Length; i++) {
			if(inventory[i] == null) {
				inventory [i] = equipable;
				SetUIInventory (i, equipable);
				return;
			}
		}
	}

	public Equipable Remove() {
		Equipable ret = inventory [inventoryIndex];
		inventory [inventoryIndex] = null;
		Destroy (uiInv [inventoryIndex]);
		uiInv [inventoryIndex] = null;
		return ret;
	}

	public Equipable Next() {
		inventoryIndex = (inventoryIndex + 1) % inventory.Length;
		RecalculateUISelect ();
		return inventory [inventoryIndex];
	}

	public Equipable Prev() {
		inventoryIndex--;
		if (inventoryIndex < 0) {
			inventoryIndex = inventory.Length - 1;
		}
		RecalculateUISelect ();
		return inventory [inventoryIndex];
	}

	public Equipable GetCurrentWeapon() {
		return inventory [inventoryIndex];
	}

	public int getInventoryIndex() {
		return inventoryIndex;
	}

	void SetUIInventory(int index, Equipable equip) {
		uiInv[index] = Instantiate(equip.getEquipableGameObject(), invParent) as GameObject;
		ChangeLayer (uiInv [index], 5);
		uiInv [index].transform.localPosition = new Vector3 (-255f + 55f * index, 20f, -.1f);
		uiInv [index].transform.localRotation = Quaternion.Euler (equip.getUIRotation ());
		uiInv [index].transform.localScale = equip.getUIScale ();
	}

	void RecalculateUISelect () {
		Vector2 newPos = invUiSelect.anchoredPosition;
		newPos.x = inventoryIndex * 55f;
		invUiSelect.anchoredPosition = newPos;
	}

	void ChangeLayer(GameObject go, int layer) {
		go.layer = layer;
		Debug.Log (go.name + ": " + go.transform.childCount);
		for (int i = 0; i < go.transform.childCount; i++) {
			ChangeLayer (go.transform.GetChild (i).gameObject, layer);
		}
	}
}
