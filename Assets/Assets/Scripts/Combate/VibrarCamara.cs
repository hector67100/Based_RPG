using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VibrarCamara : MonoBehaviour
{
    public static VibrarCamara Instance;
    private CinemachineVirtualCamera camara;
    private CinemachineBasicMultiChannelPerlin perlin;
    private float tiempoMovimiento;
    private float tiempoMovimientoTotal = 1;
    private float intensidadInicial;
    // Start is called before the first frame update
    void Awake()
    {
        camara = GetComponent<CinemachineVirtualCamera>();
        perlin = camara.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if(tiempoMovimiento > 0)
        {
            tiempoMovimiento -= Time.deltaTime;
            perlin. m_AmplitudeGain = Mathf.Lerp(intensidadInicial, 0, 1 - (tiempoMovimiento/tiempoMovimientoTotal));
        }
    }

    // Update is called once per frame
    public void MoverCamara(float intensidad, float frecuencia, float tiempo)
    {
        perlin.m_AmplitudeGain = intensidad;
        perlin.m_FrequencyGain = frecuencia;
        intensidadInicial = intensidad;
        tiempoMovimiento = tiempo;
    }
}
