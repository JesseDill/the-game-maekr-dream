using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    Rigidbody2D rb;
    string direction = "Down";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ShiftGravity("Right");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShiftGravity("Left");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ShiftGravity("Up");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShiftGravity("Down");
        }
    }
    private void FixedUpdate()
    {
        switch (direction)
        {
            case "Up":
                rb.AddForce(new Vector2(0, 9.81f) * rb.gravityScale, ForceMode2D.Force);
                break;
            case "Left":
                rb.AddForce(new Vector2(-9.81f, 0) * rb.gravityScale, ForceMode2D.Force);
                break;
            case "Right":
                rb.AddForce(new Vector2(9.81f, 0) * rb.gravityScale, ForceMode2D.Force);
                break;
            default:
                rb.AddForce(new Vector2(0, -9.81f) * rb.gravityScale, ForceMode2D.Force);
                break;
        }
        //switch (direction)
        //{
        //    case "Up":
        //        Physics2D.gravity = new Vector2(0, 9.81f);
        //        break;
        //    case "Left":
        //        Physics2D.gravity = new Vector2(-9.81f, 0);
        //        break;
        //    case "Right":
        //        Physics2D.gravity = new Vector2(9.81f, 0);
        //        break;
        //    default:
        //        Physics2D.gravity = new Vector2(0, -9.81f);
        //        break;
        //}
    }
    public void ShiftGravity(string direction)
    {
        this.direction = direction;
        UpdateVelocity();
        RotateGameObject();
    }

    private void RotateGameObject()
    {
        switch (direction)
        {
            case "Up":
                transform.eulerAngles = new Vector3(0, 0, 180f);
                break;
            case "Left":
                transform.eulerAngles = new Vector3(0, 0, -90f);
                break;
            case "Right":
                transform.eulerAngles = new Vector3(0, 0, 90f);
                break;
            default:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
        }
    }

    private void UpdateVelocity()
    {
        Vector2 oldVelocity = rb.velocity;
        float magnitude = oldVelocity.magnitude;
        switch (direction)
        {
            case "Up":
                rb.velocity = Vector2.up * magnitude;
                break;
            case "Left":
                rb.velocity = Vector2.left * magnitude;
                break;
            case "Right":
                rb.velocity = Vector2.right * magnitude;
                break;
            default:
                rb.velocity = Vector2.down * magnitude;
                break;
        }
    }
    public bool GravityIsLeftToRight()
    {
        switch (direction)
        {
            case "Left":
                return true;
            case "Right":
                return true;
            default:
                return false;
        }
    }
    public string GetGravityDirection()
    {
        return direction;
    }
}
