using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEngine.Rendering.DebugUI.Table;

public class EndingDisplayer1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool DEBUGMODE;
    
    public TextMeshProUGUI titleTMP;
    public TextMeshProUGUI articleTMP;

    public bool ticket, files, connections, id = false;

    String ENTER = "\n\n\t";

    String title = "";
    String article = "";

    //titles && base success
    String freeTitle = "HUNT FOR SEATTLE KILLER CONTINUES";
    String namedTitle = "SUSPECT NAMED IN HUNT FOR SEATTLE KILLER";
    String caughtTitle = "SUSPECT APPREHENDED IN HUNT FOR SEATTLE KILLER";
    String guiltyTitle = "SUSPECT FOUND GUILTY IN SEATTLE MURDER CASE";

    bool free, named, caught, guilty = false;

    //hooks
    String opening = "Police have released new information this morning regarding the death, now officially declared a murder, of Secretary of the Navy Richard Funderburg earlier this week in the Seattle area. The Secretary’s body was discovered early on the morning of the 16th, floating in an inlet of Puget Sound, and though details were not initially released regarding the cause of death, the Seattle Police Department announced this morning that they are considering the case to be a homicide. ";

    String hookConnections = "Local connections of Seagram’s have claimed that Seagram said they were going away on emergency family business. ";

    String freeHook = "Though a witness provided a description of a suspicious figure moving towards the inlet with a wagon on the night of the murder, there was not enough information for police to name or detain any suspects. ";

    String freeHookNoCon = "In local news, Seattle native Robin Seagram has been reported missing and has not been seen since the day after the murder. Police are cautioning against rumors of a potential serial killer, as no links have been found between Seagram and Funderburg, but the disappearance has heightened tensions in the local area. ";

    String namedHook = "They have also named a suspect: 27-year-old Robin Seagram, who disappeared the day after the murder took place. Upon investigation of Seagram’s place of residence, police found and confiscated a personal computer which contained files and communications they believed could be tied to the case. Whether these are clues or coincidence has yet to be determined. ";

    String namedHookNoID = "Officials at the Bremerton Ferry Terminal say that Seagram did pass through the terminal that day. ";

    String caughtHook = "They have also taken in a suspect: 27-year-old Robin Seagram, who reportedly matched a description given by a witness who saw a figure moving towards the inlet with a wagon on the night of the murder. Seagram was apprehended at King Street Station in Seattle and has claimed they were on their way out of the city, despite not having possessed a ticket at the time of their arrest. ";

    String caughtHookID = "The suspect was in possession of a falsified driver’s license at the time of their apprehension, which, though its possession carries a felony charge, has not yet been linked to the murder. ";

    String guiltyHook = "In what looks to be the end of a harrowing saga for Seattle locals, Robin Seagram, 27, pleaded guilty this morning to a charge of first-degree murder in the killing of Secretary of the Navy Richard Funderburg. The original charge of aggravated first-degree murder, which would have carried the potential of capital punishment, was dropped, leaving Seagram with a sentence of life imprisonment. \n\n\t Seagram was apprehended earlier this week at King Street Station in Seattle, where they were on their way out of the city, despite not having possessed a ticket at the time of their arrest. Upon investigation of Seagram’s place of residence, police found and confiscated a personal computer which contained files and communications which have been used as evidence in the case. ";

    String guiltyHookID = "The suspect was also in possession of a falsified driver’s license at the time of their arrest, which carries an additional felony charge. ";

    String marsupialDawn = "Files and messages on Seagram’s personal computer revealed potential ties to an anti-military organization known as “The Order of the Marsupial Dawn,” which has taken credit online for several other incidents this year, including the explosion at the naval construction site in Maine back in August. Though this assassination would match the organization’s pattern of military targets, if they are involved it would mark a clear escalation in both their targets and tactics, as all previous incidents involved no fatalities. ";

    String funderburg = "Funderburg was in the Seattle area, specifically Bremerton, to visit and oversee the construction and expansion at the Puget Sound Naval Shipyard. He had ambitious plans to update the shipyard’s infrastructure and chain of command to accommodate a doubling of personnel and productivity within two years. ";

    String freeFunderburg = "Potential suspects in the case include local opponents to the expansion, as the construction will bring much commotion to local neighborhoods, as well as lower-ranking officers whose positions would have been removed or replaced by changes to the chain of command. While Funderburg has been hailed as a genius of modern military architecture, an anonymous officer stationed at Puget Sound was quoted as saying, “His intense nature has the tendency to turn people away.” The officer declined to be identified for fear of retaliation. ";

    String filesFunderburg = "Aside from ties to Marsupial Dawn, Seagram appears to have no relation to Funderburg or any military projects. ";

    String caughtFunderburg = "No ties have been found between Seagram and Funderburg or any military projects, and though they have not been released, current public evidence does not heavily suggest that they are the culprit. ";

    String funderburg2 = "Without Funderburg’s initiative, it is unlikely that the project at Puget Sound will continue. The role of Secretary of the Navy has yet to be filled. Many congress members have offered public statements of condolence for the Secretary’s family or put forward calls for further justice. \n\n\tThe White House has announced that they will be holding a press conference in the upcoming week to address what the Secretary’s death means for military operations and national security. ";

    //

    private void Start()
    {
        if (!DEBUGMODE) createArticle();
        else
        {
            titleTMP.text = "ENDINGS ARE IN DEBUG MODE!!!";
            articleTMP.text = "Toggle off 'DEBUGMODE' in the editor to take it out of debug mode. \n\n To show articles: check conditions that are met in editor and press space";
        
        }
    }
    private void Update()
    {
        if (DEBUGMODE)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                article = "";
                articleTMP.text = "";
                free = false; named = false; caught = false; guilty = false;
                createArticle();
            }
        }
    }

    void createArticle()
    {


        //titles
        if (ticket && files) { title = freeTitle; free = true; }
        else if (ticket && !files) { title = namedTitle; named = true; }
        else if (!ticket && files) { title = caughtTitle; caught = true; }
        else { title = guiltyTitle; guilty = true; }

        titleTMP.text = title;

        //hooks
        if (guilty)
        {
            article += "\t" + guiltyHook;
            if (connections) article += hookConnections;
            if (id) article += guiltyHookID;
        }

        else
        {
            article += "\t" + opening + ENTER;

            if (free)
            {
                article += freeHook;
                if (!connections) article += ENTER + freeHookNoCon;
            }

            else if (named)
            {
                article += namedHook;
                if (connections) article += hookConnections;
                if (!id) article += namedHookNoID;
            }

            else if (caught)
            {
                article += caughtHook;
                if (connections) article += hookConnections;
                if (id) article += caughtHookID;
            }
        }

        article += ENTER;

        //body
        if (!files) article += marsupialDawn + ENTER;

        article += funderburg + ENTER;

        if (free) article += freeFunderburg;
        else if (caught) article += caughtFunderburg;
        else article += filesFunderburg;

        article += ENTER + funderburg2;

        articleTMP.text = article;
    }
}
