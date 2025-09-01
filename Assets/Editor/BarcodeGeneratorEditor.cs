/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BarcodeGeneratorEditor.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/8/28
 *  Description  :  Initial development version.
 *************************************************************************/

using System.IO;
using UnityEditor;
using UnityEngine;

namespace MGS.Barcode.Editors
{
    [CustomEditor(typeof(BarcodeGenerator), true)]
    public class BarcodeGeneratorEditor : Editor
    {
        protected BarcodeGenerator Target { get { return target as BarcodeGenerator; } }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            OnCustomInspectorGUI();
        }

        protected virtual void OnCustomInspectorGUI()
        {
            if (Target.Texture is Texture2D texture2D)
            {
                EditorGUILayout.BeginHorizontal("Box");
                if (GUILayout.Button("Save As PNG"))
                {
                    SaveTextureToPNG(texture2D);
                }
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
        }

        protected void SaveTextureToPNG(Texture2D texture)
        {
            var cacheFile = EditorUtility.SaveFilePanel("Save PNG File",
                    Application.streamingAssetsPath, Target.name, "png");

            if (string.IsNullOrEmpty(cacheFile))
            {
                Debug.Log("Cancel.");
                return;
            }

            var bytes = texture.EncodeToPNG();
            File.WriteAllBytes(cacheFile, bytes);
            Debug.Log($"Succeed save to {cacheFile}");
        }
    }
}