/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BarcodeRaw.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/28
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.Barcode
{
    [RequireComponent(typeof(RawImage))]
    public abstract class BarcodeRaw : MonoBehaviour
    {
        [SerializeField]
        [HideInInspector]
        protected RawImage rawImage;

        public Texture Texture
        {
            get { return rawImage.texture; }
        }

        protected virtual void Reset()
        {
            rawImage = GetComponent<RawImage>();
        }
    }
}