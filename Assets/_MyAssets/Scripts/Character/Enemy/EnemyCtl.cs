using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Common
{
    /// <summary>
    /// 敵キャラクターの制御
    /// </summary>
    public class EnemyCtl: MonoBehaviour
    {
        // 爆発エフェクト
        [SerializeField] private GameObject _explosion;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullet") || other.CompareTag("Player"))
            {
                // PlayerBulletとの衝突時
                // 爆発エフェクトを生成
                var explosion = Instantiate(_explosion);
                explosion.transform.position = transform.position;
                
                // 自身のゲームオブジェクトを削除
                Destroy(this.gameObject);
            }
        }
    }
}