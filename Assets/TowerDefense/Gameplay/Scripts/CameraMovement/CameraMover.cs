using System;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Scripts.CameraMovement
{
    public class CameraMover : MonoBehaviour, IInitializable
    {
        [Min(0)][SerializeField] private float _moveLerpSpeed;
        [Min(0)][SerializeField] private float _zoomLerpSpeed;
        [Min(0)][SerializeField] private float _moveSpeed;
        [SerializeField] private InputToMovementHandler _inputToMovementHandler;
        [SerializeField] private Bounds _bounds;
        [Min(0)][SerializeField] private float _zoomSpeed;
        [Min(0)][SerializeField] private float _maxFOV;
        [Min(0)][SerializeField] private float _minFOV;
        
        private Camera _camera;
        private Transform _cameraTransform;
        private Vector3 _targetDirection;
        private Vector3 _newPosition;
        private float _targetZoomInput;
        
        public void Initialize()
        {
            _camera = ServiceLocator.GetService<Camera>();
            _cameraTransform = _camera.transform;
        }

        private void Update()
        {
            CalculateDirection(_inputToMovementHandler.GetMovementInput(), Time.deltaTime);
            Move(_targetDirection, Time.deltaTime);
            CalculateZoom(_inputToMovementHandler.GetZoomInput(), Time.deltaTime);
            Zoom(_targetZoomInput, Time.deltaTime);
        }

        private void CalculateDirection(Vector3 newDirection, float deltaTime)
        {
            _targetDirection = Vector3.Lerp(_targetDirection, newDirection, _moveLerpSpeed * deltaTime);
        }

        private void CalculateZoom(float zoomInput, float deltaTime)
        {
            _targetZoomInput = Mathf.Lerp(_targetZoomInput, -zoomInput, _zoomLerpSpeed * deltaTime);
        }
        
        private void Move(Vector3 moveDirection, float deltaTime)
        {
            _newPosition = _cameraTransform.position + moveDirection * (_moveSpeed * deltaTime);

            _newPosition = new Vector3
            (
                Mathf.Clamp(_newPosition.x, _bounds.NegBound.x, _bounds.PosBound.x),
                _newPosition.y,
                Mathf.Clamp(_newPosition.z, _bounds.NegBound.y, _bounds.PosBound.y)
            );
            
            _cameraTransform.position = _newPosition;
        }

        private void Zoom(float zoomInput, float deltaTime)
        {
            _camera.fieldOfView += zoomInput * _zoomSpeed * deltaTime;
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, _minFOV, _maxFOV);
        }
    }
}
