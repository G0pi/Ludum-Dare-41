using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimatedEquipable : Equipable {
	public static Animator animator;

	public void TriggerAttackAnimation () {
		animator.SetTrigger ("Attack");
	}
}
