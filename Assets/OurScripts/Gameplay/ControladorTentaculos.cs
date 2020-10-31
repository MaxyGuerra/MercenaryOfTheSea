using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTentaculos : MonoBehaviour
{
    public int cadencia;
    private float timer;
    private Animator Animacion;
    private bool opened = false;

    private void Start()
    {
        Animacion = GetComponent<Animator>();
    }

    public void DoAnimacion()
    {
        Animacion.SetBool("Ataque",opened);
        opened = !opened;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer>= cadencia)
        {
            DoAnimacion();
            timer = 0;
        }
    }
}
