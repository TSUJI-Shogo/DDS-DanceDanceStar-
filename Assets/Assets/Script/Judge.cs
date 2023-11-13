using System;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour
{
    //�ϐ��̐錾
    [SerializeField] private GameObject[] MessageObj;//�v���C���[�ɔ����`����Q�[���I�u�W�F�N�g
    [SerializeField] NotesManager notesManager;//�X�N���v�g�unotesManager�v������ϐ�

    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject finish;
    AudioSource audio;
    [SerializeField] AudioClip hitSound;

    float endTime = 0;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        endTime = notesManager.NotesTime[notesManager.NotesTime.Count - 1];
    }
    void Update()
    {
        if (Gmanager.instance.Start)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)//�Z�L�[�������ꂽ�Ƃ�
            {
                if (notesManager.LaneNum[0] == 1)//�����ꂽ�{�^���̓��[���̔ԍ��Ƃ����Ă��邩�H
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + Gmanager.instance.StartTime)));
                    /*
                    �{���m�[�c���������ꏊ�Ǝ��ۂɂ��������ꏊ���ǂꂭ�炢����Ă��邩�����߁A
                    ���̐�Βl��Judgement�֐��ɑ���
                    */
                }
                else
                {
                    if (notesManager.LaneNum[1] == 1)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + Gmanager.instance.StartTime)));
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)
            {
                if (notesManager.LaneNum[0] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + Gmanager.instance.StartTime)));
                }
                else
                {
                    if (notesManager.LaneNum[1] == 2)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + Gmanager.instance.StartTime)));
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)
            {
                if (notesManager.LaneNum[0] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + Gmanager.instance.StartTime)));
                }
                else
                {
                    if (notesManager.LaneNum[1] == 3)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + Gmanager.instance.StartTime)));
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
            {
                if (notesManager.LaneNum[0] == 4)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + Gmanager.instance.StartTime)));
                }
                else
                {
                    if (notesManager.LaneNum[1] == 4)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + Gmanager.instance.StartTime)));
                    }
                }
            }
            if(Time.time > endTime + Gmanager.instance.StartTime)
            {
                finish.SetActive(true);
                Invoke("ResultScene", 3f);
                return;
            }

            if (Time.time > notesManager.NotesTime[0] + 0.2f + Gmanager.instance.StartTime)//�{���m�[�c���������ׂ����Ԃ���0.2�b�����Ă����͂��Ȃ������ꍇ
            {
                message(3);
                deleteData();
                Debug.Log("Miss");
                Gmanager.instance.miss++;
                Gmanager.instance.combo = 0;
                //�~�X
            }
        }
        

    }
    void Judgement(float timeLag)
    {
        audio.PlayOneShot(hitSound);
        if (timeLag <= 0.10)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.1�b�ȉ���������
        {
            Debug.Log("Perfect");
            Gmanager.instance.ratioScore += 5;
            Gmanager.instance.perfect++;
            Gmanager.instance.combo++;
            message(0);
            deleteData();
            
        }
        else
        {
            if (timeLag <= 0.15)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.15�b�ȉ���������
            {
                Debug.Log("Great");
                Gmanager.instance.ratioScore += 3;
                Gmanager.instance.great++;
                Gmanager.instance.combo++;
                message(1);
                deleteData();
            }
            else
            {
                if (timeLag <= 0.20)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.2�b�ȉ���������
                {
                    Debug.Log("Good");
                    Gmanager.instance.ratioScore += 1;
                    Gmanager.instance.good++;
                    Gmanager.instance.combo++;
                    deleteData();
                    message(2);
                }
            }
        }
    }
    float GetABS(float num)//�����̐�Βl��Ԃ��֐�
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    void deleteData()//���łɂ��������m�[�c���폜����֐�
    {
        notesManager.NotesTime.RemoveAt(0);
        notesManager.LaneNum.RemoveAt(0);
        notesManager.NoteType.RemoveAt(0);
        Gmanager.instance.score = (int)Math.Round(1000000 * Math.Floor(Gmanager.instance.ratioScore / Gmanager.instance.maxScore * 1000000) / 1000000);
        //��new!!
        comboText.text = Gmanager.instance.combo.ToString();//new!!
        scoreText.text = Gmanager.instance.score.ToString();//new!!
    }

    void message(int judge)//�����\������
    {
        Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
    void ResultScene()
    {
        SceneManager.LoadScene("Result");
    }
}