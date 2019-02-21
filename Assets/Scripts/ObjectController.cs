using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

	public GameObject halfFruit;
	public GameObject Splash;
	public GameObject SplashFlat;
	public AudioClip audioClip;

	private bool cut=false;

	public void OnCut(){
		if(cut){
			return;
		}
		if(gameObject.name.Contains("Bomb")){
			Instantiate(Splash,transform.position,Quaternion.identity);
			UIScore.Instance.Remove(100);
		}else{
			for(int i=0;i<2;i++){
				GameObject fruitcut=Instantiate<GameObject>(halfFruit,transform.position,Random.rotation);
				fruitcut.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*5f,ForceMode.Impulse);
			}
			Instantiate(Splash,transform.position,Quaternion.identity);
			Instantiate(SplashFlat,transform.position,Quaternion.identity);
			UIScore.Instance.AddScore(10);
		}
		AudioSource.PlayClipAtPoint(audioClip,transform.position);
		Destroy(gameObject);
		cut=true;
	}
}
