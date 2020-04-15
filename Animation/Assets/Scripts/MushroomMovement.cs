using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody;

    [SerializeField]
    float speed = 2f;


    Vector2 direction = new Vector2(1, 0);


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(rigidbody.position +
            direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Floor"))
        {
            direction *= -1;
            Debug.Log("Cilloded");
        }
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
