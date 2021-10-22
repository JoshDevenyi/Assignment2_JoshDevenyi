using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_n01486790.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        ///  A program that provides the total calories amount of a user's meal based on their four menu choices.
        /// </summary>
        /// <param name="BurgerChoice"> The user's choice of burger option from the menu (1, 2, 3, or 4) </param>
        /// <param name="DrinkChoice"> The user's choice of drink option from the menu (1, 2, 3, or 4) </param>
        /// <param name="SideChoice"> The user's choice of side option from the menu (1, 2, 3, or 4) </param>
        /// <param name="DessertChoice"> The user's choice of dessert option from the menu (1, 2, 3, or 4) </param>
        /// <returns> A message stating the sum of calories for all the food choices made by the user. </returns>
        /// <example>
        ///  GET : /api/j1/Menu/1/2/3/4 -> Your total calorie count is 691 ""
        /// </example>
        [HttpGet]
        [Route("api/j1/Menu/{BurgerChoice}/{DrinkChoice}/{SideChoice}/{DessertChoice}")]
        public string Menu(int BurgerChoice, int DrinkChoice, int SideChoice, int DessertChoice)
        {

            int TotalCalorie = 0;
            string message = "Your total calorie count is ";

            //Checks User's Choice of Burger
            if (BurgerChoice == 1) TotalCalorie = TotalCalorie + 461;

            else if (BurgerChoice == 2) TotalCalorie = TotalCalorie + 431;

            else if (BurgerChoice == 3) TotalCalorie = TotalCalorie + 420;

            else if (BurgerChoice == 4) TotalCalorie = TotalCalorie + 0;


            //Checks User's Choice of Drink
            if (DrinkChoice == 1) TotalCalorie = TotalCalorie + 130;

            else if (DrinkChoice == 2) TotalCalorie = TotalCalorie + 160;

            else if (DrinkChoice == 3) TotalCalorie = TotalCalorie + 118;

            else if (DrinkChoice == 4) TotalCalorie = TotalCalorie + 0;


            //Check User's Choice of Side
            if (SideChoice == 1) TotalCalorie = TotalCalorie + 100;

            else if (SideChoice == 2) TotalCalorie = TotalCalorie + 57;

            else if (SideChoice == 3) TotalCalorie = TotalCalorie + 70;

            else if (SideChoice == 4) TotalCalorie = TotalCalorie + 0;


            //Check User's Choice of Dessert
            if (DessertChoice == 1) TotalCalorie = TotalCalorie + 167;

            else if (DessertChoice == 2) TotalCalorie = TotalCalorie + 266;

            else if (DessertChoice == 3) TotalCalorie = TotalCalorie + 75;

            else if (DessertChoice == 4) TotalCalorie = TotalCalorie + 0;

            //Returns final message
            message = message + TotalCalorie.ToString();

            return message;
        }

    }


}
