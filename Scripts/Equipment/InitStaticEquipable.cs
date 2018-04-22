using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStaticEquipable : GameControllerRunnable {

	[SerializeField]
	private Transform equipableParent;
	[SerializeField]
	private Animator playerAnimator;
	[SerializeField] 
	private Transform attackCheck;


	public override void Init() {
		Equipable.equipableParent = equipableParent;
		AnimatedEquipable.animator = playerAnimator;
		Weapon.center = attackCheck;
	}

}
