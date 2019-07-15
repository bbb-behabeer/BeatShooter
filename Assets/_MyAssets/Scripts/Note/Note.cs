using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの制御
    /// </summary>
    [RequireComponent(typeof(AudioClip))]
    public class Note: MonoBehaviour
    {
        // ノート再生時のエフェクト
        [SerializeField] private GameObject _effect;
        
        // ノートを配置するタイミング
        private int _moment = 0;
        public int Moment => _moment;

        // 照準をあわせられた
        private bool _aimed = false;
        public bool Aimed => _aimed;
        
        
        // オーディオクリップ
        [SerializeField] private AudioClip _se;
        
        // 経過時間
        private float _time;

        public Transform Transform => transform;

        public Vector3 Position => transform.position;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize(int moment)
        {
            _moment = moment;
            _aimed = false;
        }

        /// <summary>
        /// 削除する
        /// </summary>
        public void Explode() 
        {
            // エフェクトを生成
            var effect = Instantiate(_effect);
            effect.transform.position = transform.position;
            
            // 自身を削除
            Destroy(this.gameObject);
        }
    }
}