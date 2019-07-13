using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの制御
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class Note: MonoBehaviour
    {
        // ノート再生時のエフェクト
        [SerializeField] private GameObject _effect;
        
        // ノートを配置するタイミング
        // 1--8
        [SerializeField] private int _moment;

        // 入力の許容範囲
        [SerializeField] private float _range;

        // 一小節の長さ
        [SerializeField] private float _duration = 1f;
        [SerializeField] private int _beat = 8;

        // 経過時間
        private float _time;
        
        // 入力した
        private bool _isAimed;

        // オーディオソース
        private AudioSource _audioSource;
        private float _timePerBeat;
        private float _just;

        [Button("Start")]
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            
            // タイミングを取得
            _timePerBeat = _duration / (float)_beat;
            _just = _timePerBeat * _moment;
            
            // 縦幅を取得
            var h = Screen.height;
            var hh = h / 2f;

            var k = Camera.main.orthographicSize / hh;
            
            var mb = (float)_moment /  (float)_beat ;
            var y = (h * mb - hh) * k;

            // 位置を初期化
            var pos = transform.position;
            pos.y = y;
            transform.position = pos;
            
            
            // NoteManagerをシーンから取得
            //    _noteManager = GameObject.Find("NoteManager").GetComponent<NoteManager>();
        }

        private void FixedUpdate()
        {
            _time += Time.deltaTime;

            // タイミングを計算
            var min = _just - _range;
            var max = _just + _range;

            // 範囲内であればエイム可能
            if (_time > min && _time < max)
            {
                // エイムしておらず
                // 入力があればエイムする
                if (!_isAimed && Input.GetButtonDown("Jump"))
                {
                    _isAimed = true;
                    
                    // エイム処理
                    _audioSource.Play();
                    Debug.Log(gameObject);
                }
            }
        }
        
        /*private void OnWillRenderObject()
        {
            if (Camera.current.name != "SceneCamera" && Camera.current.name != "Preview Camera")
            {
                // すでに可視なら処理を無視
                if (_visible) return;
                
                // カメラ内に表示されたとき（ゲームビューのみ）
                if (_noteManager != null)
                {
                    // スキップ可能に設定
                    // 可視に設定
                    _noteManager.SetSkippable();
                    _visible = true;
                }
            }
        }*/

        /// <summary>
        /// 削除できるか
        /// </summary>
        /// <returns></returns>
        /*public bool CanDestroy()
        {
            // 可視のとき
            if (_visible)
                return true;
            return false;
        }*/

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