using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    #region Inspector Settings

    [Tooltip("The amount of time, in seconds, that it should take the player to reach the peak of their jump arc.")]
    public float jumpTime = 0.75f;
    [Tooltip("The height, in meters, of the player's jump arc.")]
    public float jumpHeight = 3;
    [Tooltip("The horizontal acceleration to use when the player moves left or right.")]
    public float walkAcceleration = 10;
    [Tooltip("How much to scale the acceleration when the player's horizontal input is opposite of their velocity. Higher numbers make the player stop and turn around more quickly.")]
    public float turnAroundMultiplier = 10;
    [Tooltip("The maximum speed of the player, in meters-per-second.")]
    public float maxSpeed = 10;
    #endregion
    #region Additional Properties
    /// <summary>
    /// The standard acceleration to use for gravity. This will be calculated from the jumpTime and jumpHeight fields.
    /// </summary>
    public float gravityAcceleration { get; private set; }
    /// <summary>
    /// The takeoff speed to use as vertical velocity for the player's jump. This will be calculated from jumpTime and jumpHeight fields.
    /// </summary>
    public float jumpVelocity { get; private set; }
    /// <summary>
    /// The velocity of the player in LOCAL SPACE! This is used each frame for Euler physics integration.
    /// </summary>
    private Vector3 velocity = new Vector3();
    /// <summary>
    /// Whether or not the player is moving up on a jump arc (and still holding the jump button).
    /// </summary>
    private bool isJumping = false;
    #endregion

    CharacterController pawn;

    void Start()
    {
        pawn = GetComponent<CharacterController>();
        DeriveJumpValues();
    }
    void OnValidate() {
        DeriveJumpValues();
    }
    /// <summary>
    /// This method calculates the gravity and jumpVelocity to use for jumping.
    /// </summary>
    void DeriveJumpValues() {
        gravityAcceleration = (jumpHeight * 2) / (jumpTime * jumpTime);
        jumpVelocity = gravityAcceleration * jumpTime;
    }

    void Update() {
        if (PauseMenu.isPaused) return;
        DoVerticalMovement();
        DoHorizontalMovement();
        MoveCharacter();
    }

    private void MoveCharacter() {
        // convert velocity from local-space to world-space:
        Vector3 deltaMove = Vector3.up * velocity.y + transform.right * velocity.x;

        // move the CharacterController:
        CollisionFlags flags = pawn.Move(deltaMove * Time.deltaTime);

        if((flags & CollisionFlags.Sides) != 0) {
            velocity.x = 0;
        }
        if ((flags & CollisionFlags.Above) != 0 && velocity.y > 0) {
            velocity.y = 0;
        }
    }

    private void DoHorizontalMovement() {
        float axisH = Input.GetAxisRaw("Horizontal");

        if (axisH == 0) {
            DecelerateX(walkAcceleration);
        } else {
            bool isMovingInDirectionOfInput = (velocity.x <= 0) == (axisH <= 0);
            // if the player pushes the opposite direction from how they're moving, the player turns around quicker!
            float scaleAcceleration = (!isMovingInDirectionOfInput) ? turnAroundMultiplier : 1;

            // only accelerate if we're moving below the maxSpeed
            // OR if we're trying to move in the opposite direction
            if(!isMovingInDirectionOfInput || Mathf.Abs(velocity.x) < maxSpeed) {
                AccelerateX(axisH * walkAcceleration * scaleAcceleration);
            }

        }
    }

    private void DoVerticalMovement() {
        if (pawn.isGrounded) velocity.y = 0;
        if (velocity.y < 0) isJumping = false;
        if (!Input.GetButton("Jump")) isJumping = false;

        float gravMultiplier = isJumping ? 0.8f : 1.5f;

        // apply gravity:
        velocity.y -= gravityAcceleration * Time.deltaTime * gravMultiplier;
        if (Input.GetButtonDown("Jump") && pawn.isGrounded) {
            velocity.y = jumpVelocity;
            isJumping = true;
        }
    }
    /// <summary>
    /// This method accelerates the horizontal speed of the object.
    /// </summary>
    /// <param name="amount">The value of horizontal acceleration.</param>
    protected void AccelerateX(float amount) {
        velocity.x += amount * Time.deltaTime;
    }
    /// <summary>
    /// This method decelerates the horizontal speed of the object.
    /// </summary>
    /// <param name="amount">How much decelerating-force to apply.</param>
    protected void DecelerateX(float amount) {
        // slow down the player
        if (velocity.x > 0) // moving right...
        {
            AccelerateX(-amount);
            if (velocity.x < 0) velocity.x = 0;
        }
        if (velocity.x < 0) // moving left...
        {
            AccelerateX(amount);
            if (velocity.x > 0) velocity.x = 0;
        }
    }

    public void ApplyForce2D(Vector3 forceVector) {
        velocity.x += forceVector.x;
        velocity.y += forceVector.y;
    }
}
