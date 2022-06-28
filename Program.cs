using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Linq;
using TestNew.interfaces;
using TestNew.Models;
using TestNew.Repos;
using TestNew.Repos.Interfaces;
using TestNew.Services;
using TestNew.Services.Interfaces;

namespace TestNew
{
    /// <summary>
    /// Loan Viabillity App
    /// </summary>
    class Program
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var loanService = host.Services.GetService<ILoanService>();

            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("To attain suitability for a loan, please enter the following details.");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("**************** (type quit at anytime to end program) **************\n\n");
            
            while (true)
            {
                var amount = ValidInput("Loan Amount");
                var assetValue = ValidInput("Asset Value");
                var creditScore = ValidInput("Client Credit Score");

                var claim = new Claim(amount, assetValue, creditScore, null);
                Logger.Info($"New claim application for {claim}");
                Console.WriteLine($"New claim application for {claim}");

                try 
                {
                    var successfulCritiera = loanService.ClaimSuccessful(claim);
                
                
                    if (successfulCritiera != null)
                    {
                        Console.WriteLine($"Success with Criteria: {successfulCritiera}\n");
                        Logger.Info($"Successful claim: {claim} with criteria {successfulCritiera}");
                        claim.SetApproval(true);
                        loanService.AddClaim(claim);
                    }
                    else
                    {
                        Console.WriteLine($"Failed with claim: {claim}\n");
                        Logger.Info($"Failed with claim: {claim}");
                    }

                    var claims = loanService.GetClaims();
                    var successfulClaimsCount = claims.Where(claim => claim.Approved == true).Count();
                    var unsuccessfulClaimCount = claims.Where(claim => claim.Approved == false).Count();
                    var meanLtv = claims.Select(claim => claim.Ltv).ToArray().Average();
                    var totalLoans = claims.Select(claim => claim.Amount).ToArray().Sum();

                    Console.WriteLine("\nNo. Claims\tSuccessful\tUnsuccessful\tMeanLtv\t\tTotalLoaned");
                    Console.WriteLine($"{claims.Count()}\t\t{successfulClaimsCount}\t\t{unsuccessfulClaimCount}\t\t{meanLtv.ToString("00.00")}%\t\t{totalLoans}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Logger.Error(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <param name="inputType">Type of the input.</param>
        /// <returns></returns>
        private static int ValidInput(string inputType)
        {
            while (true)
            {
                Console.WriteLine($"Enter {inputType}:");
                var v = Console.ReadLine();

                if (v == "quit")
                {
                    Environment.Exit(0);
                }

                int response;
                if (int.TryParse(v, out response) && response > 0)
                {
                    return response;
                }

                Console.WriteLine($"Invalid {inputType} entered, please try again");
            }
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IClaimRepo, ClaimRepo>();
                    services.AddSingleton<ICriteriaRepo, CriteriaRepo>();
                    services.AddSingleton<ILoanService, LoanService>();
                });

            return hostBuilder;
        }
    }
}