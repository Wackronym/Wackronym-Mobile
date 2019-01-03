using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SocialPlatforms.GameCenter;
public class Menu : BaseUI {
	public TextMesh XP;
    public TextMesh Clock;
    public TextMesh Coins;
    public TextMesh Level;
    public TextMesh Scores;
	void Start () {
		GameManager.Instance.menuManager.previousState = UIManager.State.MainMenu;
		GameManager.Instance.menuManager.currentState = UIManager.State.MainMenu;
		AudioListener.pause = false;
        Time.timeScale = 1;
	    
	    if (PlayerPrefs.HasKey("Unlimited"))
	    {
		    GameManager.Instance.unlimited = true;
	    }
		GameManager.Instance.backButton.transform.parent.gameObject.SetActive(true);
		base.AddMouseDownEvent();
    }

	void Update () {
		DateTime time = DateTime.Now;
	}

	public void Play(){
 
	    GameManager.Instance.menuManager.PushMenu(UIManager.State.Settings);
        GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(GameManager.Instance.beginLevel);
    }

	public void Setting(){
		if(GameManager.Instance.menuManager.NavigationStackPeek() == UIManager.State.Settings){
			return;
		}
		GameManager.Instance.menuManager.PushMenu (UIManager.State.Settings);
	}
    
	public void PopSetting(){
		if(GameManager.Instance.menuManager.NavigationStackPeek() == UIManager.State.Settings){
			GameManager.Instance.menuManager.PopMenuToState(UIManager.State.MainMenu);
		}
	}
    public void UpdateUI()
    {
        Coins.text = GameManager.Instance.Coin().ToString();
    }
}
