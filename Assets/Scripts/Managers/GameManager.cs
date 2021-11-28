using UnityEngine;

namespace TimeRace.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Carrega uma Scene por seu caminho
        /// </summary>
        /// <param name="sceneName"></param>
        public static void playScene(string sceneName)
        {
            SceneLoadManager.Instance.LoadScene(sceneName);
        }

        /// <summary>
        /// Fecha a aplicação do jogo
        /// </summary>
        public static void quitGame() => Application.Quit();
    }
}