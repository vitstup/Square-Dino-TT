using Mirror;
using UnityEngine;

public class NetworkConsoleLogger : NetworkBehaviour
{
    [Command]
    public void CmdLog(string message)
    {
        RpcLog(message);
    }

    [ClientRpc]
    private void RpcLog(string message)
    {
        Debug.Log(message);
    }
}