using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectables
{
    public class ItemLayoutManager : MonoBehaviour
    {
        public ItemLayout pfbLayout;
        public Transform container;

        public List<ItemLayout> itemLayouts;

        private void Start()
        {
            CreateItens();
        }


        
        private void CreateItens()
        {
            foreach(var settup in ItemManager.Instance.itemSettups)
            {
                var item = Instantiate(pfbLayout, container);
                item.Load(settup);
                itemLayouts.Add(item);
            }
        }




    }
}
