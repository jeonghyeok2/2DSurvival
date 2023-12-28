using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private PlayerChangeWepon _playerChangeWepon;
    private Vector2 _aimDirection = Vector2.right;

    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform _bulletSpawnPoint;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _playerChangeWepon = GetComponent<PlayerChangeWepon>();
    }

    private void Start()
    {
        _controller.OnAttackEvent += Shoot;
        _controller.OnLookEvent += Aim;
    }

    private void Aim(Vector2 aimDirection)
    {
        _aimDirection = aimDirection;
    }

    private void Shoot(StatusData statusData)
    {
        if (_playerChangeWepon.SetItemData().Type != ItemType.MeleeAttack)
        {
            CreateBullet();
        }
    }
    private void CreateBullet()
    {
        Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
    }
}
