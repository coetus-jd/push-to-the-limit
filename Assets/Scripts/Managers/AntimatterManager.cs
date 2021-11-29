using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TimeRace.Scripts.Managers
{
    public class AntimatterManager : MonoBehaviour
    {
        /// <summary>
        /// Diálogo contendo a mensagem do cientista de que a quantidade de antimatéria está quase lá
        /// </summary>
        [SerializeField]
        private GameObject FullAntimatterDialog;

        /// <summary>
        /// Número de antimatéria coletadas
        /// </summary>
        [SerializeField]
        private int Count;

        /// <summary>
        /// A partir de quantas antimatérias deverá ser trocado a fase do jogo
        /// </summary>
        [SerializeField]
        private int CountToNextPhase;

        /// <summary>
        /// A partir de quantas antimatérias deverá ser mostrado a mensagem ao jogador
        /// </summary>
        private int CountToShowMessage;

        /// <summary>
        /// A imagem do combustível sendo preenchido
        /// </summary>
        [SerializeField]
        private Image Fuel;

        /// <summary>
        /// Áudio que será tocado ao terminar a última fase
        /// </summary>
        private AudioSource WinAudio;

        /// <summary>
        /// UI com a mensagem de que o jogador ganhou
        /// </summary>
        [SerializeField]
        private GameObject WinPanel;

        /// <summary>
        /// Indica se é a fase final ou não
        /// </summary>
        [SerializeField]
        private bool FinalPhase;

        /// <summary>
        /// Controla se o diálogo de mensagem já foi aberto
        /// </summary>
        private bool DialogOpened;

        /// <summary>
        /// Todos os gameobjects que devem ser desabilitados ao ganhar
        /// </summary>
        [SerializeField]
        private List<GameObject> UiElementsToDisable;

        void Start()
        {
            CountToShowMessage = CountToNextPhase / 2;
            WinAudio = GetComponent<AudioSource>();
        }

        void Update()
        {
            // Atalho somente para fins de apresentação, remover posteriormente
            if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.LeftShift))
                GoToNextScene();
        }

        public void Add(int quantity)
        {
            Count += quantity;
            DisplayCount();

            if (Count >= CountToNextPhase)
            {
                GoToNextScene();
                return;
            }

            if (DialogOpened)
                return;

            if (Count >= CountToShowMessage)
            {
                FullAntimatterDialog.SetActive(true);
                DialogOpened = true;
            }
        }

        private void Win()
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);

            UiElementsToDisable.ForEach(ui => ui.SetActive(false));

            WinAudio.Play();
        }

        private void DisplayCount()
        {
            Fuel.fillAmount = (float)Count / CountToNextPhase;
        }

        private void GoToNextScene()
        {
            if (FinalPhase)
            {
                Win();
                return;
            }

            SceneLoadManager.Instance.PlaySceneWithLoading("GamePhase2");
        }
    }
}