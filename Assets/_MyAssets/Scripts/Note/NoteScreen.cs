using System;
using _MyAssets.Scripts.Base;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class NoteScreen :SingletonMonoBehaviour<NoteScreen>
    {
        public float Height =>  Screen.height;
        //[SerializeField] private float height = 640;
        //public float Height => height;

        public float Offset =>  Height * .25f;

        public float K => Camera.main.orthographicSize / Height;

    }
}