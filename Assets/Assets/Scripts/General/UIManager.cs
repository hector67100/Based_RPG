using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Pantalla Acciones")]
    [SerializeField] GameObject pantallaAcciones;
    [SerializeField] GameObject botonHabilidad;
    [SerializeField] Slider vidaSlider;
    [SerializeField] Slider energiaSlider;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void ponerBontonesAcciones(Arma arma)
    {
        for(int i=0; i<arma.acciones.Length; i++)
        {
            GameObject boton = Instantiate(  botonHabilidad ) ;
            int index = i;
            boton.GetComponent<Button>().onClick.AddListener(() => arma.usarHabilidad(index));
            boton.GetComponentInChildren<TextMeshProUGUI>().text=arma.acciones[i].nombre;
            boton.transform.SetParent(pantallaAcciones.transform);
        }
    }
    
    public void setSlidersMaxValues(float vida, float stamina)
    {
        vidaSlider.maxValue = vida;
        energiaSlider.maxValue = stamina;
    }

    public void setSlidersValues(float vida = 0, float stamina = 0)
    {
        if(vida != 0)
        {
            vidaSlider.value = vida;
        }

        if(stamina != 0)
        {
            energiaSlider.value = stamina;
        }
    }
}
