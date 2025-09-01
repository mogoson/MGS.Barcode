/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BarcodeGenerator.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/28
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Barcode
{
    public abstract class BarcodeGenerator : BarcodeRaw
    {
        [SerializeField]
        protected string content;

        public string Content
        {
            set
            {
                content = value;
                UpdateTex(content);
            }
            get { return content; }
        }

        protected virtual void Start()
        {
            if (content == null)
            {
                return;
            }
            UpdateTex(content);
        }

        protected void UpdateTex(string content)
        {
            var width = (int)rawImage.rectTransform.rect.width;
            var height = (int)rawImage.rectTransform.rect.height;
            rawImage.texture = GenerateTex(content, width, height);
        }

        protected abstract Texture GenerateTex(string content, int width, int height);
    }
}