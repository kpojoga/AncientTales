using UnityEngine;
using UnityEngine.UI;
using System;

public class Gift : MonoBehaviour
{
    [SerializeField] private GameObject giftReward;

    [SerializeField] private Text text;

    [HideInInspector] public int giftCount;
    private Button _giftButton;
    
    private void Awake()
    {
        _giftButton = GetComponentInChildren<Button>();
        _giftButton.onClick.AddListener(GiveGift);
    }
    
    public void GiveGift()
    {
        PlayerPrefs.SetString("LastGetGift", DateTime.Now.ToString());
        DailyReward.Instance.DectivateAllGifts();
        DailyReward.Instance.GenerateAllRewards();
        DailyReward.Instance.SaveGiftResults();
        DailyReward.Instance.ShowAllRewards();
        //_giftButton.gameObject.SetActive(false);

        GenerateReward();
        ShowReward();
    }
    public void ShowReward()
    {
        _giftButton.gameObject.SetActive(false);
        text.text = "+" + giftCount;
        giftReward.SetActive(true);
    }
    public void SetGiftState(bool state)
    {
        _giftButton.interactable = state;
        if (state)
        {
            giftReward.SetActive(false);
        }
    }
    public void GenerateReward()
    {
        giftCount = UnityEngine.Random.Range(100, 1000);
        PlayerPrefs.SetInt("BubblesCount", PlayerPrefs.GetInt("BubblesCount", 0) + giftCount);
    }
}
