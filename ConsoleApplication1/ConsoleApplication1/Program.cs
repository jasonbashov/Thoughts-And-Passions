using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public delegate int Func();

        //Instantiate a Singleton of the Semaphore with a value of 1. This means that only 1 thread can be granted access at a time.
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        delegate void TestDelegate(string s);

        static void Main(string[] args)
        {
            PlayingWithDefaultIfEmpty();

            //PlayingWithTryGetValue();

            //PlayingWithSemaphore();
            //Console.ReadKey();

            //PlayingWithNewFeatures(new Department() { Name = "123", Id = 3});

            //PlayingWithDateFormats();

            //PlayingWithExceptions();

            //PlayingWithDates();

            //PlayingWithDelegates();

            //PlayingWithReferences();
        }

        private static void PlayingWithDefaultIfEmpty()
        {
            // Empty list.
            List<int> list = new List<int>();
            var result = list.DefaultIfEmpty();

            // One element in collection with default(int) value.
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }

            list = new List<int>();
            result = list.DefaultIfEmpty(-1);

            // One element in collection with -1 value.
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }

            list = new List<int>();
            var average = list.DefaultIfEmpty(-1).Average();

            Console.WriteLine(average);
        }

        //private static void PlayingWithFuncsAsParameters()
        //{
        //    BaseClass bc = new BaseClass();
        //    ClassThatGetsPassedArgumrents ctgpa = new ClassThatGetsPassedArgumrents(bc.Foo, new Action<string>(bc.FooWithParameter), new Func(bc.AnswerToEveryThing));
        //    int answer = ctgpa.AnswerToEveryThing();
        //    //ctgpa = new ClassThatGetsPassedArgumrents(bc.Foo, new Action<string>(staticClass.FooWithParameter),  new Func(staticClass.AnswerToEveryThing));
        //    ctgpa.Foo();
        //    ctgpa.FooWithParameter("myParameters");
        //    Console.WriteLine("AnswerToEverything = " + answer);
        //    Console.ReadLine();
        //}

        private static void PlayingWithTryGetValue()
        {
            var counts = new Dictionary<int, Department>();
            counts.Add(1, new Department());

            counts.TryGetValue(2, out var depart);

            if (depart == null)
            {
                Console.WriteLine("DEPARTMENT IS NULL");
            }
            else
            {
                Console.WriteLine("Department is NOT null");
            }
        }

        private static async void PlayingWithSemaphore()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"starting iteration #{i}");

                //Asynchronously wait to enter the Semaphore. If no-one has been granted access to the Semaphore, code execution will proceed,
                //otherwise this thread waits here until the semaphore is released 
                await semaphoreSlim.WaitAsync();
                try
                {
                    Console.WriteLine($"before Task.Delay Counter#{i}");
                    await Task.Delay(1000);
                    Console.WriteLine($"after Task.Delay Counter#{i}");
                }
                finally
                {
                    Console.WriteLine($"in finally block #{i}");

                    //When the task is ready, release the semaphore. It is vital to ALWAYS release the semaphore when we are ready, or 
                    //else we will end up with a Semaphore that is forever locked.
                    //This is why it is important to do the Release within a try...finally clause; program execution may crash or take
                    //a different path, this way you are guaranteed execution
                    semaphoreSlim.Release();
                }

                Console.WriteLine($"ending iteration #{i}");
            }

        }

        private static void PlayingWithNewFeatures(Department department)
        {
            var output = department?.Id;
            Console.WriteLine(output);
        }

        private static void TestGetDateRangeBetweenDays(Department department)
        {
            var dateRange = DateRange.GetDateRangeBetweenDays("3", "-3");
            Console.WriteLine("From {0}; To {1}", dateRange.FromDate.Value, dateRange.ToDate.Value);
        }

        private static void PlayingWithDateFormats()
        {
            const string Time24HourFormat = "HH:mm";
            const string Time12HourFormat = "hh:mm tt";
            const string Time24HourLongFormat = "HH:mm:ss";
            const string Time12HourLongFormat = "hh:mm:ss tt";
            const string AmericanLongDateFormat = "MMMM dd, yyyy";
            const string DefaultLongDateFormat = "dd MMMM yyyy";
            const string AmericanShortDateFormat = "MM/dd/yyyy";
            const string DefaultShortDateFormat = "dd/MM/yyyy";
            const string AmericanLongDateMonthAndYearFormat = "MMMM, yyyy";
            const string DefaultLongDateMonthAndYearFormat = "MMMM yyyy";
            const string AmericanLongDateWithWeekDayFormat = "ddd MMM d, yyyy";
            const string DefaultLongDateWithWeekDayFormat = "ddd d MMM yyyy";
            const string ShortDateMonthAndYearFormat = "MM/yyyy";

            var dateNow = DateTime.Now; // = 29/08/2017 16:08:39
            Console.WriteLine("Format: {0,19}| Time: {1,16}", Time24HourFormat + "|HH:m|H:m|H:mm", dateNow.ToString(Time24HourFormat)); //24 hours time "16:08"
            Console.WriteLine("Format: {0,19}| Time: {1,16}", Time12HourFormat, dateNow.ToString(Time12HourFormat)); //12 hours time "04:08 PM"
            Console.WriteLine("Format: {0,19}| Time: {1,16}", Time24HourLongFormat + "|H:m:s", dateNow.ToString(Time24HourLongFormat)); //24 hours time with seconds "16:30:03"
            Console.WriteLine("Format: {0,19}| Time: {1,16}", Time12HourLongFormat, dateNow.ToString(Time12HourLongFormat)); //American time "04:30:03 PM"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", AmericanLongDateFormat, dateNow.ToString(AmericanLongDateFormat)); //American long date "August 30, 2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", DefaultLongDateFormat, dateNow.ToString(DefaultLongDateFormat)); //Default long date "30 August 2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", AmericanShortDateFormat, dateNow.ToString(AmericanShortDateFormat)); //American short date "08/30/2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", DefaultShortDateFormat, dateNow.ToString(DefaultShortDateFormat)); //default short date "30/08/2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", AmericanLongDateMonthAndYearFormat, dateNow.ToString(AmericanLongDateMonthAndYearFormat)); // "August, 2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", DefaultLongDateMonthAndYearFormat, dateNow.ToString(DefaultLongDateMonthAndYearFormat));// "August 2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", AmericanLongDateWithWeekDayFormat, dateNow.ToString(AmericanLongDateWithWeekDayFormat)); //American semi-long date "Wed Aug 30, 2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", DefaultLongDateWithWeekDayFormat, dateNow.ToString(DefaultLongDateWithWeekDayFormat)); //default semi-long date "Wed 30 Aug 2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", ShortDateMonthAndYearFormat, dateNow.ToString(ShortDateMonthAndYearFormat)); //Short Month and year "08/2017"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", "ToString(\"o\")", dateNow.ToString("o")); //ISO format "2017-08-30T08:52:01.8717133+03:00"
            Console.WriteLine("Format: {0,19}| Date: {1,16}", "dateNow", dateNow); //current culture format (EN-US) "8/30/2017 8:52:01 AM"

        }

        private static void PlayingWithExceptions()
        {
            try
            {
                throw new Exception("Big bang");
            }
            catch (HoursAllowedValidationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Aloha");
        }

        private static void PlayingWithDates()
        {
            var asd = new Department() { SomeDate = DateTime.Now };
            var originalDate = asd.SomeDate;
            asd.SomeDate = DateTime.Now.AddDays(2);

            Console.WriteLine(originalDate.ToShortDateString());
            Console.WriteLine(asd.SomeDate.ToShortDateString());

            var firstStartDate = Convert.ToDateTime("2017-05-22 12:05:00.000");
            var firstEndDate = Convert.ToDateTime("2017-05-19 12:30:00.000");
            var secondStartDate = Convert.ToDateTime("2017-05-22 12:05:00.000");
            var secondEndDate = Convert.ToDateTime("2017-05-22 12:30:00.000");

            var a = (firstEndDate - firstStartDate) + (secondEndDate - secondStartDate);
            Console.WriteLine(a.TotalHours);
        }

        private static void PlayingWithDelegates()
        {
            TestDelegate myDel = n =>
            {
                string s = n + " " + "you fok ";
                Console.WriteLine(s);
            };
            myDel("Hello");
        }

        private static void PlayingWithReferences()
        {
            //playing with references
            var departments1 = new List<Department>()
            {
                new Department() {Name = "First"},
                new Department() {Name = "Second"},
            };
            var departments2 = new List<Department>()
            {
                new Department() {Name = "First2"},
                new Department() {Name = "Second2"},
            };

            var locatoins = new List<Location>()
            {
                new Location() {Departments = departments1},
                new Location() {Departments = departments2}
            };

            //var asd = DoStuff(locatoins);

            var department = new Department() { Name = "Bai Pesho" };

            department.Nicknames.Add("Pesho opasniq");

            DoStuff(ref department);

            foreach (var nickname in department.Nicknames)
            {
                Console.WriteLine(nickname);
            }

            var a = 1;
        }

        static Department DoStuff(Department department)
        {
            if (department.IsActive)
            {
                department.Name = "Active Name";
            }
            else
            {
                department.Nicknames.Add("Shano manqk");
            }

            return department;
        }

        static void DoStuff(ref Department department)
        {
            if (department.IsActive)
            {
                department.Name = "Active Name";
            }
            else
            {
                department.Nicknames.Add("Shano REF manqk");
            }
        }

        static List<Location> DoStuff(List<Location> locations)
        {
            var newList = new List<Location>();
            locations.RemoveAt(0);
            //newList = locations;
            locations.Add(new Location() { Departments = new List<Department>() { new Department() { Name = "asdas" } } });
            return locations;
        }

        static DateRange GetDateRangeBetweenDays(string daysBefore, string daysAfter)
        {
            //if (daysBefore.IsNullOrWhiteSpace() && daysAfter.IsNullOrWhiteSpace())
            //{
            //    return GetYesterdayDateRange();
            //}

            var dateRange = new DateRange();
            int value;
            if (int.TryParse(daysBefore, out value))
                dateRange.From = DateTime.Now.AddDays(-value).ToShortDateString();

            if (int.TryParse(daysAfter, out value))
                dateRange.To = DateTime.Now.AddDays(value).ToShortDateString();

            return dateRange;
        }
    }

    //public class ClassThatGetsPassedArgumrents
    //{
    //    private MethodInvoker fooPointer;
    //    private Program.Func answerPointer;
    //    private Action<string> fooWithParamsPointer;

    //    public ClassThatGetsPassedArgumrents(MethodInvoker foo, Action<String> fooWithParams, Program.Func answer)
    //    {
    //        fooPointer = foo;
    //        fooWithParamsPointer = fooWithParams;
    //        answerPointer = answer;
    //    }

    //    public void Foo()
    //    {
    //        fooPointer();
    //    }

    //    public void FooWithParameter(string s)
    //    {
    //        fooWithParamsPointer(s);
    //    }

    //    public int AnswerToEveryThing()
    //    {
    //        return answerPointer();
    //    }

    //}

    //public class BaseClass
    //{

    //    public void Foo()
    //    {
    //        Console.WriteLine("foo");
    //    }

    //    public void FooWithParameter(string s)
    //    {
    //        Console.WriteLine("foo with parameter {0}", s);
    //    }

    //    public int AnswerToEveryThing()
    //    {
    //        return 42;
    //    }
    //}

    //public class staticClass
    //{
    //    public static void Foo()
    //    {
    //        Console.WriteLine("foo");
    //    }

    //    public static void FooWithParameter(string s)
    //    {
    //        Console.WriteLine("foo with parameter {0}", s);
    //    }

    //    public static int AnswerToEveryThing()
    //    {
    //        return 42;
    //    }
    //}

    public class DateRange
    {
        private string _from = "";
        private string _to = "";
        /// <summary>
        /// Start date in string format
        /// </summary>
        public string From
        {
            get { return _from; }
            set
            {
                _from = value;
                DateTime from;
                FromDate = DateTime.TryParse(value, out from) ? from : (DateTime?)null;
            }
        }
        /// <summary>
        /// End date in string format
        /// </summary>
        public string To
        {
            get { return _to; }
            set
            {
                _to = value;
                DateTime to;
                ToDate = DateTime.TryParse(value, out to) ? to : (DateTime?)null;
            }
        }
        /// <summary>
        /// ISO 8601 representation of the start date
        /// </summary>
        public DateTime? FromDate { get; set; }
        /// <summary>
        /// ISO 8601 representation of the end date
        /// </summary>
        public DateTime? ToDate { get; set; }

        public bool Valid
        {
            get { return FromDate.HasValue && ToDate.HasValue; }
        }

        public long DaysInRange()
        {
            return (long)(ToDate - FromDate).Value.TotalDays;
        }

        public static DateRange GetYesterdayDateRange()
        {
            var yesterday = DateTime.UtcNow.AddDays(-1).Date;
            return new DateRange() { FromDate = yesterday, ToDate = yesterday.AddDays(1).AddTicks(-1) };
        }

        public static DateRange GetDateRangeBetweenDays(string daysBefore, string daysAfter)
        {
            //if (daysBefore.IsNullOrWhiteSpace() && daysAfter.IsNullOrWhiteSpace())
            //{
            //    return GetYesterdayDateRange();
            //}

            var dateRange = new DateRange();
            int value;
            if (int.TryParse(daysBefore, out value))
                dateRange.From = DateTime.Now.AddDays(-value).ToShortDateString();

            if (int.TryParse(daysAfter, out value))
                dateRange.To = DateTime.Now.AddDays(value).ToShortDateString();

            return dateRange;
        }

        public static DateRange GetDateRangeBetweenDates(string from, string to)
        {
            //if (from.IsNullOrWhiteSpace() && to.IsNullOrWhiteSpace())
            //{
            //    return GetYesterdayDateRange();
            //}
            return new DateRange() { From = from, To = to };
        }
    }

    public class HoursAllowedValidationException : Exception
    {

    }

    class Location
    {
        public List<Department> Departments { get; set; }
    }

    class Department
    {
        public Department()
        {
            this.Nicknames = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime SomeDate { get; set; }
        public List<string> Nicknames { get; set; }
    }
}
