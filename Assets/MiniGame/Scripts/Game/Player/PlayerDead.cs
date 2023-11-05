using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Naninovel;
using Naninovel.Commands;

public class PlayerDead : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Events.OnDeadedPlayer += PlayerDeadStopGame;
        Events.OnDeadedPlayer += PlayerDeadAnimation;
        Events.OnDeadedPlayer += PlayerDeadShutDownMoveAndShoot;
        Events.OnDeadedPlayer += PlayerShutDownReDead;
        Events.OnDeadedPlayer += Switch;

    }

    private void Switch()
    {
        StartCoroutine(NaninovelScene());
    }
    IEnumerator NaninovelScene()
    {
        yield return new WaitForSeconds(2);

        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;

        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.PreloadAndPlayAsync("Home", label: "AfterMiniGame").Forget();

        var hidePrinter = new HidePrinter();
        hidePrinter.ExecuteAsync().Forget();

        var naniCamera = Engine.GetService<ICameraManager>().Camera;
        naniCamera.enabled = true;

        SceneManager.LoadScene("SampleScene");
    }

    private void PlayerShutDownReDead()
    {
        gameObject.tag = "Untagged";
    }
    private void PlayerDeadStopGame()
    {
        StartCoroutine(PlayerDeadStopGameCorotina());

        IEnumerator PlayerDeadStopGameCorotina()
        {
            yield return new WaitForSeconds(3);
            Time.timeScale = 0;
        }
    }

    private const string NameFirstDeadAnimation = "DeadFirst";
    private const string NameSecondDeadAnimation = "DeadSecond";
    private void PlayerDeadAnimation()
    {
        int randomChoseAnimation = Random.Range(1, 3);
        if (randomChoseAnimation == 1)
        {
            anim.Play(NameFirstDeadAnimation);
        }
        else if (randomChoseAnimation == 2)
        {
            anim.Play(NameSecondDeadAnimation);
        }
    }

    private void PlayerDeadShutDownMoveAndShoot()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerRotation>().enabled = false;
        GetComponent<ShootingPistol>().enabled = false;
    }
    private void OnDestroy()
    {
        Events.OnDeadedPlayer -= PlayerDeadStopGame;
        Events.OnDeadedPlayer -= PlayerDeadAnimation;
        Events.OnDeadedPlayer -= PlayerDeadShutDownMoveAndShoot;
        Events.OnDeadedPlayer -= PlayerShutDownReDead;
        Events.OnDeadedPlayer -= Switch;
    }
}
