using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BestHTTP;
using System;

public class Profile : BaseUI {

	public Text diplayName;
	public InputField firstName;
	public InputField lastName;
	public InputField email;
	public InputField username;
	public Image profilePic;
	void Start () {
		transform.parent = GameManager.Instance.topPopup.transform;
		if(GameManager.Instance.player.username==""){
			if(GameManager.Instance.menuManager.NavigationStackPeek() == UIManager.State.Profile){
				GameManager.Instance.menuManager.PushMenu(UIManager.State.Authenticate);
			}
		}
		else{
			RefresUI();
		}
	}
	
	
	public void RefresUI(){
		string url = "https://159.203.125.111/" + GameManager.Instance.player.profileImageURL.TrimStart('/');
		Debug.Log("WWW download >" + url);
		
		new HTTPRequest(new Uri(url), (request, response) =>
		{
			var tex = new Texture2D(0, 0);
			HTTPResponse res = (HTTPResponse)response;
			tex.LoadImage(res.Data);
			profilePic.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f,0.5f), 40);
		}).Send();
		firstName.text = GameManager.Instance.player.firstName;
		lastName.text = GameManager.Instance.player.lastName;
		email.text = GameManager.Instance.player.email;
		username.text = GameManager.Instance.player.username;
		diplayName.text = GameManager.Instance.player.displayName;

		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
