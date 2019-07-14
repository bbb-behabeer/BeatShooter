using System;
using System.Collections.Generic;
using _MyAssets.Scripts.Note;
using UnityEngine;

namespace _MyAssets.Scripts.Manager
{
    public class Controller: MonoBehaviour
    {
        [SerializeField]
        private List<Pod> _podList;

        [SerializeField] private List<Note.Note> _noteList;

        private int _offset = 0;

        private void Start()
        {
        }

        private void FixedUpdate()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }

        private void Fire()
        {
            foreach (var note in _noteList.ToArray())
            {
                if (note.CanAim())
                {
                    _podList[_offset].AimAt(note);
                }

                _offset++;
                if (_offset >= _podList.Count)
                    _offset = 0;
            }
            
            foreach (var pod in _podList)
            {
                if (pod.CanShot())
                    pod.Shot();
            }
        }
    }
}