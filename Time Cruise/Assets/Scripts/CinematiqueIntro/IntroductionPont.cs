using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IntroductionPont : MonoBehaviour
{
    public UnityEvent Speech;
    public GameObject inspecteur;
    public GameObject matelot;
    public GameObject Paul;
    public GameObject blackScreen;
    public GameObject mur;
    public DialogueTrigger matelotDial;
    public DialogueTrigger paulDial;
    public Sprite matelotGauche;
    public Sprite matelotDroite;
    public Sprite inspecteurDroite;
    public Sprite inspecteurGauche;
    public Sprite inspecteurBas;
    public Sprite paulGauche;
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
        inspecteur.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        matelot.GetComponent<Animator>().enabled = false;
        inspecteur.GetComponent<Animator>().enabled = false;
        inspecteur.GetComponent<SpriteRenderer>().sprite = inspecteurDroite;
        matelot.GetComponent<SpriteRenderer>().sprite = matelotGauche;

        /*Dialogue début*/

        while (alpha > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha -= 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        matelotDial.SetSentence("Bienvenue à bord inspecteur.");
        yield return new WaitForSeconds(2);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("C'est un plaisir d'avoir quelqu'un d'aussi célèbre que vous à bord.");
        yield return new WaitForSeconds(3);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Si vous voulez bien me suivre, je vais vous accompagner jusqu'à vos quartiers.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();


        /*On marche jusqu'à l'escalier*/

        inspecteur.GetComponent<Animator>().enabled = true;
        matelot.GetComponent<Animator>().enabled = true;

        GameObject targetObjectMatelot = new GameObject();
        GameObject targetObjectInspecteur = new GameObject();


        targetObjectMatelot.transform.position = new Vector3(-12, -120);
        targetObjectInspecteur.transform.position = new Vector3(-12, -120);
        matelot.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectMatelot.transform;
        yield return new WaitForSeconds(0.5f);
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectInspecteur.transform;

        yield return new WaitForSeconds(0.5f);

        while (alpha < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha += 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);


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





        while (alpha > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha -= 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        /*Dialogue présentation chambre*/

        matelotDial.SetSentence("Voici votre chambre, c'est petit mais vous devriez y trouver tout le confort nécessaire.");
        matelot.GetComponent<Animator>().enabled = false;
        inspecteur.GetComponent<Animator>().enabled = false;
        inspecteur.GetComponent<SpriteRenderer>().sprite = inspecteurGauche;
        matelot.GetComponent<SpriteRenderer>().sprite = matelotDroite;
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Si vous voulez il y a une malle ici.");
        matelot.GetComponent<SpriteRenderer>().sprite = matelotGauche;
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Si vous y laissez un objet personne n'y touchera jusqu'à la fin du voyage.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("Bon séjour parmi nous.");
        matelot.GetComponent<SpriteRenderer>().sprite = matelotDroite;
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        /*MAtelot sort de la cabine*/
        matelot.GetComponent<Pathfinding.AILerp>().enabled = true;

        targetObjectMatelot.transform.position = new Vector3(178.5f, -15.7f);
        matelot.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectMatelot.transform;



        /*Quelques jours plus tard*/

        text.text = "Quelques jours plus tard";
        while (alpha < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha += 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            text.color = new Color(1, 1, 1, alpha);
        }
        text.color = new Color(1, 1, 1, 1);
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);

        matelot.GetComponent<Animator>().enabled = true;
        inspecteur.GetComponent<SpriteRenderer>().sprite = inspecteurBas;

        /*Retour du matelot*/

        inspecteur.transform.position = new Vector3(164.5f, -12.0f);
        yield return new WaitForSeconds(4);
        while (alpha > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha -= 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            text.color = new Color(1, 1, 1, alpha);
        }
        text.color = new Color(1, 1, 1, 0);
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        targetObjectMatelot.transform.position = new Vector3(170.8f, -13.5f);

        /*Dialogue au mon dieux c'est horrible*/

        matelotDial.SetSentence("Inspecteur!!!!!!");
        yield return new WaitForSeconds(2);
        matelotDial.ResetSentence();

        matelot.GetComponent<Animator>().enabled = false;
        inspecteur.GetComponent<SpriteRenderer>().sprite = inspecteurDroite;
        matelot.GetComponent<SpriteRenderer>().sprite = matelotGauche;

        matelotDial.SetSentence("Vite Inspecteur, suivait moi dans le bureau du Capitaine.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        matelotDial.SetSentence("C'est une catastrophe.");
        yield return new WaitForSeconds(4);
        matelotDial.ResetSentence();

        /*Téléportation dans le bureau*/

        while (alpha < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha += 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        inspecteur.GetComponent<Animator>().enabled = true;

        matelot.GetComponent<Pathfinding.AILerp>().enabled = false;
        matelot.GetComponent<Pathfinding.AIDestinationSetter>().target = null;
        matelot.transform.position = new Vector3(-32, 2.5f);
        inspecteur.transform.position = new Vector3(-23, 8f);

        matelot.GetComponent<Pathfinding.AILerp>().enabled = true;
        inspecteur.GetComponent<Pathfinding.AILerp>().enabled = true;

        targetObjectMatelot.transform.position = new Vector3(-32, 2.5f);

        targetObjectInspecteur.transform.position = new Vector3(-4.3f, 3.33f);

        matelot.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectMatelot.transform;
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectInspecteur.transform;

        yield return new WaitForSeconds(2f);
        matelot.GetComponent<SpriteRenderer>().sprite = matelotDroite;

        while (alpha > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha -= 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        /*Quelqu'un à tué le Capitaine*/
        Paul.GetComponent<Animator>().enabled = false;
        Paul.GetComponent<SpriteRenderer>().sprite = paulGauche;

        yield return new WaitForSeconds(2.5f);
        inspecteur.GetComponent<Animator>().enabled = false;
        inspecteur.GetComponent<SpriteRenderer>().sprite = inspecteurDroite;





        paulDial.SetSentence("Le Capitaine est mort.");
        yield return new WaitForSeconds(4);
        paulDial.ResetSentence();

        paulDial.SetSentence("Mais la situtation est pire que ce que vous pensez.");
        yield return new WaitForSeconds(4);
        paulDial.ResetSentence();

        paulDial.SetSentence("Le Capitaine est le seul à savoir où il a cachée les clefs du bateau.");
        yield return new WaitForSeconds(4);
        paulDial.ResetSentence();

        paulDial.SetSentence("Si vous ne nous aidez pas nous allons tous mourrir en s'écrasant sur les côtes.");
        yield return new WaitForSeconds(4);
        paulDial.ResetSentence();

        paulDial.SetSentence("Vous devez inspecter. Ecouter les membres du navire se présenter dehors et chercher les indices dans la pièce.");
        yield return new WaitForSeconds(6);
        paulDial.ResetSentence();

        /*FREEDOM*/

        inspecteur.GetComponent<Animator>().enabled = true;

        inspecteur.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        mur.GetComponent<BoxCollider2D>().enabled = true;

        inspecteur.GetComponent<PlayerController>().UnlockMoves();
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().enabled = false;
        inspecteur.GetComponent<Pathfinding.AILerp>().enabled = false;

        Speech.Invoke();
    }



}
