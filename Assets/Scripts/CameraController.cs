using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public void Initialize(Transform followTarget)
    {
        virtualCamera.Follow = followTarget;
    }
}