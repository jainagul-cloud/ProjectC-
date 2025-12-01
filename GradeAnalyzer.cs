using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// This class will handle all the core business logic and calculations for a single student.
// Demonstrates OOP (Object-Oriented Programming).
public class Student
{
    // Private fields for encapsulation
    private string studentName;
    private List<int> grades;

    // Public properties
    public string Name
    {
        get { return studentName; }
    }

    // Constructor to initialize the object and the list of grades
    public Student(string name)
    {
        studentName = name;
        grades = new List<int>();
    }

    // Method to add a grade, includes basic conditional validation
    public void AddGrade(int grade)
    {
        if (grade >= 0 && grade <= 100)
        {
            grades.Add(grade);
        }
        else
        {
            // Simple error handling
            Console.WriteLine($"\n[ERROR] Grade {grade} is out of the valid range (0-100) for {studentName}. Skipped.");
        }
    }

    // Calculates the average grade. Demonstrates mathematical logic.
    public double CalculateAverage()
    {
        // Conditional check to avoid division by zero
        if (grades.Count == 0)
        {
            return 0.0;
        }
        // Use LINQ for efficient summation, which is good practice (a type of concept use)
        return grades.Average();
    }

    // Determines the letter grade based on the average. Demonstrates complex conditionals.
    public char GetLetterGrade()
    {
        double average = CalculateAverage();

        // Sequential conditional logic (if-else if-else ladder)
        if (average >= 90)
        {
            return 'A';
        }
        else if (average >= 80)
        {
            return 'B';
        }
        else if (average >= 70)
        {
            return 'C';
        }
        else if (average >= 60)
        {
            return 'D';
        }
        else
        {
            return 'F';
        }
    }

    // Gets the raw list of grades. Demonstrates use of List/Array concept.
    public List<int> GetGrades()
    {
        return grades;
    }

    // Returns a summary string for file export
    public override string ToString()
    {
        string gradeList = string.Join(", ", grades); // Demonstrates string manipulation
        return $"{studentName,-20} | Avg: {CalculateAverage():F2} | Min: {grades.Min()} | Max: {grades.Max()} | Letter: {GetLetterGrade()} | Grades: [{gradeList}]";
    }
}

// Main class to manage the application flow and class statistics.
// Demonstrates OOP (class design) and overall program structure.
public class GradeAnalyzer
{
    // List to store all Student objects (demonstrates use of collections/arrays)
    private static List<Student> students = new List<Student>();
    private const string ExportFileName = "Class_Summary_Report.txt";

    public static void Main(string[] args)
    {
        // 1. Initial Setup
        Console.OutputEncoding = Encoding.UTF8; // Ensures clean display of special characters
        Console.Title = "Applied Math - Student Grade Analyzer";
        Console.WriteLine("=================================================");
        Console.WriteLine("    Student Grade Analyzer & Statistics Tool");
        Console.WriteLine("=================================================");
        
        // 2. Data Input Loop (Loops and Conditionals)
        InputStudentData();

        // Conditional: Only proceed if there is data
        if (students.Count == 0)
        {
            Console.WriteLine("\nNo student data was entered. Exiting application.");
            return;
        }

        // 3. Calculation and Display
        DisplayStudentDetails();
        
        // 4. Class Statistics Calculation and Display
        DisplayClassStatistics();

        // 5. File Handling (Export)
        ExportSummaryToFile();

        Console.WriteLine("\n=================================================");
        Console.WriteLine("Analysis Complete. Press any key to exit.");
        Console.ReadKey();
    }

