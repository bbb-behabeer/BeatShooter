using System;
using _MyAssets.Scripts.Base;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class NoteScreen :SingletonMonoBehaviour<NoteScreen>
    {
        public float Height =>  Screen.height;
        public float Width => Screen.width;

        public float Offset =>  Height * .25f;

        public float K => Camera.main.orthographicSize / Height;

    }
}