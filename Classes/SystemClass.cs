using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class SystemClass
    {
        private static List<User> _userList = new List<User>();
        private static SystemClass _instance = null;
        
        private SystemClass()
        {

        }
        public static SystemClass GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SystemClass();
            }
            return _instance;
        }
        private void TryAnythingElse()
        {
            Console.WriteLine("Do you want try anything else?(Y or N)");
            string chosen = Console.ReadLine().ToLower();
            if (chosen == "y" || chosen == "yes")
            {
                Console.Clear();
                Run();
            }
                
            else
            {
                Console.WriteLine("\n\nthank you for try my program");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
        private bool Validate(User user)
        {
            string massage = "\n=====================================Something is Wrong=====================================\n";
            if (_userList.FirstOrDefault(s => s.Phone == user.Phone)!=null)
            {
                Console.WriteLine(massage+"this Phone number already Exist in system please try again!!");
                return false;
            }
            else if (_userList.FirstOrDefault(s => s.Email == user.Email) != null)
            {
                Console.WriteLine(massage+"this Email already Exist in system please try again!!");
                return false;
            }
            return true;
        }
        private bool IsInList(string phone,out int idx)
        {
            var user=_userList.FirstOrDefault(s=>s.Phone == phone);
            if(user==null)
            {
                idx = -1;
                return false;
            }
            idx = _userList.IndexOf(user);
            return true;

        }

        private void Print(User user)
        {
            Console.WriteLine(user);
        }

        private void AddUser()
        {
            User user= new User();
            Console.WriteLine("=====================================Add User========================================");
            Console.Write("Enter Name: ");
            user.Name = Console.ReadLine();
            Console.Write("\nEnter Phone: ");
            user.Phone = Console.ReadLine();
            Console.Write("\nEnter Email: ");
            user.Email = Console.ReadLine();
            if (Validate(user))
            {
                _userList.Add(user);
                Console.WriteLine("=====================================New User You Added===============================");
                Print(user);
                
            }
            else
            {
                AddUser();
            }
            TryAnythingElse();
        }

        private void UpdateData()
        {
            
            User user = new User();
            Console.WriteLine("=====================================Update Data of User=============================");
            Console.Write("Enter User Phone Number You Want To Edit:");
            user.Phone = Console.ReadLine();
            if (!IsInList(user.Phone,out int index))
            {
                Console.WriteLine("Not found this user in the system!!!");
            }
            else
            {
                Console.WriteLine("1-Edit Name\t2-Edit Phone\t3-Edit Email");
                Console.Write("Enter to Edit:");
                int chosen=Convert.ToInt32(Console.ReadLine());
                user=new User();
                switch (chosen)
                {
                    case 1:
                        Console.Write("Enter new Name:");
                        user.Name = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter new Phone:");
                        user.Phone = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter New Email:");
                        user.Email = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("\n=====================================Something is Wrong=====================================\n");
                        Console.WriteLine("please try again!!");
                        UpdateData();
                        break;
                }
                if(Validate(user))
                {
                    if (chosen == 1) _userList[index].Name = user.Name;
                    else if (chosen == 2) _userList[index].Phone = user.Phone;
                    else if (chosen == 3) _userList[index].Email = user.Email;
                    Console.WriteLine("=====================================New User Information You Edited=====================================");
                    Print(_userList[index]);
                }
                else
                {
                    UpdateData();
                }
            }
            
            TryAnythingElse();
        }

        private void DeleteUser()
        {
            User user = new User();
            Console.WriteLine("=====================================Delete User=====================================");
            Console.Write("Enter User Phone Number You Want To Delete:");
            user.Phone = Console.ReadLine();
            if (!IsInList(user.Phone, out int index))
            {
                Console.WriteLine("Not found this user in the system!!!");
                goto TRYA;
            }
            else
            {
                _userList.RemoveAt(index);
            }
            TRYA:
            TryAnythingElse();
        }

        private void PrintAll()
        {
            Console.WriteLine("==================================Print All Users================================");
            if (_userList.Count > 0)
            {
                for(int i=0;i< _userList.Count; i++)
                {
                    Console.WriteLine($"User {i+1}");
                    Print(_userList[i]);
                    Console.WriteLine("***********************************************");
                }
            }
            else
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("the system is Empty!!");
                Console.WriteLine("**********************************");
                Run();
            }
            
            TryAnythingElse();
        }

        public void Run()
        {
            Console.WriteLine("1-Add User\n2-Update Data of User\n3-Delete User\n4-Print All Users\n5-Exit");
            Console.Write("enter number (1~4):");
            int chosen=Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (chosen)
            {
                case 1:
                    AddUser();
                    break;
                case 2:
                    UpdateData();
                    break;
                case 3:
                    DeleteUser();
                    break;
                case 4:
                    PrintAll();
                    break;
                case 5:
                    Console.WriteLine("\n\nthank you for try my program");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid input Please try again!!");
                    Console.WriteLine("=====================================================================================");

                    Run();
                    break;
            }



        }

    }
}
