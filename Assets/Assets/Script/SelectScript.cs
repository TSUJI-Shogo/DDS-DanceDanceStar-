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
    public void music01()//�ォ��P�Ԗڂ̋Ȃ��I�΂ꂽ�Ƃ��̏���
    {
        Gmanager.instance.songName = "ClasicYama";//�Q�[���}�l�[�W���ɋȂ̖��O��ݒ�
        Gmanager.instance.noteSpeed = 8;//�m�[�c���x���w��
        SceneManager.LoadScene("Play");//�v���C��ʂɑJ��
    }
    public void music02()//�ォ��Q�Ԗڂ̋Ȃ��I�΂ꂽ�Ƃ��̏���
    {
        Gmanager.instance.songName = "M4Z";
        Gmanager.instance.noteSpeed = 10;
        SceneManager.LoadScene("Play");
    }
    public void music03()//�ォ��R�Ԗڂ̋Ȃ��I�΂ꂽ�Ƃ��̏���
    {
        Gmanager.instance.songName = "kawii_gabbah_-_01_2";
        Gmanager.instance.noteSpeed = 15;
        SceneManager.LoadScene("Play");
    }
    public void music04()//�ォ��S�Ԗڂ̋Ȃ��I�΂ꂽ�Ƃ��̏���
    {
        Gmanager.instance.songName = "CHOCO_SHIP";
        Gmanager.instance.noteSpeed = 12;
        SceneManager.LoadScene("Play");
    }
}
