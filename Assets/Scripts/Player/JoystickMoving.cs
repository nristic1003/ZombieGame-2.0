using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoystickMoving : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private PlayerMovement player;
	private LadderMovement ladder;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerMovement>();
		ladder = GameObject.Find("Player").GetComponent<LadderMovement>();
	}

	public void OnPointerDown(PointerEventData data)
	{

		switch(gameObject.name)
        {
			case "Left": 
				player.setDirrection(true);
			break;
			case "Right":
				player.setDirrection(false);
			break;
			case "UpButton":
				ladder.setDirrection(true);
			break;
			case "DownButton":
				ladder.setDirrection(false);
			break;
			case "JUMP":
				player.checkJumping(true);
			break;

		}

	
	}

	public void OnPointerUp(PointerEventData data)
	{
		player.clearMovong();
		ladder.clearMovong();
	}
}
