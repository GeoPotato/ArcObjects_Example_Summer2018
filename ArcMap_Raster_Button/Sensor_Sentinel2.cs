// GISC 6387 - Workshop Project
// David Lindsey - dcl160230@utdallas.edu
//
// This code controls the band combinations for Sentinel-2.

namespace ArcMap_Raster_Button
{
    class Sensor_Sentinel2
    {

        // Integer value of one, used for subtraction purposes for the band indices.
        // ArcObjects starts the band counts with index zero, so a band combination of 3, 2, 1 should actually be stored as 2, 1, 0.
        int indexOne = 1;

        public void Sentinel2_Combinations(GUI_AddRaster theGUI)
        {
            
            // If the user selects Agriculture...
            if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_1)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_Agriculture.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_Agriculture.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_Agriculture.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 11 - indexOne, 8 - indexOne, 2 - indexOne);

            }

            // If the user selects Bare Earth...
            else if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_2)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_BareEarth.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_BareEarth.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_BareEarth.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 11 - indexOne, 3 - indexOne, 2 - indexOne);

            }

            // If the user selects Burn Scarring...
            else if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_3)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_BurnScarring.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_BurnScarring.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_BurnScarring.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 12 - indexOne, 8 - indexOne, 2 - indexOne);

            }

            // If the user selects Healthy Vegetation...
            else if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_4)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_HealthyVegetation.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_HealthyVegetation.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_HealthyVegetation.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 8 - indexOne, 11 - indexOne, 2 - indexOne);

            }

            // If the user selects Land - Water Boundaries...
            else if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_5)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_LandWaterBoundaries.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_LandWaterBoundaries.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_LandWaterBoundaries.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 8 - indexOne, 11 - indexOne, 4 - indexOne);

            }

            // If the user selects Natural Color...
            else if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_6)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_NaturalColor.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_NaturalColor.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_NaturalColor.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 4 - indexOne, 3 - indexOne, 2 - indexOne);

            }

            // If the user selects Natural Color - No Atmosphere...
            else if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_7)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_NaturalColorNoAtmosphere.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_NaturalColorNoAtmosphere.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_NaturalColorNoAtmosphere.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 12 - indexOne, 8 - indexOne, 3 - indexOne);

            }

            // If the user selects Urban...
            else if (theGUI.combo_StudyType.SelectedItem.ToString() == GUI_AddRaster.STUDYTYPE_8)
            {

                // Define the band parameters to be passed for this study type.
                Class_BandCombination run_BandCombinationClass = new Class_BandCombination();
                run_BandCombinationClass.bandCombination(theGUI,
                    Class_AssignTextBoxRGB_Urban.int_R.Value - indexOne,
                    Class_AssignTextBoxRGB_Urban.int_G.Value - indexOne,
                    Class_AssignTextBoxRGB_Urban.int_B.Value - indexOne);

                //run_BandCombinationClass.bandCombination(theGUI, 12 - indexOne, 11 - indexOne, 4 - indexOne);

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

                //run_BandCombinationClass.bandCombination(theGUI, 8 - indexOne, 4 - indexOne, 3 - indexOne);

            }

        } 

    }

}