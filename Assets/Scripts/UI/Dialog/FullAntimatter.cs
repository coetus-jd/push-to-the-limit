using System.Collections;
using TMPro;
using UnityEngine;
using TimeRace.Resources;

namespace TimeRace.UI
{
    public class FullAntimatter : BaseDialogController
    {
        void Awake()
        {
            ResourceBase = Resource.Language["pt-BR"].FullAntimatter;
        }
    }
}