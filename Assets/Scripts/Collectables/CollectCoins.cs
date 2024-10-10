using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectables;

public class CollectCoins : BaseCollectable
{

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.COIN);
        collider.enabled = false;
    }

}
