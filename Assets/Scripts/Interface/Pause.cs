using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _menu;

    private void Awake()
    {
        _menu.onClick.AddListener(Continue);
    }

    private void Continue()
    {
        SceneManager.LoadScene("Menu");
    }
}
