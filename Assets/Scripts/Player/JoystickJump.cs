
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickJump : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private PlayerMovement player;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}

	public void OnPointerDown(PointerEventData data)
	{
		if (gameObject.name=="JUMP")
        {
			player.checkJumping(true);
			Debug.Log("JUMP");
		}
			
	}

	public void OnPointerUp(PointerEventData data)
	{
		player.clearJumping();
	}


}
