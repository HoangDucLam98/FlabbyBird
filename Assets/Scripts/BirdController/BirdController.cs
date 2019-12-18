using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, dieClip;
    private bool isAlive, didFly;
    
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Flabbing();
    }

    private void _Flabbing()
    {

        if( isAlive ) {
            if( didFly ) {
                didFly = false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speed);
                audioSource.PlayOneShot(flyClip);
            }
        }

        if( rigidbody2D.velocity.y > 0 ) {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, rigidbody2D.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }

        if( rigidbody2D.velocity.y < 0 ) {
            float angel = 0;
            angel = Mathf.Lerp(0, -70, -rigidbody2D.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    public void flyButton()
    {
        didFly = true;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        audioSource.PlayOneShot(dieClip);
        GamePlayController.instance._ShowGameOverPanel();
        if( score > GameManagerController.instance._GetHighScore() ) {
            GameManagerController.instance._SetHighScore(score);
        }
        GamePlayController.instance._SetEndScore(score);
        GamePlayController.instance._SetHighScoreText(GameManagerController.instance._GetHighScore());
        // new WaitForSeconds(2f);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        score++;
        if( GamePlayController.instance != null ) {
            GamePlayController.instance._SetScore(score);
        }
        audioSource.PlayOneShot(pingClip);
    }
}
