using UnityEngine;
using Zenject;

public class NetworkInstaller : MonoInstaller
{
    [SerializeField] private GameNetworkManager manager;
    [SerializeField] private Matchmaker matchmaker;

    public override void InstallBindings()
    {
        Container.Bind<GameNetworkManager>().FromInstance(manager).AsSingle().NonLazy();
        Container.Bind<Matchmaker>().FromInstance(matchmaker).AsSingle().NonLazy();

        Container.Bind<LocalNicknameHandler>().AsSingle().NonLazy();
    }
}