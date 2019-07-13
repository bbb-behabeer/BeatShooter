using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class NoteScreen : MonoBehaviour
    {
        private static int height;
        private static float halfHeight;
        private static float k;

        public static int Height => height;

        public static float HalfHeight => halfHeight;

        public static float K => k;

        private void Start()
        {
            // 縦幅を取得
            height = Screen.height;
            halfHeight = height / 2f;

            k = Camera.main.orthographicSize / halfHeight;
        }

        
    }
}