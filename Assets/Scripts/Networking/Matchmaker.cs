using Mirror;
using UnityEngine;
using Zenject;

public class Matchmaker : MonoBehaviour
{
    [SerializeField] private ushort port = 7777;

    [Inject] private GameNetworkManager manager;

    public void Connect()
    {
        JoinOrCreateMatch();
    }

    private void JoinOrCreateMatch()
    {
        if (Transport.active is PortTransport portTransport)
            portTransport.Port = port;

        try
        {
            manager.StartHost();
        }
        catch
        {
            manager.StartClient();
        }
            
    }
}