using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains and controls the flow of the instructions 

public class InstructionManager : MonoBehaviour
{
    /// <summary>
    ///  The instructions are divided up each by the trigger they are attached to.
    ///  They are also number in chronological order.
    ///  i.e inst_0 = instruction_0
    /// </summary>

    // Trigger 1
    string inst_0 = "Welcome to the Color Study Lab.";
    string isnt_1 = "You will see visual prompts outlining the basic controls for this simulation.";
    string isnt_2 = "Please move forward to grab the palette";

    // Trigger 2
    string isnt_3 = "There are a few stations in the Color Study Lab you should get familiar with.";
    string isnt_4 = "The first of which is the Coloring Book table. This is where we figure out what kind of theme our picture should have.";
    string isnt_5 = "Please select the Coloring Book to continue.";

    // Trigger 3
    string isnt_6 = "At the Coloring Book table, you will be given an image, a theme, the amount of colors required and a color palette.";
    string isnt_7 = "You will be able to select the colors on the palette using your mouse.";
    // Subtrigger
    string isnt_8 = "Now that we have hit the color selection limit, you are able to submit your choices. " +
                    "You are still able to change your solution if you wish";

    /// <summary>
    /// SUBTRACTIVE
    /// </summary>
    // Trigger 4
    string isnt_9 = "The second part of the Color Study Lab is the Mixing table.";
    string isnt_10 = "Please select The Mixer at the Mixing Table to continue.";

    // Trigger 5
    string isnt_11 = "At the mixing table you must mix the colors that were decided for the theme.";
    string isnt_12 = "You are given vials for the main three subtractive colors on your left. In the middle is the mixer, " +
                     "where you will mix certain amounts of those three colors in order to get the expected color.";
    string isnt_13 = "In order to start the mixing process, you must select a vial to pour in. " +
                     "After that, add the next sequence of colors to reach the color you desire.";
    string isnt_14 = "Depending on the colors you must make, you might need to multiple of the same color.";
    // Subtrigger
    string isnt_15 = "Once you have finished mixing one color you can press “Submit”";
    // Subtrigger
    string isnt_16 = "Once you have finished mixing all the colors “Complete” button will appear.";
    string isnt_17 = "If you run out of ink in one of the vials, you will be scored on current result.";

    // Trigger 6 
    string isnt_18 = "The last part in the subtractive coloring track is to finally add color to the picture.";
    string isnt_19 = "Please select the Brush on the Canvas to continue.";

    // Trigger 7
    string isnt_20 = "You can use your palette to color the picture.";
    string isnt_21 = "You should select the color that matches the picture the most.";
    string isnt_22 = "Whether it should be the natural color of things or how the theme affects the colors of things.";
    string isnt_23 = "There does exist multiple answers for a particular object.";
    // Subtrigger 
    string isnt_24 = "Press the “Complete” button.";

    // Trigger 8
    string isnt_25 = "This is the end of the subtractive coloring tutorial. " +
                     "After every level you will be ranked on how you completed each part of the stage.";
    string isnt_26 = "You will receive a grade for each stage as well as a cumulative grade.";
    string isnt_27 = "These grades represent the accuracy, speed and knowledge of color theory.";
    string isnt_28 = "Click the “Next” button to go the Additive tutorial. Good luck.";

    /// <summary>
    /// ADDITIVE
    /// </summary>

    // Trigger 9
    string isnt_29 = "We will be using the same colors for the additive coloring. This is because the color selection is the same for both types.";
    string isnt_30 = "The fourth part of the Color Study Lab is the Light Mixing Table.";
    string isnt_31 = "Please select The Laser Controller at the Light Mixing Table to continue.";

    // Trigger 10
    string isnt_32 = "At the mixing table you must mix the colors that were decided for the theme.";
    string isnt_33 = "You are given lasers for the main three additivecolors on your left. " +
                     "In the middle is the reflector where you will mix certain amounts of three colors in order to get the expected color.";
    string isnt_34 = "In order to start the mixing process you must select a laser. After that change the intensity of each laser to reach the color you desire.";
    string isnt_35 = "Depending on how precise the color you must make, you might need to have more precise intensity.";
    // Subtrigger
    string isnt_36 = "“Once you have finished mixing one color you can press “Submit”";
    // Subtrigger 
    string isnt_37 = "Once you have finished mixing all the colors “Complete” button will appear.";
    string isnt_38 = "If you run out of energy in one of the lasers, you will be thrown out";

    // Trigger 11
    string isnt_39 = "The last part in the additive coloring track is to finally add color to the picture.";
    string isnt_40 = "Please select the Remote on the Screen to continue.";

    // Trigger 12
    string isnt_41 = "The colors you have made have been uploaded to your remote. You can select the color you want to use by clicking on it.";
    string isnt_42 = "You should select the color that matches the picture the most.";
    string isnt_43 = "Whether it should be the natural color of things or how the theme affects the colors of things.";
    string isnt_44 = "There does exist multiple answers for a particular object.";
    // Subtrigger 
    string isnt_45 = "Press the “Complete” button";

    /// <summary>
    /// END
    /// </summary>
    string isnt_46 = "This is the end of the tutorial. After every level you will be ranked on how you completed each part of the stage.";
    string isnt_47 = "You will receive a grade for each stage as well as a cumulative grade.";
    string inst_48 = "These grades represent the accuracy, speed and knowledge of color theory";
    string isnt_49 = "Click the “Next” button to go to the next level. Good luck.";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
