using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperScrollView;

public class RoundItem : MonoBehaviour {
	
	
	public Text mTitle;
	public Image mStatus;
	public Text mBody;
	public GameObject mContentRootObj;
	public int mItemDataIndex = -1;
	public LoopListView2 mLoopListView;
	public RoundData data;
	public void Init()
	{
   
	}
	
	public void SetItemData(RoundData itemData,int itemIndex)
	{
		data = itemData;
		mItemDataIndex = itemIndex;
		if(data.mTotalRoundTime.Equals("90")){
			mTitle.text = "Wack " + data.time.Substring(0, 8)  + " ("+data.mTotalRoundTime+"s)";
		}
		else if( data.mTotalRoundTime.Equals("60")){
			mTitle.text = "Wack " + data.time.Substring(0, 8)  + " ("+data.mTotalRoundTime+"s)";
		}
		else if( data.mTotalRoundTime.Equals("30")){
			mTitle.text = "Wack " + data.time.Substring(0, 8)  + " ("+data.mTotalRoundTime+"s)";
		}
		else{
			mTitle.text = "Wack " + data.time.Substring(0, 8)  + " (Unlimited)";
		}
		
		mBody.text = data.mSenence + " <i> " + data.mAnswer +"</i>";
		if(data.mCompleted){
			mStatus.sprite = Card.Get.GetSpriteByName("checked");	
		}
		else{
			mStatus.sprite = Card.Get.GetSpriteByName("unchecked");	
		}
		
		if(GameManager.Instance.menuManager.previousState == UIManager.State.MainMenu){
			Toggle t = GetComponentInChildren<Toggle>();
			if(t!=null){
				t.isOn = true;
				t.enabled = false;	
			}
			
		}
	}

}
