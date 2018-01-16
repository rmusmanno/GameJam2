using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingInput : MonoBehaviour {

	public UnityEvent shootEvent = new UnityEvent();

	private Camera cam;
	private float currentRecoil = 0.0f;

	public float recoil = 1.0f;

	void Start()
	{
		cam = Camera.main;
		currentRecoil = recoil;
	}

	void Update()
	{
		currentRecoil += Time.deltaTime;
		currentRecoil = Mathf.Clamp (currentRecoil, 0.0f, recoil);

		if (!Input.GetMouseButton(0) || !IsRecoilDone())
			return;

		shootEvent.Invoke ();

		currentRecoil = 0.0f;

		RaycastHit hit;
		if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
			return;

		Renderer rend = hit.transform.GetComponent<Renderer>();
		MeshCollider meshCollider = hit.collider as MeshCollider;

		DamageReceiver damageReceiver = hit.transform.GetComponent<DamageReceiver>();
		if (damageReceiver) {
			damageReceiver.damageEvent.Invoke ();
		}

		/*
		if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
			return;


		Texture2D tex = rend.material.mainTexture as Texture2D;
		Vector2 pixelUV = hit.textureCoord;
		pixelUV.x *= tex.width;
		pixelUV.y *= tex.height;

		//tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
		//tex.Apply();
		Debug.Log(tex.GetPixel((int)pixelUV.x,(int)pixelUV.y));
		*/
	}

	private bool IsRecoilDone() {
		return currentRecoil >= recoil;
	}
}