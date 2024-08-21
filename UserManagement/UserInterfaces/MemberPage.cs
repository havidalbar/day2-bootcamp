using Services.Dtos;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserManagement.UserInterfaces
{
    public static class MemberPage
    {
        private static LoginService loginService = LoginService.Instance;
        private static MemberService memberService = MemberService.Instance;
        private static LoginInfo loginInfo = loginService.GetLoginInfo();
        private static List<string> options = new List<string>()
        {
            "Change password",
            "Get Profile Info",
            "Get List Profile Member",
            "Logout"
        };
        public static void Start()
        {
            while (loginInfo.IsLoggedIn)
            {
                var choice = Helpers.GetChoice(options);

                if (choice == options.Count)
                {
                    loginService.Logout();
                    Console.WriteLine("You've logged out.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter member username:");
                            var username = Console.ReadLine();
                            Console.WriteLine("Enter new password:");
                            var password = Console.ReadLine();
                            Console.WriteLine();

                            memberService.UpdatePassword(username, password);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Enter member username (except admin):");
                            var username = Console.ReadLine();
                            var user = memberService.GetUserByUsername(username);
                            Console.WriteLine("Info Profile:");
                            Console.WriteLine(user.ToString());

                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("List Info Profile:");
                            Console.WriteLine(String.Concat(memberService.GetListUser().Select(o => o.ToString() + "\n")));

                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                        break;

                }
            }
        }
    }
}
