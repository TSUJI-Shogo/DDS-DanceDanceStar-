using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SongName;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI perfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI goodText;
    [SerializeField] TextMeshProUGUI missText;
    // Start is called before the first frame update
    void Start()
    {
        SongName.text =Gmanager.instance.songName;
        scoreText.text = Gmanager.instance.score.ToString();
        perfectText.text = Gmanager.instance.perfect.ToString();
        greatText.text = Gmanager.instance.great.ToString();
        goodText.text = Gmanager.instance.good.ToString();
        missText.text = Gmanager.instance.miss.ToString();
    }

    // Update is called once per frame
    public void Retry()
    {
        Gmanager.instance.perfect = 0;
        Gmanager.instance.great = 0;
        Gmanager.instance.good = 0;
        Gmanager.instance.miss = 0;
        Gmanager.instance.maxScore = 0;
        Gmanager.instance.ratioScore = 0;
        Gmanager.instance.score = 0;
        Gmanager.instance.combo = 0;
        SceneManager.LoadScene("Play");
    }
    public void BackSelect()
    {
        Gmanager.instance.perfect = 0;
        Gmanager.instance.great = 0;
        Gmanager.instance.good = 0;
        Gmanager.instance.miss = 0;
        Gmanager.instance.maxScore = 0;
        Gmanager.instance.ratioScore = 0;
        Gmanager.instance.score = 0;
        Gmanager.instance.combo = 0;
        SceneManager.LoadScene("MusicSelect");
    }
}
