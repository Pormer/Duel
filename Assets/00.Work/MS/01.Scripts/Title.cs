using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void OnPanel()
    {
        panel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Lobby");
    }

}
