using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(GameManager.Instance.click);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
