using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClotheChanger : MonoBehaviour
    {
        public SkinnedMeshRenderer mesh;

        public Texture2D texture;
        public string shaderIDName = "_EmissionMap";

        private Texture2D _defalutTexture;

        private void Awake()
        {
            _defalutTexture = (Texture2D) mesh.sharedMaterials[0].GetTexture(shaderIDName);
        }

        [NaughtyAttributes.Button]
        private void ChangeTexture()
        {
            mesh.materials[0].SetTexture(shaderIDName, texture);
        }

        public void ChangeTexture(ClothSettup setup)
        {
            mesh.materials[0].SetTexture(shaderIDName, setup.texture);
        }

        public void ResetTexture()
        {
            mesh.materials[0].SetTexture(shaderIDName, _defalutTexture);
        }



    }
}
