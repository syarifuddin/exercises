<Query Kind="Program" />

void Main()
{
/**You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
**/
//Enumerable.Range(1900, 2000 - 1900).Dump();
var epoch = new DateTime(1900, 1, 1);
var months = Enumerable.Range(1,12);
var allMonths = Enumerable.Range(1901, 2001 - 1901).SelectMany(y=> months.Select(m => new { day = 1 , month = m, year = y}));
//allMonths.Where(i => DayOfWeek(i.day, i.month, i.year) == 7).Count().Dump();//
DayOfWeek(23, 5, 2000).Dump();
}

public static bool IsLeap(int year) {
	return year%4 == 0 && (year%100 != 0 || year%400 == 0);
}

public int DayOfWeek(int day, int month, int year){
	var days = CalculateDaysFromEpoch(day,month, year);
	return (days % 7) + 1;
}

public static int CalculateDaysFromEpoch(int day, int month, int year){
   var days = day - 1;
   var daysFromMonth = CalculateDaysOfMonths(month, year);
   var dayFromYear = CalculateDaysOfYears(year, month);
   
	return days + daysFromMonth + dayFromYear;
}

public static int CalculateDaysOfYears(int year, int month){
	var days = Enumerable.Range(1900, year - 1900).Select(y=> {
	 if(y == year && month < 3) return 365;
	return IsLeap(y) ? 366 : 365;
	});
	return days.Sum();
}

public static readonly int[] ThirtyDaysMonth =  { 4, 6, 9, 11 }; 
public static int CalculateDaysOfMonths(int months, int year){
	var days = Enumerable.Range(1, months - 1).Select(m=> {
		if (m == 2) return IsLeap(year) ? 29 : 28;
		if (ThirtyDaysMonth.Contains(m)) return 30;
		else return 31;
		
	});
	return days.Sum();
}

// Define other methods and classes here