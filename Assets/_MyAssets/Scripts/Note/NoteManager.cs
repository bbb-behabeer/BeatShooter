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
        private int CurrentMoment => Mathf.FloorToInt(CurrentTime / Duration * _beat);
        private int _cacheMoment = -1;

        // キャッシュ
        private List<Note> _cacheNotes = new List<Note>();

        // 楽譜
        [SerializeField]
        private List<NoteUnit> _units;
        private NoteUnit _cacheUnit;
        
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
                if (CurrentMoment == 0)
                {
                    SpawnUnit();
                }
                
                if (_cacheUnit != null)
                {
                    if (_cacheUnit.ExitMoment == CurrentMoment)
                        NotesExit();
                    if (_cacheUnit.EnterMoment == CurrentMoment)
                        NotesEnter();
                }
                
                // 照準
                //AimCurrent();
                _cacheMoment = CurrentMoment;
            }
        }

        /// <summary>
        /// ノートを入場させる
        /// </summary>
        private void SpawnUnit()
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
        }

        private void NotesEnter()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                // ノートを入場させる
                note.Enter();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void NotesEnterCurrent()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                // ノートのモーメントが現在のものとき
                if (note.Moment == CurrentMoment)
                {
                    // ノートを入場させる
                    note.Enter();
                }
            }
        }

        /// <summary>
        /// ノートを退場させる
        /// </summary>
        private void NotesExit()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                note.Exit();
                _cacheNotes.Remove(note);
            }
        }

        /// <summary>
        /// 現在のモーメントをもつノートに照準を合わせる
        /// </summary>
        private void AimCurrent()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                // ノートのモーメントが現在のものとき
                if (note.Moment == CurrentMoment)
                {
                    // シューターに命令
                    // ノートに照準をあわせるように
                    _shooter.AimAt(note);
                }
            }
        }
        
        /// <summary>
        /// 現在のモーメントをもつノートに照準を合わせる
        /// </summary>
        public void Aim()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                // ノートのモーメントが現在のものとき
                if (CanHit(note.Moment))
                {
                    // シューターに命令
                    // ノートに照準をあわせるように
                    _shooter.AimAt(note);
                }
            }
        }
        
        /// <summary>
        /// 照準をもつノートにレーザーを撃つ
        /// </summary>
        public void Laser()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                // シューターに命令
                // ノートを射撃するように
                // ノートにエイムにしているとき
                if (note.Aimed)
                {
                    var period = _shooter.LaserAt(note);
                    Observable.Timer(TimeSpan.FromSeconds(period))
                        .Subscribe(_ =>
                        {
                            note.Explode();
                            _cacheNotes.Remove(note);
                        });
                }
            }
        }
        
        /// <summary>
        /// 前方のノートを撃つ
        /// </summary>
        public void Shot()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                // シューターに命令
                // ノートを射撃するように
               _shooter.ShotAt(note);
               _cacheNotes.Remove(note);
            }
        }

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

        /// <summary>
        /// ショットできる
        /// </summary>
        /// <returns>ショットする/しない</returns>
        public bool CanShot()
        {
            if (_cacheUnit == null) return false;
            
            var a = CurrentMoment % 2;
            return a == 0 && CanHit(CurrentMoment);
        }
        
        /// <summary>
        /// レーザーをショットできる
        /// </summary>
        /// <returns>ショットする/しない</returns>
        public bool CanLaser()
        {
            if (_cacheUnit == null) return false;

            var a = CurrentMoment % 2;
            return a == 1 && CanHit(CurrentMoment);
        }
    }
}