using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Accusation : MonoBehaviour
{

    public GameObject inspecteur;
    public GameObject matelot1;
    public GameObject matelot2;
    public GameObject longueVue;
    public DialogueTrigger inspecteurDial;
    public DialogueTrigger pierreDial;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(accusation());
        }

    }

    IEnumerator accusation()
    {
        /*BLOCAGE DU PERSONNAGE*/
        inspecteur.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        inspecteur.GetComponent<PlayerController>().LockMoves();
        inspecteur.GetComponent<Pathfinding.AILerp>().enabled = true;
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().enabled = true;

        GameObject targetObjectInspecteur = new GameObject();
        targetObjectInspecteur.transform.position = new Vector3(-6.42f, -14.14f);
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectInspecteur.transform;

        yield return new WaitForSeconds(1);

        inspecteurDial.SetSentence("Messieurs veuillez me suivre.", false);
        yield return new WaitForSeconds(4);
        inspecteurDial.ResetSentence();

        /*MOUVEMENT VERS PIERRE*/



        GameObject targetObjectMatelot1 = new GameObject();
        GameObject targetObjectMatelot2 = new GameObject();
        targetObjectInspecteur.transform.position = new Vector3(23.95f, -21.97f);
        targetObjectMatelot1.transform.position = new Vector3(25.18f, -24.9f);
        targetObjectMatelot2.transform.position = new Vector3(20.2f, -24.9f);

        matelot1.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectMatelot1.transform;
        matelot2.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectMatelot2.transform;

        /*ACCUSATION*/

        yield return new WaitForSeconds(10);

        inspecteurDial.SetSentence("Pierre, au vu des indices que j'ai pu récolter, je vous accuse du meurtre de votre père.", false);
        yield return new WaitForSeconds(4);
        inspecteurDial.ResetSentence();

        pierreDial.SetSentence("Non, vous faites erreur je vous assure.", false);
        yield return new WaitForSeconds(4);
        pierreDial.ResetSentence();

        inspecteurDial.SetSentence("Messieurs, veuillez fouiller Pierre s'il-vous-plait.", false);
        yield return new WaitForSeconds(4);
        inspecteurDial.ResetSentence();

        longueVue.SetActive(true);
        yield return new WaitForSeconds(2);

        inspecteurDial.SetSentence("La longue vue du Capitaine, surement l'arme du crime.", false);
        yield return new WaitForSeconds(4);
        inspecteurDial.ResetSentence();

        targetObjectInspecteur.transform.position = new Vector3(20.60f, -22.59f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(1);
    }



}
