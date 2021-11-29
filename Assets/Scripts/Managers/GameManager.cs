using UnityEngine;
using UnityEngine.SceneManagement;

namespace TimeRace.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {   
        [SerializeField]
        private GameObject PausePanel;

        [SerializeField]
        private GameObject BackgroundSound;

        /// <summary>
        /// Fecha a aplicação do jogo
        /// </summary>
        public static void QuitGame() => Application.Quit();

        void Awake()
        {
            Time.timeScale = 1;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                TogglePauseGame();

            // Atalho somente para fins de apresentação, remover posteriormente
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.B))
                BackgroundSound.SetActive(!BackgroundSound.activeSelf);
        }

        public void TogglePauseGame()
        {
            PausePanel.SetActive(!PausePanel.activeSelf);
            Time.timeScale = PausePanel.activeSelf ? 0 : 1;
        }
    }
}