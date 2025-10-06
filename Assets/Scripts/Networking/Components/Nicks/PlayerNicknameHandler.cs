using System.Collections;
using Mirror;
using StarterAssets;
using UnityEngine;
using Zenject;

public class PlayerNicknameHandler : NetworkBehaviour
{
    [SerializeField] private NicknameWorldUI ui;

    [SerializeField] private NetworkConsoleLogger logger;

    [SerializeField] private StarterAssetsInputs input;

    [Inject] private LocalNicknameHandler handler;

    [SyncVar(hook = nameof(OnNickChanged))] private string nick;

    public void Initialize()
    {
        if (isLocalPlayer)
            CmdSetNick(handler.nick);
    }

    [Command]
    private void CmdSetNick(string newNick)
    {
        nick = newNick;
    }

    private void OnNickChanged(string oldValue, string newValue)
    {
        ui.SetNickame(newValue);
    }

    private void OnEnable()
    {
        input.OnSendMessageRequest += () => logger.CmdLog($"Привет от <{nick}>");
    }

    private void OnDisable()
    {
        input.OnSendMessageRequest -= () => logger.CmdLog($"Привет от <{nick}>");
    }
}