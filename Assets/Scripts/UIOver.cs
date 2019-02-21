using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.Events;

public class UIOver : MonoBehaviour {

	//public UnityEvent events;

	public void OnClick(){
		SceneManager.LoadScene(0);
	}
}
