using System;
using _MyAssets.Scripts.Player;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの制御
    /// </summary>
    [RequireComponent(typeof(AudioClip))]
    public class NoteBase: BeatSprite
    {
        // 爆発エフェクト
        [SerializeField] private GameObject _effect;
        [SerializeField] private GameObject _hitStopSprite;
        
        // 照準をあわせられた
        public bool Aimed => _sight != null;

        // オーディオクリップ
        [SerializeField] private AudioClip _se;

        // 経過時間
        private float _time;

        // 位置を伝える
        public Vector3 Position => transform.position;

        // 照準
        private Sight _sight;

        public Sight Sight
        {
            set => _sight = value;
        }

        /// <summary>
        /// ヒット
        /// </summary>
        /// <returns></returns>
        public void Hit()
        {
            var sec = .1f;
            
            HitStopSprite();
            Observable.Timer(TimeSpan.FromSeconds(sec))
                .Subscribe(_ => Explode());
        }

        /// <summary>
        /// 爆発する
        /// </summary>
        private void Explode()
        {
            // 照準を削除
            if (_sight != null)
                Destroy(_sight.gameObject);
            
            // エフェクトを生成
            var effect = Instantiate(_effect);
            effect.transform.position = transform.position;
            
            // 自身を削除
            Destroy(gameObject);
        }
    }
}