using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer; 

    private RangedAttackData _attackData; 
    private float _currentDuration;
    private Vector2 _direction;
    private bool _isReady;

    private Rigidbody2D _rigidbody; //
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;
    private ProjectileManager _projectileManager;

    public bool fxOnDestory = true;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (!_isReady)
        {
            return;
        }

        _currentDuration += Time.deltaTime;

        if (_currentDuration > _attackData.duration) //내가 지정한 지속시간보다 길어지면 삭제
        {
            DestroyProjectile(transform.position, false);
        }

        _rigidbody.velocity = _direction * _attackData.speed; //플레이어가 바라보고 있는 방향으로 속도를 곱해 전달하기
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   //비트연산을 통해 내가 원하는 Layer와 충돌하면 작동
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestory);
        }
    }


    public void InitializeAttack(Vector2 direction, RangedAttackData attackData, ProjectileManager projectileManager)
    {
        // 3개의 값들 초기화
        _projectileManager = projectileManager;
        _attackData = attackData; 
        _direction = direction;

        UpdateProjectilSprite();//화살의 크기 
        _trailRenderer.Clear(); // TrailRenderer 초기화
        _currentDuration = 0f; //화살 쿨타임
        _spriteRenderer.color = attackData.projectileColor; //내가 설정한 색으로 변경

        transform.right = _direction; //화살의 방향

        _isReady = true;
    }

    private void UpdateProjectilSprite()
    {
        transform.localScale = Vector3.one * _attackData.size;
    }

    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        if (createFx)
        {

        }
        gameObject.SetActive(false);
    }
}
