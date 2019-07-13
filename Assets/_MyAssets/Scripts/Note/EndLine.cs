using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class EndLine: MonoBehaviour
    {
        // 位置Zのキャッシュ
        //private Vector3 _cache;

        [SerializeField] private int _moment = 0;

        void Start()
        {
            var _cache = transform.position;
        
            var noteManager = NoteManager.Instance;

            var h = NoteScreen.Height;
            var hh = NoteScreen.HalfHeight;
            var k = NoteScreen.K;
            
            var ny = ((float)_moment / (float)noteManager.Beat) * h;
            ny *= k;
            
            transform.position = new Vector3(_cache.x, ny, _cache.z);
        }
    }
}