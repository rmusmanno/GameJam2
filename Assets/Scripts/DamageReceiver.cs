using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageReceiver : MonoBehaviour {

	public UnityEvent damageEvent = new UnityEvent();

	// Use this for initialization
	void Start () {
		damageEvent.AddListener (Die);
	}

	private void Die () {
		Debug.Log ("DIE!!!");
	}
}
