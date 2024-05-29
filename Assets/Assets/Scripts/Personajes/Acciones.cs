using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Acciones
{
    public enum Tipo { cadena , ejecutar, neutral}
    // Start is called before the first frame update
    public string nombre;
    public int poder;
    public float costo;
    public string descripcion;
    public int minNivel;
    public int golpes;
    public string animacion;
    public Tipo tipo = Tipo.neutral;
}
