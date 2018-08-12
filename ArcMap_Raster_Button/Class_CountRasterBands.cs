// GISC 6387 - Workshop Project
// David Lindsey - dcl160230@utdallas.edu
//
// This code controls the import and display of the raster image.


// Reference libraries utilized.
using System;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;

namespace ArcMap_Raster_Button
{
    public class Class_CountRasterBands
    {

        // Shortcut for adding new line while writing text.
        string nL = Environment.NewLine;

        public int totalBands;

        // Function with arguments that have been passed from each sensor.
        public void BandCounts(GUI_AddRaster theGUI)
        {

            try
            {

                // Folder path only.
                string rasterFolderPath = Path.GetDirectoryName(theGUI.textBox_PathURL.Text);

                // Image file name only.
                string rasterFileName = Path.GetFileName(theGUI.textBox_PathURL.Text);

                // Needed for working with rasters.
                IWorkspaceFactory wSF = new RasterWorkspaceFactoryClass();
                
                // Set the raster image workspace.
                IWorkspace wS = wSF.OpenFromFile(rasterFolderPath, ArcMap.Application.hWnd);

                // Prepare the raster workspace.
                IRasterWorkspace rasterWS = wS as IRasterWorkspace;

                IRasterDataset rasterDataset;

                try
                {

                    // Open the raster image.
                    rasterDataset = rasterWS.OpenRasterDataset(rasterFileName);

                }
                catch
                {
                    // If the raster image is invalid with no bands to count,
                    // catch the error and display this message.
                    MessageBox.Show("Invalid raster. No bands to be counted.");
                    return;
                }

                // Prepare raster image as raster layer.
                IRasterLayer rasterLayer = new RasterLayerClass();

                // Create the raster layer from raster image.
                rasterLayer.CreateFromDataset(rasterDataset);

                // Access band total for image.
                IRasterBandCollection rasterBC = rasterDataset as IRasterBandCollection;
                IEnumRasterBand pEnumRasterBand = rasterBC.Bands;
                totalBands = rasterBC.Count;

                // The following code is for accessing individual band names, if needed. 
                // These are unused for the code in its current format.
                //int curBandCount = rasterBC.Count;
                //IRasterBand pRasterBand;
                //string bandName;
                //while (curBandCount > 0)
                //{
                //pRasterBand = pEnumRasterBand.Next();
                //bandName = pRasterBand.Bandname.ToString();
                //curBandCount = curBandCount - 1;
                //}

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