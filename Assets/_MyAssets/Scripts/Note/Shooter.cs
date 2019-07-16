using System;
using System.Collections.Generic;
using Arbor;
using UniRx;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class Shooter: MonoBehaviour
    {
        [SerializeField]
        private Laser _laser;
        [SerializeField]
        private Sight _sight;

        private List<Note> _targets;

        // 時間
        private float _time;
        
        private void Start()
        {
            _time = 0;
        }

        private void Update()
        {
            var noteManager = NoteManager.Instance;
            
            // 時間経過
            _time += Time.deltaTime;
            _time %= noteManager.Duration;
        }

        /// <summary>
        /// レイキャストで手前のノートを取得
        /// </summary>
        private Note GetLookingNote()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.up, LayerMask.GetMask("Note"));
            if (hit.collider)
            {
                return hit.collider.gameObject.GetComponent<Note>();
            }

            return null;
        }
        
        /// <summary>
        /// ショットする
        /// </summary>
        public void Shot()
        {
            var note = GetLookingNote();
            // レイキャストで手前のノートを取得
            if (note != null)
            {
                ShotAt(note);
            }
        }

        /// <summary>
        /// ショットする
        /// </summary>
        public void ShotAt(Note note)
        {
            // 射撃で爆発
            note.Explode();
        }

        /// <summary>
        /// レーザーを撃つ
        /// </summary>
        public void Laser()
        {
            foreach (var t in _targets.ToArray())
            {
                LaserAt(t);
            }
        }

        /// <summary>
        /// レーザーを撃つ
        /// </summary>
        /// <param name="t">ターゲット</param>
        /// <returns></returns>
        public void LaserAt(Note t)
        {
            // レーザーを生成する
            var l = Instantiate(_laser).GetComponent<Laser>();
            l.Initialize(transform.position);
            l.SetTarget(t);
            var period = l.Period;

            // 発射後にノートを破壊
            Observable.Timer(TimeSpan.FromSeconds(period))
                .Subscribe(_ =>
                {
                    t.Explode();
                    _targets.Remove(t);
                });
        }

        /// <summary>
        /// エイムする
        /// </summary>
        public void Aim()
        {
            
        }

        /// <summary>
        /// エイムする
        /// </summary>
        /// <param name="t">ターゲット</param>
        public void AimAt(Note t)
        {
            // SetTarget内で
            // 照準を生成する
            var s = Instantiate(_sight).GetComponent<Sight>();
            s.SetTarget(t);
        }
        
        /// <summary>
        /// ショットできる
        /// </summary>
        /// <returns>ショットする/しない</returns>
        public bool CanShot()
        {
            var a = NoteManager.Instance.CurrentMoment % 2;
            return a == 0 && NoteManager.Instance.CanHit(a);
        }
        
        /// <summary>
        /// 照準をあわせられる
        /// </summary>
        /// <returns>あわせられる/あわせられない</returns>
        public bool CanAim()
        {
            if (_targets == null) return false;
            
            var a = NoteManager.Instance.CurrentMoment % 2;
            return a == 1 && NoteManager.Instance.CanHit(a);
        }
        
        /// <summary>
        /// レーザーを発射できる
        /// </summary>
        /// <returns>できる/できない</returns>
        public bool CanLaser()
        {
            if (_targets == null) return false;
            
            var a = NoteManager.Instance.CurrentMoment % 2;
            return a == 1 && NoteManager.Instance.CanHit(a);
        }
    }
}