using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UIElements;

public class Iputer : MonoBehaviour
{
    [SerializeField] private float Speed = 3;//���鑬�x
    [SerializeField] private int num = 3;
    private Renderer rend;
    private float alfa;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();//�����_�����O����Ώۂ̃R���|���w��
    }

    // Update is called once per frame
    void Update()
    {
        if(!(rend.material.color.a <= 0))//�����ł͂Ȃ��ꍇ�̏���
        {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g,rend.material.color.b,alfa);
        }
        if(num == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))//�����̃L�[���m
            {
                colorChange();
            }
        }
        if (num == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))//�E���̃L�[���m
            {
                colorChange();
            }
        }
        if (num == 3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))//����̃L�[���m
            {
                colorChange();
            }
        }
        if (num == 4)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))//�����̃L�[���m
            {
                colorChange();
            }
        }
        alfa -= Speed * Time.deltaTime;
    }

    void colorChange()
    {
        alfa = 0.3f;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.b, rend.material.color.g, alfa);
    }
}
