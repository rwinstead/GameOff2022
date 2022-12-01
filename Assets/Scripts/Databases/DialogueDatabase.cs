using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDatabase : MonoBehaviour
{

    public List<DialoguePopup> dialogueDb = new List<DialoguePopup>();

    private DialoguePopup defaultPopup; 

    // Start is called before the first frame update
    //public DialoguePopup(int popupID, string characterSpeaking, string message, string portraitSprite, string portraitLeftSide = [Left,Right,None])
    void Awake()
    {
        defaultPopup = new DialoguePopup(0,"ERROR","Unable to retrieve dialogue message.  Check your message ID.","","None");

        dialogueDb.Add(new DialoguePopup(1,"COOK","Hello your highness! Are you hungry?\nStew is almost ready!","Cook1","Right"));
        dialogueDb.Add(new DialoguePopup(2,"COOK","Oh that creep is back?\nQuick, run to the other room! I'll distract him!","Cook1","Left"));
        dialogueDb.Add(new DialoguePopup(3,"GUARD","Oy! I'm a guard! Bring me pie!","Guard1","Left"));
        dialogueDb.Add(new DialoguePopup(4,"","This door is locked and requires a key of the same color to open","","None"));

        //Intro Scene
        dialogueDb.Add(new DialoguePopup(5, "Morel", "What a lovely feast, Princess Plum.\nYou've really out done yourself this time.", "Morel", "Left"));
        dialogueDb.Add(new DialoguePopup(6, "Morel", "Now who is that strapping lad ente-", "Morel", "Left"));
        dialogueDb.Add(new DialoguePopup(7, "Marco", "M'lady! Letsa go-", "Marco", "Left"));
        dialogueDb.Add(new DialoguePopup(8, "Princess Plum", "Oh God, oh no.\nIt's that weird plumber who fixed my sink last week.", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(9, "Princess Plum", "He won't leave me alone, and he keeps muttering weird nonsense like 'Wahoo!'.", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(10, "Morel", "Quickly your highness, escape through the kitchens!\nI'll tell him he has the wrong castle.", "Morel", "Left"));
        dialogueDb.Add(new DialoguePopup(11, "Morel", "Not sure if he'll buy it for long, though. Now GO!", "Morel", "Left"));

        //Picked Up Pie Ingredients
        dialogueDb.Add(new DialoguePopup(20, "Princess Plum", "Perfect! I should get these ingredients back to the cooks.", "Princess", "Right"));
        //Triggering Secret Door
        dialogueDb.Add(new DialoguePopup(21, "", "You hear something click in the armor and a deep rumbling in the room.  Perhaps a door was opened?", "", "None"));
        //Opened Chest with Wardrobe Key
        dialogueDb.Add(new DialoguePopup(22, "", "You found the blue key! Perhaps it opens the blue door?", "", "None"));
        //Need Parisol to Leave
        dialogueDb.Add(new DialoguePopup(23, "Princess Plum", "Oh I almost forgot! It's raining, I can't leave without my parisol! I left it in the wardrobe.", "Princess", "Right"));

        dialogueDb.Add(new DialoguePopup(90,"Cook 1","Hello your highness! Are you hungry?\nStew is almost ready!","Cook1","Right"));
        dialogueDb.Add(new DialoguePopup(91, "Princess Plum", "Not right now thanks! I'm trying to hide from this guy! He's right behind me!", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(92,"Cook 2","Oh don't you worry princess!\nRun to the other room! We'll keep him busy","Cook2","Left"));

        //Guards asking for Pie
        dialogueDb.Add(new DialoguePopup(100, "Guard 1", "Sorry Princess, You're not allowed in here.", "Guard1", "Left"));
        dialogueDb.Add(new DialoguePopup(101, "Princess Plum", "But I have to get through! He's right behind me!", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(102, "Guard 1", "Sorry, but orders are orders.", "Guard1", "Left"));
        dialogueDb.Add(new DialoguePopup(103, "Guard 2", "Unless...", "Guard2", "Left"));
        dialogueDb.Add(new DialoguePopup(104, "Princess Plum", "Unless?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(105, "Guard 2", "I guess we could go on break a bit early, look the other way for a minute...", "Guard2", "Left"));
        dialogueDb.Add(new DialoguePopup(106, "Guard 1", "But we'd need a good reason.  A real good reason.", "Guard1", "Left"));
        dialogueDb.Add(new DialoguePopup(107, "Princess Plum", "Like helping your boss' daughter hide from a plumber?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(108, "Guard 2", "Nah that wouldn't do it.", "Guard2", "Left"));
        dialogueDb.Add(new DialoguePopup(109, "Princess Plum", "Well what would then?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(110, "Guard 1", "A dire emergency of some sort", "Guard1", "Left"));
        dialogueDb.Add(new DialoguePopup(111, "Princess Plum", "Such as?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(112, "Guard 2", "Such as a pie.", "Guard2", "Left"));
        dialogueDb.Add(new DialoguePopup(113, "Princess Plum", "...", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(114, "Princess Plum", "A PIE ?!?!?!?!?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(115, "Princess Plum", "DO YOU NOT UNDERSTAND THE URGENCY HERE?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(116, "Guard 2", "Yeah, I reckon a piping hot blueberry pie would qualify as an emergency.", "Guard1", "Left"));
        dialogueDb.Add(new DialoguePopup(117, "Princess Plum", "I'll have you fired for this.", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(118, "Guard 1", "Sorry princess, we're unionized.", "Guard1", "Left"));
        dialogueDb.Add(new DialoguePopup(119, "Princess Plum", "*sigh*", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(120, "Princess Plum", "Fine.  I'll get your pie.  The cooks probably have an extra.", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(121, "Guard 1", "Much obliged ma\'am.", "Guard1", "Left"));

        //Talking to the guards before getting pie
        dialogueDb.Add(new DialoguePopup(125, "Guard 2", "By your empty hands and lack of divine aroma it appears there is not currently a pie related emergency.", "Guard2", "Left"));
        dialogueDb.Add(new DialoguePopup(126, "Princess Plum", "Yeah, yeah I'm working on it. You'll get your pie.", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(127, "Guard 1", "We anxiously away your return, princess.", "Guard1", "Left"));

        //Talking to cooks about needing pie
        dialogueDb.Add(new DialoguePopup(130, "Princess Plum", "Quick! I need a blueberry pie!", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(131, "Cook 1", "A pie? At this hour?", "Cook1", "Left"));
        dialogueDb.Add(new DialoguePopup(132, "Cook 2", "Weren't you trying to hide from that young man?", "Cook2", "Left"));
        dialogueDb.Add(new DialoguePopup(133, "Princess Plum", "Yes I'm trying! Thats why I need the pie!", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(134, "Cook 2", "I'll never understand you young people.", "Cook2", "Left"));
        dialogueDb.Add(new DialoguePopup(135, "Cook 1", "We don't have any ready, but I'd be happy to make you one", "Cook1", "Left"));
        dialogueDb.Add(new DialoguePopup(136, "Cook 2", "I can't leave this stew so you'll have to go to the pantry to get the ingredients.  Here's the key.", "Cook2", "Left"));
        dialogueDb.Add(new DialoguePopup(137, "Princess Plum", "Nothing is ever simple is it?", "Princess", "Right"));

        //Talking to cooks before getting ingredients
        dialogueDb.Add(new DialoguePopup(140, "Cook 1", "Have you found those ingredients in the pantry yet?", "Cook1", "Left"));
        dialogueDb.Add(new DialoguePopup(141, "Princess Plum", "Not yet I'm about to head that way!", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(142, "Cook 1", "Okay princesss just bring them to me when you get them.", "Cook1", "Left"));
        dialogueDb.Add(new DialoguePopup(143, "Princess Plum", "Will do!", "Princess", "Right"));

        //Talking to cooks after getting ingredients
        dialogueDb.Add(new DialoguePopup(151, "Cook 1", "That was quick! I'm glad you found the ingredients, that pantry is a mess!", "Cook1", "Left"));
        dialogueDb.Add(new DialoguePopup(152, "Princess Plum", "Well thankfully someone had laid all the ingredients out neatly on the table!", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(153, "Cook 2", "That's the emergency pie stash! See babe, I told you that would come in handy!  Otherwise it takes forever to rummage around all those cabinents.", "Cook2", "Left"));
        dialogueDb.Add(new DialoguePopup(154, "Cook 1", "Yes dear, you're a genius.", "Cook1", "Left"));
        dialogueDb.Add(new DialoguePopup(155, "Cook 2", ":D", "Cook2", "Left"));
        dialogueDb.Add(new DialoguePopup(156, "Princess Plum", "If its an emergency stash why don't you keep it in the kitchen?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(157, "Cook 2", "...", "Cook2", "Left"));
        dialogueDb.Add(new DialoguePopup(158, "Cook 2", "That would make more sense wouldn't it?", "Cook2", "Left"));
        dialogueDb.Add(new DialoguePopup(159, "Cook 1", "Shhhh don't think about it too much it breaks the immersion.", "Cook1", "Left"));
        dialogueDb.Add(new DialoguePopup(160, "Princess Plum", "Huh?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(161, "Cook 1", "Oh look your pie is ready! Here you go!", "Cook1", "Left"));
        dialogueDb.Add(new DialoguePopup(162, "Princess Plum", "Thanks! You guys are lifesavers!", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(163, "Cook 1", "Anytime princess!", "Cook1", "Left"));

        dialogueDb.Add(new DialoguePopup(170, "Princess Plum", "Here's your stupid pie.", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(171, "Guard 2", "Oh, it's glorious! It smells delicious.", "Guard2", "Left"));
        dialogueDb.Add(new DialoguePopup(172, "Guard 2", "And so warm! It must be straight from the oven.  This is perfect, thank you princess.", "Guard2", "Left"));
        dialogueDb.Add(new DialoguePopup(173, "Guard 1", "Would you care for a slice? It's really quite ta-", "Guard1", "Left"));
        dialogueDb.Add(new DialoguePopup(174, "Princess Plum", "Yeah yeah can I go in now?", "Princess", "Right"));
        dialogueDb.Add(new DialoguePopup(175, "Guard 1", "*shrug*\nSure, your loss.", "Guard1", "Left"));

        dialogueDb.Add(new DialoguePopup(176, "Marco", "I know you're in here, Princess! Ima coming!", "Marco", "Left"));

        dialogueDb.Add(new DialoguePopup(177, "Princess", "I can't believe it. I finally escaped that lunatic.", "Princess", "Left"));
        dialogueDb.Add(new DialoguePopup(178, "Marco", "What a lovely chapel you have here, Princess.\nAnd the mood lighting? Wow. Just wow.", "Marco", "Right"));
        dialogueDb.Add(new DialoguePopup(179, "Princess", "Ahhh! How did you get past the guards?", "Princess", "Left"));
        dialogueDb.Add(new DialoguePopup(180, "Marco", "Easy. Two pies.", "Marco", "Right"));
        dialogueDb.Add(new DialoguePopup(181, "Princess", "I knew it. One pie per guard makes way more sense...\nDoesn't matter! I'm getting the hell out of here.", "Princess", "Left"));
        dialogueDb.Add(new DialoguePopup(182, "Marco", "Wait! At least hear me out, no?\nYou pretty ones never like-a the nice guys like me.", "Marco", "Right"));
        dialogueDb.Add(new DialoguePopup(183, "Princess", "Maybe you shouldn't be chasing me around my own castle? I don't even know you.\nNow, I'll be taking my leave.", "Princess", "Left"));
        dialogueDb.Add(new DialoguePopup(184, "Marco", "Please...don't say it. Not again.", "Marco", "Right"));
        dialogueDb.Add(new DialoguePopup(185, "Princess", "I'm afraid... your princess is in another castle, Marco.", "Princess", "Left"));
    }

    public DialoguePopup Lookup(int popupID){
        foreach (DialoguePopup popup in dialogueDb)
        {
            if(popup.popupID == popupID){
                return popup;
            }
        }
        return defaultPopup;

    }
}
