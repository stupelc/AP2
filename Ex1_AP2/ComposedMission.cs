/**
 * Chagit Stupel
 * ID: 209089960
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_AP2
{
    public class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        private cusFunc allDelMission = null;
        private string name;
        private string type;

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }

        }
        public String Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        //constructor for a new ComposedMisission - get name
        //and pointer to function
        public ComposedMission(string compName)
        {
            this.name = compName;
            this.type = "Single";
        }

        //calculate the value
        public double Calculate(double value)
        {
            double result = value;
            //calc all the delegates
            foreach (cusFunc del in allDelMission.GetInvocationList())
            {
                result = del.Invoke(result);
            }

            //if the event isn't empey
            if (OnCalculate != null)
            {
                OnCalculate.Invoke(this, result);
            }
            return result;
        }

        public ComposedMission Add(cusFunc mission)
        {
            //add the mission to the delegates
            allDelMission += mission;
            //return this so we can do fluently programming and add over and over
            return this;
        }


    }
}
