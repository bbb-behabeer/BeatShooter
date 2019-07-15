using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class NoteUnit : MonoBehaviour
    {
        [SerializeField] private int _releaseMoment;
        public int ReleaseMoment => _releaseMoment;
    }
}