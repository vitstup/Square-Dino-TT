using UnityEngine;
using Zenject;

public class MatchmakingUI : MonoBehaviour
{
    [SerializeField] private GameObject hud;

    [Inject] private Matchmaker matchmaker;

    private void Start()
    {
        hud.SetActive(true);
    }

    public void Connect()
    {
        hud.SetActive(false);
        matchmaker.Connect();
    }
}