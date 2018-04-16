/*
* Copyright (c) 2017-2018 Alan Yeats http://alanyeats.com
*
* This software is provided 'as-is', without any express or implied
* warranty.  In no event will the authors be held liable for any damages
* arising from the use of this software.
* Permission is granted to anyone to use this software for any purpose,
* including commercial applications, and to alter it and redistribute it
* freely, subject to the following restrictions:
* 1. The origin of this software must not be misrepresented; you must not
* claim that you wrote the original software. If you use this software
* in a product, an acknowledgment in the product documentation would be
* appreciated but is not required.
* 2. Altered source versions must be plainly marked as such, and must not be
* misrepresented as being the original software.
* 3. This notice may not be removed or altered from any source distribution.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Example
{
    public class EasingExample : MonoBehaviour
    {
        /// <summary>
        /// Easing function dropdown
        /// </summary>
        [SerializeField]
        Dropdown easingTypeDropdown = null;

        /// <summary>
        /// in or out type of drop down
        /// </summary>
        [SerializeField]
        Dropdown inOrOutTypeDropdown = null;

        /// <summary>
        /// Display object use to show what each lerp does
        /// </summary>
        [SerializeField]
        GameObject displayObject =null;

        /// <summary>
        /// time of Lerp function
        /// </summary>
        float time = 0;
        /// <summary>
        ///  Start Point of object
        /// </summary>
        float startPoint = -0.9f;
        /// <summary>
        /// End point of object
        /// </summary>
        float EndPoint = 5;

        /// <summary>
        /// Lerp Function type to be used
        /// </summary>
        EasingLerps.EasingLerpsType lerpType;
        
        /// <summary>
        /// What type of in or out to use 
        /// </summary>
        EasingLerps.EasingInOutType inOutType;

        private void Awake()
        {
            // Fill out dropdowns with enum values 
            string[] EasingTypeNames = System.Enum.GetNames(typeof(EasingLerps.EasingLerpsType));
            for (int i = 0; i < EasingTypeNames.Length; i++)
            {
                easingTypeDropdown.options.Add(new Dropdown.OptionData(EasingTypeNames[i]));
            }

            string[] EasingInOrOutNames = System.Enum.GetNames(typeof(EasingLerps.EasingInOutType));
            for (int i = 0; i < EasingInOrOutNames.Length; i++)
            {
                inOrOutTypeDropdown.options.Add(new Dropdown.OptionData(EasingInOrOutNames[i]));
            }

            // hack to update the dropbox
            inOrOutTypeDropdown.value =1;
            easingTypeDropdown.value = 1;
        }

        private void Start()
        {
            StartCoroutine(UpdateGraph());
        }

        IEnumerator UpdateGraph()
        {

            // Gets the easing value from function
            float easingValue = EasingLerps.EasingLerp(lerpType, inOutType, time, startPoint, EndPoint);
            //Gets lerp Values to show time passing
            float lerpValue = Mathf.Lerp(-5, 5, time);

            // Move object across screen
            displayObject.transform.position = new Vector3(lerpValue, easingValue);

            time += Time.deltaTime; ;

            // After time is complete
            if (time > 1)
            {

                time = 0;

                //delay time between lerping to display trail
                yield return new WaitForSeconds(2);

                // Get the current lerp value
                // Don't want user to be able to change it mid lerp so update after lerp has completed 
                lerpType = (EasingLerps.EasingLerpsType)easingTypeDropdown.value;
                inOutType = (EasingLerps.EasingInOutType)inOrOutTypeDropdown.value;
            }
    
            
            yield return new WaitForEndOfFrame();

            // recursion
            yield return UpdateGraph();
        }

    }
}