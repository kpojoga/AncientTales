using System.Collections;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    public float CurrentStageRadius { get; private set; } = 0;
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;
    private int currentPointIndex;
    private int maxPriority = 11;
    private int minPriority = 10;

    [SerializeField] private GameObject tutorial;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private AudioClip coinsClip;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject finalEffectGO;
    [SerializeField] private TextMeshProUGUI finalCoinsText;
    [SerializeField] private TextMeshProUGUI finalKeysText;
    
    [SerializeField] private GameObject losePanel;
    
    private AudioSource audioSource;
    private bool gameStarted = false;

    public int Reward { get; private set; }
    public int Keys { get; private set; }

    public static Level Instance;
    private void Awake()
    {
        Instance = this;
        currentPointIndex = 0;
        virtualCameras[currentPointIndex].Priority = maxPriority;
        audioSource = GetComponent<AudioSource>();

        GlobalEventManager.OnNextPointMove.AddListener(MoveToNextPoint);
        GlobalEventManager.OnFinishGame.AddListener(FinishGame);
    }
    private void Start()
    {
        tutorial.SetActive(true);
        winPanel.SetActive(false);
        Reward = 0;
        Keys = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameStarted == false)
        {
            gameStarted = true;
            tutorial.SetActive(false);
            GlobalEventManager.SendNextPointMove();
        }
    }
    
    public void MoveToNextPoint()
    {
        var prevPoint = currentPointIndex;
        currentPointIndex++;

        if (currentPointIndex >= virtualCameras.Length) return;
        
        if(currentPointIndex == virtualCameras.Length - 1)
        {
            GlobalEventManager.SendFinishGame(true);
        }
        
        if (currentPointIndex + 1 < virtualCameras.Length)
        {
            var curCameraPos = virtualCameras[currentPointIndex].transform.position;
            var nextCameraPos = virtualCameras[currentPointIndex + 1].transform.position;
            CurrentStageRadius = (nextCameraPos - curCameraPos).magnitude;
        }
        else
        {
            CurrentStageRadius = float.MaxValue;
        }

        virtualCameras[currentPointIndex].Priority = maxPriority;
        virtualCameras[prevPoint].Priority = minPriority;
    }
    public CinemachineVirtualCamera GetActiveCamera()
    {
        return virtualCameras[currentPointIndex];
    }
    public void AddReward(int count)
    {
        if (count <= 0)
        {
            return;
        }
        Reward += count;
        _playerData.coins += count;
        audioSource.PlayOneShot(coinsClip);
        coinsText.text = Reward.ToString();
    }
    public void AddKey()
    {
        Keys++;
        if(Keys > 3)
        {
            Keys = 3;
        }
    }
    private void FinishGame(bool isWin)
    {
        if(isWin)
        {
            int allKeys = PlayerPrefs.GetInt("Keys", 0) + Keys;
            if (allKeys > 3)
            {
                allKeys = 3;
            }
            PlayerPrefs.SetInt("Keys", allKeys);
            StartCoroutine(WinGameSequence());
        }
        else
        {
            losePanel.gameObject.SetActive(true);
        }
    }
    private IEnumerator WinGameSequence()
    {
      
        int chestRoomCounter = PlayerPrefs.GetInt("ChestRoomCounter", 0);
        chestRoomCounter++;
        if (chestRoomCounter > 3)
            chestRoomCounter = 1;
        if(chestRoomCounter == 3)
        PlayerPrefs.SetInt("ChestRoomCounter", chestRoomCounter);

        finalCoinsText.text = Reward.ToString();
        finalKeysText.text = Keys.ToString();

        yield return new WaitForSeconds(2f);
        finalEffectGO.SetActive(true);
        yield return new WaitForSeconds(1f);
        winPanel.SetActive(true);
    }

    public void OpenMainScreen()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void OpenNextLevel()
    {
        int curLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        curLevel++;
        if(curLevel > SceneManager.sceneCountInBuildSettings - 1)
        {
            curLevel = 1;
        }

        // if (curLevel == 2)
        // {
        //     _playerData.isUlocked1 = true;
        // }
        // if (curLevel == 5)
        // {
        //     _playerData.isUlocked2 = true;
        // }

        PlayerPrefs.SetInt("CurrentLevel", curLevel);
        SceneManager.LoadScene("Level " + curLevel.ToString());
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
