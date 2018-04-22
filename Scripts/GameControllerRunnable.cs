using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameControllerRunnable : MonoBehaviour {
	public virtual void Init (){}
	public virtual void Tick(){}
}
