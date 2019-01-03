using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperScrollView;
using System;
using UnityEngine.EventSystems;

public class CardItem : MonoBehaviour {

	public Text mNameText;
	public Image mIcon;
	public Text mDescText;
	public GameObject mContentRootObj;
	int mItemDataIndex = -1;
	public LoopListView2 mLoopListView;
	public CardData data;
	public void Init()
	{
   
	}
	public void SetItemData(CardData itemData,int itemIndex)
	{
		data = itemData;
		mItemDataIndex = itemIndex;
		System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-GB");
		DateTime d = DateTime.Parse(data.mDate);
		
		mNameText.text = d.ToString("dddd., MMM dd yyyy, hh:MM tt", culture);// data.mName;
		//mDescText.text = data.mDate + " | " + data.mDuration;
		//mIcon.sprite = Card.Get.GetSpriteByName(data.mPic);
		mIcon.gameObject.SetActive(false);
		mNameText.transform.parent.GetComponent<Button>().onClick.AddListener(OnBtnClicked);
		//mNameText.transform.parent.GetComponent<EventTrigger>().triggers[0].callback.AddListener( (eventData) => {OnBtnClicked();});
		Destroy(mNameText.transform.parent.GetComponent<EventTrigger>());
		
	}
	void OnBtnClicked()
	{
		if(GameManager.Instance.menuManager.NavigationStackPeek()!=UIManager.State.Win){
			GameManager.Instance.cardIndex = data.mId;
			GameManager.Instance.menuManager.PushMenu(UIManager.State.Win);
			GameManager.Instance.menuManager.GetComponentInChildren<Card>().HideSaveButton();
		}
	}

}
