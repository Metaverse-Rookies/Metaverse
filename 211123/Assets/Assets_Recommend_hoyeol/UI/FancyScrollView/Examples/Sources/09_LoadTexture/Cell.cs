/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using EasingCore;

namespace FancyScrollView.Example09
{
    class Cell : FancyCell<ItemData>
    {
        readonly EasingFunction alphaEasing = Easing.Get(Ease.OutQuint);

        [SerializeField] Text title = default;
        [SerializeField] Text description = default;
        [SerializeField] RawImage image = default;
        [SerializeField] Image background = default;
        [SerializeField] CanvasGroup canvasGroup = default;

        ItemData data;
        Button btn;
        public override void UpdateContent(ItemData itemData)
        {
            data = itemData;
            image.texture = null;

            TextureLoader.Load(itemData.Url, result =>
            {
                if (image == null || result.Url != data.Url)
                {
                    return;
                }

                image.texture = result.Texture;
            });

            title.text = itemData.Title;
            description.text = itemData.Description;

            UpdateSibling();
        }

        void UpdateSibling()
        {
            var cells = transform.parent.Cast<Transform>()
                .Select(t => t.GetComponent<Cell>())
                .Where(cell => cell.IsVisible);

            if (Index == cells.Min(x => x.Index))
            {
                transform.SetAsLastSibling();
            }

            if (Index == cells.Max(x => x.Index))
            {
                transform.SetAsFirstSibling();
            }
        }

        public override void UpdatePosition(float t)
        {
            const float popAngle = -15;
            const float slideAngle = 25;

            const float popSpan = 0.75f;
            const float slideSpan = 0.25f;

            t = 1f - t;

            var pop = Mathf.Min(popSpan, t) / popSpan;
            var slide = Mathf.Max(0, t - popSpan) / slideSpan;

            transform.localRotation = t < popSpan
                ? Quaternion.Euler(0, 0, popAngle * (1f - pop))
                : Quaternion.Euler(0, 0, slideAngle * slide);

            transform.localPosition = Vector3.left * 500f * slide;

            canvasGroup.alpha = alphaEasing(1f - slide);

            background.color = Color.Lerp(Color.gray, Color.white, pop);
        }
        
        void Start()
        {
            btn = gameObject.AddComponent<Button>();
            Debug.Log(title.text);
            if (title.text == "상품번호 S0167913")
                btn.onClick.AddListener(AnamURL);
            else if (title.text == "상품번호 S2974243")
                btn.onClick.AddListener(Samsung75URL);
            else if (title.text == "상품번호 S2987021")
                btn.onClick.AddListener(Samsung85URL);
            else if (title.text == "상품번호 S3121113")
                btn.onClick.AddListener(Lg48URL);
            else if (title.text == "상품번호 S3308023")
                btn.onClick.AddListener(Lg77URL);
            else
                btn.onClick.AddListener(AnamURL);
        }
        public void AnamURL()
        {
            Application.OpenURL("https://m.etlandmall.co.kr/mobile/product/product.do?prdMstCd=S0167913");
        }
        public void Lg48URL()
        {
            Application.OpenURL("https://m.etlandmall.co.kr/mobile/product/product.do?prdMstCd=S3121113");
        }
        public void Samsung85URL()
        {
            Application.OpenURL("https://m.etlandmall.co.kr/mobile/product/product.do?prdMstCd=S2987021");
        }
        public void Samsung75URL()
        {
            Application.OpenURL("https://m.etlandmall.co.kr/mobile/product/product.do?prdMstCd=S2974243");
        }
        public void Lg77URL()
        {
            Application.OpenURL("https://m.etlandmall.co.kr/mobile/product/product.do?prdMstCd=S3308023");
        }
    }
}
