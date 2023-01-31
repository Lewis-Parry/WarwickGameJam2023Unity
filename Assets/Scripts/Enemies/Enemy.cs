using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//THIS IS A WORK IN PROGRESS AND IS NOT CURRENTLY BEING USED
public class Enemy : MonoBehaviour
{

    private float speed;

    [SerializeField] private Rigidbody2D rb; //rb for rigid body 2d reference to component
    [SerializeField] private Rigidbody2D playerRb; //rb for rigid body 2d reference to component

    public Transform enemy; //referencing enemy Inspector values
    public Transform player; //referencing player Inspector values
    public Collider2D enemyCollider;
    public Collider2D playerCollider;

    public Enemy(float speed, Rigidbody2D rb, Rigidbody2D playerRb, Transform enemy, Transform player, Collider2D enemyCollider, Collider2D playerCollider) {

        this.rb = rb;
        this.playerRb = playerRb;
        this.speed = speed;
        this.enemy = enemy;
        this.player = player;
        this.enemyCollider = enemyCollider;
        this.playerCollider = playerCollider;
    }

    private bool IsTouchingPlayer()
    {
       return playerCollider.IsTouching(enemyCollider);
    }

}

