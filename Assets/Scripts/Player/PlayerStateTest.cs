using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateTest : PlayerBaseState
{
    private float timeToSwitch = 5f;
    public PlayerStateTest(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        Debug.Log("Enter");
    }
    public override void Tick(float deltaTime)
    {
        timeToSwitch -= Time.deltaTime;
        Debug.Log(timeToSwitch);
        if (timeToSwitch <= 0f)
        {
            stateMachine.SwitchState(new PlayerStateTest(stateMachine));
            timeToSwitch = 5f;
        }

    }
    public override void Exit()
    {
        Debug.Log("Exit");
    }
}
