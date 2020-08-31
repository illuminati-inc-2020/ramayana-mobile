using UnityEngine;
using System.Collections;

public abstract class Trigger : MonoBehaviour {

	public string type;
	public bool affectPlayer = true;
	public bool affectEnemy = true;

	public const string JUMP_TRIGGER = "JumpTrigger";

	public Trigger(string type) {
		this.type = type;
	}

}
