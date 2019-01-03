using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperScrollView;
using BayatGames.SaveGamePro;
using System;
using UnityEngine.UI;

	public class History : MonoBehaviour
	{
		
		
		public LoopListView2 mLoopListView;
		public Sprite[] spriteObjArray;
		System.Action mOnRefreshFinished = null;
		System.Action mOnLoadMoreFinished = null;
		int mLoadMoreCount = 20;
		float mDataLoadLeftTime = 0;
		bool mIsWaittingRefreshData = false;
		bool mIsWaitLoadingMoreData = false;
		public int mTotalDataCount = 10;
		Dictionary<string, Sprite> spriteObjDict = new Dictionary<string, Sprite>();
		

		
		void Awake()
		{
			Init();
			InitData();
			
		}
		void Start()
		{
			mLoopListView.InitListView(TotalItemCount, InitScrollView);
		}
		
		void InitData()
		{
			spriteObjDict.Clear();
			foreach (Sprite sp in spriteObjArray)
			{
				spriteObjDict[sp.name] = sp;
			}
		}
		
		public void Init()
		{
			DoRefreshDataSource();
		}
		
		public void SetDataTotalCount(int count)
		{
			mTotalDataCount = count;
			DoRefreshDataSource();
		}

		void DoRefreshDataSource()
		{
			//SaveGame.Save ( "mItemDataList", mItemDataList );
			GameManager.Instance.mItemDataList = SaveGame.Load<List<CardData>> ( "mItemDataList" );
			
		}
		
		public void SaveData(){
			SaveGame.Save ( "mItemDataList", GameManager.Instance.mItemDataList );
		}
		public void MainMenu(){
			
			GameManager.Instance.mItemDataList.RemoveAt(GameManager.Instance.mItemDataList.Count-1);
			GameManager.Instance.menuManager.PopMenuToState (UIManager.State.MainMenu);
			GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(GameManager.Instance.click);
			GameManager.Instance.Scroll.transform.parent.GetChild(0).gameObject.SetActive (true);
		}
		LoopListViewItem2 InitScrollView(LoopListView2 listView, int index)
		{
			if (index < 0 || index >= TotalItemCount)
			{
				return null;
			}

			CardData itemData = GetItemDataByIndex(index);
			if(itemData == null)
			{
				return null;
			}
			//get a new item. Every item can use a different prefab, the parameter of the NewListViewItem is the prefab’name. 
			//And all the prefabs should be listed in ItemPrefabList in LoopListView2 Inspector Setting
			LoopListViewItem2 item = listView.NewListViewItem("CardItem");
			CardItem itemScript = item.GetComponent<CardItem>();
			if (item.IsInitHandlerCalled == false)
			{
				item.IsInitHandlerCalled = true;
				itemScript.Init();
			}
			itemScript.SetItemData(itemData,index);
			return item;
		}

		void OnJumpBtnClicked(int count)
		{
			mLoopListView.MovePanelToItemIndex(count, 0);
		}

		void OnAddItemBtnClicked(int count)
		{
			
			mLoopListView.SetListItemCount(count, false);
		}

		void OnSetItemCountBtnClicked(int count)
		{
			mLoopListView.SetListItemCount(count, false);
		}
		
		public Sprite GetSpriteByName(string spriteName)
		{
			Sprite ret = null;
			if (spriteObjDict.TryGetValue(spriteName, out ret))
			{
				return ret;
			}
			return null;
		}

		public CardData GetItemDataByIndex(int index)
		{
			if (index < 0 || index >= GameManager.Instance.mItemDataList.Count)
			{
				return null;
			}
			return GameManager.Instance.mItemDataList[index];
		}

		public CardData GetItemDataById(int itemId)
		{
			int count = GameManager.Instance.mItemDataList.Count;
			for (int i = 0; i < count; ++i)
			{
				if(GameManager.Instance.mItemDataList[i].mId == itemId)
				{
					return GameManager.Instance.mItemDataList[i];
				}
			}
			return null;
		}

		public int TotalItemCount
		{
			get
			{	if(GameManager.Instance.mItemDataList== null)
			{
				return 0;
			}
				return GameManager.Instance.mItemDataList.Count;
			}
		}

		public void RequestRefreshDataList(System.Action onReflushFinished)
		{
			mDataLoadLeftTime = 1;
			mOnRefreshFinished = onReflushFinished;
			mIsWaittingRefreshData = true;
		}

		public void RequestLoadMoreDataList(int loadCount,System.Action onLoadMoreFinished)
		{
			mLoadMoreCount = loadCount;
			mDataLoadLeftTime = 1;
			mOnLoadMoreFinished = onLoadMoreFinished;
			mIsWaitLoadingMoreData = true;
		}


		
		
		public string GetSpriteNameByIndex(int index)
		{
			if (index < 0 || index >= spriteObjArray.Length)
			{
				return "";
			}
			return spriteObjArray[index].name;
		}
		

		public void CheckAllItem()
		{
			int count = GameManager.Instance.mItemDataList.Count;
			for (int i = 0; i < count; ++i)
			{
				GameManager.Instance.mItemDataList[i].mChecked = true;
			}
		}

		public void UnCheckAllItem()
		{
			int count = GameManager.Instance.mItemDataList.Count;
			for (int i = 0; i < count; ++i)
			{
				GameManager.Instance.mItemDataList[i].mChecked = false;
			}
		}

		public bool DeleteAllCheckedItem()
		{
			int oldCount = GameManager.Instance.mItemDataList.Count;
			GameManager.Instance.mItemDataList.RemoveAll(it => it.mChecked);
			return (oldCount != GameManager.Instance.mItemDataList.Count);
		}

	}