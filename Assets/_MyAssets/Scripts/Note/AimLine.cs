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

            var ny = NoteSetter.Instance.GetYPos();

            transform.position = new Vector3(_cache.x, ny, _cache.z);
        }
    }
}