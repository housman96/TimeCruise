using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionPont : MonoBehaviour
{
    public GameObject inspecteur;
    public GameObject matelot;
    public GameObject blackScreen;
    public Vector3 target;
    public DialogueTrigger matelotDial;
    public Text text;
    private float alpha = 1.0f;

    void Start()
    {
        inspecteur.GetComponent<PlayerController>().LockMoves();
        StartDialogue();
    }

    public void StartDialogue()
    {
        StartCoroutine(dialogueWelcome());
    }

    public IEnumerator dialogueWelcome()
    {
        /*Dialogue début*/

        while (alpha > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha -= 0.02f;
            blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

        matelotDial.SetSentence("Bienvenu à bord Inspecteur.");
        yield return new WaitForSeconds(2);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("C'est un plaisir d'avoir quelqu'un d'aussi célébre que vous à bord.");
        yield return new WaitForSeconds(3);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Si vous voulez bien me suivre, je vais vous accompagner jusqu'à vos quartiers.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();


        /*On marche jusqu'à l'escalier*/

        GameObject targetObjectMatelot = new GameObject();
        GameObject targetObjectInspecteur = new GameObject();


        targetObjectMatelot.transform.position = new Vector3(target.x, target.y, target.z);
        targetObjectInspecteur.transform.position = new Vector3(target.x, target.y, target.z);
        matelot.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectMatelot.transform;
        yield return new WaitForSeconds(0.5f);
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectInspecteur.transform;

        yield return new WaitForSeconds(0.5f);

        while (alpha < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha += 0.02f;
            blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);


        /*Téléportation*/

        targetObjectMatelot.transform.position = new Vector3(matelot.transform.position.x, matelot.transform.position.y);
        targetObjectInspecteur.transform.position = new Vector3(inspecteur.transform.position.x, inspecteur.transform.position.y);

        yield return new WaitForSeconds(1.0f);

        matelot.GetComponent<Pathfinding.AILerp>().enabled = false;
        inspecteur.GetComponent<Pathfinding.AILerp>().enabled = false;

        matelot.GetComponent<Pathfinding.AIDestinationSetter>().target = null;
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = null;


        matelot.transform.position = new Vector3(167, -13.5f);
        inspecteur.transform.position = new Vector3(170.8f, -13.5f);

        matelot.GetComponent<BoxCollider2D>().enabled = false;
        matelot.GetComponent<BoxCollider2D>().enabled = true;

        while (alpha > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha -= 0.02f;
            blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

        /*Dialogue présentation chambre*/

        matelotDial.SetSentence("Voici votre chambre, c'est petit mais vous devriez y trouver tout le confort nécessaire.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Si vous voulez il y a une malle ici.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Si vous y laissez un objet personne n'y touchera jusqu'à la fin du voyage.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Bon séjour parmis nous.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        /*MAtelot sort de la cabine*/
        matelot.GetComponent<Pathfinding.AILerp>().enabled = true;

        targetObjectMatelot.transform.position = new Vector3(178.5f, -15.7f);
        matelot.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectMatelot.transform;


        /*Quelques jours plus tard*/
        while (alpha < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha += 0.02f;
            blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);
            text.color = new Color(1, 1, 1, alpha);
        }
        text.color = new Color(1, 1, 1, 1);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);

        /*Retour du matelot*/

        inspecteur.transform.position = new Vector3(164.5f, -12.0f);
        yield return new WaitForSeconds(4);
        while (alpha > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha -= 0.02f;
            blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);
            text.color = new Color(1, 1, 1, alpha);
        }
        text.color = new Color(1, 1, 1, 0);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

        targetObjectMatelot.transform.position = new Vector3(170.8f, -13.5f);

        /*Dialogue au mon dieux c'est horrible*/
        matelotDial.SetSentence("Inspecteur!!!!!!");
        yield return new WaitForSeconds(2);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Vite Inspecteur, suivait moi dans le bureau du Capitaine.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("C'est une catastrophe.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();
    }


}
