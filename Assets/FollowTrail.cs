using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrail : MonoBehaviour {

	public BezierCurve trail;

	[Range(0.0f, 1.0f)]
	public float trailPosition;

	[Range(0.0f, 1.0f)]
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		trailPosition += Input.GetAxis ("Horizontal") * speed;
		trailPosition = Mathf.Clamp (trailPosition, 0.0f, 1.0f);
		transform.position = trail.GetPointAt (trailPosition);
	}
}
