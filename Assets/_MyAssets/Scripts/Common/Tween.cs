using System.Threading.Tasks;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    /// <summary>
    /// Tweenクラス
    /// </summary>
    public class Tween
    {
        /// <summary>
        /// ワールド座標で移動させる
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration">秒</param>
        /// <returns></returns>
        public static async Task TweenPosition(Transform transform, Vector3 to, float duration)
        {
            var current = 0f;
            var from = transform.position;

            while (current < duration)
            {
                var pos = Vector3.Lerp(from, to, current / duration);
                transform.position = pos;
                current += Time.deltaTime;
            }

            transform.position = to;

        }
    }
}