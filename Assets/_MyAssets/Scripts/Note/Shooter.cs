using System;
using Arbor;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class Shooter: MonoBehaviour
    {
        [SerializeField]
        private Laser _laser;
        [SerializeField]
        private Sight _sight;

        // private bool _aimed;

        private Note _target;

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
        /// ショットできるか
        /// </summary>
        /// <returns></returns>
        /*public bool CanShotAt(Note t)
        {
            var noteManager = NoteManager.Instance;
            return noteManager.CanHit(t.Moment);
        }*/

        public void Shot()
        {
            // レイキャストで手前のノートを取得
            var hit = Physics2D.Raycast(transform.position, Vector2.up, LayerMask.GetMask("Note"));
            if (hit.collider != null)
            {
                var note = hit.collider.gameObject.GetComponent<Note>();
                ShotAt(note);
            }
        }

        /// <summary>
        /// ショットする
        /// </summary>
        public void ShotAt(Note note)
        {
            // レーザーを生成する
            //var l = Instantiate(_laser).GetComponent<Laser>();
            //l.Initialize(transform.position);
            //l.SetTarget(t);
            note.Explode();
        }
        
        /// <summary>
        /// ショットする
        /// </summary>
        public float LaserAt(Note t)
        {
            // レーザーを生成する
            var l = Instantiate(_laser).GetComponent<Laser>();
            l.Initialize(transform.position);
            l.SetTarget(t);
            return l.Period;
        }

        /// <summary>
        /// エイムする
        /// </summary>
        /// <param name="t">ターゲット</param>
        //public void AimAt(Transform t)
        public void AimAt(Note t)
        {
            // SetTarget内で
            // 照準を生成する
            var s = Instantiate(_sight).GetComponent<Sight>();
            s.SetTarget(t);
        }
    }
}