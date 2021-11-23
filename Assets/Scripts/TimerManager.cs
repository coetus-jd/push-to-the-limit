using TMPro;
using UnityEngine;

namespace TimeRace.Scripts
{
    public class TimerManager : MonoBehaviour
    {
        /// <summary>
        /// Diálogo contendo o aviso do cientista sobre o tempo estar acabando
        /// </summary>
        [SerializeField]
        private GameObject RunningOutOfTimeDialog;

        /// <summary>
        /// Tempo restante
        /// </summary>
        [SerializeField]
        private float TimeRemaining = 180;

        /// <summary>
        /// A partir de que tempo deverá ser mostrado o aviso ao jogador
        /// </summary>
        [SerializeField]
        private float TimeToShowWarning = 100;

        /// <summary>
        /// Componente aonde será exibido os minutos e segundos
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI Text;

        /// <summary>
        /// Controla se o timer está rodando
        /// </summary>
        private bool TimerIsRunning;

        /// <summary>
        /// Controla se o diálogo de aviso já foi aberto
        /// </summary>
        private bool DialogOpened;

        void Start()
        {
            TimerIsRunning = true;
        }
        void Update()
        {
            if (!TimerIsRunning)
                return;

            OpenDialogWarning();

            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                DisplayTime(TimeRemaining);
                return;
            }

            TimeRemaining = 0;
            TimerIsRunning = false;
        }

        private void OpenDialogWarning()
        {
            if (DialogOpened)
                return;

            if (TimeRemaining > TimeToShowWarning)
                return;

            RunningOutOfTimeDialog.SetActive(true);
            DialogOpened = true;
        }

        private void DisplayTime(float time)
        {
            time += 1;

            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}