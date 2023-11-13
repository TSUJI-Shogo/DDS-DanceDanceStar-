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
        
        songName = Gmanager.instance.songName;//�v���C����Ȃ��擾
        audio = GetComponent<AudioSource>();//�Ȃ̍Đ��R���|���擾
        Music = (AudioClip)Resources.Load("Musics/" + Gmanager.instance.songName);//�Ȃ̃t�@�C���p�X��ݒ�
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !played)//�X�y�[�X�L�[�������ꂽ��X�^�[�g
        {
            AnnounceText.SetActive(false);//�X�y�[�X�L�[�������Ă��������Ƃ����\��������
            Gmanager.instance.Start = true;//�Q�[���}�l�[�W���ɊJ�n���Ă��邱�Ƃ�ݒ�
            Gmanager.instance.StartTime = Time.time;//�X�^�[�g���Ԃ��L�^
            Debug.Log(Gmanager.instance.StartTime);
            played = true;
            audio.PlayOneShot(Music);//�Ȃ��Đ�
        }
    }
}
