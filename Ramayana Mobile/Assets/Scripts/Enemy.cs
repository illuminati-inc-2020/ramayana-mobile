using UnityEngine;
using System.Collections;

public abstract class Enemy : Character {

	protected virtual void Awake() {
		//random speed
		speed += Random.Range (-1f, 1f);

		//random size
		float scale = Random.Range (0.95f, 1.05f);
		transform.localScale *= scale;
	}

	protected override void Start () {
		base.Start ();
		StartCoroutine ("ManageState");
	}



	//******************************************** Trigger ************************************************

	protected override bool TriggerAffects(Trigger trigger) {
		return trigger.affectEnemy;
	}



	//******************************************** Run ************************************************

	public bool moveTowardsPlayer = true;

	protected override float GetRunVelocity() {
		float newVelocity = 0f;

		//set speed
		if (moveTowardsPlayer) {
			newVelocity = Mathf.Sign (Player.Nearest (transform).transform.position.x - transform.position.x);
		}

		return newVelocity;
	}

	protected override void HandleRun() {
		if (sleeping) {
			return;
		}

		//set direction
		SetFaceDirection (Mathf.Sign (Player.Nearest (transform).transform.position.x - transform.position.x));

		//run
		if (!IsAttacking()) {
			base.HandleRun ();
		}
	}



	//******************************************** Jump ************************************************

	protected override void HandleJump() {
		if (!sleeping && !IsAttacking()) {
			base.HandleJump ();
		}
	}



	//******************************************** Wake up/Destroy ************************************************

	protected const float WAKEUP_DISTANCE = 20f;
	public const float DIE_DISTANCE = 30f;
	public bool sleeping = true;

	IEnumerator ManageState() {
		while (sleeping) {
			if (sleeping && Player.main.HorDist(transform) < WAKEUP_DISTANCE) {
				sleeping = false;
			}
			yield return new WaitForSeconds (0.5f);
		}
		while (gameObject.activeSelf) {
			if (IsDead () && Player.main.HorDist (transform) > DIE_DISTANCE) {
				Destroy (gameObject);
			}
			yield return new WaitForSeconds (0.5f);
		}
	}

}

