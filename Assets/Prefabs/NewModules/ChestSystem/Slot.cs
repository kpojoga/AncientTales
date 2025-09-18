using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private ChestManager _chestManager;
    [SerializeField] private Transform _dotSpawn;
    
    public GameObject ItemReward;
    public int GemCountReward;
    
    public Text GemReward;

    private void OnEnable()
    {
        gameObject.GetComponent<Image>().DOFade(1f, 0f);
        gameObject.GetComponent<Button>().enabled = true;
    }
    
    private void OnDisable()
    {
        //Destroy(ItemReward);
    }

    public void SpawnItemSlot()
    {
       //GameObject item = Instantiate(ItemReward, _dotSpawn.transform.position, transform.rotation);
       //item.transform.parent = _dotSpawn.transform;
       //ItemReward = item;
    }
    
    public void SpawnGemSlot()
    {
        GemReward.text = GemCountReward.ToString();
    }
    
    public void OpenSlot()
    {
        if (_chestManager.KeyCount > 0)
        {
            gameObject.GetComponent<Image>().DOFade(0f, 1f);
            gameObject.GetComponent<Button>().enabled = false;

            _chestManager.GetFinalGemReward[_chestManager.GemCount] = GemCountReward;
            _chestManager.GemCount++;
            //PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + ?);
            
            _chestManager.KeyCount--;
            PlayerPrefs.SetInt("Keys", _chestManager.KeyCount);

            _chestManager.KeyCountText.text = _chestManager.KeyCount.ToString();
            
            _chestManager.ChekFinalChest();
        }
    }
}