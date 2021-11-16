using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace PirateCave.Resources
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
        public Scientist Scientist;
        public Apprentice Apprentice;
    }

    [Serializable]
    public class ResourceBase
    {
        public List<string> texts;
    }

    [Serializable]
    public class Scientist : ResourceBase {}

    [Serializable]
    public class Apprentice : ResourceBase {}
}