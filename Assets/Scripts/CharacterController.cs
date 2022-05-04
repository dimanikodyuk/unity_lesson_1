using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;           //  �������� ����/������
    [SerializeField] private float rotateAngle;     //  ���� ��������
    [SerializeField] private Animator anim;         //  ��������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �������� � ��������
        if (Input.GetKey(KeyCode.W))
        {
            characterMove(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            characterMove(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            chatacterRotate(-rotateAngle);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            chatacterRotate(rotateAngle);
        }
        else 
        {
            // ���������� ��������
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

    }

    // ���
    void characterMove(Vector3 direction)
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        anim.SetBool("Run", true);
        
        
    }

    // �������
    void chatacterRotate(float rotateValue)
    {
        transform.Rotate(0, rotateValue * Time.deltaTime, 0);
        anim.SetBool("Walk", true);
    }
}
