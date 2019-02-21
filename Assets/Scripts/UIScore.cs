using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScore : MonoBehaviour {
	//单例对象
	public static UIScore Instance = null;

	void Awake(){
		Instance=this;
	}

	[SerializeField]
	private Text TextScore;

	private int score=0;

	public void AddScore(int score){
		this.score+=score;
		TextScore.text=this.score.ToString();
	}

	public void Remove(int score){
		this.score-=score;
		if(this.score<=0){
			SceneManager.LoadScene("overScene");
		}
		TextScore.text=this.score.ToString();
	}
}
