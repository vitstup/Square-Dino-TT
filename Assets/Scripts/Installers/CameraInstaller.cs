using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private CameraController controller;

    public override void InstallBindings()
    {
        Container.Bind<CameraController>().FromInstance(controller).AsSingle().NonLazy();
    }
}