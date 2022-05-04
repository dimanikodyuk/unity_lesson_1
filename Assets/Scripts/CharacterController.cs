using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;           //  Скорость бега/ходьбы
    [SerializeField] private float rotateAngle;     //  Угол поворота
    [SerializeField] private Animator anim;         //  Аниматор

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Движение и повороты
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
            // Выключение анимаций
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

    }

    // Бег
    void characterMove(Vector3 direction)
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        anim.SetBool("Run", true);
        
        
    }

    // Поворот
    void chatacterRotate(float rotateValue)
    {
        transform.Rotate(0, rotateValue * Time.deltaTime, 0);
        anim.SetBool("Walk", true);
    }
}
