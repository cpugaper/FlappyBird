using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce = 350f;

    private bool isDead; 
    private Rigidbody2D playerRb;
    private Animator playerAnimator; 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDead)
        {
            Flap(); 
        }

        // Rotate the player based on its vertical velocity
        float angle = Mathf.Lerp(-90, 45, (playerRb.velocity.y + 10) / 20);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Flap()
    {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(Vector2.up * upForce);
        playerAnimator.SetTrigger("Flap");
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
        GameManager.Instance.GameOver(); 
    }
}