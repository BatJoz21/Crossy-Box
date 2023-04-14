using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Duck : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float moveDuration;
    [SerializeField, Range(0, 1)] float jumpHeight;

    void Update()
    {
        if (DOTween.IsTweening(transform))
        {
            return;
        }
        Vector3 dir = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir += Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir += Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir += Vector3.right;
        }

        if (dir == Vector3.zero)
        {
            return;
        }

        Move(dir);
    }

    public void Move(Vector3 dir)
    {
        transform.DOJump(transform.position + dir, jumpHeight, 1, moveDuration);

        transform.forward = dir;
    }
}
