
int numStudents = 0;
int controlNumber = 9;

do
{
    Console.Write("How many students do you have to enter? ");
    numStudents = Convert.ToInt32(Console.ReadLine());

    if(numStudents > controlNumber)
    {
       System.Console.WriteLine( "Invalid it needs to be less then 20");
    }

}while(numStudents > controlNumber);

string[] students = new string[numStudents];


//limit this to 10 or less
for(int i = 0; i < numStudents; i++)
{
    if((i + 1) == 1)//first student
    {
        System.Console.Write($"Enter the student full name for the {i + 1}st student: ");
    }

    else if((i + 1 ) == 2)//second
    {
        System.Console.Write($"Enter the student full name for the {i + 1}nd student: ");
    }
    
    else if((i + 1 ) == 3)//third
    {
        System.Console.Write($"Enter the student full name for the {i + 1}rd student: ");
    }
    else
    {
        System.Console.Write($"Enter the student full name for the {i + 1}th student: "); 
    }

    // else if((i + 1 ) >= 4)//third
    // {
    //     System.Console.Write($"Enter the student full name for the {i + 1}th student: ");
    // }

    students[i] = Console.ReadLine().Trim();
}

string[] userNames = MakeUsernameFromArray(students);


int[] studentIDs = new int[numStudents];

for(int i = 0; i < numStudents; i++)
{
    studentIDs[i] = MakeUserId();
}

int[] studentLockerNum = new int[numStudents];

for(int i = 0; i < numStudents; i++)
{
    studentLockerNum[i] = GetLockerNumber();
}

int userChoice = 0;

do{

    PrintOutAllStudents(students);

    System.Console.Write("Which student do you want to see more information on? -1 to exit");
    userChoice = Convert.ToInt32(Console.ReadLine());

    DisplayASingleStudentInformation(students, userNames, studentIDs, studentLockerNum, userChoice);

}while(userChoice != -1);




// Console.Write("Please give me your first name. ");
// string firstName = Console.ReadLine();

// Console.Write("Please give me your last name. ");
// string lastName = Console.ReadLine();

// string userName = MakeUsername(firstName, lastName);

// System.Console.WriteLine($"Your user name is {userName}.");

// int studentId = MakeUserId();
// int studentLockerNumber = GetLockerNumber();
// int checkDigit = CheckDigit(studentId); 

static void PrintOutAllStudents(string[] students)
{
    for(int i = 0; i < students.Length; i++)
    {
        System.Console.WriteLine($"{i + 1}. {students[i]}");
    }
}


static int MakeUserId()
{
    Random rng = new Random();
    return  rng.Next(10000, 1000000);

}

static int GetLockerNumber()
{
    Random rng = new Random();
    return  rng.Next(1, 501);
}

static string[] MakeUsernameFromArray(string[] names)
{
    string[] userNames = new string[names.Length];

    for(int i = 0; i < names.Length; i++)
    {
        string[] nameSplit = names[i].Split(" "); //Mathew Desjardins
        userNames[i] = MakeUsername(nameSplit[0], nameSplit[1]);
    }

    return userNames;
}

static string MakeUsername(string firstName, string lastName)
{
    string userName = "";

    userName += firstName.ToLower()[0];
    userName += lastName.ToLower();

    return userName;
}

static int CheckDigit(int studentId)
{
    return studentId % 9;
}

static double WalkDistance(double x1, double y1, double x2, double y2)
{
    return Math.Sqrt(Math.Pow((x2 - x1),2) + Math.Pow((y2 - y1),2));
}

static int WalkTimeInMinutes(double distance, double speed)
{

    return (int)((distance / speed) / 60);
}

static int WalkTimeInSeconds(double distance, double speed)
{

    return (int)((distance / speed) % 60);
}

static string MessageForWalkTime(int minutes, int seconds)
{
    return $"{minutes} minutes {seconds} seconds";
}

static void DisplayASingleStudentInformation(string[] fullName, string[] userName, int[] studId, int[] studLockerNum, int whichStudent)
{
    System.Console.WriteLine($"Students Full Name: {fullName[whichStudent - 1]}");
    System.Console.WriteLine($"Students User Name: {userName[whichStudent - 1]}");
    System.Console.WriteLine($"Students Student Id: {studId[whichStudent - 1]}");
    System.Console.WriteLine($"Students Locker Number: {studLockerNum[whichStudent - 1]}");
}

