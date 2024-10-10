using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothItemStrong : ClothPickerBase
    {
        public float damageMult = .5f;

        public override void Collect()
        {
            base.Collect();
            Player.Instance.healthBase.ChangeDamageMult(damageMult, duration);
        }

    }
}
