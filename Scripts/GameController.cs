using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public bool paused { get; private set; }
	private CursorLock cursorLock;

	// Use this for initialization
	void Awake () {
		paused = false;
		cursorLock = GetComponent<CursorLock> ();
		cursorLock.Lock ();
		GameControllerRunnable[] initScripts = GetComponents<GameControllerRunnable> ();
		foreach (GameControllerRunnable gcr in initScripts) {
			gcr.Init ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Invoke all GameControllerRunnable scripts on this object
		GameControllerRunnable[] initScripts = GetComponents<GameControllerRunnable> ();
		foreach (GameControllerRunnable gcr in initScripts) {
			gcr.Tick ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			OnPause ();
		}
	}

	void OnPause() {
		paused = !paused;
		if (paused) {
			Time.timeScale = 0f;
			cursorLock.Unlock ();
		} else {
			Time.timeScale = 1f;
			cursorLock.Lock ();
		}
	}
}
