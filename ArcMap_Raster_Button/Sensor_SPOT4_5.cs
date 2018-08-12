// GISC 6387 - Workshop Project
// David Lindsey - dcl160230@utdallas.edu
//
// This code controls the band combinations for SPOT 4-5.

namespace ArcMap_Raster_Button
{
    class Sensor_SPOT4_5
    {

        // Integer value of one, used for subtraction purposes for the band indices.
        // ArcObjects starts the band counts with index zero, so a band combination of 3, 2, 1 should actually be stored as 2, 1, 0.
        int indexOne = 1;

        public void SPOT4_5_Combinations(GUI_AddRaster theGUI)
        {

            // If the user selects Land - Water Boundaries...
            if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_5)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_LandWaterBoundaries.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_LandWaterBoundaries.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_LandWaterBoundaries.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 3 - indexOne, 4 - indexOne, 2 - indexOne);

            }

            // If the user selects Vegetation...
            else if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_9)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_Vegetation.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_Vegetation.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_Vegetation.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 3 - indexOne, 2 - indexOne, 1 - indexOne);

            }

        } 

    }

}