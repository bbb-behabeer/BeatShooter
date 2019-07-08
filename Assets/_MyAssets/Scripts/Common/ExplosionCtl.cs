using System;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    /// <summary>
    /// 爆発の制御
    /// </summary>
    public class ExplosionCtl: MonoBehaviour
    {
        public void Destroy()
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}