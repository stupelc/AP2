using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_AP2
{
    //delegate to function that gets a number and return the result (which will be in double)
    public delegate double cusFunc(double num);
    public class FunctionsContainer
    {
        //dictionary from string to his fuction in the dictionary
        Dictionary<string, cusFunc> dictionary;
        public FunctionsContainer()
        {
            dictionary = new Dictionary<string, cusFunc>();
        }

        //get the value from the dictionary or return itself if we dint fint the key
        //build up our dictionary or get value from him according to the key
        public cusFunc this[String key]
        {
            get
            {
                cusFunc newMission;
                //get value from our dictionary - if find it
                if (dictionary.TryGetValue(key, out newMission))
                {
                    return dictionary[key];
                }
                //if dont find it create a 'stam' action and put it in our dictionary
                else
                {
                    //using 'lamda expression' add a new action to our dictionary
                    dictionary[key] = (x) => x;
                    return dictionary[key];
                }
            }

            set
            {
                dictionary[key] = value;
            }
        }


        //return all the keys in the Dictionary - all the available funcs
        public Array getAllMissions()
        {
            return dictionary.Keys.ToArray();
        }
    }
}
