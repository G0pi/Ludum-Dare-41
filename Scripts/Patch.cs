using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patch : MonoBehaviour {
	public static GameObject[] growCycle;
	public bool harvestable { get; private set; }


	[SerializeField]
	private Plant plant;

	private float growStart = 0;
	private int growCycleIndex = 0;
	private GameObject currGrowing;
	private Transform growPoint;

	void Start () {
		growPoint = transform.Find ("SpawnPoint");
		harvestable = false;
	}

	void Update() {
		if (plant != null) {
			if (Time.time >= growStart + plant.getGrowTime()) {
				harvestable = true;
				UpdateCurrGrowing (plant.getHarvest ().getEquipableGameObject ());
			} else {
				float timeSinceGrowStart = Time.time - growStart;
				int newGrowCycleIndex = (int)(timeSinceGrowStart / (plant.getGrowTime () / growCycle.Length));
				if (newGrowCycleIndex != growCycleIndex) {
					UpdateCurrGrowing (growCycle[newGrowCycleIndex]);
					growCycleIndex = newGrowCycleIndex;
				}
			}
		}
	}

	public void PlantSeed(Plant plant) {
		growStart = Time.time;
		UpdateCurrGrowing (growCycle [0]);
		this.plant = plant;
	}

	public bool Plantable() {
		return plant == null;
	}

	public bool Harvestable() {
		return plant != null;
	}

	public Equipable Harvest() {
		Equipable ret = plant.getHarvest ();
		plant = null;
		Destroy (currGrowing);
		return ret;
	}

	void UpdateCurrGrowing(GameObject newGrowing) {
		if(currGrowing != null)
			Destroy (currGrowing);
		currGrowing = Instantiate (newGrowing, growPoint) as GameObject;
	}
}

