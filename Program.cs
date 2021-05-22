using System;
using System.Linq;
using System.Threading;

namespace TurkishIdNumber
{
    class Program
    {
        static int CharToInt(char charNumber) {
            return int.Parse(charNumber.ToString());
        }
        static bool IsNumeric(string text) {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        static int TenthDigit(int dp1, int dp2, int dp3, int dp4, int dp5, int dp6, int dp7, int dp8, int dp9) {
            return CharToInt(((dp1+dp3+dp5+dp7+dp9)*7 + (dp2+dp4+dp6+dp8)*9).ToString().Last());
        }
        static int EleventhDigit(int dp1, int dp2, int dp3, int dp4, int dp5, int dp6, int dp7, int dp8, int dp9) {
            return CharToInt(((dp1+dp3+dp5+dp7+dp9)*8).ToString().Last());
        }
        static int Query(string idNumber, int length) {
            if(IsNumeric(idNumber)) {
                if(idNumber.Length == length) {
                    int dp1 = CharToInt(idNumber[0]);
                    if(dp1 != 0) {
                        return 0;
                    }
                    else {
                        return 1;
                    }
                }
                else {
                    return 2;
                }
            }
            else {
                return 3;
            }
        }
        static void Main(string[] args)
        {
            while(true) {
                Console.Clear();
                Console.Write("Operations:\n1 - For check Turkish Identification Number correction\n2 - For find 10. and 11. digits from first nine digits\n3 - For exit\nEnter an operation number : ");
                string operation = Console.ReadLine(), idNumber;
                int dp1, dp2, dp3, dp4, dp5, dp6, dp7, dp8, dp9, dp10, dp11, _dp10, _dp11;
                switch (operation) {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter a Turkish Identification Number : ");
                        idNumber = Console.ReadLine();
                        
                        switch(Query(idNumber, 11)) {
                            case 0:
                                dp1 = CharToInt(idNumber[0]);
                                dp2 = CharToInt(idNumber[1]);
                                dp3 = CharToInt(idNumber[2]);
                                dp4 = CharToInt(idNumber[3]);
                                dp5 = CharToInt(idNumber[4]);
                                dp6 = CharToInt(idNumber[5]);
                                dp7 = CharToInt(idNumber[6]);
                                dp8 = CharToInt(idNumber[7]);
                                dp9 = CharToInt(idNumber[8]);
                                dp10 = CharToInt(idNumber[9]);
                                dp11 = CharToInt(idNumber[10]);

                                _dp10 = TenthDigit(dp1,dp2,dp3,dp4,dp5,dp6,dp7,dp8,dp9);
                                _dp11 = EleventhDigit(dp1,dp2,dp3,dp4,dp5,dp6,dp7,dp8,dp9);

                                if(dp10 == _dp10 && dp11 == _dp11) {
                                    Console.Clear();
                                    Console.WriteLine("This Turkish Identification Number can exist.");
                                }
                                else {
                                    Console.Clear();
                                    Console.WriteLine("This Turkish Identification Number can not exist!!");
                                }
                                Console.ReadKey();
                                continue;
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Turkish Identification Numbers can not start with 0.");
                                Console.ReadKey();
                                continue;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Turkish Identification Numbers must have 11 digits.");
                                Console.ReadKey();
                                continue;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("You must enter a numeric thing.");
                                Console.ReadKey();
                                continue;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Enter first nine digits of Turkish Identification Number which you want to find 10. and 11. digits :");
                        idNumber = Console.ReadLine();

                        switch(Query(idNumber, 9)) {
                            case 0:
                                dp1 = CharToInt(idNumber[0]);
                                dp2 = CharToInt(idNumber[1]);
                                dp3 = CharToInt(idNumber[2]);
                                dp4 = CharToInt(idNumber[3]);
                                dp5 = CharToInt(idNumber[4]);
                                dp6 = CharToInt(idNumber[5]);
                                dp7 = CharToInt(idNumber[6]);
                                dp8 = CharToInt(idNumber[7]);
                                dp9 = CharToInt(idNumber[8]);

                                _dp10 = TenthDigit(dp1,dp2,dp3,dp4,dp5,dp6,dp7,dp8,dp9);
                                _dp11 = EleventhDigit(dp1,dp2,dp3,dp4,dp5,dp6,dp7,dp8,dp9);

                                Console.Clear();
                                Console.WriteLine("Turkish Identification Number with 10. and 11. digits :" + idNumber + _dp10 + _dp11);
                                Console.ReadKey();
                                continue;
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Turkish Identification Numbers can not start with 0.");
                                Console.ReadKey();
                                continue;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("You must enter first nine digits.");
                                Console.ReadKey();
                                continue;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("You must enter a numeric thing.");
                                Console.ReadKey();
                                continue;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default :
                        Console.Clear();
                        Console.WriteLine("You choose wrong option, application restarting...");
                        Thread.Sleep(2000);
                        continue;
                }
                Console.ReadKey();
            }
        }
    }
}
