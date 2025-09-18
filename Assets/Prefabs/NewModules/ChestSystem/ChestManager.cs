using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class ChestManager : MonoBehaviour
{
    //[SerializeField] private GameObject[] _itemsReward;
    [SerializeField] private int[] _gemsReward;
    
    [Space]
    [SerializeField] private Slot[] _slots;
    [SerializeField] private GameObject _button;

    [SerializeField] private GameObject _getFinalItemReward;
    public int[] GetFinalGemReward;

    public TextMeshProUGUI KeyCountText;
    public int KeyCount, GemCount;

    private void OnEnable()
    {
        KeyCount = PlayerPrefs.GetInt("Keys", 0);
        GemCount = 0;
        KeyCountText.text = KeyCount.ToString();

        RewardGeneration();
    }

    private void RewardGeneration()
    {
        //int randomItem = Random.Range(0 , _itemsReward.Length);
        int randomSlot = Random.Range(0, _slots.Length);
        //_slots[randomSlot].ItemReward = _itemsReward[randomItem];
        //_getFinalItemReward = _itemsReward[randomItem];
        _slots[randomSlot].SpawnItemSlot();
        
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i != randomSlot)
            {
                int randomGem = Random.Range(0, _gemsReward.Length);
                _slots[i].GemCountReward = _gemsReward[randomGem];
                _slots[i].SpawnGemSlot();
            }
        }
    }
    
    public void ChekFinalChest()
    {
        if (KeyCount == 0||KeyCount==1||KeyCount==2||KeyCount==3)
        {
            _button.SetActive(true);
        }
    }
}
