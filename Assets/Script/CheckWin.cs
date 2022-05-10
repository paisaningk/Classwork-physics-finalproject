using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class CheckWin : MonoBehaviour
    {
        public GameObject uiGameObject;
        public TextMeshProUGUI timeText;
        public TextMeshProUGUI timeWinText;
        public Button reStartButton;
        public Button quitButton;
        private float time;

        private void Start()
        {
            reStartButton.onClick.AddListener(Restart);
            quitButton.onClick.AddListener(Quit);
            uiGameObject.SetActive(false);
        }

        private void Update()
        {
            time += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            timeText.text = $"{timeSpan:m\\:ss\\.fff}";
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            uiGameObject.SetActive(true);
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            timeWinText.text = $"Time : {timeSpan:m\\:ss\\.fff}";
        }

        private void Restart()
        {
            SceneManager.LoadScene("Gameplay");
        }

        private void Quit()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
