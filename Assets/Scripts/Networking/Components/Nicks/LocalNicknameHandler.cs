using UnityEngine;

public class LocalNicknameHandler
{
    public string nick { get; private set; }

    public void TrySetNickname(string nickname)
    {
        if (string.IsNullOrWhiteSpace(nickname))
            nickname = $"User {Random.Range(0, int.MaxValue)}";

        nick = nickname;

        Debug.Log($"Local player nickname {nick}");
    }
}