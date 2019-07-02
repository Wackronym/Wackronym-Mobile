using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperScrollView;
//using TMPro;
using UnityEngine.EventSystems;

public class RoundItem : MonoBehaviour {

    //Ghilman
    public Text mainText;
    public Toggle favoriteToggle;
    public RoundData roundData;
    bool isHistory;
    int indexInDumyFavorite;
    //Ghilman

    public void Init()
	{
   
	}
    //Ghilman 

    /// <summary>
    /// this function will set the values for this object
    /// </summary>
    /// <param name="_itemData"></param>
    /// <param name="_isHistory"></param>
    public void SetItemData(RoundData _itemData, bool _isHistory,int _indexInDumyFavorite)
	{
        roundData = _itemData;
        isHistory = _isHistory;
        indexInDumyFavorite = _indexInDumyFavorite;

        string[] srtingParts = roundData.mSenence.Split("_"[0]);
        string stringToShow = srtingParts[0];

        mainText.text = stringToShow+ " <color=Blue>"+ roundData.mAnswer+"</color> "+ srtingParts[srtingParts.Length-1];

        //Ghilman
        if (GameManager.Instance.menuManager.previousState == UIManager.State.MainMenu)
        {
            favoriteToggle.enabled = true;
            if (_isHistory)
            {
               
            }
            else
            {
                favoriteToggle.isOn = true;
            }
        }
        else
        {
            Debug.Log("there is a other thing not main menu");
        }
        //Ghilman
    }
    /// <summary>
    /// this function will be called on share button pressed.
    /// </summary>
    public void ShareButtonCall()
    {
        Debug.Log("Share button is pressed");
    }
    /// <summary>
    /// this function will remove the Favorite.
    /// </summary>
    void RemoveFromFavorite()
    {
        if (GameManager.Instance.menuManager.previousState == UIManager.State.MainMenu)
        {
            if (isHistory)
            {
                Debug.Log("this is history");
            }
            else
            {
                Debug.Log("this is not history");
                GameManager.Instance.shouldSaveFavorites = true;
                GameManager.Instance.favorite[roundData.mainIndex].rData[roundData.innerIndex].reCheck = true;
                GameManager.Instance.favorite[roundData.mainIndex].rData[roundData.innerIndex] = null;
                GameManager.Instance.dummyFavorite.RemoveAt(indexInDumyFavorite);

                this.gameObject.SetActive(false);
                DeleteMySelf();
            }
        }
    }
    void DeleteMySelf()
    {
        this.transform.parent.parent.parent.GetComponent<LoopListView2>().RefreshAllShownItem();
    }
    void AddInFavorite()
    {
        if (GameManager.Instance.menuManager.previousState == UIManager.State.MainMenu)
        {
            Debug.Log("this is main menu");
            if (isHistory)
            {
                Debug.Log("this is history too");
               // GameManager.Instance.mItemDataList[GameManager.Instance.cardIndex].rData[roundData.innerIndex].reCheck = false;
            }
            else
            {
                Debug.Log("this is faverites too");
            }
        }
        else
        {
            Debug.Log("this is not main menu");
        }
        
    }

    /// <summary>
    /// this will call on value change of toggle.
    /// </summary>
    public void OnValuesChangeOfFavoriteToggle()
    {
        if (!favoriteToggle.isOn)
        {
            RemoveFromFavorite();
        }
        else
        {
            AddInFavorite();
        }
    }
    //Ghilman

}


