using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicMnager : MonoBehaviour
{
    AudioSource audio;
    AudioClip Music;
    string songName;
    bool played;
    GameObject AnnounceText;
    // Start is called before the first frame update
    void Start()
    {
        Gmanager.instance.Start = false;
        
        songName = Gmanager.instance.songName;//プレイする曲を取得
        audio = GetComponent<AudioSource>();//曲の再生コンポを取得
        Music = (AudioClip)Resources.Load("Musics/" + Gmanager.instance.songName);//曲のファイルパスを設定
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !played)//スペースキーが押されたらスタート
        {
            AnnounceText.SetActive(false);//スペースキーを押してくださいという表示を解除
            Gmanager.instance.Start = true;//ゲームマネージャに開始していることを設定
            Gmanager.instance.StartTime = Time.time;//スタート時間を記録
            Debug.Log(Gmanager.instance.StartTime);
            played = true;
            audio.PlayOneShot(Music);//曲を再生
        }
    }
}
