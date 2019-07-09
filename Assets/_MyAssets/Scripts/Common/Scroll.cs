using System;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    /// <summary>
    /// オブジェクトをスクロールする
    /// </summary>
    public class Scroll: MonoBehaviour
    {
        // スクロールする距離
        [SerializeField]
        private Vector2 _dist;

        // スクロールする時間
        [SerializeField] private float _sec = 60;

        // 位置Zのキャッシュ
        private Vector3 _cache;

        void Start()
        {
            _cache = transform.position;
        }

        private void FixedUpdate()
        {
            var nx = _dist.x * (Time.timeSinceLevelLoad / _sec) + _cache.x;
            var ny = _dist.y * (Time.timeSinceLevelLoad / _sec) + _cache.y;
            transform.position = new Vector3(nx, ny, _cache.z);
        }
    }
}