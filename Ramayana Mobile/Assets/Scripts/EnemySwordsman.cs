using UnityEngine;
using System.Collections;

public class EnemySwordsman : Enemy {

	public float range = 1f;

	private bool attacking = false;
	
	protected override void HandleAttack() {
		if (!sleeping) {
			attacking = (Player.Nearest(transform).HorDist(transform) <= range);
		}
	}

	public override bool IsAttacking() {
		return !IsDead() && attacking;
	}

}

