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
        [SerializeField] private int _moment = 0;

        // 入力した
        private bool _isAimed;
        
        // オーディオクリップ
        [SerializeField] private AudioClip _se;
        
        // 経過時間
        private float _time;

        public Transform Transform => transform;

        public Vector3 Position => transform.position;

        public void Start()
        {
            Initialize();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            var cache = transform.position;
            cache.y = NoteSetter.Instance.GetYPosWithMoment(_moment);
            transform.position = cache;
        }

        public bool CanAim()
        {
            var noteManager = NoteManager.Instance;
            return noteManager.CanHit(_moment);
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