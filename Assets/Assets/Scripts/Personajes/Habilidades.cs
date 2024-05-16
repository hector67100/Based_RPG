using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public class Habilidades
    {
        public string nombre;
        public int rango;

        // Start is called before the first frame update
        public int getRango()
        {
            return rango;
        }

        public string getNombre()
        {
            return nombre;
        }

    }
