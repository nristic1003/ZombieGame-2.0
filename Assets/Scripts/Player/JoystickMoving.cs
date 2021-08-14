using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoystickMoving : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private PlayerWalk player;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerWalk>();
	}

	public void OnPointerDown(PointerEventData data)
	{
		if (gameObject.name == "Left")
		{
			player.setDirrection(true);
		}
		else
		{
			player.setDirrection(false);
		}
	}

	public void OnPointerUp(PointerEventData data)
	{
		player.clearMovong();
	}
}
