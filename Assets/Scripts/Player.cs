using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Stat health;

    private float initHealth = 100.0f;

    [SerializeField]
    private Stat mana;

    private float initMana = 50.0f;

    [SerializeField]
    private Stat experience;

    private float initExperience = 100.0f;

    protected override void Start()
    {
        health.Initialize(initHealth, initHealth);

        mana.Initialize(initMana, initMana);

        experience.Initialize(initExperience, initExperience);

        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();

        base.Update();
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.Z))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Attack()
    {
        myAnimator.SetTrigger("ope");
    }
}
