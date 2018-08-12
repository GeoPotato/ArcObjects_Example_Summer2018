// GISC 6387 - Workshop Project
// David Lindsey - dcl160230@utdallas.edu
//
// This code controls the Add-In button functionality.


// Reference libraries utilized.
using System;
using System.Windows.Forms;

namespace ArcMap_Raster_Button
{
    public class Button_AddRaster : ESRI.ArcGIS.Desktop.AddIns.Button
    {

        // Declare the new windows form as GUI_AddRaster.
        GUI_AddRaster gui_AddRaster;

        public Button_AddRaster()
        {

        }

        protected override void OnClick()
        {

            // Once the button has been clicked, disable the Add-In button.
            this.Enabled = false;

            // Controls the launch and display of the GUI window.
            gui_AddRaster = new GUI_AddRaster();
            gui_AddRaster.StartPosition = FormStartPosition.CenterScreen; // Open GUI on active window as ArcMap, and centered.
            gui_AddRaster.Show(Control.FromHandle((IntPtr)ArcMap.Application.hWnd)); // Show the GUI window in front of ArcMap at all times.

        }

        protected override void OnUpdate()
        {

            // If the GUI is not visible...
            if (gui_AddRaster.Visible == false)
            {
                // ...enable the Add-In button.
                this.Enabled = true;
            }

        }

    }

}