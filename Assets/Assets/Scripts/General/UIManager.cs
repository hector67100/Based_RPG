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
    [SerializeField] Button[] botonesAcciones;
    [SerializeField] Button Atacar;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void ponerBontonesAcciones(Arma arma, Personaje personaje)
    {
        List<Button> botones = new List<Button>();
        Personaje jugador = personaje;
        string categoria = getCategoria(arma.categoria);
        int rangoHabilidad = 0;
        foreach(Habilidades habilidad in jugador.habilidades) 
        { 
            if(habilidad.getNombre() == categoria)
            {
                rangoHabilidad = habilidad.getRango();
            }
        }

        for(int i=0; i<arma.acciones.Length; i++)
        {
            if(arma.acciones[i].minNivel <= rangoHabilidad)
            {
                GameObject boton = Instantiate(  botonHabilidad ) ;
                int index = i;
                boton.GetComponent<Button>().onClick.AddListener(() => arma.usarHabilidad(index));
                boton.GetComponentInChildren<TextMeshProUGUI>().text=arma.acciones[i].nombre;
                boton.transform.SetParent(pantallaAcciones.transform);
                botones.Add(boton.GetComponent<Button>());
            }
        }
        botones.Add(Atacar);
        botonesAcciones = botones.ToArray();
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

    
    public string getCategoria(int categoria)
    {
        switch(categoria)
        {
            case 0:
            return "Mano a mano";
            break;
            case 1:
            return "Distancia";
            break;
            case 2:
            return "Una Mano";
            break;
            case 3:
            return "Dos Manos";
            break;
            case 4:
            return "Armas de asta";
            break;
            case 5:
            return "Distancia";
            break;
            case 6:
            return "Exotica";
            break;
        }

        return "Mano a mano";
    }

    public void checkStaminaBotones(float energia, Arma arma)
    {
        for(int i=0; i<arma.acciones.Length; i++)
        {
            if(arma.acciones[i].costo > energia)
            {
                botonesAcciones[i].enabled = false; 
            }
            else
            {
                botonesAcciones[i].enabled = true; 
            }
        }

        if(arma.basico.costo > energia)
        {
            botonesAcciones[botonesAcciones.Length-1].enabled = false; 
        }
        else
        {
            botonesAcciones[botonesAcciones.Length-1].enabled = true; 
        }
    }
}







