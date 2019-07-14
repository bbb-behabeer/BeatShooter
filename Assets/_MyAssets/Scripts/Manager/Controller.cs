using System;
using System.Collections.Generic;
using _MyAssets.Scripts.Note;
using UnityEngine;

namespace _MyAssets.Scripts.Manager
{
    public class Controller: MonoBehaviour
    {
        [SerializeField]
        private List<Laser> _laserList;

        private void FixedUpdate()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shot();
            }
        }

        private void Shot()
        {
            foreach (var laser in _laserList)
            {
                laser.ShotTo(null);
            }
        }
    }
}