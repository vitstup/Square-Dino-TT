using Mirror;
using StarterAssets;
using UnityEngine;

public class NetworkCubeSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private StarterAssetsInputs input;

    private void OnEnable()
    {
        input.OnSpawnRequest += CmdSpawn;
    }

    private void OnDisable()
    {
        input.OnSpawnRequest -= CmdSpawn;
    }

    [Command]
    private void CmdSpawn()
    {
        var prefab = Instantiate(this.prefab, spawnPoint.position, Quaternion.identity);
        NetworkServer.Spawn(prefab);
    }
}