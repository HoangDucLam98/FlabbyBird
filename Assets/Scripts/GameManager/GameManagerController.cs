using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;
    // Start is called before the first frame update
    private void Awake() {
        _MakeSingleInstance();
    }

    private void _MakeSingleInstance()
    {
        if( instance != null ) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void _SetHighScore(int score)
    {
        PlayerPrefs.SetInt("High Score", score);
    }

    public int _GetHighScore()
    {
        return PlayerPrefs.GetInt("High Score");
    }
}
