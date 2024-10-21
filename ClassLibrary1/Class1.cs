using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Database<TKey, TValue>
    {
        private TKey[] keys;
        private TValue[] values;
        private int count = 0;
        private int arraySize = 5;
        public Database()
        {
            keys = new TKey[arraySize];
            values = new TValue[arraySize];
        }

        public void Add(TKey key, TValue value)
        {


            if (count < arraySize)
            {
                this.keys[count] = key;
                this.values[count] = value;
                Console.WriteLine(keys[count] + ", " + values[count] + " added. Count:" + (count + 1));
                count++;
            }
            else
            {
                arraySize = arraySize * 2;
                TKey[] tempkeys = new TKey[arraySize];
                TValue[] tempvalues = new TValue[arraySize];
                //copy content of old array into new array
                for (int i = 0; i < count; i++)
                {
                    tempkeys[i] = keys[i];
                    tempvalues[i] = values[i];
                }
                //replace old arrays with new one 
                keys = tempkeys;
                values = tempvalues;

                this.keys[count] = key;
                this.values[count] = value;
                Console.WriteLine(keys[count] + ", " + values[count] + " added after doubling the size of array. Count: " + (count + 1) + ", Array size now: " + arraySize);
                count++;
            }


        }
        // removes the key-value pair with the specified key from the database. Returns true if the pair was removed, false otherwise.
        public bool Remove(TKey key)
        {
            bool result = false;
            for (int i = 0; i < arraySize; i++)
            {
                if (key.Equals(keys[i]))
                {
                    Console.Write(keys[i] + ", " + values[i] + " removed.");
                    for (int j = i; j < arraySize; j++)
                    {
                        if (arraySize - 1 == j)
                        {
                            //keys[j] = default(key);
                            //values[j] = 0;
                            break;
                        }
                        keys[j] = keys[j + 1];
                        values[j] = values[j + 1];


                    }
                    count--;
                    Console.WriteLine(" Count: " + count + ", Array size now: " + arraySize);
                    Console.WriteLine("-------------------");
                    //Print
                    for (int k = 0; k < arraySize; k++)
                    {
                        Console.WriteLine(keys[k] + ", " + values[k]);
                    }

                    return result = true;
                }
            }
            return result;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {

            bool result = false;
            value = default(TValue);
            for (int i = 0; i < count; i++)
            {
                if (keys[i].Equals(key))
                {
                    value = values[i];
                    Console.WriteLine("Value of key " + key + " is: " + value);
                    result = true;
                }
            }
            if (result == false)
            {
                Console.WriteLine("There is no value associated with the specified key");
            }
            return result;
        }
        public int Count()
        {

            return count;

        }

        public void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("Before Swap: Value of a: " + a + ", Value of b: " + b);
            T temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After Swap: Value of a: " + a + ", Value of b: " + b);
        }
    }
}
