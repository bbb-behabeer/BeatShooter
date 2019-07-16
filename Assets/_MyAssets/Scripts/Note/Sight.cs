using System;
using System.Security.Cryptography;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// 照準
    /// </summary>
    public class Sight : MonoBehaviour
    {
        private NoteBase _target;
        
        public void SetTarget(NoteBase t)
        {
            _target = t;

            if (_target == null)
            {
                Destroy(gameObject);
                return;
            }
            
            transform.position = _target.Position;
            transform.rotation = Quaternion.identity;

            t.Sight = this;
        }
    }
}