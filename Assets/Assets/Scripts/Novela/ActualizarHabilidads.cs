using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using Naninovel.Commands;

[CommandAlias("actualizarhabilidad")]
public class ActualizarHabilidad : Command
{
    // Start is called before the first frame update
    [ParameterAlias("Habilidad")]
    public IntegerParameter habilidad;

    [ParameterAlias("Cambio")]
    public IntegerParameter cambio;
    public Personaje pordefecto = new Personaje();
    public override async UniTask ExecuteAsync (AsyncToken asyncToken)
    {
        var varManager = Engine.GetService<ICustomVariableManager>();
        int nivel = int.Parse(varManager.GetVariableValue(pordefecto.habilidades[habilidad].nombre.ToLower()));
        nivel = nivel + cambio;
        varManager.SetVariableValue(pordefecto.habilidades[habilidad].nombre.ToLower(), ""+nivel+"");
        Debug.Log(nivel);

    }
}
