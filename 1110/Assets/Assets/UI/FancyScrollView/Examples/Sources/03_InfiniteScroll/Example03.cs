/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System.Linq;
using UnityEngine;

namespace FancyScrollView.Example03
{
    class Example03 : MonoBehaviour
    {
        [SerializeField] ScrollView scrollView = default;

        void Start()
        {
            var items = Enumerable.Range(1, 10)
                .Select(i => new ItemData($"제품 {i}"))
                .ToArray();
            

            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
        }
    }
}
