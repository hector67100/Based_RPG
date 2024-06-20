using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInv : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventario inver;
    public List<Lista> obj = new List<Lista> {
        new Lista {id = 0, cantidad=1},
        new Lista {id = 1, cantidad=1},
        new Lista {id = 2, cantidad=1},
    };

    public int index;

    public void test()
    {
        // List<Lista> ann = new List<Lista>();
        // ann.Add(obj);
        inver.addItem(obj);
        // GlobalVariables.Set("pp", inver);
    }

    public void log()
    {
        // Inventario prueba = GlobalVariables.Get<Inventario>("pp");

        foreach(Lista item in inver.inv)
        {
            Debug.Log("prueba de cargado id ="+item.id+" cantidad ="+item.cantidad);
        }
        
    }

}
