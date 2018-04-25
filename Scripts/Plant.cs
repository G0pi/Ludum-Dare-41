using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

	[SerializeField]
	private string plantName;
	[SerializeField]
	public float growTime;
	[SerializeField]
	private Equipable harvest;

	public Equipable getHarvest() {
		return harvest;
	}

	public float getGrowTime() {
		return growTime;
	}
}
