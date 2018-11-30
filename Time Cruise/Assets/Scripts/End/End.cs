using System.Collections;
using UnityEngine;

public class End : MonoBehaviour
{

    public GameObject inspecteur;
    public GameObject capitaine;
    public GameObject pierre;
    public GameObject tapis;
    public GameObject key;
    public DialogueTrigger capitaineDial;
    public DialogueTrigger pierreDial;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(end());
    }

    public IEnumerator end()
    {
        yield return new WaitForSeconds(1);

        /*CACHER SOUS LE TAPIS*/

        GameObject targetObjectCapitaine = new GameObject();
        targetObjectCapitaine.transform.position = new Vector3(-0.24f, 2.1f);
        capitaine.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectCapitaine.transform;

        yield return new WaitForSeconds(1);

        tapis.SetActive(false);
        yield return new WaitForSeconds(1);
        key.SetActive(true);
        yield return new WaitForSeconds(1);
        key.SetActive(false);
        tapis.SetActive(true);

        capitaineDial.SetSentence("Et voilà personne n'ira la chercher ici.");
        yield return new WaitForSeconds(5);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("Ho inspecteur, je ne vous avez pas vu.");
        yield return new WaitForSeconds(5);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("Pouvez vous sortir s'il-vous-plait? Mon fils ne devrait pas tarder.");
        yield return new WaitForSeconds(5);
        capitaineDial.ResetSentence();

        GameObject targetObjectinspecteur = new GameObject();
        targetObjectinspecteur.transform.position = new Vector3(-14.5f, 5.4f);
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectinspecteur.transform;

        GameObject targetObjectPierre = new GameObject();
        targetObjectPierre.transform.position = new Vector3(-1f, 2.1f);
        pierre.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectPierre.transform;

        yield return new WaitForSeconds(3);
        pierreDial.SetSentence("Bonjour Inspecteur.", false);
        yield return new WaitForSeconds(3);
        pierreDial.ResetSentence();

    }

}
