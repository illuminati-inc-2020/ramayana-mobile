using UnityEngine;
using System.Collections;

public class JumpTrigger : Trigger {

	public float force = 0.2f;
	public float direction = 1f;

	public JumpTrigger(): base(Trigger.JUMP_TRIGGER) {}

}
