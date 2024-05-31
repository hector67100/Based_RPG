using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    private async void Start ()
    {
        await RuntimeInitializer.InitializeAsync();
    }
}
