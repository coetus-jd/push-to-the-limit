using TMPro;
using UnityEngine;

namespace TimeRace.Scripts
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
        [SerializeField]
        private int CountToShowMessage;

        /// <summary>
        /// Componente aonde será exibido a contagem de antimatéria
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI Text;

        /// <summary>
        /// Controla se o diálogo de mensagem já foi aberto
        /// </summary>
        private bool DialogOpened;

        void Update()
        {
            //Código somente para testes, remover depois
            if (Input.GetKeyDown(KeyCode.Space))
                Add(1);
        }

        public void Add(int quantity)
        {
            Count += quantity;
            DisplayCount();

            if (Count >= CountToNextPhase)
            {
                Debug.Log("Lógica para mudar de fase");
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

        private void DisplayCount()
        {
            Text.text = Count.ToString();
        }
    }
}