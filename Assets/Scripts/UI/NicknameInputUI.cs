using TMPro;
using UnityEngine;
using Zenject;

public class NicknameInputUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    [Inject] private LocalNicknameHandler handler;

    private string currentValue;

    public void OnValueChanged(string value)
    {
        currentValue = value;
    }

    public void TrySetNickname()
    {
        handler.TrySetNickname(currentValue);
    }
}