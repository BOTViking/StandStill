using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PNJRight : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float direction = -1;

    private Animator animator;
    private bool stop;

    private bool noMoney;
    // Start is called before the first frame update
    void Start()
    {
        noMoney = false;
        animator = GetComponent<Animator>();
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Detruire l'objet si il est hors de l'ecran
        if (transform.position.x <= -2f)
        {
            Destroy(this.gameObject);
            return;
        }

        //Deplacement
        Vector3 movement = new Vector3(moveSpeed * -1, 0, 0);
        movement *= Time.deltaTime;
        if (!stop) //Sauf si le pnj est arreté devant le clochard
          transform.Translate(movement);

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && noMoney == false)
        {
            StartCoroutine(giveCoin());
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PNJ")
              Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
 
    }

    IEnumerator giveCoin()
    {
        noMoney = true;
        int rdm;

        //1 chance sur 4 de donner de l'argent
        rdm = Random.Range(1, 100);
        if (rdm <= 25)
        {
            //Temps random avant de s'arreter pour eviter d'avoir tout les pnj au meme endroit
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            stop = true;
            animator.SetTrigger("giveCoin");
            //+1 gold
            GameHandler.instance.addGold(1);

            yield return new WaitForSeconds(0.5f);
        }
        stop = false;
    }
}
