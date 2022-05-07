using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed;           //  �������� ����/������
    [SerializeField] private float _rotateAngle;     //  ���� ��������
    [SerializeField] private Animator _anim;         //  ��������
    private int itsWalk = 0;


    void Update()
    {
        // �������� � ��������
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            CharacterMove(Vector3.forward);
            ChatacterRotate(-_rotateAngle);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            CharacterMove(Vector3.forward);
            ChatacterRotate(_rotateAngle);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            CharacterMove(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CharacterMove(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            itsWalk = 1;
            ChatacterRotate(-_rotateAngle);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            itsWalk = 1;
            ChatacterRotate(_rotateAngle);
        }
        else 
        {
            // ���������� ��������
            _anim.SetBool("Walk", false);
            _anim.SetBool("Run", false);
            itsWalk = 0;
        }
    }

    // ���
    void CharacterMove(Vector3 direction)
    {
        transform.Translate(direction.normalized * _speed * Time.deltaTime);
        _anim.SetBool("Run", true);  
    }

    // �������
    void ChatacterRotate(float rotateValue)
    {
        transform.Rotate(0, rotateValue * Time.deltaTime, 0);
        if (itsWalk == 1)
        {
            _anim.SetBool("Walk", true);
        }
    }

}
