using System;
using _MyAssets.Scripts.Base;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class NoteScreen :SingletonMonoBehaviour<NoteScreen>
    {
        public float Height =>  Screen.height;

        float HalfHeight => (float)Height * .5f;

        public float K => (Camera.main.orthographicSize / HalfHeight);

    }
}