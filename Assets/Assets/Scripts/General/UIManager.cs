using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Pantalla Habilidades")]
    [SerializeField] GameObject pantallaHabilidades;
    [SerializeField] GameObject botonHabilidad;


    // [SerializeField] TextMeshProUGUI PuntajeMasAlto;
    // [SerializeField] TextMeshProUGUI PuntajeMasActual;
    // [SerializeField] TextMeshProUGUI Calificacion;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void ponerBontonesHabilidades(Arma arma)
    {
        for(int i=0; i<arma.habilidades.Length; i++)
        { Debug.Log(i);
            GameObject boton = Instantiate(  botonHabilidad ) ;
            int index = i;
            boton.GetComponent<Button>().onClick.AddListener(() => arma.usarHabilidad(index));
            boton.GetComponentInChildren<TextMeshProUGUI>().text=arma.habilidades[i].nombre;
            boton.transform.SetParent(pantallaHabilidades.transform);
        }
    }

}
