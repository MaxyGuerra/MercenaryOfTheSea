using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAnimacionesCalamar : MonoBehaviour
{
    private Animator Animacion;
    private float tiempo;
    public float Cadencia;

    public string[] animationsList=new string[7];


    // Start is called before the first frame update
    void Start()
    {
        Animacion = GetComponent<Animator>();
    }

    public void DoAnimacion()
    {
        string targetAnimationName=animationsList[Random.Range(0,animationsList.Length)];

        Animacion.SetTrigger(targetAnimationName);
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;

        if(Cadencia<=tiempo)
        { 
            DoAnimacion();
            tiempo=0;
        }
    }
}
