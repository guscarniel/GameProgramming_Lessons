using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] int num; //custom number
    [SerializeField] int num2; //custom number

    void Start()
    {
        Message(); //void function call
        Add(num, num2); //arguments
        Subtract(num, num2);
    }

    void Message()
    {
        Debug.Log("Calculadora inicializada!");
    }

    public int Add(int a, int b) //parameters
    {
        int result = a + b;
        Debug.Log($"{num} mais {num2} igual a {result}"); //string interpolation
        return result;
    }

    public int Subtract(int a, int b)
    {
        int result = a - b;
        Debug.Log($"{num} menos {num2} igual a {result}");
        return result;
    }
}