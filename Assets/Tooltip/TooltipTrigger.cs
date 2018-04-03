﻿/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipTrigger.cs
 *  Description  :  Trigger for Tooltip.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/13/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  3/8/2018
 *  Description  :  Extend and optimize.
 *************************************************************************/

using UnityEngine;
using TouchScript.Gestures;

namespace Developer.Tooltip
{
    [AddComponentMenu("Developer/Tooltip/TooltipTrigger")]
    [RequireComponent(typeof(Collider))]
    public class TooltipTrigger : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Tooltip info.
        /// </summary>
        [Multiline]
        public string tipInfo = "Tooltip Info";
        #endregion

		void OnEnable()
		{
			GetComponent<TapGesture>().Tapped += delegate(object sender, System.EventArgs e) {
				TooltipAgent.Instance.ShowTip(tipInfo);
				PressedProgress.Instance.Reset();
			};
		}
    }
}