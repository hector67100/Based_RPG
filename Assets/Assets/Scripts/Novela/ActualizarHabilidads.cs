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
        int max = int.Parse(varManager.GetVariableValue("nivel"))+2;
        int puntos = int.Parse(varManager.GetVariableValue("puntos"));
        int maxpuntos = int.Parse(varManager.GetVariableValue("maxpuntos"));
        if(((nivel + cambio <= max) && (nivel + cambio >= 0) && puntos > 0  && puntos <= maxpuntos) || (puntos == 0 && cambio < 0)) 
        {
            nivel += cambio;
            puntos = cambio > 0 ? puntos - cambio : puntos - cambio;

        }
        varManager.SetVariableValue(pordefecto.habilidades[habilidad].nombre.ToLower(), ""+nivel+"");
        varManager.SetVariableValue("puntos", ""+puntos+"");
    }
}
