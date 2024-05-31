using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ObtenerEnemigo : MonoBehaviour

{
    private void OnMouseDown()
    {
         Director.Instance.seleccionarEnemigo(gameObject.name);
    }
}
