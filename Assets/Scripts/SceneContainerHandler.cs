using UnityEngine;
using Zenject;

// Костыль что бы получить контейнер для игроков. 
public class SceneContainerHandler : MonoBehaviour
{
    public static SceneContainerHandler I;
    [Inject] public DiContainer container { get; private set; }

    private void Awake()
    {
        if (I == null)
            I = this;
        else Destroy(gameObject);
    }
}