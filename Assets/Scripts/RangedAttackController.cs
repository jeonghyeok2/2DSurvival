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

        if (_currentDuration > _attackData.duration) //���� ������ ���ӽð����� ������� ����
        {
            DestroyProjectile(transform.position, false);
        }

        _rigidbody.velocity = _direction * _attackData.speed; //�÷��̾ �ٶ󺸰� �ִ� �������� �ӵ��� ���� �����ϱ�
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   //��Ʈ������ ���� ���� ���ϴ� Layer�� �浹�ϸ� �۵�
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestory);
        }
    }


    public void InitializeAttack(Vector2 direction, RangedAttackData attackData, ProjectileManager projectileManager)
    {
        // 3���� ���� �ʱ�ȭ
        _projectileManager = projectileManager;
        _attackData = attackData; 
        _direction = direction;

        UpdateProjectilSprite();//ȭ���� ũ�� 
        _trailRenderer.Clear(); // TrailRenderer �ʱ�ȭ
        _currentDuration = 0f; //ȭ�� ��Ÿ��
        _spriteRenderer.color = attackData.projectileColor; //���� ������ ������ ����

        transform.right = _direction; //ȭ���� ����

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
