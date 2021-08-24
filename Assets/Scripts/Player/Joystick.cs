using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private PlayerAttack player;
	

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerAttack>();

	}

	public void OnPointerDown(PointerEventData data)
	{
		if (gameObject.name == "Gun")
		{
			player.setAttack(true);
		}
		else
		{
			player.setAttack(false);
		}
	}

	public void OnPointerUp(PointerEventData data)
	{
		player.clearAttack();
	}
}
