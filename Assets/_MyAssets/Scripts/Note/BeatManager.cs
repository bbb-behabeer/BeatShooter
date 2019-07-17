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
    public class BeatManager: SingletonMonoBehaviour<BeatManager>
    {
        // 入力の許容範囲
        [SerializeField] private float _range;
        
        // 一小節の長さ
        public float Duration => 60f / _bpm * _beat;

        private int _beat = 4;

        [SerializeField] private int _bpm = 120;

        // 一拍の時間
        public float DurationPerBeat => Duration / _beat;

        // 時間
        public float CurrentTime => _audioSource.time;//Time.timeSinceLevelLoad % Duration;
        public float CurrentTimePerDuration => CurrentTime % Duration;
        
        public int CurrentMeasure => Mathf.FloorToInt(CurrentTime / Duration);
        
        // 拍
        public int CurrentMoment => Mathf.FloorToInt(CurrentTimePerDuration / Duration * _beat);
        private int _cacheMoment = -1;

        private AudioSource _audioSource;

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
        /// 時間を取得する
        /// </summary>
        /// <param name="moment">拍</param>
        /// <returns></returns>
        private float GetTiming(float moment)
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
            if (moment == 0)
            {
                var start = 0;
                var end = Duration;
                return (CurrentTimePerDuration < start + _range || CurrentTimePerDuration > end -_range);
            }
            
            // タイミングを計算
            var just = GetTiming(moment);
            var min = just - _range;
            var max = just + _range;
            
            // 範囲内であればエイム可能
            return (CurrentTimePerDuration > min && CurrentTimePerDuration < max);
        }
    }
}