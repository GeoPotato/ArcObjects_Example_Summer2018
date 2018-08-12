// GISC 6387 - Workshop Project
// David Lindsey - dcl160230@utdallas.edu
//
// This code controls the layout and functionality of the GUI window.


// Reference libraries utilized.
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.Catalog;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ArcMap_Raster_Button
{
    public partial class GUI_AddRaster : Form
    {
        
        // Variable for the user selected raster image file path.
        string image_FilePath;

        // Shortcut variable for creating new line within string.
        string nL = Environment.NewLine;

        // Default text that will populate within the URL textbox when an image has yet to be selected by the user.
        public string default_URLText = "Raster image path will populate here once selected...";

        // Empty array for storing each study type.
        string[] studyTypes;

        // Each study type as a publicly accessible constant.
        public const string STRING_SELECT = "Select...";
        public const string STUDYTYPE_1 = "Agriculture";
        public const string STUDYTYPE_2 = "Bare Earth";
        public const string STUDYTYPE_3 = "Burn Scarring";
        public const string STUDYTYPE_4 = "Healthy Vegetation";
        public const string STUDYTYPE_5 = "Land - Water Boundaries";
        public const string STUDYTYPE_6 = "Natural Color";
        public const string STUDYTYPE_7 = "Natural Color - No Atmosphere";
        public const string STUDYTYPE_8 = "Urban";
        public const string STUDYTYPE_9 = "Vegetation";

        // Nullable integer for the designated band count for each sensor int he Sensor Type combobox.
        int? int_SensorBandCount;

        public GUI_AddRaster()
        {
            InitializeComponent();
        }

        private void GUI_AddRaster_Load(object sender, EventArgs e)
        {

            try
            {

                // Add all sensor types to the array.
                string[] sensorTypes = new string[] { STRING_SELECT, "ASTER", "EO-1 ALI", "EO-1 Hyperion", "FormoSat-1", "FormoSat-2", "FormoSat-5",
                                                    "GeoEye-1", "IKONOS", "Landsat 1-5 MSS", "Landsat 4-5 TM", "Landsat 7", "Landsat 8", "MODIS",
                                                    "NAIP - 3 Band", "NAIP - 4 Band", "OrbView-3", "Pleiades-1", "QuickBird", "RapidEye", "Sentinel-2",
                                                    "Sentinel-3", "SPOT 1-3", "SPOT 4-5", "SPOT 6-7", "WorldView-2", "WorldView-3", "WorldView-4" };

                // Populate the Sensor Type combobox.
                foreach (string sensorType in sensorTypes)
                    combo_SensorType.Items.Add(sensorType);

                // Populate URL textbox with initial default message.
                textBox_PathURL.Text = default_URLText;

                // Disable the Study Type combobox.
                combo_StudyType.Enabled = false;

                // Set the Sensor Type combobox to index zero (Select...).
                combo_SensorType.SelectedIndex = 0;


            }
            catch (Exception exc)
            {

                // Catch any exception found and display a message box.
                MessageBox.Show("Exception caught: " + nL + exc.Message + nL + exc.StackTrace);
                return;

            }

        }

        private void button_Browse_Click(object sender, EventArgs e)
        {

            // Hide the GUI.
            this.Hide();

            // Initialize, configure, and display the dialog box to select raster image.
            IGxDialog gxd = new GxDialogClass();
            gxd.AllowMultiSelect = false;
            gxd.ButtonCaption = "Add Raster";
            gxd.Title = "Add Raster Layer";
            gxd.RememberLocation = true;
            IGxObjectFilter gxObjFilter = new GxFilterRasterDatasetsClass();
            gxd.ObjectFilter = gxObjFilter;
            IEnumGxObject gxEnumObj;

            // Once user selects a raster image and clicks OK...
            if (gxd.DoModalOpen(ArcMap.Application.hWnd, out gxEnumObj))
            {
                // Assign image path, populate in URL textbox, then show the GUI again.
                IGxObject gxObj = gxEnumObj.Next();
                image_FilePath = gxObj.FullName;
                textBox_PathURL.Text = image_FilePath;
                this.Show();
                this.Activate();

                // If the URL textbox does not show the default URL text and the Sensor Type is not "Select..."...
                if ((textBox_PathURL.Text != default_URLText) && (combo_SensorType.SelectedItem.ToString() != STRING_SELECT))
                {

                    // Execute Class/Function to count the raster bands of the selected iamge.
                    Class_CountRasterBands countRasterBands = new Class_CountRasterBands();
                    countRasterBands.BandCounts(this);

                    // If the raster band count does not equal the expected Sensor Type's band count...
                    if (countRasterBands.totalBands != int_SensorBandCount)
                    {
                        // Display warning label for user, populate band count information, and adjust textbox background color to red.
                        label_Warning.Show();
                        textBox_ImageBandCount.Text = countRasterBands.totalBands.ToString();
                        textBox_ImageBandCount.BackColor = Color.Red;
                        textBox_SensorBandCount.BackColor = Color.Red;

                    }
                    else
                    {
                        // Else if the band counts match:
                        // Do not show warning label, populate matching band count values in textboxes, and remove any background red colors.
                        label_Warning.Hide();
                        textBox_ImageBandCount.Text = countRasterBands.totalBands.ToString();
                        textBox_ImageBandCount.BackColor = Color.Empty;
                        textBox_SensorBandCount.BackColor = Color.Empty;
                    }

                }

                else
                {
                    // Else if the URL textbox shows the default message or the image path is missing (no image selected)...
                    label_Warning.Hide();
                    textBox_ImageBandCount.Text = null;
                    textBox_ImageBandCount.BackColor = Color.Empty;
                    textBox_SensorBandCount.BackColor = Color.Empty;
                }

            }
            else
            {
                
                // Else if the user does not select a raster image (hits cancel within dialog box): 
                // Do not show warning label, remove any image band count values, and remove any background red colors.
                if ((textBox_PathURL.Text == default_URLText) || (textBox_PathURL.Text == null))
                {
                    // Ensure the default path is visible, remove any image band count values, ensure warning message is not visible, 
                    // and remove any background red colors.
                    textBox_PathURL.Text = default_URLText;
                    textBox_ImageBandCount.Text = null;
                    label_Warning.Hide();
                    textBox_ImageBandCount.BackColor = Color.Empty;
                    textBox_SensorBandCount.BackColor = Color.Empty;

                }

                // Activate and show the GUI regardless of the above if statement.
                this.Show();
                this.Activate();
                return;

            }

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {

            // If user selects the Exit button, close the application.
            GUI_AddRaster.ActiveForm.Close();

            // Ensure ArcMap remains present on the screen after Exit is clicked.
            ArcMap.Application.Visible = true;

    }

        private void button_OK_Click(object sender, EventArgs e)
        {

            // If Sensor Type comboxbox selection is "Select..."...
            if (combo_SensorType.SelectedItem.ToString() == STRING_SELECT)
            {
                // Display error message.
                MessageBox.Show("A valid Sensor Type must be selected to proceed." + nL + "Please try again.");
                return;

            }

            // If Study Type combobox selection is "Select..."...
            else if (combo_StudyType.SelectedItem.ToString() == STRING_SELECT)
            {
                // Display error message.
                MessageBox.Show("A valid Study Type must be selected to proceed." + nL + "Please try again.");
                return;
            }

            // If URL textbox shows the default message...
            else if (textBox_PathURL.Text == default_URLText)
            {
                // Display error message.
                MessageBox.Show("A raster image must be selected to proceed." + nL + "Please try again.");
                return;

            }
            else
            {
                // If all input parameters properly selected, proceed to import the raster image.
                importRaster();
            }


        }

        private void importRaster()
        {

            try
            {

                if (combo_SensorType.SelectedItem.ToString() == "ASTER")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Aster sensor_Aster = new Sensor_Aster();
                    sensor_Aster.Aster_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "EO-1 ALI")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_EO1_ALI sensor_EO1_ALI = new Sensor_EO1_ALI();
                    sensor_EO1_ALI.EO1_ALI_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "EO-1 Hyperion")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_EO1_Hyperion sensor_EO1_Hyperion = new Sensor_EO1_Hyperion();
                    sensor_EO1_Hyperion.EO1_Hyperion_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "FormoSat-1")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_FormoSat1 sensor_FormoSat1 = new Sensor_FormoSat1();
                    sensor_FormoSat1.FormoSat1_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "FormoSat-2")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_FormoSat2_5 sensor_FormoSat2_5 = new Sensor_FormoSat2_5();
                    sensor_FormoSat2_5.FormoSat2_5_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "FormoSat-5")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_FormoSat2_5 sensor_FormoSat2_5 = new Sensor_FormoSat2_5();
                    sensor_FormoSat2_5.FormoSat2_5_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "GeoEye-1")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_GeoEye1 sensor_GeoEye1 = new Sensor_GeoEye1();
                    sensor_GeoEye1.GeoEye1_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "IKONOS")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_IKONOS sensor_IKONOS = new Sensor_IKONOS();
                    sensor_IKONOS.IKONOS_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "Landsat 1-5 MSS")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Landsat1_5_MSS sensor_Landsat1_5_MSS = new Sensor_Landsat1_5_MSS();
                    sensor_Landsat1_5_MSS.Landsat1_5_MSS_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "Landsat 4-5 TM")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Landsat4_5_TM sensor_Landsat4_5_TM = new Sensor_Landsat4_5_TM();
                    sensor_Landsat4_5_TM.Landsat4_5_TM_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "Landsat 7")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Landsat7 sensor_Landsat7 = new Sensor_Landsat7();
                    sensor_Landsat7.Landsat7_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "Landsat 8")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Landsat8 sensor_Landsat8 = new Sensor_Landsat8();
                    sensor_Landsat8.Landsat8_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "MODIS")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Modis sensor_Modis = new Sensor_Modis();
                    sensor_Modis.Modis_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "NAIP 3-Band")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_NAIP_3Band sensor_NAIP_3Band = new Sensor_NAIP_3Band();
                    sensor_NAIP_3Band.NAIP_3Band_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "NAIP 4-Band")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_NAIP_4Band sensor_NAIP_4Band = new Sensor_NAIP_4Band();
                    sensor_NAIP_4Band.NAIP_4Band_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "OrbView-3")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_OrbView3 sensor_OrbView3 = new Sensor_OrbView3();
                    sensor_OrbView3.OrbView3_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "Pleiades-1")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Pleiades1 sensor_Pleiades1 = new Sensor_Pleiades1();
                    sensor_Pleiades1.Pleiades1_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "QuickBird")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_QuickBird sensor_QuickBird = new Sensor_QuickBird();
                    sensor_QuickBird.QuickBird_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "RapidEye")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_RapidEye sensor_RapidEye = new Sensor_RapidEye();
                    sensor_RapidEye.RapidEye_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "Sentinel-2")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Sentinel2 sensor_Sentinel2 = new Sensor_Sentinel2();
                    sensor_Sentinel2.Sentinel2_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "Sentinel-3")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_Sentinel3 sensor_Sentinel3 = new Sensor_Sentinel3();
                    sensor_Sentinel3.Sentinel3_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "SPOT 1-3")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_SPOT1_3 sensor_SPOT1_3 = new Sensor_SPOT1_3();
                    sensor_SPOT1_3.SPOT1_3_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "SPOT 4-5")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_SPOT4_5 sensor_SPOT4_5 = new Sensor_SPOT4_5();
                    sensor_SPOT4_5.SPOT4_5_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "SPOT 6-7")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_SPOT6_7 sensor_SPOT6_7 = new Sensor_SPOT6_7();
                    sensor_SPOT6_7.SPOT6_7_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "WorldView-2")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_WorldView2 sensor_WorldView2 = new Sensor_WorldView2();
                    sensor_WorldView2.WorldView2_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "WorldView-3")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_WorldView3 sensor_WorldView3 = new Sensor_WorldView3();
                    sensor_WorldView3.WorldView3_Combinations(this);

                }

                else if (combo_SensorType.SelectedItem.ToString() == "WorldView-4")
                {

                    // Execute the Class/Function for importing this sensor's image with proper band combinations.
                    Sensor_WorldView4 sensor_WorldView4 = new Sensor_WorldView4();
                    sensor_WorldView4.WorldView4_Combinations(this);

                }

            }
            catch (Exception exc)
            {
                // Catch any exception found and display a message box.
                MessageBox.Show("Exception caught: " + nL + exc.Message + nL + exc.StackTrace);
                return;
            }

        }

        private void combo_SensorType_SelectedIndexChanged(object sender, EventArgs e)

        {

            try
            {

                // Switch commands for each Sensor Type combobox selection change.
                switch (combo_SensorType.SelectedItem.ToString())
                {
                    case STRING_SELECT:

                        // Disable and clear the Study Type combobox and array, remove band count information.
                        combo_StudyType.Enabled = false;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = null;
                        textBox_SensorBandCount.Text = null;

                        break;

                    case "ASTER":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 14;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_5, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "EO-1 ALI":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 10;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_1, STUDYTYPE_2, STUDYTYPE_3, STUDYTYPE_4,
                            STUDYTYPE_5, STUDYTYPE_6, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "EO-1 Hyperion":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 242;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_1, STUDYTYPE_2, STUDYTYPE_3, STUDYTYPE_4,
                            STUDYTYPE_5, STUDYTYPE_6, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "FormoSat-1":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 7;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "FormoSat-2":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "FormoSat-5":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "GeoEye-1":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "IKONOS":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "Landsat 1-5 MSS":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 4;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "Landsat 4-5 TM":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 7;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_1, STUDYTYPE_2, STUDYTYPE_3, STUDYTYPE_4,
                            STUDYTYPE_5, STUDYTYPE_6, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "Landsat 7":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 8;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_1, STUDYTYPE_2, STUDYTYPE_3, STUDYTYPE_4,
                            STUDYTYPE_5, STUDYTYPE_6, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "Landsat 8":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 11;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_1, STUDYTYPE_2, STUDYTYPE_3, STUDYTYPE_4,
                            STUDYTYPE_5, STUDYTYPE_6, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "MODIS":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 36;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_1, STUDYTYPE_2, STUDYTYPE_3, STUDYTYPE_4,
                            STUDYTYPE_5, STUDYTYPE_6, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "NAIP - 3 Band":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 3;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "NAIP - 4 Band":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 4;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "OrbView-3":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "Pleiades-1":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "QuickBird":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "RapidEye":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "Sentinel-2":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 12;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_1, STUDYTYPE_2, STUDYTYPE_3, STUDYTYPE_4,
                            STUDYTYPE_5, STUDYTYPE_6, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "Sentinel-3":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 21;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "SPOT 1-3":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 4;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "SPOT 4-5":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_5, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "SPOT 6-7":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "WorldView-2":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 9;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "WorldView-3":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 29;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_1, STUDYTYPE_2, STUDYTYPE_3, STUDYTYPE_4,
                            STUDYTYPE_5, STUDYTYPE_6, STUDYTYPE_7, STUDYTYPE_8, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                    case "WorldView-4":

                        // Enable Study Type combobox, clear any pre-existing Study Type array values, assign and display sensor band count.
                        combo_StudyType.Enabled = true;
                        combo_StudyType.Items.Clear();
                        int_SensorBandCount = 5;
                        textBox_SensorBandCount.Text = int_SensorBandCount.ToString();

                        // Assign these study types into the Study Type array based on sensor capabilities.
                        studyTypes = new string[] { STRING_SELECT, STUDYTYPE_6, STUDYTYPE_9 };

                        // Populate the array values into combobox drop-down list, set index at zero.
                        foreach (string studyType in studyTypes)
                            combo_StudyType.Items.Add(studyType);
                        combo_StudyType.SelectedIndex = 0;
                        break;

                }

                // If the URL textbox does not show the default URL text and the Sensor Type is not "Select..."...
                if ((textBox_PathURL.Text != default_URLText) && (combo_SensorType.SelectedItem.ToString() != STRING_SELECT))
                {

                    // Execute Class/Function to count the raster bands of the selected image.
                    Class_CountRasterBands countRasterBands = new Class_CountRasterBands();
                    countRasterBands.BandCounts(this);

                    // If the raster band count does not equal the expected Sensor Type's band count...
                    if (countRasterBands.totalBands != int_SensorBandCount)
                    {
                        // Display warning label for user, populate band count information, and adjust textbox background color to red.
                        label_Warning.Show();
                        textBox_ImageBandCount.Text = countRasterBands.totalBands.ToString();
                        textBox_ImageBandCount.BackColor = Color.Red;
                        textBox_SensorBandCount.BackColor = Color.Red;

                    }
                    else
                    {
                        // Else if the band counts match:
                        // Do not show warning label, populate matching band count values in textboxes, and remove any background red colors.
                        label_Warning.Hide();
                        textBox_ImageBandCount.Text = countRasterBands.totalBands.ToString();
                        textBox_ImageBandCount.BackColor = Color.Empty;
                        textBox_SensorBandCount.BackColor = Color.Empty;
                    }

                }

                else
                    {
                    // Else if the user does not have an image selected by changing sensor types:
                    // Do not show warning label, remove any image band count values, and remove any background red colors.
                    label_Warning.Hide();
                    textBox_ImageBandCount.Text = null;
                    textBox_ImageBandCount.BackColor = Color.Empty;
                    textBox_SensorBandCount.BackColor = Color.Empty;
                    }

            }

            catch (Exception exc)
            {

                // Catch any exception found and display a message box.
                MessageBox.Show("Exception caught: " + nL + exc.Message + nL + exc.StackTrace);
                return;

            }

        }

        private void combo_StudyType_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                // Switch commands for each Study Type combobox selection change.
                switch (combo_StudyType.SelectedItem.ToString())
                {
                    case STRING_SELECT:

                        // Clear the RGB textbox values.
                        textBox_R.Text = null;
                        textBox_G.Text = null;
                        textBox_B.Text = null;

                        break;

                    // Agriculture
                    case STUDYTYPE_1:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_Agriculture rgb_Agriculture = 
                            new Class_AssignTextBoxRGB_Agriculture();
                        rgb_Agriculture.RGB_Assignments_Agriculture(this);

                        break;

                    // Bare Earth
                    case STUDYTYPE_2:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_BareEarth rgb_BareEarth = 
                            new Class_AssignTextBoxRGB_BareEarth();
                        rgb_BareEarth.RGB_Assignments_BareEarth(this);

                        break;

                    // Burn Scarring
                    case STUDYTYPE_3:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_BurnScarring rgb_BurnScarring = 
                            new Class_AssignTextBoxRGB_BurnScarring();
                        rgb_BurnScarring.RGB_Assignments_BurnScarring(this);
                        break;

                    // Healthy Vegetation
                    case STUDYTYPE_4:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_HealthyVegetation rgb_HealthyVegetation = 
                            new Class_AssignTextBoxRGB_HealthyVegetation();
                        rgb_HealthyVegetation.RGB_Assignments_HealthyVegetation(this);
                        break;

                    // Land - Water Boundaries
                    case STUDYTYPE_5:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_LandWaterBoundaries rgb_LandWaterBoundaries = 
                            new Class_AssignTextBoxRGB_LandWaterBoundaries();
                        rgb_LandWaterBoundaries.RGB_Assignments_LandWaterBoundaries(this);
                        break;

                    // Natural Color
                    case STUDYTYPE_6:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_NaturalColor rgb_NaturalColor = 
                            new Class_AssignTextBoxRGB_NaturalColor();
                        rgb_NaturalColor.RGB_Assignments_NaturalColor(this);
                        break;

                    // Natural Color - No Atmosphere
                    case STUDYTYPE_7:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_NaturalColorNoAtmosphere rgb_NaturalColorNoAtmosphere = 
                            new Class_AssignTextBoxRGB_NaturalColorNoAtmosphere();
                        rgb_NaturalColorNoAtmosphere.RGB_Assignments_NaturalColorNoAtmosphere(this);
                        break;

                    // Urban
                    case STUDYTYPE_8:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_Urban rgb_Urban = 
                            new Class_AssignTextBoxRGB_Urban();
                        rgb_Urban.RGB_Assignments_Urban(this);
                        break;

                    // Vegetation
                    case STUDYTYPE_9:

                        // Execute Class/Function to populate RGB combination for this study type.
                        Class_AssignTextBoxRGB_Vegetation rgb_Vegetation = 
                            new Class_AssignTextBoxRGB_Vegetation();
                        rgb_Vegetation.RGB_Assignments_Vegetation(this);
                        break;

                }
            }
            catch (Exception exc)
            {

                // Catch any exception found and display a message box.
                MessageBox.Show("Exception caught: " + nL + exc.Message + nL + exc.StackTrace);
                return;

            }

        }

    }

}