using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Enum type;

    public GameObject vfxTouch;

    public GameObject vfxWrong;

    private Vector2 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Wall"))
        {
            if (collision.GetComponent<Wall>().type == this.type)
            {
                GameObject vfx = Instantiate(vfxTouch, transform.position, Quaternion.identity) as GameObject;
                Destroy(vfx, 1f);

                gameObject.SetActive(false);

                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
                GameManager.Instance.CheckLevelUp();
            }
            else
            {
                GameObject vfx = Instantiate(vfxWrong, transform.position, Quaternion.identity) as GameObject;
                Destroy(vfx, 1f);
                GetComponent<DragAndDrop>()._dragging = false;
                transform.position = startPos;
            }
        }
    }
}
