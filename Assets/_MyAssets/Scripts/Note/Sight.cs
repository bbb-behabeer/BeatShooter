using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// 照準
    /// </summary>
    public class Sight : MonoBehaviour
    {
        private Transform _target;
        
        public void AimAt(Transform t)
        {
            _target = t;
            gameObject.SetActive(true);
        }

        public void FixedUpdate()
        {
            if (_target != null)
            {
                transform.position = _target.position;
                transform.rotation = Quaternion.identity;
            }
        }
    }
}