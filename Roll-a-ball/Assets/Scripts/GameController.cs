using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType {Normal, SpeedRun}
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameType gameType;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }
    //Sets Game Type
    public void SetGameType(GameType _gameType)
    {
        gameType = _gameType;
    }

    //Toggle Speedrun option
    public void ToggleSpeedRun(bool _speedrun)
    {
        if (_speedrun)
            SetGameType(GameType.SpeedRun);
        else
            SetGameType(GameType.Normal);

    }



}
