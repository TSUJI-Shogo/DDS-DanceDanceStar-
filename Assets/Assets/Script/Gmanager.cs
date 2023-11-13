using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gmanager : MonoBehaviour
{
    public static Gmanager instance = null;

    public float maxScore;
    public float ratioScore;

    public int songID;
    public string songName;
    public float noteSpeed;

    public bool Start;
    public float StartTime;

    public int combo;
    public int score;

    public int perfect;
    public int great;
    public int good;
    public int miss;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
