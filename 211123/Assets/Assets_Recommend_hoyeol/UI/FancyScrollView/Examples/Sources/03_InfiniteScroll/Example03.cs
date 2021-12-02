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
        /*readonly ItemData[] itemData = 
        {
            new ItemData(
                "75inch\tUHD\t삼성전자\t스탠드",
                (Resources.Load("Img/samsung",typeof(GameObject))) as GameObject,
                "https://m.etlandmall.co.kr/mobile/product/product.do?prdMstCd=S3308023"
            ),
            new ItemData(
                "75inch\tUHD\t삼성전자\t스탠드",
                (Resources.Load("Img/lg",typeof(GameObject))) as GameObject,
                "https://m.etlandmall.co.kr/mobile/product/product.do?prdMstCd=S3308023"
            )
        };*/
        [SerializeField] ScrollView scrollView = default;

        void Start()
        {
            var items = Enumerable.Range(1, 11)
                .Select(i => new ItemData($"제품 {i}"))
                .ToArray();

            //scrollView.UpdateData(itemData);
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
        }
    }
}
