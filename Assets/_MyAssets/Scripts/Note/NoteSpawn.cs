using System.Collections.Generic;
using _MyAssets.Scripts.Base;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートを生成
    /// </summary>
    public class NoteSpawn: SingletonMonoBehaviour<NoteSpawn>
    {
        //[SerializeField] private Note _notePrefab;
        //[SerializeField] private NoteUnit _noteUnis;

        /// <summary>
        /// ノートを生成する
        /// </summary>
        /*public Note SpawnNote()
        {
            var obj = Instantiate(_notePrefab);
            //var y = NoteSetter.Instance.GetYPosWithMoment(moment);
            obj.transform.position = transform.position;

            var note = obj.GetComponent<Note>();
            return note;
        }
        
        /// <summary>
        /// ノートユニットを生成する
        /// </summary>
        /// <param name="unit">生成するユニット</param>
        public Note[] SpawnUnit(NoteUnit unit)
        {
            var obj = Instantiate(unit);
            var notes = obj.GetComponentsInChildren<Note>();
            //note.Initialize();
            
            return notes;
        }*/
    }
}