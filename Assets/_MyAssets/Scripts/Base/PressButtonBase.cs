using UnityEngine;
using UnityEngine.EventSystems;

namespace _MyAssets.Scripts.Others
{

    public class PressButtonBase : MonoBehaviour
    {
        private Transform _childTransform;
        private Vector3 _cashPosition;
        [SerializeField] private float _offsetY;

        public void Awake()    
        {
            if (transform.childCount != 0) 
            {
                // 子要素があるときは、オフセットに子要素の座標を保存する
                _childTransform = transform.GetChild(0);
                _cashPosition = _childTransform.localPosition;
                //_offsetY = - _cashPosition.y;
            }
        }

        public void SetChildTransformOnPressed()
        {
            if (_childTransform == null) return;

            // 子要素をボタンの高さに追従させる
            _childTransform.localPosition = new Vector2 (
                _cashPosition.x,
                _cashPosition.y + _offsetY
            ); 
        }

        public void SetChildTransformOnReleased()
        {
            // 子要素の座標をもとの高さに戻す
            if (_childTransform == null) return;
            _childTransform.localPosition = _cashPosition;
        }
    }
}