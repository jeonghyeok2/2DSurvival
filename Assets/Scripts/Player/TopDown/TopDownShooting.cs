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
    private Transform _bulletSpawnPoint;
    private ProjectileManager _projectileManager;

    private void Awake()
    {
        _projectileManager = ProjectileManager.instance;
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
        if (_playerChangeWepon.SetItemData() != null && _playerChangeWepon.SetItemData().Type != ItemType.MeleeAttack)
        {
            RangedAttackData rangedAttackData = statusData as RangedAttackData;
            float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel; //발사 각도
            int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot; // 발사 량

            float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;


            for (int i = 0; i < numberOfProjectilesPerShot; i++)
            {
                float angle = minAngle + projectilesAngleSpace * i;
                float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
                angle += randomSpread;
                CreateBullet(rangedAttackData, angle);
            }
        }
    }
    private void CreateBullet(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(_bulletSpawnPoint.position, RotateVector2(_aimDirection, angle), rangedAttackData);
    }
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
