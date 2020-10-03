using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;

    protected Animator myAnimator;

    protected Vector2 direction;

    private Rigidbody2D myRigidbody;

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        myRigidbody.velocity = direction.normalized * speed;
    }

    private void HandleLayers()
    {
        if (IsMoving)
        {
            ActivateLayer("Walk Layer");

            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
        }
        else
        {
            ActivateLayer("Idle Layer");
        }
    }

    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
    }
}
