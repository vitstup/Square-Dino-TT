using System;
using Mirror;
using UnityEngine;

public class GameNetworkManager : NetworkManager
{
    public Action<NetworkConnectionToClient> OnServerAddedPlayer;
    public Action<NetworkConnectionToClient> OnServerDisconnectedPlayer;

    public Action OnLocalClientStarted;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn); // создаёт игрока

        Debug.Log($"[Server] Player {conn.connectionId} connected");

        OnServerAddedPlayer?.Invoke(conn);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log($"[Server] Player {conn.connectionId} disconnected");

        base.OnServerDisconnect(conn);

        OnServerDisconnectedPlayer?.Invoke(conn);
    }

    public override void OnStartClient()
    {
        Debug.Log("Client started");
        OnLocalClientStarted?.Invoke();
    }
}