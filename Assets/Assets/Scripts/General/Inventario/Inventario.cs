using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventario : MonoBehaviour
{
    public int oro;
    public List<Lista> inv = new List<Lista>();
    
    public void addItem(List<Lista> item)
    {
        bool objeto = false;
        foreach(Lista items in item)
        {
            Debug.Log("prueba de cargado id ="+items.id+" cantidad ="+items.cantidad);
            objeto = inv.Exists(x => x.id == items.id);
            Debug.Log(objeto);
            if(objeto)
            {
                int index = inv.FindIndex(x => x.id == items.id);
                inv[index].cantidad += items.cantidad;
            }
            else
            {
                inv.Add(items);
            }
            objeto = false;
            Debug.Log(objeto);
        }    
    }

    public void addItem(Lista item)
    {
        bool objeto = false;
            Debug.Log("prueba de cargado id ="+item.id+" cantidad ="+item.cantidad);
            objeto = inv.Exists(x => x.id == item.id);
            Debug.Log(objeto);
            if(objeto)
            {
                int index = inv.FindIndex(x => x.id == item.id);
                inv[index].cantidad += item.cantidad;
            }
            else
            {
                inv.Add(item);
            }
            objeto = false;
    }

    public void removeItem(List<Lista> item)
    {
        foreach(Lista items in item)
        {
            Lista objeto = inv.Find(x => x.id == items.id) ;
            if(objeto != null)
            {
                int index = inv.FindIndex(x => x.id == objeto.id);
                inv[index].cantidad -= items.cantidad;
                if(inv[index].cantidad <= 0)
                {
                    inv.RemoveAt(index);
                }
            }
        }    
    }
    public void removeItem(Lista item)
    {
        Lista objeto = inv.Find(x => x.id == item.id) ;
        if(objeto != null)
        {
            int index = inv.FindIndex(x => x.id == objeto.id);
            inv[index].cantidad -= item.cantidad;
            if(inv[index].cantidad <= 0)
            {
                inv.RemoveAt(index);
            }
        }
    }
    public void modificarOro(int dinero)
    {
        oro += dinero;
    }
}

[System.Serializable]
    public class Lista
    {
        public int id;
        public int cantidad;

        public void setId( int ids)
        {
            id = ids;
        }

        public void setCantidad(int num)
        {
            cantidad = num;
        }

    }
