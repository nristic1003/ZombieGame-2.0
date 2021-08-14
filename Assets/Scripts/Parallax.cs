using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Vector2 parrallaxEffect;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    [SerializeField]
    private bool inifiniteHorizontal, inifinteVertical;

    private float textureUnitSizeX;

    private float textureUnitSizeY;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit ;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("dada");
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parrallaxEffect.x, deltaMovement.y * parrallaxEffect.y);
        lastCameraPosition = cameraTransform.position;

        if(inifiniteHorizontal)
        if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >=textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }

        if(inifinteVertical)
        if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
        {
            float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(cameraTransform.position.x  , transform.position.y + offsetPositionY) ;
        }
    }
}
