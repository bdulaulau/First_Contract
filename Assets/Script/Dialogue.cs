using UnityEngine;

[System.Serializable] 
public class Dialogue 
{

    public string name; //nom du png 

    [TextArea(3, 10)] //zone de texte qui mets mieux en forme, 3 et 10 taille dans l'inspector
    public string[] sentences; //pour autoriser les png � dire plusieurs choses, en faisant une array


}
