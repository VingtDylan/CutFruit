using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[Header("水果的预设")]
	public GameObject[] Fruits;
	[Header("炸弹的预设")]
	public GameObject Bomb;

	private bool isPlaying=true;

	private float spawnTime = 1.0f;
	private float currentTime = 0.0f;
	private float tmpz=-2.0f;

	void Start () {

	}

	void Update () {
		if(!isPlaying){
			return;
		}
		if(currentTime<spawnTime){
			currentTime+=Time.deltaTime;
			if(currentTime>=spawnTime){
				int fruitCount=Random.Range(1,5);
				for(int i=0;i<fruitCount;i++){
					onSpawn(true);
				}
				currentTime=0.0f;
				int bombNum=Random.Range(0,100);
				if(bombNum>70){
					onSpawn(false);
				}
			}
		}
	}

	private void onSpawn(bool isFruit){
		float x = Random.Range(-8.4f,8.4f);
		float y = transform.position.y;
		float z = tmpz;
		if(tmpz<=-10)
			tmpz=0.0f;
		tmpz-=2.0f;
		int fruitIndex=Random.Range(0,Fruits.Length);
		GameObject go;
		if(isFruit)
			go=Instantiate<GameObject>(Fruits[fruitIndex],new Vector3(x,y,z),Random.rotation);
		else
			go=Instantiate<GameObject>(Bomb,new Vector3(x,y,z),Random.rotation);
		Vector3 velocity = new Vector3(-x*Random.Range(0.2f,0.8f),-Physics.gravity.y*Random.Range(1.0f,1.2f),0);
		Rigidbody rigidbody = go.GetComponent<Rigidbody>();
		rigidbody.velocity=velocity;
	}

	private void OnCollisionEnter(Collision col){
		Destroy(col.gameObject);
	}
}
