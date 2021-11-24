using System.Collections;
using TMPro;
using UnityEngine;
using TimeRace.Resources;

namespace TimeRace.UI.Dialog
{
    public class Final : BaseDialogController
    {
        void Awake()
        {
            ResourceBase = Resource.Language["pt-BR"].Final;
        }
    }
}