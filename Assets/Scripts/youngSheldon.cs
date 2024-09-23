using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class youngSheldon : MonoBehaviour
{
    float min = .8f;
    float max = 1.2f;

    private int spawncount = 0;

    //when ball touches young sheldon, destroy it and spawn 2 balls at a random ball's location
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 0 && spawncount <=20)
        {
            spawncount += 2;

            GameObject randomBall = Singleton.instance.selectRandomFromList(collision.gameObject);

            while (randomBall.transform.position.x > -.5 && randomBall.transform.position.x < .5  && randomBall.transform.position.y > -.5 && randomBall.transform.position.y < .5)
            {
                randomBall = Singleton.instance.selectRandomFromList(collision.gameObject);
            }

            GameObject NewBall = Instantiate(collision.gameObject, randomBall.transform.position, randomBall.transform.rotation);
            GameObject NewBall2 = Instantiate(collision.gameObject, randomBall.transform.position, randomBall.transform.rotation);

            NewBall.GetComponent<Rigidbody2D>().velocity = randomBall.GetComponent<Rigidbody2D>().velocity * Random.Range(min,max);
            NewBall2.GetComponent<Rigidbody2D>().velocity = randomBall.GetComponent<Rigidbody2D>().velocity * Random.Range(min, max);

            Destroy(collision.gameObject);

            this.GetComponent<AudioSource>().pitch = Singleton.instance.pitch;
            this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip, 1f);
            Singleton.instance.pitch += .0001f;

            spawncount -= 2;

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            this.GetComponent<AudioSource>().mute = !this.GetComponent<AudioSource>().mute;
        }
    }
}
