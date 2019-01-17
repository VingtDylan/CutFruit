using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour {

	public Sprite[] soundSprites;

	private Button Play;
	private Button Sound;
	private AudioSource bgSound;
	private Image imgSound;

	void Start () {
		getComponents();
		Play.onClick.AddListener(onPlayClick);
		Sound.onClick.AddListener(onSoundClick);
	}

	private void getComponents(){
		Play=transform.Find("Play").GetComponent<Button>();
		Sound=transform.Find("Sound").GetComponent<Button>();
		bgSound=transform.Find("Sound").GetComponent<AudioSource>();
		imgSound=transform.Find("Sound").GetComponent<Image>();
	}

	private void onDestroy(){
		Play.onClick.RemoveListener(onPlayClick);
		Sound.onClick.RemoveListener(onSoundClick);
	}

	private void onPlayClick(){
		SceneManager.LoadScene("PlayScene",LoadSceneMode.Single);
	}


	private void onSoundClick(){
		if(bgSound.isPlaying){
			bgSound.Pause();
			imgSound.sprite=soundSprites[1];
		}else{
			bgSound.Play();
			imgSound.sprite=soundSprites[0];
		}
	}

}
