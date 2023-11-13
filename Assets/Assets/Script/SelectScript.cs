using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void music01()//上から１番目の曲が選ばれたときの処理
    {
        Gmanager.instance.songName = "ClasicYama";//ゲームマネージャに曲の名前を設定
        Gmanager.instance.noteSpeed = 8;//ノーツ速度を指定
        SceneManager.LoadScene("Play");//プレイ画面に遷移
    }
    public void music02()//上から２番目の曲が選ばれたときの処理
    {
        Gmanager.instance.songName = "M4Z";
        Gmanager.instance.noteSpeed = 10;
        SceneManager.LoadScene("Play");
    }
    public void music03()//上から３番目の曲が選ばれたときの処理
    {
        Gmanager.instance.songName = "kawii_gabbah_-_01_2";
        Gmanager.instance.noteSpeed = 15;
        SceneManager.LoadScene("Play");
    }
    public void music04()//上から４番目の曲が選ばれたときの処理
    {
        Gmanager.instance.songName = "CHOCO_SHIP";
        Gmanager.instance.noteSpeed = 12;
        SceneManager.LoadScene("Play");
    }
}
