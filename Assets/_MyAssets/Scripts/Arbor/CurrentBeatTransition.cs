using _MyAssets.Scripts.Note;
using Arbor;
using UnityEditor;
using UnityEngine;

namespace _MyAssets.Scripts.Arbor
{
    // 現在の拍数で遷移する
    [AddComponentMenu("MyArbor")]
    [AddBehaviourMenu("Transition/CurrentBeatTransition")]
    public class CurrentBeatTransition : StateBehaviour
    {
        [SerializeField] private int _measure;
        [SerializeField] private int _moment;
        
		/// <summary>
		/// 遷移先ステート
		/// </summary>
        [SerializeField] private StateLink _NextState = new StateLink();
        
        void Transition()
        {
            Transition(_NextState);
        }

        public override void OnStateUpdate()
        {
            if (_NextState != null)
            {
                var measure = BeatManager.Instance.CurrentMeasure;
                var moment = BeatManager.Instance.CurrentMoment;

                if (measure > _measure && moment > _moment)
                {
                    Transition();
                }
            }
        }
    }
}