using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range = 2f;
    [SerializeField] private GameObject enemy;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x + horizontal * speed,
            transform.position.y + vertical * speed, transform.position.z);

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mouseWorldPosition - (Vector2) transform.position;
        Vector2 directionToEnemy = (Vector2) enemy.transform.position - (Vector2) transform.position;
        transform.up = direction;

        var angle = Vector3.Angle(transform.up, enemy.transform.up);
        var angleDirection = Vector3.Angle(transform.up, directionToEnemy);

        if (Input.GetMouseButtonDown(0) && angleDirection <= 15)
        {
            print("Enemy in area for visible");

            if (angle < 45)
            {
                print("Hit in back");
            }
            else if (angle > 45 && angle < 135)
            {
                var side = Vector3.Cross(transform.up, enemy.transform.up);
                if (side.z > 0)
                {
                    print("Hit in the left side");
                }
                else
                {
                    print("Hit in the right side");
                }
            }
            else if (angle > 135)
            {
                print("Hit in front");
            }
        }
    }
}