using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InvUiObj : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI cantidad;
    [SerializeField] TextMeshProUGUI nombre;
    [SerializeField] TextMeshProUGUI precio;
    [SerializeField] Image imagen;
    [SerializeField] int id;
    [SerializeField] int cantidadInicial;
    [SerializeField] int max = 99;

    public void modificarNum(int num)
    {
        int suma = int.Parse(cantidad.text);
        if((suma+num)>=0 && (suma+num)<=max)
        {
            suma += num;
        }
        cantidad.text = suma.ToString();
    }

    public void setNombre(string texto)
    {
        nombre.text = texto;
    }

    public void setImage(Sprite img)
    {
        imagen.sprite = img;
    }

    public void setMax(int num)
    {
        max=num;
    }

    public void setPrecio(string texto)
    {
        precio.text = texto;
    }

    public void setId(int num)
    {
        id = num;
    }

    public int getId()
    {
        return id;
    }

    public int getPrecio()
    {
        return int.Parse(precio.text);
    }

    public int getCantidad()
    {
        return int.Parse(cantidad.text);
    }

    public void setCantidad(string texto)
    {
        cantidad.text = texto;
    }
    public void setCantidadInicial(int num)
    {
        cantidadInicial = num;
    }

    public bool compararCantidad()
    {
        bool comparacion = cantidadInicial != int.Parse(cantidad.text) ? true : false;
        return comparacion;
    }
}
