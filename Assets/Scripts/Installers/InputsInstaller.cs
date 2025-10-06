using Zenject;

public class InputsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<StarterAssetsInputSchema>().AsSingle().NonLazy();
    }
}