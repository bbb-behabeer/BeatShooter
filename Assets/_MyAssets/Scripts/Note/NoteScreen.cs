using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class NoteScreen : MonoBehaviour
    {

        public static int Height =>  Screen.height;

        public static float HalfHeight => (float)Height * .5f;

        public static float K => (Camera.main.orthographicSize / HalfHeight) * .5f;

    }
}