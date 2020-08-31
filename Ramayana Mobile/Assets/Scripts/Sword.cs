using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private Character parent;
	private bool attackPlayer;

	public int damage = 10;

	void Start () {
		if (transform.parent.GetComponent<Character> () == null) {
			parent = transform.parent.parent.GetComponent<Character> ();
		} else {
			parent = transform.parent.GetComponent<Character> ();
		}
		attackPlayer = parent is Enemy;
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Character target = collider.gameObject.GetComponent <Character>();
		if (parent.IsAttacking () && target != null && (attackPlayer ? target is Player : target is Enemy)) {
			target.Hit (damage, GetComponent<Collider2D>().bounds.center);
		}
	}
}
