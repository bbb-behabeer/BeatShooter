using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// 照準
    /// </summary>
    public class Sight : MonoBehaviour
    {
        private Note _target;
        
        public void SetTarget(Note t)
        {
            _target = t;
            gameObject.SetActive(true);
            transform.position = _target.Position;
            transform.rotation = Quaternion.identity;

            t.Sight = this;
        }
    }
}