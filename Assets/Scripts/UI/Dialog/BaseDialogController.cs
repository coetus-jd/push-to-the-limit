using System.Collections;
using TMPro;
using UnityEngine;
using TimeRace.Resources;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

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
        /// Define se o diálogo será interativo
        /// </summary>
        [SerializeField]
        private bool Interactable = true;

        /// <summary>
        /// Quais textos estarão sendo utilizados nos diálogos
        /// </summary>
        protected List<ResourceBase> ResourceBase;

        /// <summary>
        /// Indica o índice do próximo texto
        /// </summary>
        private int NextDialogTextIndex;

        /// <summary>
        /// O nome da última pessoa a falar
        /// </summary>
        private string PastPersonName;

        private bool IsLastIndex
        {
            get
            {
                return NextDialogTextIndex == ResourceBase.Count - 1;
            }
        }

        void Start()
        {
            DialogPanel1.GetComponentInChildren<Button>()
                ?.onClick.AddListener(delegate { NextDialog(); });

            DialogPanel2.GetComponentInChildren<Button>()
                ?.onClick.AddListener(delegate { NextDialog(); });

            CurrentDialog = SecondPersonStarts
                ? DialogPanel2
                : DialogPanel1;

            StartDialog();
        }

        private void StartDialog()
        {
            if (Interactable)
                Time.timeScale = 0f;

            OpenDialog();
        }

        public void NextDialog()
        {
            CurrentDialog.SetActive(false);

            if (IsLastIndex)
            {
                FinishDialog();
                return;
            }

            NextDialogTextIndex++;

            if (PastPersonName != ResourceBase[NextDialogTextIndex].PersonName)
                CurrentDialog = CurrentDialog == DialogPanel1 ? DialogPanel2 : DialogPanel1;
            
            OpenDialog();
        }

        private void OpenDialog()
        {
            CurrentDialog.SetActive(true);
            CurrentDialog.GetComponentsInChildren<TextMeshProUGUI>()
                .Last()
                .text = ResourceBase[NextDialogTextIndex].Text;
            PastPersonName = ResourceBase[NextDialogTextIndex].PersonName;

            if (ResourceBase[NextDialogTextIndex].TimeToLeave > 0)
                StartCoroutine(WaitDialogFinish());
        }

        private IEnumerator WaitDialogFinish()
        {
            yield return new WaitForSeconds(ResourceBase[NextDialogTextIndex].TimeToLeave);
            NextDialog();
        }

        private void FinishDialog()
        {
            if (Interactable)
                Time.timeScale = 1f;
        }
    }
}