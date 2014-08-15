﻿using Esri.ArcGISRuntime.Controls;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArcGISRuntime.Toolkit.Samples.Desktop.Legend
{
	/// <summary>
	/// Demonstrates how to show legend on the map view.
	/// </summary>
	/// <title>Legend</title>
	/// <category>Toolkit</category>
	/// <subcategory>Legend</subcategory>
	/// <usesoffline>false</usesoffline>
	/// <usesonline>true</usesonline>
	public partial class LegendSample : UserControl
	{
		public LegendSample()
		{
			InitializeComponent();
		}

		private void MyMapView_OnLayerLoaded(object sender, LayerLoadedEventArgs e)
		{
			// Zoom to water network
			var layer = e.Layer as ArcGISDynamicMapServiceLayer;
			if (layer != null)
			{
				var extent = layer.ServiceInfo.InitialExtent ?? layer.ServiceInfo.InitialExtent;
				if (extent != null)
				{
					// If extent is not in the same spatial reference than map, reproject it
					if (!SpatialReference.Equals(extent.SpatialReference, MyMapView.SpatialReference))
						extent = GeometryEngine.Project(extent, MyMapView.SpatialReference) as Envelope;
					if (extent != null)
					{
						extent = extent.Expand(0.5);
						MyMapView.SetView(extent);
					}
				}
			}
		}
	}
}
