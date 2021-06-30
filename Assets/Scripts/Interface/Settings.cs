
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private Toggle _mute;

    private bool _IsMuted;

    private void Awake()
    {
        _mute.onValueChanged.AddListener(Mute);
    }

    private void Mute(bool value)
    {
        _IsMuted = value;
    }
}
