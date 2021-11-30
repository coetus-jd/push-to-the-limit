using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TimeRace.Resources
{
    /// <summary>
    /// Todos os textos que são necessários na interface do jogo
    /// </summary>
    public static class Resource
    {
        public static Dictionary<string, AllResources> Language
        {
            get
            {
                if (_Language != null && _Language.Count > 0)
                    return _Language;

                string path = Path.Combine(Application.streamingAssetsPath, "Resources");

                _Language = new Dictionary<string, AllResources>()
                {
                    ["pt-BR"] = JsonUtility.FromJson<AllResources>(File.ReadAllText($"{path}/pt-BR.json")),
                };

                return _Language;
            }
        }

        /// <summary>
        /// Váriavel auxiliar, para guardar a referência dos textos
        /// </summary>
        private static Dictionary<string, AllResources> _Language;
    }

    [Serializable]
    public class AllResources
    {
        public List<ResourceBase> Introduction;
        public List<ResourceBase> Explication;
        public List<ResourceBase> FullAntimatter;
        public List<ResourceBase> RunningOutOfTime;
        public List<ResourceBase> HitBorderTwice;
        public List<ResourceBase> ToTheFuture;
        public List<ResourceBase> TurnWithoutHit;
        public List<ResourceBase> Lost;
    }

    [Serializable]
    public class ResourceBase
    {
        public string Text;
        public string PersonName;
        public int TimeToLeave;
        public string AnimationName;
    }
}