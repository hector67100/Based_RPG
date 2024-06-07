using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Consumible: MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] string tipo;
    [SerializeField] string Nombre;
    [SerializeField] int[] valores;
    [SerializeField] bool vida;
    [SerializeField] bool aguante;
    public Sprite img;
    public void Usar(Personaje pj)
    {   
        if(vida)
        {
            pj.modificarVida(valores[0]);
        }
        if(aguante)
        {
            pj.modificarEnergia(valores[1]);
        }
    }
}

