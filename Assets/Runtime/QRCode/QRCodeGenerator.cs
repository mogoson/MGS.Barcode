/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  QRCodeGenerator.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/27
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Barcode.QRCode
{
    public class QRCodeGenerator : BarcodeGenerator
    {
        protected override Texture GenerateTex(string content, int width, int height)
        {
            return QRCodeUtility.EncodeToTex(content, width, height);
        }
    }
}