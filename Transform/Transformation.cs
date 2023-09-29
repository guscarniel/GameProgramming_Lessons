using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    private Transform myTransform; //atribuindo uma variavel a outra
    private Vector3 myVector3;

    public int userRotationValue;
    public int userScaleValue;

    void Start()
    {
      myTransform = GetComponent<Transform>(); // <> é uma tipagem
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)) //tecla para aumentar
        {
            //Debug.Log("Apertei Espaço");
            myTransform.localScale += new Vector3(userScaleValue, userScaleValue, userScaleValue); //+= significa que vai somar
        }
       
       if (Input.GetKeyDown(KeyCode.LeftControl)) //tecla para diminuir
        {
            myTransform.localScale -= new Vector3(1, 1, 1);
        }

       if (Input.GetKeyDown(KeyCode.RightArrow)) //tecla para direita com nova variavel para Vector3
        {
            Vector3 myVector3 = new Vector3(1, 0, 0);
            myTransform.Translate(myVector3); //Translate precisa de um parametro
        }

       if (Input.GetKeyDown(KeyCode.LeftArrow)) //tecla para esquerda usando .position
        {
            myTransform.position += new Vector3(-1, 0, 0);
        }

       if (Input.GetKeyDown(KeyCode.UpArrow)) //tecla para cima usando Translate
        {  
            myTransform.Translate(Vector3.up, Space.World);
        }

       if (Input.GetKeyDown(KeyCode.DownArrow)) //tecla para baixo usando Translate
        {
            myTransform.Translate(Vector3.down, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.R)) //tecla para rotacionar com escolha dos graus pelo usuário
        {
            Vector3 myVector3 = new Vector3(userRotationValue, 0, 0);
            myTransform.Rotate(myVector3);
        }
    }







}
