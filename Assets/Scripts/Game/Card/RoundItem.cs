using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperScrollView;
using TMPro;

public class RoundItem : MonoBehaviour {

    //Ghilman
    public Text mBodyText;
    public Color mBodyAnsColor;
    //Ghilman
    public RoundData data;

	//public Text underline;
	//public int mainCardIndex;
	//Dictionary<string, Sprite> spriteObjDict = new Dictionary<string, Sprite>();
	//public Sprite[] spriteObjArray;
    //public Text mTitle;
    //public Image mStatus;
    //public TextMeshProUGUI mBody;
    //public GameObject mContentRootObj;
    //public int mItemDataIndex = -1;
    //public LoopListView2 mLoopListView;

    public void Init()
	{
   
	}
	
	public void SetItemData(RoundData itemData,int itemIndex, bool isHistory)
	{
        //Ghilman 
        data = itemData;
        data.id = itemIndex;

        string[] srtingParts = data.mSenence.Split("_"[0]);
        string stringToShow = srtingParts[0];
        mBodyText.text = stringToShow+ " <color=Blue>"+data.mAnswer+"</color> "+ srtingParts[srtingParts.Length-1];
        //Ghilman

        //underline = mBody.transform.GetChild(0).GetComponent<Text>();

        //mItemDataIndex = itemIndex;
        //if(data.mTotalRoundTime.Equals("90")){
        //	mTitle.text = "Wack " + data.time.Substring(0, 8)  + " ("+data.mTotalRoundTime+"s)";
        //}
        //else if( data.mTotalRoundTime.Equals("60")){
        //	mTitle.text = "Wack " + data.time.Substring(0, 8)  + " ("+data.mTotalRoundTime+"s)";
        //}
        //else if( data.mTotalRoundTime.Equals("30")){
        //	mTitle.text = "Wack " + data.time.Substring(0, 8)  + " ("+data.mTotalRoundTime+"s)";
        //}
        //else{
        //	//mTitle.text = "Wack " + data.time.Substring(0, 8)  + " (Unlimited)";
        //}
        //string dataStr = data.mSenence.Replace("__","__");

        //mBody.text =  dataStr +"<u>" +data.mAnswer+"</u>";


        //underline.text = "<color=white>"; 


        //int totalLength = dataStr.Length-1;

        //if(data.mAnswer!=null){
        //	totalLength = totalLength - 5;
        //}
        //for(int i=0; i<totalLength;i++){
        //underline.text += "_";
        //}

        //underline.text += "</color>";

        //if(data.mAnswer!=null){
        //underline.text += "<color=black>"; 
        //for(int i=0; i<data.mAnswer.Length-1;i++){
        //underline.text += "_";
        //}
        //underline.text += "</color>";
        //}


        //if(data.mCompleted){
        //mStatus.sprite = GetSpriteByName("checked");	
        //}
        //else{
        //mStatus.sprite = GetSpriteByName("unchecked");	
        //}

       // if (GameManager.Instance.menuManager.previousState == UIManager.State.MainMenu){
		//	Toggle t = GetComponentInChildren<Toggle>();
		//	if(t!=null){
				//t.isOn = true;
				//t.enabled = false;	
		//		if(isHistory){
					//t.gameObject.SetActive(false);
		//		}
		//	}
			
		//}
	}
	
	//public void ReEnable(){
	//	if(GameManager.Instance.menuManager.previousState == UIManager.State.MainMenu){
	//		Toggle t = GetComponentInChildren<Toggle>();
	//		if(t!=null){
	//			t.isOn = true;
	//		}
	//	}
	//	GameManager.Instance.favObj = this.gameObject;
	
//	}
	
	//public void MyIndex(){
//		GameManager.Instance.favTempIndex = (int)data.id;
//		GameManager.Instance.favMIndex = data.mainIndex;
//		GameManager.Instance.favRIndex = (int)data.innerIndex;
//		GameManager.Instance.favObj = this.gameObject;
//	}
	
	//public void RemoveFavorite(){
		
		//GameManager.Instance.favorite[GameManager.Instance.favMIndex].rData.RemoveAt(GameManager.Instance.favRIndex);
		//if(GameManager.Instance.favorite[GameManager.Instance.favMIndex].rData.Count==0){
		//	GameManager.Instance.favorite.RemoveAt(GameManager.Instance.favMIndex);
		//}
		//Destroy(GameManager.Instance.favObj);
	//}
	
	//void InitData()
	//{
	//	spriteObjDict.Clear();
	//	foreach (Sprite sp in spriteObjArray)
	//	{
	//		spriteObjDict[sp.name] = sp;
	//	}
	//}
	//public Sprite GetSpriteByName(string spriteName)
	//{
	//	Sprite ret = null;
	//	if (spriteObjDict.TryGetValue(spriteName, out ret))
	//	{
	//		return ret;
	//	}
	//	return null;
	//}

}
