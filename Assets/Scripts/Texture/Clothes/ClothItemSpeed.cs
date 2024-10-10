using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothItemSpeed : ClothPickerBase
    {
        public float targetSpeed = 60f;


        public override void Collect()
        {
            base.Collect();
            Player.Instance.ChangeSpeed(targetSpeed, duration);
        }
    }
}