    // Method to handle user input for all students
    private static void InputStudentData()
    {
        Console.WriteLine("\nEnter student data. Type 'done' for the name when finished.");
        
        // Outer loop to collect data for multiple students
        while (true)
        {
            Console.Write("\nEnter student name (or 'done'): ");
            string nameInput = Console.ReadLine().Trim();

            // Conditional check to break the loop
            if (string.IsNullOrEmpty(nameInput) || nameInput.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            // Create a new Student object (OOP instantiation)
            Student student = new Student(nameInput);
            Console.WriteLine($"\n--- Entering grades for {nameInput} ---");
            
            // Inner loop to collect grades for the current student
            while (true)
            {
                Console.Write("Enter grade (0-100) or '0' to stop adding grades for this student: ");
                string gradeInput = Console.ReadLine().Trim();

                if (int.TryParse(gradeInput, out int grade))
                {
                    // Conditional check to break the inner loop
                    if (grade == 0 && student.GetGrades().Count > 0)
                    {
                        Console.WriteLine($"Finished adding grades for {nameInput}.");
                        break;
                    } 
                    else if (grade == 0 && student.GetGrades().Count == 0)
                    {
                         Console.WriteLine($"Please enter at least one valid grade for {nameInput}.");
                         continue;
                    }
                    
                    student.AddGrade(grade);
                }
                else
                {
                    // String handling and conditional error message
                    Console.WriteLine("[ERROR] Invalid input. Please enter a whole number for the grade.");
                }
            }

            // Conditional: Only add the student if they have grades
            if (student.GetGrades().Count > 0)
            {
                students.Add(student);
            }
        }
    }

    // Displays individual student averages, min, max, and letter grades
    private static void DisplayStudentDetails()
    {
        Console.WriteLine("\n\n--- INDIVIDUAL STUDENT REPORT ---");
        Console.WriteLine("-----------------------------------------------------------------------------------");
        Console.WriteLine($"{"Student Name",-20} | {"Average",-8} | {"Min",-5} | {"Max",-5} | {"Letter",-8} | Grades");
        Console.WriteLine("-----------------------------------------------------------------------------------");

        // Loop through the list of students (Array/Collection traversal)
        foreach (var student in students)
        {
            // Conditional to handle students with no grades (though prevented during input)
            if (student.GetGrades().Count > 0)
            {
                var grades = student.GetGrades();
                double avg = student.CalculateAverage();
                char letter = student.GetLetterGrade();
                
                // Display output, using string formatting
                Console.WriteLine($"{student.Name,-20} | {avg,-8:F2} | {grades.Min(),-5} | {grades.Max(),-5} | {letter,-8} | [{string.Join(", ", grades)}]");
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------");
    }

    // Calculates and displays overall class statistics. Demonstrates more complex calculations.
    private static void DisplayClassStatistics()
    {
        // 1. Combine all grades into one list (demonstrates aggregation/array manipulation)
        var allGrades = students.SelectMany(s => s.GetGrades()).ToList();

        Console.WriteLine("\n\n--- CLASS STATISTICS SUMMARY ---");

        // Conditional check
        if (allGrades.Count == 0)
        {
            Console.WriteLine("No grades available to calculate class statistics.");
            return;
        }

        // 2. Calculate Class-wide Metrics
        double classAverage = allGrades.Average();
        int classMin = allGrades.Min();
        int classMax = allGrades.Max();
        
        // Use a dictionary for frequency count (demonstrates another collection type)
        Dictionary<char, int> letterGradeCounts = new Dictionary<char, int>();
        foreach (var student in students)
        {
            char letter = student.GetLetterGrade();
            if (letterGradeCounts.ContainsKey(letter))
            {
                letterGradeCounts[letter]++;
            }
            else
            {
                letterGradeCounts[letter] = 1;
            }
        }

        // 3. Display Class Statistics
        Console.WriteLine($"Total Students Analyzed: {students.Count}");
        Console.WriteLine($"Total Grades Counted:    {allGrades.Count}");
        Console.WriteLine($"Class Average Grade:     {classAverage:F2}");
        Console.WriteLine($"Highest Grade in Class:  {classMax}");
        Console.WriteLine($"Lowest Grade in Class:   {classMin}");
        
        Console.WriteLine("\nLetter Grade Distribution:");
        // Loop through the dictionary keys for display
        foreach (var kvp in letterGradeCounts.OrderBy(k => k.Key))
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value} Students ({((double)kvp.Value / students.Count):P1})");
        }
    }

    // Exports the full summary report to a text file. Demonstrates file handling.
    private static void ExportSummaryToFile()
    {
        try
        {
            // Use a StringBuilder for efficient string concatenation (string concept)
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===================================================================================");
            sb.AppendLine("                   STUDENT GRADE ANALYZER - CLASS SUMMARY REPORT                   ");
            sb.AppendLine($"Report Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine("===================================================================================");
            
            // Append Individual Student Report
            sb.AppendLine("\n--- INDIVIDUAL STUDENT REPORT ---");
            sb.AppendLine($"{"Student Name",-20} | {"Average",-8} | {"Min",-5} | {"Max",-5} | {"Letter",-8} | Grades");
            sb.AppendLine("-----------------------------------------------------------------------------------");
            foreach (var student in students)
            {
                sb.AppendLine(student.ToString());
            }
            sb.AppendLine("-----------------------------------------------------------------------------------");
            
            // Append Class Statistics (re-calculate for a complete, self-contained report)
            var allGrades = students.SelectMany(s => s.GetGrades()).ToList();
            if (allGrades.Count > 0)
            {
                double classAverage = allGrades.Average();
                int classMin = allGrades.Min();
                int classMax = allGrades.Max();
                
                sb.AppendLine("\n\n--- CLASS STATISTICS SUMMARY ---");
                sb.AppendLine($"Total Students Analyzed: {students.Count}");
                sb.AppendLine($"Total Grades Counted:    {allGrades.Count}");
                sb.AppendLine($"Class Average Grade:     {classAverage:F2}");
                sb.AppendLine($"Highest Grade in Class:  {classMax}");
                sb.AppendLine($"Lowest Grade in Class:   {classMin}");
            }
            
            // Use File.WriteAllText for simple, synchronous file writing (file handling concept)
            File.WriteAllText(ExportFileName, sb.ToString());

            // Success message
            Console.WriteLine($"\n[SUCCESS] Summary successfully exported to: {Path.GetFullPath(ExportFileName)}");
        }
        catch (IOException ex)
        {
            // Exception handling (required concept)
            Console.WriteLine($"\n[FATAL ERROR] An I/O error occurred during file export: {ex.Message}");
        }
    }
}