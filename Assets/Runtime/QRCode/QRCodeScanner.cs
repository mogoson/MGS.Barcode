/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  QRCodeScanner.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/28
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using ZXing;

namespace MGS.Barcode.QRCode
{
    public class QRCodeScanner : BarcodeScanner<Result>
    {
        protected override Result DecodeTex(Color32[] rawColor32, int width, int height)
        {
            return QRCodeUtility.Decode(rawColor32, width, height);
        }
    }
}