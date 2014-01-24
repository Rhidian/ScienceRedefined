using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


/*
 * ScienceRedefined v. 0.1 [WIP]
 * Author: Rhidian
 * All Rights Reserved
 */


namespace ScienceRedefined
{
    
    public class ModuleResearchExperiment : ModuleScienceExperiment
    {
        [KSPField(isPersistant = true)]
        public bool beenBoosted = false;

        protected ScienceExperiment boostExperiment = null;


        public void initializeExperiment()
        {
            boostExperiment = new ScienceExperiment();
            ConfigNode sNode = new ConfigNode();
            
            ResearchAndDevelopment.GetExperiment(this.experimentID).Save(sNode);
            
            //Copies values from original experiment to the internal experiment
            boostExperiment.Load(sNode);

            this.experiment = boostExperiment;

            beenBoosted = false;
        }

        new public void DeployExperiment()
        {
            //Resets Data Decay
            List<ScienceSubject> ssList = ResearchAndDevelopment.GetSubjects();
            foreach (ScienceSubject sub in ssList)
            {
                sub.scientificValue = 1.0f;
            }

            initializeExperiment();

            base.DeployExperiment();
        }
    }
}
