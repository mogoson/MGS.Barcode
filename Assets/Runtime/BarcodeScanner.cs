/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BarcodeScanner.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/28
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using UnityEngine;

namespace MGS.Barcode
{
    public abstract class BarcodeScanner<T> : BarcodeRaw
    {
        public event Action<T> OnResult;
        public float interval = 0.25f;

        protected Coroutine scanner;
        protected WebCamTexture webCamTexture;

        protected virtual void Start()
        {
            StartScan();
        }

        protected virtual void OnDestroy()
        {
            StopScan();
        }

        public void StartScan()
        {
            if (scanner == null)
            {
                var width = (int)rawImage.rectTransform.rect.width;
                var height = (int)rawImage.rectTransform.rect.height;
                webCamTexture = new WebCamTexture(width, height);
                rawImage.texture = webCamTexture;

                webCamTexture.Play();
                scanner = StartCoroutine(Scanner());
            }
        }

        public void StopScan()
        {
            if (scanner == null)
            {
                return;
            }

            webCamTexture.Stop();
            webCamTexture = null;

            StopCoroutine(scanner);
            scanner = null;
        }

        protected IEnumerator Scanner()
        {
            T result = default;
            while (result == null)
            {
                yield return new WaitForSeconds(interval);
                result = DecodeTex(webCamTexture.GetPixels32(), webCamTexture.width, webCamTexture.height);
            }

            StopScan();
            OnResult?.Invoke(result);
        }

        protected abstract T DecodeTex(Color32[] rawColor32, int width, int height);
    }
}