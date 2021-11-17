using System.Collections;
using TMPro;
using UnityEngine;
using TimeRace.Resources;

namespace TimeRace.UI
{
    public class BaseDialogController : MonoBehaviour
    {
        /// <summary>
        /// A primeira "pessoa" do dialog
        /// </summary>
        [SerializeField]
        protected GameObject DialogPanel1;

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
        /// Indica o índice do próximo texto
        /// </summary>
        protected int NextDialogTextIndex;

        protected bool IsLastIndex
        {
            get
            {
                return NextDialogTextIndex == ResourceBase.Texts.Count - 1;
            }
        }

        protected ResourceBase ResourceBase;

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
            CurrentDialog = CurrentDialog == DialogPanel1 ? DialogPanel2 : DialogPanel1;

            CurrentDialog.SetActive(true);
            CurrentDialog.GetComponentInChildren<TextMeshProUGUI>()
                .text = ResourceBase.Texts[NextDialogTextIndex];
        }

        private void FinishDialog()
        {
            Time.timeScale = 1f;
        }
    }
}