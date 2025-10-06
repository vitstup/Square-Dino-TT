using TMPro;
using UnityEngine;

public class NicknameWorldUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void SetNickame(string nick)
    {
        text.text = nick;
    }

    public void Update()
    {
        transform.LookAt(cam.transform);
    }
}