using UnityEngine;

namespace CaseSimulator.Gameplay
{
    public class LoopBackground : MonoBehaviour
    {
        [SerializeField] private Material _bgMaterial;
        [SerializeField] private float _xSpeed;
        [SerializeField] private float _ySpeed;
        private Vector2 _offset;

        private void Update()
        {
            _offset = new Vector2(_offset.x + _xSpeed * Time.deltaTime, _offset.y + _ySpeed * Time.deltaTime);
            _bgMaterial.mainTextureOffset = _offset;
        }

        private void OnApplicationQuit()
        {
            _bgMaterial.mainTextureOffset = Vector2.zero;
        }
    }
}