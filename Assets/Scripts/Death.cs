using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour {

	public UnityEvent beforeDeath = new UnityEvent();
	public UnityEvent afterDeath = new UnityEvent();

	private bool dead = false;

	public void Die () {
		if (!dead) {
			dead = true;
			beforeDeath.AddListener (afterDeath.Invoke);
			afterDeath.AddListener (DestroyObject);
			beforeDeath.Invoke ();
		}
	}

	private void DestroyObject() {
		Destroy (gameObject);
	}
}
