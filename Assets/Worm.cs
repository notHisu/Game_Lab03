using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    public float speed = 2f;

    private void Start()
    {
        InvokeRepeating("changeDir", 0, 0.5f);
    }

    Vector2 randDir()
    {
        int r = Random.Range(-1, 2);
        return (Random.value < 0.5) ? new Vector2(r,0) : new Vector2(0,r);
    }

    bool isValidDir(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider.gameObject == gameObject);
    }

    void changeDir()
    {
        Vector2 dir = randDir();
        if (isValidDir(dir))
        {
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            GetComponent<Animator>().SetInteger("X", (int)dir.x);
            GetComponent<Animator>().SetInteger("Y", (int)dir.y);
        }
    }

}
