using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateTest : PlayerBaseState
{
    private float timeSinceJump = 0f;
    public PlayerStateTest(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        
        stateMachine.InputReader.JumpEvent += OnJump;
    }
    public override void Tick(float deltaTime)
    {
        timeSinceJump += Time.deltaTime;
        Debug.Log(timeSinceJump);
    }
    public override void Exit()
    {

        stateMachine.InputReader.JumpEvent -= OnJump;
    }
    private void OnJump()
    {
        stateMachine?.SwitchState(new PlayerStateTest(stateMachine));
        timeSinceJump = 0f;
    }
}
