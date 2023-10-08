using System;
using System.Collections.Generic;
using de.unika.ipd.grGen.Model_hvacRules;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace HVACEarlyDesignGraphRewritting
{
    public class ZoneNode : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ZoneNode class.
        /// </summary>
        public ZoneNode()
          : base("ZoneNode", "ZoneNode",
              "Description",
              "HVAC", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "", GH_ParamAccess.item);
            pManager.AddNumberParameter("AreaHVAC", "AH", "", GH_ParamAccess.item);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ZoneNode", "ZN", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = "zone";
            double providerArea = 0;
            DA.GetData(0, ref name);
            DA.GetData(1, ref providerArea);
            DA.SetData(0, new Zone()
            {
                name=name,
                providerArea = providerArea
            });
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("54F337A7-BB59-40AF-B6C9-BF2C81A86CB6"); }
        }
    }
}