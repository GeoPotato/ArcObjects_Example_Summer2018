// GISC 6387 - Workshop Project
// David Lindsey - dcl160230@utdallas.edu
//
// This code controls the import and display of the raster image.


// Reference libraries utilized.
using System;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace ArcMap_Raster_Button
{
    public class Class_BandCombination
    {

        // Shortcut for adding new line while writing text.
        string nL = Environment.NewLine;

        // Function with arguments that have been passed from each sensor.
        public void bandCombination(GUI_AddRaster theGUI, int int_RedBandIndex, int int_GreenBandIndex, int int_BlueBandIndex)
        {

            try
            {

                // Folder path only.
                string rasterFolderPath = System.IO.Path.GetDirectoryName(theGUI.textBox_PathURL.Text);

                // Image file name only.
                string rasterFileName = System.IO.Path.GetFileName(theGUI.textBox_PathURL.Text);

                // Map document.
                IMxDocument mxDoc = ArcMap.Application.Document as IMxDocument;

                // Needed for working with rasters.
                IWorkspaceFactory wSF = new RasterWorkspaceFactoryClass();
                
                // Set the raster image workspace.
                IWorkspace wS = wSF.OpenFromFile(rasterFolderPath, ArcMap.Application.hWnd);

                // Prepare the raster workspace.
                IRasterWorkspace rasterWS = wS as IRasterWorkspace;

                // Open the raster image.
                IRasterDataset rasterDataset = rasterWS.OpenRasterDataset(rasterFileName);

                // Prepare raster image as raster layer.
                IRasterLayer rasterLayer = new RasterLayerClass();

                // Create the raster layer from raster image.
                rasterLayer.CreateFromDataset(rasterDataset);

                // Add raster layer to map.
                mxDoc.AddLayer(rasterLayer);

                // Required for displaying raster layer with specific band combinations (the renderer).
                IRasterRGBRenderer2 rgbRen = new RasterRGBRendererClass();
                IRasterRenderer rasRen = rgbRen as IRasterRenderer;

                // Assign band combination based on parameters that were fed into the function.
                rgbRen.RedBandIndex = int_RedBandIndex;
                rgbRen.GreenBandIndex = int_GreenBandIndex;
                rgbRen.BlueBandIndex = int_BlueBandIndex;

                // Rename the raster layer to sensor type + study type + image name, with spaces and file extension removed.
                rasterLayer.Name = theGUI.combo_SensorType.SelectedItem.ToString().Replace(" ", string.Empty) + "_" +
                                    theGUI.combo_StudyType.SelectedItem.ToString().Replace(" ", string.Empty) + "__" +
                                    System.IO.Path.GetFileNameWithoutExtension(rasterFileName).Replace(" ", string.Empty);

                // Update the renderer with band combinations.
                rasterLayer.Renderer = rasRen;
                rasRen.Update();

                if (theGUI.checkBox_RasterExtent.Checked)
                {

                    // Zoom to raster image extent if the checkbox is checked.
                    mxDoc.ActiveView.Extent = rasterLayer.AreaOfInterest;

                }

                // Refresh the map and update the table of contents.
                mxDoc.ActiveView.Refresh();
                mxDoc.UpdateContents();

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