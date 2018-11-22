using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDD_term_4
{
    class Doomsday
    {
        public const int THURSDAY = 0;
        public const int FRIDAY = 1;
        public const int SATURDAY = 2;
        public const int SUNDAY = 3;
        public const int MONDAY = 4;
        public const int TUESDAY = 5;
        public const int WEDNESDAY = 6;
        public const int TRUE = 1;
        public const int FALSE = 0;
        public const int DAYS_PER_WEEK = 7;

        public const int JAN = 1;
        public const int FEB = 2;
        public const int MAR = 3;
        public const int APR = 4;
        public const int MAY = 5;
        public const int JUN = 6;
        public const int JUL = 7;
        public const int AUG = 8;
        public const int SEP = 9;
        public const int OCT = 10;
        public const int NOV = 11;
        public const int DEC = 12;


        private int reference (int month, int leapYear)
            {
           int reference = 0;
           if(month == JAN) {
              if (leapYear == TRUE) {
                 reference = 4;
           } else {
              reference = 3;
              }
           }
        // Results vary depending on if the year is a leap year.
           if(month == FEB) {
              if (leapYear == TRUE) {
                 reference = 29;
           } else {
              reference = 28;
              }
           }
   
        // Much more straight foward after February, leap years no longer matter
           if (month == MAR) {
              reference = 0;
           }
   
           if (month == APR) {
              reference = 4;
           }
           if (month == MAY) {
              reference = 9;
           }
           if (month == JUN) {
              reference = 6;
           }   
           if (month == JUL) {
              reference = 11;
           }
           if (month == AUG) {
              reference = 8;
           }
           if (month == SEP) {
              reference = 5;
           }
           if (month == OCT) {
              reference = 10;
           }
           if (month == NOV) {
              reference = 7;
           }
           if (month == DEC) {
              reference = 12;
           }
           return reference;
        }

        public int dayOfWeek(int doomsday, int year, int month, int day)
        {
            int output;
            int difference;
            int targ = doomsday;
            int leapYear = FALSE;

            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        leapYear = TRUE;
                    } else { leapYear = FALSE; }
                } else { leapYear = TRUE; }
            } else { leapYear = FALSE; }


            // Uses a loop to count up or down (depending on if doomsdate is > target day)
            // Up
            if (reference (month, leapYear) <= day) {
                difference = day - reference(month, leapYear);
                while (difference != 0)
                {
                    targ += 1;
                    difference -= 1;
                    if (targ == 7)
                    {
                        targ = 0;
                    }
                }
                output = targ;
                // Down
            } else {
                difference = reference (month, leapYear) - day;
                while (difference != 0)
                {
                    targ -= 1;
                    difference -= 1;
                    if (targ == -1)
                    {
                        targ += 7;
                    }
                }
                output = targ;
            }
            return output;
        }
    }
}
