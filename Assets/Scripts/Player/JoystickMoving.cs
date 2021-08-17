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
		if (gameObject.name == "Left")
		{
			player.setDirrection(true);
		}
		else if(gameObject.name=="Right")
		{
			player.setDirrection(false);
		}
		else if (gameObject.name == "UpButton")
		{
			ladder.setDirrection(true);
		}
		else
		{
			ladder.setDirrection(false);
		}
	}

	public void OnPointerUp(PointerEventData data)
	{
		player.clearMovong();
		ladder.clearMovong();
	}
}
