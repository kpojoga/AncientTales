using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent OnNextPointMove = new UnityEvent();
    public static UnityEvent OnEnemyKill = new UnityEvent();
    public static UnityEvent<bool> OnFinishGame = new UnityEvent<bool>();
    public static void SendNextPointMove()
    {
        OnNextPointMove.Invoke();
        Debug.Log("OnNextPointMove");
    }
    public static void SendEnemyKill()
    {
        OnEnemyKill.Invoke();
        Debug.Log("OnEnemyKill");
    }
    public static void SendFinishGame(bool isWin)
    {
        OnFinishGame.Invoke(isWin);
        Debug.Log("OnFinishGame");
    }
}
