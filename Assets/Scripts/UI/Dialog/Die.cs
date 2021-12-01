using System.Collections;
using TMPro;
using UnityEngine;
using TimeRace.Resources;
using System.Collections.Generic;

namespace TimeRace.UI.Dialog
{
    public class Die : BaseDialogController
    {
        void Awake()
        {
            ResourceBase = Resource.Language["pt-BR"].Die;
        }
    }
}