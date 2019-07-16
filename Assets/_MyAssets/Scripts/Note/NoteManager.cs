using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの管理
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class NoteManager: SingletonMonoBehaviour<NoteManager>
    {
        // 入力の許容範囲
        [SerializeField] private float _range;
        
        // 一小節の長さ
        public float Duration => _bpm / 60f;

        [SerializeField]
        private int _beat = 4;
        public float Beat => _beat;

        [SerializeField] private int _bpm = 120;

        // 一拍の時間
        public float DurationPerBeat => Duration / _beat;

        // オーディオソース
        private AudioSource _audioSource;

        // 時間
        public float CurrentTime => Time.timeSinceLevelLoad % Duration;
        // 小節
        private int CurrentMeasure => Mathf.FloorToInt(CurrentTime / Duration);
        private int _cacheMeasure = -1;
        // 拍
        public int CurrentMoment => Mathf.FloorToInt(CurrentTime / Duration * _beat);
        private int _cacheMoment = -1;

        // キャッシュ
        private List<Note> _cacheNotes = new List<Note>();

        // 楽譜
        //[SerializeField]
        //private List<NoteUnit> _units;
        //private NoteUnit _cacheUnit;
        
        // シューター
        [SerializeField] private Shooter _shooter;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            // 拍
            if (_cacheMoment != CurrentMoment)
            {
                // 照準
                _cacheMoment = CurrentMoment;
            }
        }

        /// <summary>
        /// ノートを入場させる
        /// </summary>
        /*private void SpawnUnit()
        {
            if (_units.Count > 0)
            {
                var u = _units[0];
                // ノートユニットを生成
                var notes = NoteSpawn.Instance.SpawnUnit(u);
                _units.RemoveAt(0);
                _cacheNotes.AddRange(notes);
                _cacheUnit = u;
            }
        }*/

        /// <summary>
        /// 時間を取得する
        /// </summary>
        /// <param name="moment">拍</param>
        /// <returns></returns>
        public float GetTiming(float moment)
        {
            // タイミングを取得
            return DurationPerBeat * moment;
        }

        /// <summary>
        /// ヒットするか
        /// </summary>
        /// <param name="moment">拍</param>
        /// <returns></returns>
        public bool CanHit(int moment)
        {
            if (moment == _beat)
            {
                var start = 0;
                var end = Duration;
                return (CurrentTime < start + _range || CurrentTime > end -_range);
            }
            
            // タイミングを計算
            var just = GetTiming(moment);
            var min = just - _range;
            var max = just + _range;
            
            // 範囲内であればエイム可能
            return (CurrentTime > min && CurrentTime < max);
        }
    }
}