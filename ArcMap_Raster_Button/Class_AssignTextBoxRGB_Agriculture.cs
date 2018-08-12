// GISC 6387 - Workshop Project
// David Lindsey - dcl160230@utdallas.edu
//
// This code controls how the RGB combination textboxes will populate with Agriculture combobox selection.

namespace ArcMap_Raster_Button
{
    class Class_AssignTextBoxRGB_Agriculture
    {

        // Nullable integer variables for RGB.
        public static int? int_R;
        public static int? int_G;
        public static int? int_B;

        public void RGB_Assignments_Agriculture(GUI_AddRaster theGUI)
        {

            if (theGUI.combo_SensorType.SelectedItem.ToString() == "ASTER")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "EO-1 ALI")
            {

                // RGB Band values
                int_R = 9;
                int_G = 7;
                int_B = 3;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = int_R.ToString();
                theGUI.textBox_G.Text = int_G.ToString();
                theGUI.textBox_B.Text = int_B.ToString();

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "EO-1 Hyperion")
            {

                // RGB Band values
                int_R = 150;
                int_G = 50;
                int_B = 16;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = int_R.ToString();
                theGUI.textBox_G.Text = int_G.ToString();
                theGUI.textBox_B.Text = int_B.ToString();

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "FormoSat-1")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "FormoSat-2")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "FormoSat-5")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "GeoEye-1")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "IKONOS")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "Landsat 1-5 MSS")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "Landsat 4-5 TM")
            {

                // RGB Band values
                int_R = 5;
                int_G = 4;
                int_B = 1;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = int_R.ToString();
                theGUI.textBox_G.Text = int_G.ToString();
                theGUI.textBox_B.Text = int_B.ToString();

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "Landsat 7")
            {

                // RGB Band values
                int_R = 5;
                int_G = 4;
                int_B = 1;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = int_R.ToString();
                theGUI.textBox_G.Text = int_G.ToString();
                theGUI.textBox_B.Text = int_B.ToString();

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "Landsat 8")
            {

                // RGB Band values
                int_R = 6;
                int_G = 5;
                int_B = 2;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = int_R.ToString();
                theGUI.textBox_G.Text = int_G.ToString();
                theGUI.textBox_B.Text = int_B.ToString();

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "MODIS")
            {

                // RGB Band values
                int_R = 6;
                int_G = 2;
                int_B = 3;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = int_R.ToString();
                theGUI.textBox_G.Text = int_G.ToString();
                theGUI.textBox_B.Text = int_B.ToString();

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "NAIP 3-Band")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "NAIP 4-Band")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "OrbView-3")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "Pleiades-1")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "QuickBird")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "RapidEye")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "Sentinel-2")
            {

                // RGB Band values
                int_R = 11;
                int_G = 8;
                int_B = 2;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = int_R.ToString();
                theGUI.textBox_G.Text = int_G.ToString();
                theGUI.textBox_B.Text = int_B.ToString();

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "Sentinel-3")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "SPOT 1-3")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "SPOT 4-5")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "SPOT 6-7")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "WorldView-2")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "WorldView-3")
            {

                // RGB Band values
                int_R = 10;
                int_G = 7;
                int_B = 2;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = int_R.ToString();
                theGUI.textBox_G.Text = int_G.ToString();
                theGUI.textBox_B.Text = int_B.ToString();

            }

            else if (theGUI.combo_SensorType.SelectedItem.ToString() == "WorldView-4")
            {

                // This RGB combination is not available for this sensor.
                int_R = null;
                int_G = null;
                int_B = null;

                // Set RGB band values to textboxes.
                theGUI.textBox_R.Text = null;
                theGUI.textBox_G.Text = null;
                theGUI.textBox_B.Text = null;

            }

        }

    }

}