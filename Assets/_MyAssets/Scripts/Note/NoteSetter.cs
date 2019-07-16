using _MyAssets.Scripts.Base;

namespace _MyAssets.Scripts.Note
{
    public class NoteSetter: SingletonMonoBehaviour<NoteSetter>
    {
        /// <summary>
        /// 位置を決める
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public float GetYPosWithMoment(float moment)
        {
            // 位置を計算
            var m =  moment;
            var ny = GetYPosWithTime(m * BeatManager.Instance.DurationPerBeat);

            return ny;
        }
        
        /// <summary>
        /// 時間で位置を決める
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private float GetYPosWithTime(float time)
        {
            var noteScreen = NoteScreen.Instance;
            var noteManager = BeatManager.Instance;
            
            // 縦幅を取得
            var h = noteScreen.Height;
            var k = noteScreen.K;
            
            var t = time / noteManager.Duration;
            
            // 位置を計算
            var ny = h * t * k - noteScreen.Offset;

            return ny;
        }

        /// <summary>
        /// 時間で位置を決める
        /// </summary>
        /// <returns></returns>
        public float GetYPos()
        {
            var noteManager = BeatManager.Instance;
            
            return GetYPosWithTime(noteManager.CurrentTime);
        }
    }
}