using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Naninovel;
using Naninovel.Commands;

[CommandAlias("cambiocombate")]
public class CambiarEscena : Command
{
    // Start is called before the first frame update
    [ParameterAlias("Combate")]
    public StringParameter escena ;
    public override async UniTask ExecuteAsync (AsyncToken asyncToken)
    {
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = false;

        // 3. Reset state.
        var stateManager = Engine.GetService<IStateManager>();
        await stateManager.ResetStateAsync();
        SceneManager.LoadScene("Pelea");
    }
}
