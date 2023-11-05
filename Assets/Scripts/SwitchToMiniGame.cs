using Naninovel;
using UnityEngine.SceneManagement;
using Naninovel.Commands;

[CommandAlias("MiniGame")]
public class SwitchToMiniGame : Command

{
    public StringParameter Name;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {

        // Вихід з міні гри в скрипті Assets/MiniGame/Scripts/Game/Player/PlayerDead.cs

        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = false;

        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.Stop();

        var hidePrinter = new HidePrinter();
        hidePrinter.ExecuteAsync(asyncToken).Forget();

        SceneManager.LoadScene("MiniGame");
        var naniCamera = Engine.GetService<ICameraManager>().Camera;
        naniCamera.enabled = false;

        var stateManage = Engine.GetService<IUIManager>();
        stateManage.ResetService();

        return UniTask.CompletedTask;

    }
}