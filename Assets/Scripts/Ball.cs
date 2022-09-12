using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Vector3 direction;
    [SerializeField]
    float speed;
    [SerializeField]
    float speedPlus;

    public Grounds groundCreator;

    public static bool didItFall;

    public Text scoreText;
    public static int score;
    void Start()
    {
        direction = Vector3.forward;
        didItFall = false;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        if (transform.position.y <= 0.11f)
        {
            didItFall = true;
        }
        if (didItFall)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward; 
            }
            speed = speed + speedPlus * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * Time.deltaTime * speed;
        transform.position += movement;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            score++;
            scoreText.text = score.ToString() + " Cube";
            groundCreator.CreateGround();
            collision.gameObject.AddComponent<Rigidbody>();
            Destroy(collision.gameObject, 2f);
        }
    }
}
