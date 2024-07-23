using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected PlayerStat _playerStat;

    protected List<IngameItemController> _ingameItemList = new List<IngameItemController>();

    protected PlayerState _playerState = PlayerState.None;

    protected int _id;

    public float _scaleDuration = 0.6f;

    public Vector3 _targetScale;

    private Vector3 _initialScale;

    private Coroutine _scaleCoroutine;

    public int Id { get { return _id; } }

    // TODO
    public virtual void Init(int id)
    {
        _id = id;

        _playerStat = GetComponent<PlayerStat>();
        _playerState = PlayerState.Move;

        _initialScale = transform.localScale;
        _targetScale = _initialScale * 1.1f;
        _scaleCoroutine = StartCoroutine(CoScaleRoutine());
    }

    protected virtual void OnUpdate()
    {
        switch (_playerState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Move:
                UpdateMove();
                break;
        }
    }

    protected virtual void UpdateMove()
    {
        if (_playerState != PlayerState.Move)
            return;

        // TODO - 애니메이션으로 수정
        transform.position += Vector3.right * Time.deltaTime * _playerStat.MoveSpeed;
    }

    // TODO - 애니메이션 들어오면 사라질 코드
    IEnumerator CoScaleRoutine()
    {
        while (true)
        {
            yield return StartCoroutine(CoScaleToTargetScale(_targetScale));
            yield return StartCoroutine(CoScaleToTargetScale(_initialScale));
        }
    }

    IEnumerator CoScaleToTargetScale(Vector3 target)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < _scaleDuration)
        {
            transform.localScale = Vector3.Lerp(startScale, target, (elapsedTime / _scaleDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = target;
    }
}
