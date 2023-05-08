using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Duck : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float moveDuration;
    [SerializeField, Range(0, 1)] float jumpHeight;
    [SerializeField] int leftMoveLimit;
    [SerializeField] int rightMoveLimit;
    [SerializeField] int backMoveLimit;

    public UnityEvent<Vector3> OnJumpEnd;
    public UnityEvent<int> OnGetCoin;
    public UnityEvent OnDie;
    public UnityEvent OnMove;
    public UnityEvent HitTree;
    public UnityEvent HitCar;

    private bool isMoveable = false;

    void Update()
    {
        if (isMoveable == false)
        {
            return;
        }
        if (DOTween.IsTweening(transform))
        {
            return;
        }
        Vector3 dir = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir += Vector3.forward;
            OnMove.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir += Vector3.back;
            OnMove.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir += Vector3.left;
            OnMove.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir += Vector3.right;
            OnMove.Invoke();
        }

        if (dir == Vector3.zero)
        {
            return;
        }

        Move(dir);
    }

    public void Move(Vector3 direction)
    {
        var targetPosition = transform.position + direction;

        if (targetPosition.x < leftMoveLimit ||
            targetPosition.x > rightMoveLimit ||
            targetPosition.z < backMoveLimit ||
            Tree.AllPositions.Contains(targetPosition))
        {
            targetPosition = transform.position;
        }

        transform.DOJump(targetPosition, jumpHeight, 1, moveDuration).onComplete = BroadcastPositionOnJumpEnd;

        transform.forward = direction;
    }

    public void SetMoveable(bool var)
    {
        isMoveable = var;
    }

    public void UpdateMoveLimit(int horizontalSize, int backLimit)
    {
        leftMoveLimit = - horizontalSize / 2;
        rightMoveLimit = horizontalSize / 2;
        backMoveLimit = backLimit;
    }

    private void BroadcastPositionOnJumpEnd()
    {
        OnJumpEnd.Invoke(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (isMoveable == false)
            {
                return;
            }
            HitCar.Invoke();
            transform.DOScale(new Vector3(2, 0.1f, 2), 0.2f);

            isMoveable = false;
            Invoke("Die", 1.5f);
        }
        else if (other.CompareTag("Tree"))
        {
            if (isMoveable == false)
            {
                return;
            }
            HitTree.Invoke();
            transform.DOScale(new Vector3(2, 0.1f, 2), 0.2f);

            isMoveable = false;
            Invoke("Die", 1.5f);
        }
        else if (other.CompareTag("Coin"))
        {
            var coin = other.GetComponent<Coin>();
            OnGetCoin.Invoke(coin.Value);
            coin.Collected();
        }
        else if (other.CompareTag("TIE Fighter"))
        {
            if (this.transform != other.transform)
            {
                this.transform.SetParent(other.transform);
                Invoke("Die", 1.5f);
            }
        }
    }

    private void Die()
    {
        OnDie.Invoke();
    }
}
