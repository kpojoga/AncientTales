using UnityEngine;
using System;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    [SerializeField] private Text _textForNextGift;
    
    public static DailyReward Instance { get; private set; }

    private Gift[] gifts;

    private TimeSpan timeSinceLastGetGift;

    private void Awake()
    {
        Instance = this;
        gifts = GetComponentsInChildren<Gift>();
    }
    
    private void Start()
    {
        string lastGetGiftString = PlayerPrefs.GetString("LastGetGift", string.Empty);
        SetLeftTime();
        
        Debug.Log(timeSinceLastGetGift);

        if (string.IsNullOrEmpty(lastGetGiftString) || timeSinceLastGetGift.Days > 0 || timeSinceLastGetGift.Hours > 24)
        {
            ClearAllRewards();
            ActivateAllGifts();
        }
        else
        {
            LoadAllRewards();
            if (!string.IsNullOrEmpty(lastGetGiftString))
            {
                ShowAllRewards();
            }
            else
            {
                DectivateAllGifts();
            }
        }
    }

    private void SetLeftTime()
    {
        string lastGetGiftString = PlayerPrefs.GetString("LastGetGift", string.Empty);
        
        DateTime lastGetGiftTime;
        timeSinceLastGetGift = TimeSpan.MaxValue;
        if (DateTime.TryParse(lastGetGiftString, out lastGetGiftTime))
        {
            timeSinceLastGetGift = DateTime.Now - lastGetGiftTime ;
        }
    }

    private void Update()
    {
        SetLeftTime();
        ShowTimeForNextGift(timeSinceLastGetGift);
    }

    private void ShowTimeForNextGift(TimeSpan time)
    {
        if (timeSinceLastGetGift.Days > 0)
        {
            _textForNextGift.text = "";
            return;
        }
        TimeSpan timeLeft = new TimeSpan(1, 0, 0, 0) - time;
        _textForNextGift.text = timeLeft.ToString(@"hh\:mm\:ss");
    }
    
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
    private void ActivateAllGifts()
    {
        for (int i = 0; i < gifts.Length; i++)
        {
            gifts[i].SetGiftState(true);
        }
    }
  
    public void DectivateAllGifts()
    {
        for (int i = 0; i < gifts.Length; i++)
        {
            gifts[i].SetGiftState(false);
        }
    }

    public void ShowAllRewards()
    {
        for (int i = 0; i < gifts.Length; i++)
        {
            gifts[i].ShowReward();
        }
    }

    public void GenerateAllRewards()
    {
        for (int i = 0; i < gifts.Length; i++)
        {
            if (gifts[i].giftCount == 0) gifts[i].GenerateReward();
        }
    }
    
    public void ClearAllRewards()
    {
        foreach (var gift in gifts)
        {
            gift.giftCount = 0;
        }
    }
    
    public void LoadAllRewards()
    {
        for (int i = 0; i < gifts.Length; i++)
        {
            gifts[i].giftCount = PlayerPrefs.GetInt("gift" + i, 0);
        }
    }
    
    public void SaveGiftResults()
    {
        for (int i = 0; i < gifts.Length; i++)
        {
            PlayerPrefs.SetInt("gift" + i, gifts[i].giftCount);
        }
    }
}
