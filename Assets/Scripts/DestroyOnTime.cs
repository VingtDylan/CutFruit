using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

	public float cutTime=2.0f;

	void Start(){
		Invoke("Cut",cutTime);
	}

	void Cut(){
		Destroy(gameObject);
	}
}
