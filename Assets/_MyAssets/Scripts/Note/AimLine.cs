using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class AimLine: MonoBehaviour
    {
        // 位置Zのキャッシュ
        private Vector3 _cache;

        void Start()
        {
            _cache = transform.position;
        }

        private void FixedUpdate()
        {
            var noteManager = NoteManager.Instance;

            var h = NoteScreen.Height;
            var hh = NoteScreen.HalfHeight;
            var k = NoteScreen.K;
            
            var ny = h * (Time.timeSinceLevelLoad / noteManager.Duration);
            ny *= k;
            ny %= (h * k);
            ny -= hh;
            transform.position = new Vector3(_cache.x, ny, _cache.z);
        }
    }
}