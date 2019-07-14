using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class Pod: MonoBehaviour
    {
        [SerializeField]
        private Laser _laser;
        [SerializeField]
        private Sight _sight;

        // private bool _aimed;

        private Note _target;

        public Note Target => _target;

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
        public bool CanShot()
        {
            var noteManager = NoteManager.Instance;
            return noteManager.CanHit(noteManager.Beat);
        }

        /// <summary>
        /// ショットする
        /// </summary>
        public void Shot()
        {
            // Shot内で
            // レーザーを生成する
            //Instantiate(_laser).transform.position = transform.position;
            _laser.Shot();
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
            _sight.SetTarget(t);
            _laser.SetTarget(t);
            //_aimed = true;
            _target = t;
        }
    }
}