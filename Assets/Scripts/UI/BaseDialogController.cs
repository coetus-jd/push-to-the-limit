using System.Collections;
using TMPro;
using UnityEngine;
using TimeRace.Resources;
using System.Linq;

namespace TimeRace.UI
{
    public class BaseDialogController : MonoBehaviour
    {
        /// <summary>
        /// A primeira "pessoa" do dialog
        /// </summary>
        [SerializeField]
        protected GameObject DialogPanel1;

        protected GameObject Dialog1Text;

        /// <summary>
        /// A segunda "pessoa" do dialog
        /// </summary>
        [SerializeField]
        protected GameObject DialogPanel2;

        /// <summary>
        /// Representa o atual dialog que está sendo exibido
        /// </summary>
        protected GameObject CurrentDialog;

        /// <summary>
        /// Indica se quem deve começar a conversa é a segunda "pessoa"
        /// </summary>
        [SerializeField]
        protected bool SecondPersonStarts;

        /// <summary>
        /// Quais textos estarão sendo utilizados nos diálogos
        /// </summary>
        protected ResourceBase ResourceBase;

        /// <summary>
        /// Indica o índice do próximo texto
        /// </summary>
        private int NextDialogTextIndex;

        private bool IsLastIndex
        {
            get
            {
                return NextDialogTextIndex == ResourceBase.Texts.Count - 1;
            }
        }

        void Start()
        {
            CurrentDialog = SecondPersonStarts
                ? DialogPanel2
                : DialogPanel1;

            StartDialog();
        }

        private void StartDialog()
        {
            Time.timeScale = 0f;
            OpenDialog();
        }

        public void NextDialog()
        {
            CurrentDialog.SetActive(false);
            CurrentDialog = CurrentDialog == DialogPanel1 ? DialogPanel2 : DialogPanel1;

            if (IsLastIndex)
                FinishDialog();
            else
            {
                NextDialogTextIndex++;
                OpenDialog();
            }
        }

        private void OpenDialog()
        {
            CurrentDialog.SetActive(true);
            CurrentDialog.GetComponentsInChildren<TextMeshProUGUI>()
                .Last()
                .text = ResourceBase.Texts[NextDialogTextIndex];
        }

        private void FinishDialog()
        {
            Time.timeScale = 1f;
        }
    }
}