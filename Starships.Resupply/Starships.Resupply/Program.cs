using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Starships.Resupply.Application.Interfaces;
using Starships.Resupply.Infra.CrossCutting.IoC;
using Starships.Resupply.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading;

namespace StarWars.Starships.Resupply
{
    public class Program
    {
        static void Main(string[] args)
        {

            var services = Setup();

            ConsoleKeyInfo cki;

            do
            {
                Menu();

                cki = Console.ReadKey(false);
                switch (cki.KeyChar.ToString())
                {
                    case "1":
                        var starshipsService = services.GetService<IStarshipsAppService>();

                        InteractionOne();

                        decimal.TryParse(Console.ReadLine(), out decimal distance);

                        InteractionTwo();

                        var result = starshipsService.CalculateResupplyRequiredForAllStarships(distance).Result;

                        if (!result.Any())
                        {
                            GovermentError();
                        }

                        Console.Clear();
                        Console.WriteLine("Hmmm, I found some information!");
                        Console.WriteLine();
                        Console.WriteLine("═══════════════════════════ RESUPPLY REPORT ═══════════════════════════    ");
                        Console.WriteLine($"  TOTAL DISTANCE: {distance} MGLT");
                        Console.WriteLine("═══════════════════════════════════════════════════════════════════════    ");
                        Console.WriteLine();

                        foreach (var starship in result)
                        {
                            Console.WriteLine($" {starship.StarshipName}  -  {starship.TotalStopsRequired}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("═══════════════════════════════════════════════════════════════════════    ");

                        Console.ReadLine();
                        break;

                    case "2":
                        StarWars();
                        break;

                    default:
                        break;
                }

            } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.NumPad3 && cki.Key != ConsoleKey.D3);
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("╔══════════════════════ MENU ═════════════════════╗    ");
            Console.WriteLine("║  1 - CALCULATE RESUPPLY                         ║    ");
            Console.WriteLine("║  2 - ABOUT                                      ║    ");
            Console.WriteLine("║  3 - EXIT                                       ║    ");
            Console.WriteLine("╚═════════════════════════════════════════════════╝    ");

        }
        static void InteractionOne()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("╔═══════════════════ CALCULATE RESUPPLY ═══════════════════╗    ");
            Console.WriteLine("║  HELLO, JEDI!                                            ║    ");
            Console.WriteLine("║                                                          ║    ");
            Console.WriteLine("║  What's the total distance do you want to travel today?  ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝    ");
        }
        static void InteractionTwo()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("╔═══════════════════ CALCULATE RESUPPLY ═══════════════════╗    ");
            Console.WriteLine("║  Let us begin the research ...                           ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝    ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" MAY THE FORCE BE WITH YOU!! ");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void GovermentError()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════ CALCULATE RESUPPLY ═══════════════════╗    ");
            Console.WriteLine("║  SORRY, JEDI!                                            ║    ");
            Console.WriteLine("║                                                          ║    ");
            Console.WriteLine("║  The government broke our connection, try again later!!  ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝    ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

        }

        static void StarWars()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                       ###########################################    ###############           #######################                  ");
            Console.WriteLine("                     ###                                        ##   ##            ###          ##                    ###                ");
            Console.WriteLine("                    ##                                          ##   ##      #      ##          ##                      ###              ");
            Console.WriteLine("                    ##                                          ##  ##       ##      ##         ##       #########       ##              ");
            Console.WriteLine("                    ##        ################      ############## ###      ###       ##        ##       ##      ##      ##              ");
            Console.WriteLine("                    ###        ###          ##      ##             ##      ## ##      ##        ##       #########       ##              ");
            Console.WriteLine("                      ##         ##         ##      ##            ##      ### ##       ##       ##                      ##               ");
            Console.WriteLine("                       ###        ###       ##      ##            ##      ##   ##       ##      ##                   ####                ");
            Console.WriteLine("                        ###         ##      ##      ##           ##       #######       ##      ##       #          ####                 ");
            Console.WriteLine("    ######################          ##      ##      ##          ##                       ##     ##       ###           ##############    ");
            Console.WriteLine("    ##                              ##      ##      ##         ###                       ###    ##       #####                     ##    ");
            Console.WriteLine("    ##                             ##       ##      ##         ##      #############      ##    ##       ##  ###                   ##    ");
            Console.WriteLine("    ##                         #####        ##      ##        ##       ##          ##      ##   ##       ##    ####                ##    ");
            Console.WriteLine("    ############################            ##########       ###########           ###########  ###########       ###################    ");
            Console.WriteLine("                                                                                                                                         ");
            Console.WriteLine("     ##########    ###########    ###########    ##############           ######################                #####################    ");
            Console.WriteLine("     ##       ##   ##       ###  ##       ##    ##            ##          ##                    ###          ####                  ##    ");
            Console.WriteLine("      ##      ##  ##         ##  ##      ##     ##            ##          ##                      ###       ###                    ##    ");
            Console.WriteLine("      ###      #####          ####      ###    ##      ##      ##         ##                        ##     ###                     ##    ");
            Console.WriteLine("       ##       ###           ####      ##    ##      ###       ##        ##       ##########       ##     ##         ###############    ");
            Console.WriteLine("        ##      ##             ##      ##     ##      ####      ##        ##       ##      ###      ##      ##        ###                ");
            Console.WriteLine("         ##             #             ###    ##      ##  ##      ##       ##       #########       ##        ##         ##               ");
            Console.WriteLine("         ##            ###            ##    ##      ###  ###      ##      ##                     ###           ##        ###             ");
            Console.WriteLine("          ##          #####          ##    ###      ########      ##      ##       #          ####              ###        ##            ");
            Console.WriteLine("           ##         ## ##          ##    ##                      ##     ##       ###          ##################          ##           ");
            Console.WriteLine("           ##        ##   ##        ##    ##                        ##    ##       #####                                    ##           ");
            Console.WriteLine("            ##      ###   ###      ##    ##       ############      ###   ##       ##  ###                                 ##            ");
            Console.WriteLine("            ###     ##     ##     ###    ##      ##          ##      ##   ##       ##    ###                             ###             ");
            Console.WriteLine("             ########       ########    ###########          ###########  ###########      ###############################               ");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("╔══════════════════════ABOUT ═════════════════════╗    ");
            Console.WriteLine("║  DEVELOPER: VICTOR CAVICHIOLLI                  ║    ");
            Console.WriteLine("║  EMAIL: XVICTORPRADO@GMAIL.COM                  ║    ");
            Console.WriteLine("╚═════════════════════════════════════════════════╝    ");

            Console.ReadLine();
        }

        static ServiceProvider Setup()
        {
            //setup our DI
            return new ServiceCollection()
                .AddAutoMapper(typeof(Program))
                .AddStarWarsAPIContext()
                .AddBootStrapperIoC()
                .BuildServiceProvider();
        }

    }
}
