/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  QRCodeUtility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/27
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using ZXing;
using ZXing.Common;

namespace MGS.Barcode.QRCode
{
    public sealed class QRCodeUtility
    {
        public static Texture2D EncodeToTex(string content, int width, int height)
        {
            var colors = Encode(content, width, height);
            var texture = new Texture2D(width, height);
            texture.SetPixels32(colors);
            texture.Apply();
            return texture;
        }

        public static Color32[] Encode(string content, int width, int height)
        {
            var options = new EncodingOptions
            {
                Width = width,
                Height = height,
                Margin = 1
            };
            options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };

            return writer.Write(content);
        }

        public static Result Decode(Texture2D texture)
        {
            return Decode(texture.GetPixels32(), texture.width, texture.height);
        }

        public static Result Decode(Color32[] rawColor32, int width, int height)
        {
            var reader = new BarcodeReader();
            return reader.Decode(rawColor32, width, height);
        }
    }
}