using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;


namespace Cloth
{
    public enum ClothType
    {
        SPEED,
        STRONG

    }


    public class ChlothesManager : Singleton<ChlothesManager>
    {
        public List<ClothSettup> clothSettup;

        public ClothSettup GetSetupByType(ClothType clothType)
        {
            return clothSettup.Find(i => i.clothType == clothType);
        }

    }

    [System.Serializable]
    public class ClothSettup
    {
        public ClothType clothType;
        public Texture2D texture;
    }
}
