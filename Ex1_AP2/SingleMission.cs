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
    public class SingleMission : IMission
    {
        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        private cusFunc delMission = null;
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
        public SingleMission(cusFunc mission, string compName)
        {
            this.delMission = mission;
            this.name = compName;
            this.type = "Single";
        }

        //calculate the value
        public double Calculate(double value)
        {
            //run on all the delegates and make them work
            double sol = delMission.Invoke(value);
            //if the event isn't empty
            if (OnCalculate != null)
            {
                OnCalculate.Invoke(this, sol);
            }
            return sol;
        }
    }
}
