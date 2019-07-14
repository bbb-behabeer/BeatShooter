using _MyAssets.Scripts.Base;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートを生成
    /// </summary>
    public class NoteSpawn: SingletonMonoBehaviour<NoteSpawn>
    {
        [SerializeField]
        private GameObject _notePrefab;

        /// <summary>
        /// ノートを生成する
        /// </summary>
        /// <param name="moment">生成するタイミング</param>
        public void Spawn(int moment)
        {
            var obj = Instantiate(_notePrefab);
            var y = NoteSetter.Instance.GetYPosWithMoment(moment);
            obj.transform.position = new Vector3(0, y, 0);
        }
    }
}