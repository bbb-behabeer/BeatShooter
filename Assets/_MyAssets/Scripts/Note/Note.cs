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
        [SerializeField] private int _moment;

        // 入力した
        private bool _isAimed;
        
        // オーディオクリップ
        [SerializeField] private AudioClip _se;
        
        // 経過時間
        private float _time;
        private float _just;

        // 照準
        private GameObject _aim;

        void Start()
        {
            // NoteManagerをシーンから取得
            var noteManager = NoteManager.Instance;
            
            // 子から照準を取得
            _aim = transform.Find("Aim").gameObject;
            
            // タイミングを取得
            _just = noteManager.DurationPerBeat * _moment;
            
            // 縦幅を取得
            var h = NoteScreen.Height;
            var hh = NoteScreen.HalfHeight;

            var k = NoteScreen.K;
            
            // 位置を計算
            var mb = (float)_moment /  (float)noteManager.Beat;
            var y = h * mb * k;

            // 位置を設定
            var pos = transform.position;
            pos.y = y;
            transform.position = pos;

            _isAimed = false;
        }

        private void FixedUpdate()
        {
            var noteManager = NoteManager.Instance;

            // 時間経過
            _time += Time.deltaTime;
            _time %= noteManager.Duration * noteManager.BBeatPerBeat;

            // タイミングを計算
            var min = _just - noteManager.Range;
            var max = _just + noteManager.Range;

            // 範囲内であればエイム可能
            if (_time > min && _time < max)
            {
                // エイムしておらず
                // 入力があればエイムする
                if (!_isAimed && Input.GetButtonDown("Jump"))
                {
                    //_isAimed = true;
                    
                    // エイム処理
                    //noteManager.PlaySE(_se)
                    _aim.SetActive(true);
                    Instantiate(_effect).transform.position = transform.position;
                }
            }
        }
        
        /// <summary>
        /// 削除する
        /// </summary>
        public void DestroyThis()
        {
            // エフェクトを生成
            var effect = Instantiate(_effect);
            effect.transform.position = transform.position;
            
            // 自身を削除
            Destroy(this.gameObject);
        }
    }
}