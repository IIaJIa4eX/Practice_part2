using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LocalUserCreator
{
    //for_review
    internal class Program
    {

        static void Main(string[] args)
        {


            Console.WriteLine("AppStart");


            createUser("TestUser", "123456");

        }


        public static void createUser(string Name, string Pass)
        {


            try
            {
                DirectoryEntry AD = new DirectoryEntry("WinNT://" +
                                    Environment.MachineName + ",computer");

                
                DirectoryEntry NewGroup = AD.Children.Add("Test Group", "Group");

                if (DirectoryEntry.Exists(NewGroup.Path))
                {
                    AD.Children.Remove(NewGroup);
                }
                NewGroup.Invoke("Put", new object[]
                {
                    "Description", "Test Group for lesson 3"
                });

                NewGroup.CommitChanges();

                Console.WriteLine("Group Created Successfully");


                DirectoryEntry NewUser = AD.Children.Add(Name, "user");

                NewUser.Invoke("SetPassword", new object[] { Pass });
                NewUser.Invoke("Put", new object[]
                {
                    "Description", "Test User for lesson 3"
                });

                NewUser.CommitChanges();

                DirectoryEntry grp;

                grp = AD.Children.Find("Test Group", "group");
                if (grp != null)
                {
                    grp.Invoke("Add", new object[]
                    {
                        NewUser.Path.ToString()
                    });
                }
                Console.WriteLine("Account Created Successfully");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }

        }
    }
}
