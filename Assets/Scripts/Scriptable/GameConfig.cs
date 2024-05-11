using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [Serializable]
    public class PlayerConfigData
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private LayerMask _groundCheckLayers;
        [SerializeField] private float _jumpTime = 0.1f;
        [SerializeField] private float _jumpPower = 2f;
        [SerializeField] private float _fallMultiplier = .2f;
        [SerializeField] private float _jumpMultiplier = 0.5f;
        [SerializeField] private float _acceleration = 0;
        [Header("Camera")]
        [SerializeField] private float _cameraSmoothTime = 0.25f;
        [SerializeField] private float _xCameraOffset = 0.0f;
        [SerializeField] private float _xCameraOffsetSmooth = 0.0f;

        public float MoveSpeed => _moveSpeed;
        public LayerMask GroundCheckLayers => _groundCheckLayers;
        public float JumpTime => _jumpTime;
        public float JumpPower => _jumpPower;
        public float FallMultiplier => _fallMultiplier;
        public float JumpMultiplier => _jumpMultiplier;
        public float CameraSmoothTime => _cameraSmoothTime;
        public float XCameraOffset => _xCameraOffset;
        public float XCameraOffsetSmooth => _xCameraOffsetSmooth;
        public float Acceleration => _acceleration;
    }

    [SerializeField] private PlayerConfigData _playerConfigData;

    public PlayerConfigData PlayerConfig => _playerConfigData;
}
