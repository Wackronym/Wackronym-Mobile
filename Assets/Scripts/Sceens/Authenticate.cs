
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BestHTTP;
using BestHTTP.JSON;
using System;
using System.Collections.Generic;

public class Authenticate : BaseUI
{

	#region UI Variable Statement 
	[SerializeField] public GameObject registerPanel; 
	[SerializeField] public GameObject loginPanel; 
	[SerializeField] public GameObject forgetPanel; 
	[SerializeField] private bool isConnecting; 
	[SerializeField] private int loginHudIndex = 0;
	[SerializeField] public InputField login_Text_email;
	[SerializeField] public InputField login_Text_password;
	
	[SerializeField] public InputField reg_Text_fName;
	[SerializeField] public InputField reg_Text_lName;
	[SerializeField] public InputField reg_Text_email;
	[SerializeField] public InputField reg_Text_password;
	[SerializeField] public InputField reg_Text_username;
	[SerializeField] public InputField forget_Text_email;
	
	#endregion 
	void Start () {
		transform.parent = GameManager.Instance.topPopup.transform;
	}
	
	public void GoLogIn() {
		isConnecting = true;
		loginHudIndex = 0;
		//Gdx.input.setOnscreenKeyboardVisible(false);
		HTTPRequest www = new HTTPRequest(new Uri( GameManager.Instance.webURLPrefix + "auth/signin"),HTTPMethods.Post,(request, response) => {
			HTTPResponse res = (HTTPResponse)response;
			
			if(res.IsSuccess){
				string request_result = res.DataAsText;
				if (request_result.Length > 10) {	
					Debug.Log( res.DataAsText);
					//GameManager.Instance.player = Json.Decode(request_result) as Player;
					Dictionary<string, object> b = Json.Decode(request_result) as Dictionary<string, object>;
					GameManager.Instance.player = new Player();
					GameManager.Instance.player._id 					=  		b["_id"].ToString();
					GameManager.Instance.player.displayName 			=  		b["displayName"].ToString();
					GameManager.Instance.player.provider 				=  		b["provider"].ToString();
					GameManager.Instance.player.username 				=  		b["username"].ToString();
					GameManager.Instance.player.__v 					=  		int.Parse(b["__v"].ToString());
					GameManager.Instance.player.resetPasswordToken 		=  		b["resetPasswordToken"].ToString();
					GameManager.Instance.player.resetPasswordExpires 	=  		b["resetPasswordExpires"].ToString();
					GameManager.Instance.player.profileImageURL 		=  		b["profileImageURL"].ToString();
					GameManager.Instance.player.email 					=  		b["email"].ToString();
					GameManager.Instance.player.lastName 				=  		b["lastName"].ToString();
					GameManager.Instance.player.firstName 				=  		b["firstName"].ToString();
					GameManager.Instance.player.created 				=  		b["created"].ToString();
					Debug.Log( b["roles"].GetType());
					GameManager.Instance.player.roles  = new List<string>();
					foreach(object t in b["roles"] as List<object>){
						GameManager.Instance.player.roles.Add(t.ToString());
					}
					GameManager.Instance.menuManager.PopMenu();
					Profile p  = GameManager.Instance.topPopup.GetComponentInChildren<Profile>();
					if(p != null){
						p.RefresUI();
					}
				}
			}
			else{
				login_Text_email.text = "Incorrect User!";
			}
			isConnecting = false;
		});
		www.AddField("usernameOrEmail", login_Text_email.text);
		www.AddField("password", login_Text_password.text);
		www.Send();
	}
	public void Register() {
		isConnecting = true;
		loginHudIndex = 0;
		HTTPRequest www = new HTTPRequest(new Uri( GameManager.Instance.webURLPrefix + "auth/signup"),HTTPMethods.Post,(request, response) => {
			HTTPResponse res = (HTTPResponse)response;
			Debug.Log( res.DataAsText);
			if(res.IsSuccess){
				string request_result = res.DataAsText;
				if (request_result.Length > 10) {
					Dictionary<string, object> b = Json.Decode(request_result) as Dictionary<string, object>;
					GameManager.Instance.player = new Player();
					GameManager.Instance.player._id 					=  		b["_id"].ToString();
					GameManager.Instance.player.displayName 			=  		b["displayName"].ToString();
					GameManager.Instance.player.provider 				=  		b["provider"].ToString();
					GameManager.Instance.player.username 				=  		b["username"].ToString();
					GameManager.Instance.player.__v 					=  		int.Parse(b["__v"].ToString());
					GameManager.Instance.player.profileImageURL 		=  		b["profileImageURL"].ToString();
					GameManager.Instance.player.email 					=  		b["email"].ToString();
					GameManager.Instance.player.lastName 				=  		b["lastName"].ToString();
					GameManager.Instance.player.firstName 				=  		b["firstName"].ToString();
					GameManager.Instance.player.created 				=  		b["created"].ToString();
					Debug.Log( b["roles"].GetType());
					GameManager.Instance.player.roles  = new List<string>();
					foreach(object t in b["roles"] as List<object>){
						GameManager.Instance.player.roles.Add(t.ToString());
					}
					GameManager.Instance.menuManager.PopMenu();
					Profile p  = GameManager.Instance.topPopup.GetComponentInChildren<Profile>();
					if(p != null){
						p.RefresUI();
					}
					isConnecting = false;	
				}
			}
			else{
				if( res.DataAsText.Contains("The password must be at least 10 characters long")){
					reg_Text_username.text = "The password must be at least 10 characters long.";
				}
				else if( res.DataAsText.Contains("The password may not contain sequences of three or more repeated characters.")){
					reg_Text_username.text = "The password may not contain sequences of three or more repeated characters.";
				}
				else if( res.DataAsText.Contains("Please enter a valid username: 3+ characters long, non restricted word, characters \"_-.\", no consecutive dots, does not begin or end with dots, letters a-z and numbers 0-9.")){
					reg_Text_username.text = "Please enter a valid username: 3+ characters long, non restricted word, characters \"_-.\", no consecutive dots, does not begin or end with dots, letters a-z and numbers 0-9.";
				}
				else{
					reg_Text_username.text = "Unknown Error.";
				}
			}
			isConnecting = false;
		});
		www.AddField("firstName", reg_Text_fName.text);
		www.AddField("lastName", reg_Text_lName.text);
		www.AddField("email", reg_Text_email.text);
		www.AddField("password", reg_Text_password.text);
		www.AddField("username", reg_Text_username.text);
		www.Send();
	}
	
	
	
	public void Reset() {
		isConnecting = true;
		loginHudIndex = 0;
		HTTPRequest www = new HTTPRequest(new Uri( GameManager.Instance.webURLPrefix + "auth/forgot"),HTTPMethods.Post,(request, response) => {
			HTTPResponse res = (HTTPResponse)response;
			Debug.Log( res.DataAsText);
			if(res.IsSuccess){
				string request_result = res.DataAsText;
					forget_Text_email.text = "Successfully sent to your email";
					isConnecting = false;	
			}
			else{
				forget_Text_email.text = "Failed to connect!";
			}
			isConnecting = false;
		});
		www.AddField("usernameOrEmail", forget_Text_email.text);
		www.Send();
	}
}
