﻿namespace ConsoleApp6;

public class BigInteger
{
    private int[] _numbers;
    public BigInteger(string value)
    {
        var newArray = new List<int>();
        for (int i = value.Length; i >0; i--)
        {
           newArray.Add(int.Parse(value[i-1].ToString()));
        }
        _numbers = newArray.ToArray();
    }
    public override string ToString()
    {
        var res = "";
        for (int i = 0; i <_numbers.Length; i++)
  {
      
      res += _numbers[i].ToString();
  }

        if (res[0]=='0')
        {
            res = res.Substring(1, res.Length - 1);
        }
        return res;
    }
    public int ArrayToInt(int[] digits)
    {
        string result = "";
        for (int i = digits.Length ; i > 0; i--)
        {
            result += digits[i-1] ;
        }

        int final = int.Parse(result);
        return final;
    }

    int Reverse(string digits)
    {
        string result = "";
        for (int i = digits.Length ; i > 0; i--)
        {
            result += digits[i-1] ;
        }
        int final = int.Parse(result);
        return final;
        
    }
    public BigInteger Add(BigInteger another)
    {
        var current = new int[_numbers.Length];
        var addAr = new int[another.ToString().Length];
        
        for (int i =0 ; i <current.Length; i++)
        {
            current[i]= _numbers[i];
         //   Console.WriteLine(current[i]);
        }
        for (int i =0 ; i<addAr.Length; i++)
        {
            addAr[i]= int.Parse(another.ToString()[i].ToString());
        //    Console.WriteLine(addAr[i]);
        }
        var c = 0;
        var ResList =new int[Math.Max(current.Length, addAr.Length)+1];
        for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
        {
            if ((current[i ] + addAr[i ])>=10)
            {
                var split = (current[i ] + addAr[i ]+c).ToString();
                
                c = int.Parse(split[0].ToString());
                ResList[i] = int.Parse(split[1].ToString());
                
            }
            else
            {
                ResList[i] = current[i ] + addAr[i ]+c;
                c = 0;
            }
        }

        if (c>0)
        {
            ResList[Math.Max(current.Length, addAr.Length) ] = c;
        }
        var resText = "";
        for (int i = 0; i <ResList.Length ; i++)
        {
            resText += ResList[i].ToString();
        }

        var result =new BigInteger(resText);
        return result;
    }
    
    public BigInteger Sub(BigInteger another)
    {
        var current = new int[_numbers.Length];
        var addAr = new int[another.ToString().Length];
        
        for (int i =0 ; i <current.Length; i++)
        {
            current[i]= _numbers[i];
            //   Console.WriteLine(current[i]);
        }
        for (int i =0 ; i<addAr.Length; i++)
        {
            addAr[i]= int.Parse(another.ToString()[i].ToString());
            //    Console.WriteLine(addAr[i]);
        }
        var c = 0;
        var ResList =new int[Math.Max(current.Length, addAr.Length)];
        var resText = "";
        if (Reverse(another.ToString())<ArrayToInt(_numbers))
        {
            for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
            {
                var SubNum = 0;
                if (i<addAr.Length)
                {
                    SubNum = addAr[i];
                }
                else
                {
                    SubNum = 0;
                }
                int diff = current[i] - c - SubNum;
                if (diff < 0)
                {
                    c = 1;
                    ResList[i] = diff + 10;
                }
                else
                {
                    c = 0;
                    ResList[i] = diff;
                }
            }
           
            for (int i = 0; i <ResList.Length ; i++)
            {
                resText += ResList[i].ToString();
            }

             
        }
        else if (Reverse(another.ToString())==ArrayToInt(_numbers))
        {
            resText = "0";
        }  else if (Reverse(another.ToString())>ArrayToInt(_numbers))
        {
            for (int i = 0; i < Math.Max(current.Length, addAr.Length); i++)
            {
                var SubNum = 0;
                if (i<current.Length)
                {
                    SubNum = current[i];
                }
                else
                {
                    SubNum = 0;
                }
                int diff = addAr[i]  - c -SubNum;
                if (diff < 0)
                {
                    c = 1;
                    ResList[i] = diff + 10;
                }
                else
                {
                    c = 0;
                    ResList[i] = diff;
                }
            }

            resText += "-";
            for (int i = 0; i <ResList.Length ; i++)
            {
                resText += ResList[i].ToString();
            } 
        }
        
        var result =new BigInteger(resText); 
      
        return result;
    }
}