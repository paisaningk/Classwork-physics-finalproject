using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button creditButton;
        [SerializeField] private Button quitButton;

        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(QuitGame);
            creditButton.onClick.AddListener(Credit);
            Time.timeScale = 1;
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        private void Credit()
        {
            SceneManager.LoadScene("CreditScene");
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    
        public void MenuGame()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
