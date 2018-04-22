using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour {
	public void Lock() {
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void Unlock() {
		Cursor.lockState = CursorLockMode.None;
	}

}
