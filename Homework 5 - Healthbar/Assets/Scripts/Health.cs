using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour {

	public event Action OnTakeDamage;

	[SerializeField]
	private int health = 100;

	private Animator animator;
	public GameObject cross;

	void Start() {
		animator = GetComponent<Animator>();
	}

	public void SpawnCross() {
		Vector2 spawnPosition = new Vector2 {
			x = transform.position.x,
			y = -0.1f
		};
		Instantiate(cross, spawnPosition, Quaternion.identity);
	}

	public void Die() {
		Destroy(gameObject);
	}

	public void TakeDamage() {
		int damage = 10;
		health = Max(health - damage, 0);
		animator.SetInteger("Health", health);
		animator.SetTrigger("TookDamage");

		OnTakeDamage?.Invoke();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.parent != transform
			&& collision.gameObject.CompareTag("Hitbox")) {

			TakeDamage();
		}
	}
}
