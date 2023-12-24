using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICombate : MonoBehaviour
{
    public static UICombate Instance;
    [SerializeField] GameObject pantallaAcciones;
    [SerializeField] TextMeshProUGUI textoDescriptcion;
    [SerializeField] Slider vidaSlider;
    [SerializeField] Slider energiaSlider;
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void cambiarTextoDescripcion(string texto)
    {
        textoDescriptcion.text= texto;
    }
}
