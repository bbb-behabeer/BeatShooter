using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// コントローラーのUI
    /// </summary>
    public class ControllerUi : MonoBehaviour
    {
        [SerializeField] private Sprite _canShotSprite;
        [SerializeField] private Sprite _canLaserSprite;

        private SpriteRenderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            if (NoteManager.Instance.CanShot())
                _renderer.sprite = _canShotSprite;
            else if (NoteManager.Instance.CanLaser())
                _renderer.sprite = _canLaserSprite;
            else
                _renderer.sprite = null;
        }
    }
}