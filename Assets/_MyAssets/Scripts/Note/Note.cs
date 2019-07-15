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
        public int Moment => _moment;

        // 照準をあわせられた
        public bool Aimed => _sight != null;

        // オーディオクリップ
        [SerializeField] private AudioClip _se;
        
        // 経過時間
        private float _time;

        public Transform Transform => transform;

        public Vector3 Position => transform.position;

        private Sight _sight;

        public Sight Sight
        {
            set => _sight = value;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize(int moment)
        {
            _moment = moment;
        }
        
        /// <summary>
        /// 削除する
        /// </summary>
        public void Explode() 
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

        /// <summary>
        /// 入場する
        /// </summary>
        public void Enter()
        {
            // 移動
            //var pos = transform.position;
            //pos.y = NoteSetter.Instance.GetYPosWithMoment(_moment);
            //transform.position = pos;
        }

        public void Exit()
        {
            // 照準を削除
            if (_sight != null)
                Destroy(_sight.gameObject);
            
            // 移動
            if (!Aimed)
                Destroy(this.gameObject);
        }
    }
}