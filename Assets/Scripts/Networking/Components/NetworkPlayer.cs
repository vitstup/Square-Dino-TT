using Mirror;
using StarterAssets;
using UnityEngine;
using Zenject;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private StarterAssetsInputs inputs;
    [SerializeField] private ThirdPersonController controller;
    [SerializeField] private PlayerNicknameHandler nicknameHandler;
    [SerializeField] private Transform cameraRoot;

    [Inject] private CameraController cameraController;

    private void Start()
    {
        var sceneContainer = SceneContainerHandler.I.container;
        sceneContainer.InjectGameObject(gameObject);

        if (isLocalPlayer) InitializeLocal();
        else DeInitializeWhenNotLocal();

        nicknameHandler.Initialize();
    }

    private void InitializeLocal()
    {
        Debug.Log("Local player joined");

        cameraController.Initialize(cameraRoot);

        inputs.InitInput();
    }

    private void DeInitializeWhenNotLocal()
    {
        Debug.Log("Not local player joined");
        inputs.enabled = false;
        controller.enabled = false;
    }
}